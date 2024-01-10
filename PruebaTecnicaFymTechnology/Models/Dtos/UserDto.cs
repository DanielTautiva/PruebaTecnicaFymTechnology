using System.ComponentModel.DataAnnotations;

namespace PruebaTecnicaFymTechnology.Models.Dtos
{
    // UserDto.cs
    public class UserDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo Nombre es obligatorio.")]
        [MaxLength(50, ErrorMessage = "El campo Nombre no puede tener más de 50 caracteres.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "El campo Apellido es obligatorio.")]
        [MaxLength(50, ErrorMessage = "El campo Apellido no puede tener más de 50 caracteres.")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "El campo Correo Electronico es obligatorio.")]
        [MaxLength(100, ErrorMessage = "El campo Correo Electronico no puede tener más de 100 caracteres.")]
        [EmailAddress(ErrorMessage = "El campo Correo Electronico debe ser una dirección de correo electrónico válida.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "El campo Nombre de usuario es obligatorio.")]
        [MaxLength(20, ErrorMessage = "El campo Nombre de usuario no puede tener más de 20 caracteres.")]
        public string Username { get; set; }

        [Required(ErrorMessage = "El campo Contraseña es obligatorio.")]
        [MaxLength(100, ErrorMessage = "El campo Contraseña no puede tener más de 100 caracteres.")]
        public string Password { get; set; }

        [Required(ErrorMessage = "El campo Fecha de cumpleaños es obligatorio.")]
        public DateTime DateOfBirth { get; set; }

        [Required(ErrorMessage = "El campo Telefono es obligatorio.")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "El campo Direccion es obligatorio.")]
        public string Address { get; set; }

    }

}
