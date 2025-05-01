using BaseLibrary.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using ServerLibrary.Repositories.Contracts;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController(IUserAccount accountInteface) : ControllerBase
    {
        //changed from register to register-user-again
        [HttpPost("register")]
        public async Task<IActionResult> CreateAsync(Register user)
        {
            if(user == null)
            {

                // hello done from prince
                // lets add some more comments
                return BadRequest("Model Is Empty");
                
            }
            var result = await accountInteface.CreateAsync(user);
            // added commit branch 
            return Ok(result);
        }
        
        [HttpPost("Newlogin")]
        public async Task<IActionResult> SignInAsync(Login user)
        {
            if (user == null) return BadRequest("Model is Empty");
            var result = await accountInteface.SignInAsync(user);
            return Ok(result);
        }
        //changed refresh-token to token
        [HttpPost("token")]
        public async Task<IActionResult> RefreshTokenAsync(RefreshToken token)
        {
            if (token == null) return BadRequest("Model is Empty");
            var result = await accountInteface.RefreshTokenAsync(token);
            return Ok(result);
        }
    }
}
