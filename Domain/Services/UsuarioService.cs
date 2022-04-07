using Domain.Interfaces.IRepository;
using Domain.Interfaces.IService;
using Domain.Models;

namespace Domain.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public async Task<string> SaveUserAsync(Usuario usuario)
        {
            await _usuarioRepository.SaveUserAsync(usuario);
            return $"El usuario {usuario.Username} fue creado con exito";
        }
    }
}
