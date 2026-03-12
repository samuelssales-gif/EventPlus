using EventPlusTorloni.WebAPI.Models;

namespace EventPlusTorloni.WebAPI.Interfaces
{
public interface IUsuarioRepository
{
    void Cadastrar(Usuario usurio);
    Usuario BuscarPorId(Guid id);
    Usuario BuscarPorEmail(string Email, string Senha);

}
}
