using JobTrail.API.Models;
using JobTrail.Core.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace JobTrail.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(Login login)
        {
            var result = await _signInManager.PasswordSignInAsync(login.Username, login.Password, login.RememberMe, true);

            if(!result.Succeeded)
            {
                return BadRequest();
            }

            var user = await _userManager.FindByNameAsync(login.Username);

            return Ok(user);
        }

        [HttpDelete("Logout")]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();

            return Ok();
        }
    }
}
