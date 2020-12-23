using JobTrail.API.Models;
using JobTrail.Core.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Threading.Tasks;

namespace JobTrail.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IConfiguration _config;

        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager, IConfiguration config)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _config = config;
        }

        [AllowAnonymous]
        [HttpPost("Login")]
        public async Task<IActionResult> Login(Login login)
        {
            var result = await _signInManager.PasswordSignInAsync(login.Username, login.Password, login.RememberMe, true);

            if(!result.Succeeded)
            {
                return Unauthorized();
            }

            var token = GenerateJSONWebToken();

            return Ok(new { token });
        }

        [HttpDelete("Logout")]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();

            return Ok();
        }

        [AllowAnonymous]
        [HttpPost("Register")]
        public async Task<IActionResult> Register(Register register)
        {
            var user = register.ToUser();

            var result = await _userManager.CreateAsync(user, register.Password);

            if(!result.Succeeded)
            {
                return BadRequest();
            }

            return CreatedAtAction(nameof(Register), user);
        }

        private string GenerateJSONWebToken()
        {
            var key = _config["AppSettings:Jwt:Key"];
            var issuer = _config["AppSettings:Jwt:Issuer"];
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(issuer,
              issuer,
              null,
              expires: DateTime.Now.AddMinutes(120),
              signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
