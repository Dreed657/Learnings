using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiTest.Data.Models;
using ApiTest.Services;
using ApiTest.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace ApiTest.Controllers
{
    public class AuthController : ApiController
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IAuthService authService;
        private readonly AppSettings appSettings;

        public AuthController(UserManager<ApplicationUser> userManager, IAuthService authService, IOptions<AppSettings> appSettings)
        {
            this.userManager = userManager;
            this.authService = authService;
            this.appSettings = appSettings.Value;
        }
        
        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> Register(RegisterRequestModel model)
        {
            var user = new ApplicationUser
            {
                Email = model.Email,
                UserName = model.UserName
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
        public async Task<ActionResult<LoginResponseModel>> Login(LoginRequestModel model)
        {
            var user = await this.userManager.FindByNameAsync(model.UserName);
            if (user == null)
            {
                return Unauthorized();
            }

            var passwordValid = await this.userManager.CheckPasswordAsync(user, model.Password);
            if (!passwordValid)
            {
                return Unauthorized();
            }

            var token = this.authService.GenerateJwtToken(
                user.Id,
                user.UserName,
                "yaz9z93gyff5dp32dkduiku5hgi9yir2");

            return new LoginResponseModel
            {
                Token = token
            };
        }
    }
}
