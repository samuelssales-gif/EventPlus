using EventPlusTorloni.WebAPI.BdContextEvent;
using EventPlusTorloni.WebAPI.Interfaces;
using EventPlusTorloni.WebAPI.Models;
using EventPlusTorloni.WebAPI.Utils;
using Microsoft.EntityFrameworkCore;

namespace EventPlusTorloni.WebAPI.Repositorios
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly EventContext _context;

        public UsuarioRepository(EventContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Busca o usuario pelo e-mail e valida o hash da senha
        /// </summary>
        public Usuario BurcarPorEmailESenha(string Email, string Senha)
        {
            var usuarioBuscado = _context.Usuarios
                .Include(usuario => usuario.IdTipoUsuarioNavigation)
                .FirstOrDefault(usuario => usuario.Email == Email);

            if (usuarioBuscado != null)
            {
                bool confere = Criptografia.CompararHash(Senha, usuarioBuscado.Senha);

                if (confere)
                {
                    return usuarioBuscado;
                }
            }

            return null!;
        }

        public Usuario BuscarPorEmail(string Email, string Senha)
        {
            return BurcarPorEmailESenha(Email, Senha);
        }

        /// <summary>
        /// Busca um usuário pelo id
        /// </summary>
        public Usuario BuscarPorId(Guid id)
        {
            return _context.Usuarios
                .Include(usuario => usuario.IdTipoUsuarioNavigation)
                .FirstOrDefault(usuario => usuario.IdUsuario == id)!;
        }

        public void Cadastrar(Usuario usuario)
        {
            usuario.Senha = Criptografia.GerarHash(usuario.Senha);

            _context.Usuarios.Add(usuario);

            _context.SaveChanges();
        }
    }
}