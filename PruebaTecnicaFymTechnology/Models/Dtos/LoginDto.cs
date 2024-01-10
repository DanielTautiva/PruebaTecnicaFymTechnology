using System.ComponentModel.DataAnnotations;

namespace PruebaTecnicaFymTechnology.Models.Dtos
{
    public class LoginDto
    {

        [Required(ErrorMessage = "El campo Nombre de usuario es obligatorio.")]
        public string? Username { get; set; }

        [Required(ErrorMessage = "El campo Contraseña es obligatorio.")]
        public string? Password { get; set; }

    }
}
