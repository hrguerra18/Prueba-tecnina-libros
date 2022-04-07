using Domain.Interfaces.IService;
using Domain.Models;
using Infrastructure.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILoginService _loginService;
        private readonly IConfiguration _configuration;

        public LoginController(ILoginService loginService, IConfiguration configuration)
        {
            _loginService = loginService;
            _configuration = configuration;
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody]Usuario usuario)
        {
            try
            {
                string resp = await _loginService.login(usuario);

                if (resp == "Usuario o password incorrecto")
                {
                    return BadRequest(new {message = resp});
                }
                string token = JwtConfiguration.GetToken(usuario, _configuration);
                return Ok(new {token = token});
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }
    }
}
