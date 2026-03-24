using EventPlusTorloni.WebAPI.Models;

namespace EventPlusTorloni.WebAPI.Interfaces;

public interface IEventoRepository
{
    void Cadastrar(Evento evento);

    List<Evento> List();

    void Deletar(Guid IdEvento);

    void Atualizar(Guid id, Evento evento);

    List<Evento> ListarPorId(Guid IdUsuario);

    List<Evento> ProximosEventos();

    Evento BuscarPorId(Guid id);
}
