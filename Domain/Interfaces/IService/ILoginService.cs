using Domain.Models;

namespace Domain.Interfaces.IService
{
    public interface ILoginService
    {
        Task<string> login(Usuario usuario);
    }
}
