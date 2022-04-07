using Domain.Interfaces.IRepository;
using Domain.Interfaces.IService;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class LoginService : ILoginService
    {
        private readonly ILoginRepository _loginRepository;

        public LoginService(ILoginRepository loginRepository)
        {
            _loginRepository = loginRepository;
        }

        public async Task<string> login(Usuario usuario)
        {
            var usuarioEncontrado = await _loginRepository.login(usuario);
            if (usuarioEncontrado == null)
            {
                return "Usuario o password incorrecto";
            }

            return "Usuario logueado";
        }
    }
}
