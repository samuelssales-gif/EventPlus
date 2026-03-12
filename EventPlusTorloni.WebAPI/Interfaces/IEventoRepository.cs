using EventPlusTorloni.WebAPI.Models;

namespace EventPlusTorloni.WebAPI.Interfaces;

public interface IEventoRepository
{
    void Cadastrar(Evento evento);

    List<Evento> Listar();

    void Deletar(Guid IdEvento);

    void Delete(Guid id, Evento evento);

    List<Evento> listarPorId(Guid IdUsuario);

    List<Evento> ProximosEvento(Guid IdUsuario);

    Evento BuscarPorID(Guid id);
}
