using EventPlusTorloni.WebAPI.Models;

namespace EventPlusTorloni.WebAPI.Interfaces
{
    public interface IInstituicaoRepository
    {
        List<Instituicao> listar();

        void Cadastrar(Instituicao istituicao);

        void Atualizar(Guid id, Instituicao istituicao);

        void Deletar(Guid id);

        Instituicao BuscarPorId(Guid id);
    }
}
