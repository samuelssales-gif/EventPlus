using EventPlusTorloni.WebAPI.BdContextEvent;
using EventPlusTorloni.WebAPI.Interfaces;
using EventPlusTorloni.WebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace EventPlusTorloni.WebAPI.Repositorios;

public class EventoRepository : IEventoRepository
{
    private readonly EventContext _context;

    public EventoRepository(EventContext context)
    {
        _context = context;
    }

    public void Atualizar(Guid id, Evento evento)
    {
        var eventoBuscado = _context.Eventos.Find(id);

        if (eventoBuscado != null)
        {
            eventoBuscado.Nome = evento.Nome;
            eventoBuscado.Descricao = evento.Descricao;
            eventoBuscado.DataEvento = evento.DataEvento;
            eventoBuscado.IdTipoEvento = evento.IdTipoEvento;
            eventoBuscado.IdInstituicao = evento.IdInstituicao;

            _context.SaveChanges();
        }
    }

    public Evento BuscarPorId(Guid id)
    {
        return _context.Eventos
            .Include(e => e.IdTipoEventoNavigation)
            .Include(e => e.IdInstituicaoNavigation)
            .FirstOrDefault(e => e.IdEvento == id)!;
    }

    public void Cadastrar(Evento evento)
    {

        evento.IdEvento = Guid.NewGuid();

        if (evento.IdInstituicao != null &&
            !_context.Instituicaos.Any(i => i.IdInstituicacao == evento.IdInstituicao))
        {
            throw new Exception("Instituição não encontrada!");
        }

        if (evento.IdTipoEvento != null &&
            !_context.TipoEvento.Any(t => t.IdTipoEvento == evento.IdTipoEvento))
        {
            throw new Exception("TipoEvento não encontrado!");
        }

        _context.Eventos.Add(evento);
        _context.SaveChanges();
    }

    public void Deletar(Guid id)
    {
        var eventoBuscado = _context.Eventos.Find(id);

        if (eventoBuscado != null)
        {
            _context.Eventos.Remove(eventoBuscado);
            _context.SaveChanges();
        }
    }

    public List<Evento> List()
    {
        return _context.Eventos
            .Include(e => e.IdTipoEventoNavigation)
            .Include(e => e.IdInstituicaoNavigation)
            .OrderBy(e => e.Nome)
            .ToList();
    }

    public List<Evento> ListarPorId(Guid IdUsuario)
    {
        return _context.Eventos
            .Include(e => e.IdTipoEventoNavigation)
            .Include(e => e.IdInstituicaoNavigation)
            .Where(e => e.Presencas.Any(p => p.IdUsuario == IdUsuario))// && p.Situacao == true))
            .ToList();
    }

    public List<Evento> ProximosEventos()
    {
        return _context.Eventos
            .Include(e => e.IdTipoEventoNavigation)
            .Include(e => e.IdInstituicaoNavigation)
            .Where(e => e.DataEvento >= DateTime.Now)
            .OrderBy(e => e.DataEvento)
            .ToList();
    }
}