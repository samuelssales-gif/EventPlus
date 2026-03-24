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

        public void Atualizar(Guid id, Instituicao instituicao)
        {
            var instituicaoBuscada = _context.Instituicaos.Find(id);

            if (instituicaoBuscada != null)
            {
                instituicaoBuscada.NomeFantasia = instituicao.NomeFantasia;

                _context.SaveChanges();
            }
        }

        public Instituicao BuscarPorId(Guid id)
        {
            return _context.Instituicaos.Find(id)!;
        }

        public void Cadastrar(Instituicao instituicao)
        {

            _context.Instituicaos.Add(instituicao);
            _context.SaveChanges();
        }

        public void Deletar(Guid id)
        {
            var instituicaoBuscada = _context.Instituicaos.Find(id);

            if (instituicaoBuscada != null)
            {
                _context.Instituicaos.Remove(instituicaoBuscada);
                _context.SaveChanges();
            }
        }

        public List<Instituicao> Listar()
        {
            return _context.Instituicaos
                .OrderBy(instituicao => instituicao.NomeFantasia)
                .ToList();
        }
    }
}