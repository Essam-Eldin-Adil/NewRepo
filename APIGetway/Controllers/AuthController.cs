﻿using HRMS.APIGetway;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HRMS.APIGetway.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly JwtAuthenticationManager _jwtAuthenticationManager;
        public AuthController(JwtAuthenticationManager jwtAuthenticationManager)
        {
            this._jwtAuthenticationManager = jwtAuthenticationManager;
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult AuthUser([FromBody] User user)
        {
            try
            {
                var token= _jwtAuthenticationManager.Authenticate(user.userName,user.password);
                if (token==null)
                {
                    return Unauthorized();
                }
                return Ok(token);
            }
            catch
            {

                return BadRequest();
            }
        }
    }

    public class User
    {
        /// <summary>
        /// Use this columns to genrate the bearer token
        /// </summary>
        /// <example>essam</example>
        public string userName { get; set; } = string.Empty;
        /// <summary>
        /// Use this columns to genrate the bearer token
        /// </summary>
        /// <example>essam</example>
        public string password { get; set; } = string.Empty;
    }
}
