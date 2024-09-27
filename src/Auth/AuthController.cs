using Microsoft.AspNetCore.Mvc;
using PruebaDotnet.src.Auth.dto;
using PruebaDotnet.src.interfaces;

namespace PruebaDotnet.src.Auth
{
    [Route("api/auth/login")]
    public class AuthController : Controller, IAuthController
    {

        private readonly IAuthServices _authService;

        public AuthController(IAuthServices authService)
        {
            _authService = authService;
        }

        [HttpPost]
        public async Task<IActionResult> SignIn([FromBody] AuthDto Credencials)
        {
            var user = await _authService.FindUser(Credencials);
            if (user == null)
            {
                return Unauthorized("Invalid credentials");
            }
            var tokens = _authService.SignTokens(user);
            return Ok(tokens);
        }
    }
}