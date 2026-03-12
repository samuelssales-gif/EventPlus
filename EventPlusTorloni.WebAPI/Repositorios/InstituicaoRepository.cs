using EventPlusTorloni.WebAPI.BdContextEvent;
using EventPlusTorloni.WebAPI.Interfaces;
using EventPlusTorloni.WebAPI.Models;

namespace EventPlusTorloni.WebAPI.Repositorios
{
    public class InstituicaoRepository : IInstituicaoRepository
    {
        private readonly EventContext _context;

        public InstituicaoRepository(EventContext context)
        {
            _context = context;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="instituicao"></param>
        public void Atualizar(Guid id, Instituicao instituicao)

        {
            var InstituicaoBuscado = _context.Instituicaos.Find(id);
            if (InstituicaoBuscado != null)
            {
                InstituicaoBuscado.NomeFantasia = InstituicaoBuscado.NomeFantasia;
                _context.SaveChanges();
            }
        }

        public Instituicao BuscarPorId(Guid id)
        {
            return _context.Instituicaos.Find(id)!;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="istituicao"></param>
        /// <exception cref="NotImplementedException"></exception>

        public void Cadastrar(Instituicao istituicao)
        {
           _context.Instituicaos.Add(istituicao);
            _context.SaveChanges();
        }

        public void Deletar(Guid id)
        {
            var instituicaoBuscada = _context.Instituicaos.Find(id);
            if(instituicaoBuscada != null)
            {
                _context.Instituicaos.Remove(instituicaoBuscada);
                _context.SaveChanges();
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>

        public List<Instituicao> listar()
        {
            return _context.Instituicaos
                .OrderBy(instituicao => instituicao.NomeFantasia)
                .ToList();
        }
    }
}
