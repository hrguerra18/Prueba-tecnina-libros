using Domain.Models;
namespace Domain.Interfaces.IService
{
    public interface IUsuarioService
    {
        Task<string> SaveUserAsync(Usuario usuario);
    }
}
