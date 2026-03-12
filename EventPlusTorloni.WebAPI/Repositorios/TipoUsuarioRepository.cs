
using EventPlus.WebAPI.Interfaces;
using EventPlusTorloni.WebAPI.BdContextEvent;
using EventPlusTorloni.WebAPI.Models;

namespace EventPlusTorloni.WebAPI.Repositorios

{
    public class TipoUsuarioRepository : ITipoUsuarioRepository
    {
        private readonly EventContext _context;
        public TipoUsuarioRepository(EventContext context)
        {
            _context = context;
        }
        
        public Usuario BuscarPorEmail(string Email, string Senha)
        {
            throw new NotImplementedException();
        }

        public Usuario BuscarPorId(Guid id)
        {
            return _context.Usuarios.Find(id)!;
        }

        public void Cadastrar(Usuario usuario)
        {
            _context.Usuarios.Add(usuario);
            _context.SaveChanges();
        }

    }
}
