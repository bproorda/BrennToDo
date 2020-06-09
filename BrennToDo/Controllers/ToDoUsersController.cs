using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using BrennToDo.Models;
using BrennToDo.Models.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
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

        [HttpPost("Register")]
        public async Task<ActionResult>  Register(RegisterData data)
        {
            var newUser = new ToDoUser
            {
                UserName = data.UserName,
                FirstName = data.FirstName,
                LastName = data.LastName,
                Email = data.Email
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
                claims: tokenClaims,
                signingCredentials: new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256)
                );

            var tokenString = new JwtSecurityTokenHandler().WriteToken(token);
            return tokenString;
        }

    }
}