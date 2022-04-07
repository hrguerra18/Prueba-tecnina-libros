using Domain.Interfaces.IService;
using Domain.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibroController : ControllerBase
    {
        private readonly ILibroService _libroService;

        public LibroController(ILibroService libroService)
        {
            _libroService = libroService;
        }


        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Libro libro)
        {
            try
            {
                string respuestaMensaje = await _libroService.SaveLibroAsync(libro);
                return Ok(new {message = respuestaMensaje });
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        [HttpGet]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> GetLibros()
        {
            try
            {
                var res = await _libroService.GetLibrosAsync();
                if (res.libros == null)
                {
                    return BadRequest(new { message = res.Mensaje });
                }

                return Ok(new { libros = res.libros });
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetLibroById(int id)
        {
            try
            {
                var res = await _libroService.GetLibroByIdAsync(id);
                if (res.libro == null)
                {
                    return BadRequest(new { message = res.Mensaje });
                }

                return Ok(res.libro);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLibro(int id)
        {
            try
            {
                string res = await _libroService.DeleteLibroAsync(id);
                if (res == "El libro que desea eliminar no existe")
                {
                    return BadRequest(new { message = res});
                }

                return Ok(new { message = res });
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateLibro([FromBody]Libro libro)
        {
            try
            {
                string res = await _libroService.UpdateLibroAsync(libro);
                if (res == "El libro que intenta modificar no existe")
                {
                    return BadRequest(new { message = res });
                }

                return Ok(new { message = res });
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }




    }
}
