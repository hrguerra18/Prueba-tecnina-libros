using Domain.Models;
using Domain.Models.ModelsUtils;

namespace Domain.Interfaces.IService
{
    public interface ILibroService
    {
        Task<RespuestaMensajeYLibros> GetLibrosAsync();
        Task<RespuestaMensajeYLibro> GetLibroByIdAsync(int id);
        Task<string> SaveLibroAsync(Libro libro);
        Task<string> UpdateLibroAsync(Libro libro);
        Task<string> DeleteLibroAsync(int id);
    }
}
