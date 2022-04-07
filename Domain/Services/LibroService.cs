using Domain.Interfaces.IRepository;
using Domain.Interfaces.IService;
using Domain.Models;
using Domain.Models.ModelsUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class LibroService : ILibroService
    {
        private readonly ILibroRepository _libroRepository;

        public LibroService(ILibroRepository libroRepository)
        {
            _libroRepository = libroRepository;
        }
        public async Task<string> DeleteLibroAsync(int id)
        {
            var resp = await BuscarLibro(id, "El libro que intenta eliminar no existe");

            if (resp.libro == null)
            {
                return resp.Mensaje!;
            }

            await _libroRepository.DeleteLibroAsync(resp.libro);
            return $"El libro {resp.libro.Title} fue eliminado con exito";
        }

        public async Task<RespuestaMensajeYLibro> GetLibroByIdAsync(int id)
        {
            RespuestaMensajeYLibro resp = new RespuestaMensajeYLibro();

            resp.libro = await _libroRepository.GetLibroByIdAsync(id);

            if (resp.libro == null)
            {
                resp.Mensaje = "El libro que intenta buscar no existe";
                return resp;
            }

            return resp;
        }

        public async Task<RespuestaMensajeYLibros> GetLibrosAsync()
        {
            RespuestaMensajeYLibros resp  = new RespuestaMensajeYLibros();
           
            resp.libros = await _libroRepository.GetLibrosAsync();

            if (resp.libros == null)
            {
                resp.Mensaje = "No se encuentran libros para mostrar";
                return resp;
            }

            return resp;
        }

        public async Task<string> SaveLibroAsync(Libro libro)
        {
            await _libroRepository.SaveLibroAsync(libro);
            return $"El libro {libro.Title} fue registrado con exito";
        }

        public async Task<string> UpdateLibroAsync(Libro libro)
        {
            var resp = await BuscarLibro(libro.Id, "El libro que intenta modificar no existe");

            if(resp.libro == null)
            {
                return resp.Mensaje!;
            }

            await _libroRepository.UpdateLibroAsync(libro, resp.libro);
            return $"El libro ha sido modificado correctamente";
        }


        private async Task<RespuestaMensajeYLibro> BuscarLibro(int id, string mensaje)
        {
            RespuestaMensajeYLibro resp = new RespuestaMensajeYLibro();
            resp.libro = await _libroRepository.GetLibroByIdAsync(id);

            if (resp.libro == null)
            {
                resp.Mensaje = mensaje;
                
            }

            return resp;
        }
    }
}
