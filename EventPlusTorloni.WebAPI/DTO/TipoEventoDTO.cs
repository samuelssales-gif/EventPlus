using System.ComponentModel.DataAnnotations;

namespace EventPlusTorloni.WebAPI.DTO;

public class TipoEventoDTO
{
    [Required(ErrorMessage = "O Titulo do tipo de evento e obrigatorio!")]

    public string? Titulo { get; set; }
}
