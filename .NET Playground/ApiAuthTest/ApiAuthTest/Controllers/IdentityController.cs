using System.Threading.Tasks;
using ApiAuthTest.Data.Models;
using ApiAuthTest.Models;
using ApiAuthTest.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace ApiAuthTest.Controllers
{
    public class IdentityController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IIdentityService identity;

        public IdentityController(
            UserManager<ApplicationUser> userManager,
            IIdentityService identity)
        {
            this.userManager = userManager;
            this.identity = identity;
        }

        [HttpPost]
        [AllowAnonymous]
        [Route(nameof(Register))]
        public async Task<ActionResult> Register([FromBody] RegisterRequestModel model)
        {
            var user = new ApplicationUser()
            {
                Email = model.Email,
                UserName = model.UserName,
            };

            var result = await this.userManager.CreateAsync(user, model.Password);
            if (!result.Succeeded)
            {
                return BadRequest(result.Errors);
            }

            return Ok();
        }

        [HttpPost]
        [AllowAnonymous]
        [Route(nameof(Login))]
        public async Task<ActionResult<object>> Login([FromBody] LoginRequestModel model)
        {
            var user = await this.userManager.FindByEmailAsync(model.Email);
            if (user == null)
            {
                return Unauthorized(new { message ="Invalid credentials." });
            }

            var passwordValid = await this.userManager.CheckPasswordAsync(user, model.Password);
            if (!passwordValid)
            {
                return Unauthorized(new { message = "Invalid credentials." });
            }

            var token = this.identity.GenerateJwtToken(
                user.Id,
                user.UserName,
                "SOME MAGIC UNICORNS GENERATE THIS SECRET");

            return Ok(new {token});
        }
    }
}
