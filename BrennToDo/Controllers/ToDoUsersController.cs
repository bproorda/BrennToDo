using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using BrennToDo.Models;
using BrennToDo.Models.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using static BrennToDo.Models.Identity.UserWithToken;

namespace BrennToDo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoUsersController : ControllerBase
    {
        private readonly UserManager<ToDoUser> userManager;
        private readonly IConfiguration configuration;

        public ToDoUsersController(UserManager<ToDoUser> userManager, IConfiguration configuration)
        {
            this.userManager = userManager;
            this.configuration = configuration;
        }

        [Authorize]
        [HttpGet("Self")]
        public async Task<IActionResult> Self()
        {
            if (HttpContext.User.Identity is ClaimsIdentity identity)
            {
                var usernameClaim = identity.FindFirst("UserId");
                var userId = usernameClaim.Value;

                var user = await userManager.FindByIdAsync(userId);
                if (user == null)
                {
                    return Unauthorized();
                }
                var roles = await userManager.GetRolesAsync(user);
                bool userIsUser =  await userManager.IsInRoleAsync(user, "User");
                bool userIsAdmin = await userManager.IsInRoleAsync(user, "Administrator");
                return Ok(new
                {
                    UserId = user.Id,
                    user.Email,
                    user.FirstName,
                    user.LastName,
                    userIsUser,
                    userIsAdmin
                    
                    
                });
            }

            return Unauthorized();
        }

        
        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginData data)
        {
            var user = await userManager.FindByNameAsync(data.Username);

            if (user != null)
            {
                var passed = await userManager.CheckPasswordAsync(user, data.Password);

                if (passed)
                {
                    return Ok(new UserAndToken
                    {
                        UserId = user.Id,
                        Token = CreateToken(user)
                    });
                }
               
                await userManager.AccessFailedAsync(user);
            }
            return Unauthorized();
        }

        [AllowAnonymous]
        [Authorize]
        [HttpPost("Register")]
        public async Task<ActionResult>  Register(RegisterData data)
        {
            var newUser = new ToDoUser
            {
                UserName = data.UserName,
                FirstName = data.FirstName,
                LastName = data.LastName,
                Email = data.Email,
                
                
                
            };
            var result = await userManager.CreateAsync(newUser, data.Password);

            if (!result.Succeeded)
            {
                return BadRequest(new
                {
                    message = "Registration failed",
                    errors = result.Errors,
                });
            }

            // If user is an admin OR there aren't any users
            // Allow register to include Roles
            if (User.IsInRole("Administrator") || !await userManager.Users.AnyAsync())
            {
                await userManager.AddToRolesAsync(newUser, data.Roles);
            }

            return Ok(new UserAndToken
            {
                UserId = newUser.Id,
                //Token = userManager.CreateToken(newUser),
                Token = CreateToken(newUser)
            });
        }
        private string /*JwtSecurityToken*/ CreateToken(ToDoUser newUser)
        {
            var secret = configuration["JWT:Secret"];
            var secretBytes = Encoding.UTF8.GetBytes(secret);
            var signingKey = new SymmetricSecurityKey(secretBytes);
            var tokenClaims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, newUser.UserName),
                new Claim("UserId", newUser.Id),
                new Claim("FullName", $"{newUser.FirstName} {newUser.LastName}"),
            };
            var token = new JwtSecurityToken(
                expires: DateTime.UtcNow.AddHours(6),
                claims: tokenClaims,
                signingCredentials: new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256)
                );

            var tokenString = new JwtSecurityTokenHandler().WriteToken(token);
            return tokenString;
        }
        [HttpPost("{username}")]
        [Authorize(Roles ="Administrator")]
        public async Task<ActionResult> AddRoleToUser(string username, string roleId)
        {
            var user = await userManager.FindByNameAsync("username");
            if (user == null)
            {
                return NotFound();
            }

            var userUpdated = await userManager.AddToRoleAsync(user, roleId);

            return NoContent();
        }

      

    }
}