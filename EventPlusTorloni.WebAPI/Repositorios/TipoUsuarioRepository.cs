
using EventPlusTorloni.WebAPI.BdContextEvent;
using EventPlusTorloni.WebAPI.Interfaces;
using EventPlusTorloni.WebAPI.Models;

namespace EventPlusTorloni.WebAPI.Repositorios
{
    public class TipoUsuarioRepository :
        ITipoUsuarioRepository
    {
        private readonly EventContext _context;

        public TipoUsuarioRepository(EventContext context)
        {
            _context = context;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="tipoUsuario"></param>
        /// <exception cref="NotImplementedException"></exception>

        public void Atualizar(Guid id, TipoUsuario tipoUsuario)
        {
            var tipoUsuarioExistente = _context.TipoUsuarios.Find(id);
            if (tipoUsuarioExistente != null)
            {
                tipoUsuarioExistente.Titulo = tipoUsuario.Titulo;
                _context.SaveChanges();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        public Models.TipoUsuario BuscarPorId(Guid id)
        {
            return _context.TipoUsuarios.Find(id)!;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tipoUsuario"></param>
        /// <exception cref="NotImplementedException"></exception>

        public void Cadastrar(Models.TipoUsuario tipoUsuario)
        {
            _context.TipoUsuarios.Add(tipoUsuario);
            _context.SaveChanges();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>


        public void Deletar(Guid id)
        {
            var tipoUsuarioExistente = _context.TipoUsuarios.Find(id);
            if (tipoUsuarioExistente != null)
            {
                _context.TipoUsuarios.Remove(tipoUsuarioExistente);
                _context.SaveChanges();
            }
        }

        public List<TipoUsuario> Listar()
        {
            return _context.TipoUsuarios.OrderBy(TipoUsuario => TipoUsuario.Titulo).ToList();
        }
    }
}