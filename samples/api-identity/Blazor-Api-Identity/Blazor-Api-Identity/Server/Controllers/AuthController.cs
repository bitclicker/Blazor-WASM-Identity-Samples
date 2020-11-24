using Blazor_Api_Identity.Server.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blazor_Api_Identity.Server.Controllers
{

    public class LoginDTO 
    { 
        public string email { get; set; }
        public string password { get; set; }
    }


    [Route("[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        readonly SignInManager<ApplicationUser> _signInManager;
        public AuthController(SignInManager<ApplicationUser> signInManager)
        {
            _signInManager = signInManager;
        }

        [HttpPost]        
        public async Task<IActionResult> Post(LoginDTO login)
        {
            var result = await _signInManager.PasswordSignInAsync(login.email, login.password, false, false);
            if (result.Succeeded)
                return Ok(result.Succeeded);
            else
                return BadRequest();
        }
    }
}
