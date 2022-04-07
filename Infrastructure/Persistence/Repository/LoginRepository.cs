using Domain.Interfaces.IRepository;
using Domain.Models;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repository
{
    public class LoginRepository : ILoginRepository
    {
        private readonly ApplicationDbContext _context;

        public LoginRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Usuario> login(Usuario usuario)
        {
            var usuarioEncontrado = await _context.usuarios.Where(x => x.Username == usuario.Username && x.Password == usuario.Password).FirstOrDefaultAsync();
            return usuarioEncontrado!;
        }
    }
}
