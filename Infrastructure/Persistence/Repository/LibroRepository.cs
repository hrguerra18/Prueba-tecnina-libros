using Domain.Interfaces.IRepository;
using Domain.Models;
using Domain.Models.ModelsUtils;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repository
{
    public class LibroRepository : ILibroRepository
    {
        private readonly ApplicationDbContext _context;

        public LibroRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public  async Task DeleteLibroAsync(Libro libro)
        {
            _context.Remove(libro);
            await _context.SaveChangesAsync();

        }

        public async Task<Libro> GetLibroByIdAsync(int id)
        {
            var libro = await _context.libros.FirstOrDefaultAsync(x => x.Id == id);
            return libro!;
        }

        public async Task<List<Libro>> GetLibrosAsync()
        {
            var libros = await _context.libros.ToListAsync();
            return libros;
        }

        public async Task SaveLibroAsync(Libro libro)
        {
             _context.libros.Add(libro);
            await _context.SaveChangesAsync();

        }

        public async Task UpdateLibroAsync(Libro libro, Libro libroEncontrado)
        {

            libroEncontrado.Title = libro.Title;
            libroEncontrado.Autor = libro.Autor;
            libroEncontrado.Publisher = libro.Publisher;
            libroEncontrado.Genre = libro.Genre;
            libroEncontrado.Price = libro.Price;
               
                await _context.SaveChangesAsync();
            }

        
    }
}
