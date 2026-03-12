using EventPlusTorloni.WebAPI.Models;

namespace EventPlusTorloni.WebAPI.Interfaces;

public interface ITipoEventoRepository
{
    void Atualizar(Guid id, TipoEvento tipoEvento);
    TipoEvento BuscarPorId(Guid id);
    void Cadastrar(TipoEvento tipoEvento);
    void Deletar(Guid id);
    List<TipoEvento> Listar();
 }