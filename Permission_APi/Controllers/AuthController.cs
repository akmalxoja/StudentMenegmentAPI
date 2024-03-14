using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Permission_Application.Abstractions.Repositories;
using Permission_Application.Dto_s;

namespace Permission_APi.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]

    public class AuthController : ControllerBase
    {
        private readonly ILogin _login;
        private readonly IRegister _register;
        public AuthController(ILogin login, IRegister register)
        {
            _login = login;
            _register = register;
        }

        [HttpPost]
        public async Task<IActionResult> Register([FromForm] RegisterDTO register) => Ok(await _register.Registration(register));
        [HttpPost]
        public async Task<IActionResult> Login([FromForm] LoginDTO loginDTO) => Ok(await _login.Loogin(loginDTO));
    }
}
