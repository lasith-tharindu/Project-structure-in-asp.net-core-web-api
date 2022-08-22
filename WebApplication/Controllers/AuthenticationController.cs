using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.Common.Dtos;
using WebApplication.Services.Interfaces;

namespace WebApplication.Controllers
{
    [Route("api/v1/auth")]
    [ApiController]
    [Authorize]
    public class AuthenticationController : ControllerBase
    {
        private readonly ILogger<AuthenticationController> logger;
        private readonly IUserServices _userServices;

        public AuthenticationController(ILogger<AuthenticationController> logger,  IHttpContextAccessor httpContextAccessor, IUserServices userServices)
        {
            this.logger = logger;
            _userServices = userServices;
        }

        [HttpGet("GetSession")]
        public ActionResult Check(string jwt)
        {
            var result = (_userServices.GetCheckUser(jwt));
            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return Unauthorized();
            }
        }

        [AllowAnonymous]
        [HttpPost("Signin")]
        public ActionResult Signin([FromBody] LoginDto user)
        {

            var result = _userServices.SignIn(user.Username, user.Password);
            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }
    }
}
