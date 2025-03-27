﻿using BaseLibrary.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServerLibrary.Repositories.Contracts;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController(IUserAccount accountInteface) : ControllerBase
    {
        [HttpPost("register")]
        public async Task<IActionResult> CreateAsync(Register user)
        {
            if(user == null)
            {
                return BadRequest("Model Is Empty");
                // tested for tracking branches
            }
            var result = await accountInteface.CreateAsync(user);
            return Ok(result);
        }

        [HttpPost("login")]
        public async Task<IActionResult> SignInAsync(Login user)
        {
            if (user == null) return BadRequest("Model is Empty");
            var result = await accountInteface.SignInAsync(user);
            return Ok(result);
            // testing the merge conflict from tracking dev-branch
        }
        [HttpPost("refresh-token")]
        public async Task<IActionResult> RefreshTokenAsync(RefreshToken token)
        {
            if (token == null) return BadRequest("Model is Empty");
            var result = await accountInteface.RefreshTokenAsync(token);
            return Ok(result);
        }
    }
}
