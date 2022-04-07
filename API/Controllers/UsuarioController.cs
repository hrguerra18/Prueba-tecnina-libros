using Domain.Interfaces.IService;
using Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;

        public UsuarioController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpPost]
        public async Task<IActionResult> AddUser([FromBody]Usuario usuario)
        {
            try
            {
                string resp = await _usuarioService.SaveUserAsync(usuario);
                return Ok(new {message= resp });
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
