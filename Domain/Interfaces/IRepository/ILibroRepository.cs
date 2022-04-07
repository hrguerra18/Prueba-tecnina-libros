using Domain.Models;
using Domain.Models.ModelsUtils;

namespace Domain.Interfaces.IRepository
{
    public interface ILibroRepository
    {
        Task<List<Libro>> GetLibrosAsync();
        Task<Libro> GetLibroByIdAsync(int id);
        Task SaveLibroAsync(Libro libro);
        Task UpdateLibroAsync(Libro libro, Libro libroEncontrado);
        Task DeleteLibroAsync(Libro libro);
    }
}
