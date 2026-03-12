using EventPlusTorloni.WebAPI.Models;

namespace EventPlusTorloni.WebAPI.Interfaces
{
    public interface IPresecaRepository
    {
        void Inscrever(Presenca Incrisao);

        void Deletar(Guid id);

        List<Presenca> Listar();

        Presenca BuscarPorId(Guid id);

        List<Presenca> ListarMinhas(Guid IdUsuario);
    }
}