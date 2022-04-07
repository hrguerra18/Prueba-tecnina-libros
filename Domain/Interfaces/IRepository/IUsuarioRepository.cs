

using Domain.Models;

namespace Domain.Interfaces.IRepository
{
    public interface IUsuarioRepository
    {
        Task SaveUserAsync(Usuario usuario);
    }
}
