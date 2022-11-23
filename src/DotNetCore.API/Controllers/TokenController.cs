using DotNetCore.API.Models.Token;
using Fiver.Security.Bearer.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DotNetCore.API.Controllers
{
    [AllowAnonymous]
    [Route("api/v1/[controller]")]
    public class TokenController : Controller
    {
        /// <summary>
        /// Generate token. (Username is "james" and Password is "bond")
        /// </summary>
        /// <param name="inputModel"></param>
        /// <returns>JWT token.</returns>
        /// <response code="200">Returns the temperature list</response>
        /// <response code="500">If there was an internal server error</response>
        [HttpPost]
        [Route("token")]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        public IActionResult Create([FromBody]LoginInputModel inputModel)
        {
            if (inputModel.Username != "james" && inputModel.Password != "bond")
                return Unauthorized();

            var token = new JwtTokenBuilder()
                .AddSecurityKey(JwtSecurityKey.Create("fiver-secret-key"))
                .AddSubject("james bond")
                .AddIssuer("Fiver.Security.Bearer")
                .AddAudience("Fiver.Security.Bearer")
                .AddClaim("MembershipId", "111")
                .AddExpiry(1)
                .Build();

            return Ok(token);
            //return Ok(token.Value);
        }
    }
}