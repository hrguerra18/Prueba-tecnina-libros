using Domain.Models;

namespace Domain.Interfaces.IRepository
{
    public interface ILoginRepository
    {
        Task<Usuario> login(Usuario usuario);
    }
}
