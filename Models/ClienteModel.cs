using System.ComponentModel.DataAnnotations;

namespace web_clientes.Models
{
    public class ClienteModel
    {
        // [Key] define la clave primaria si no se usa <id> por defecto
        public int id { get; set; }
        [Display(Name = "Nombres de Clientes")]
        [MaxLength(100, ErrorMessage = "El número máximo de carácteres es 100")]
        [Required(ErrorMessage = "El campo es requerido")]
        public string nombres { get; set; }
        [MaxLength(100, ErrorMessage = "El número máximo de carácteres es 100")]
        [Required(ErrorMessage = "El campo es requerido")]
        public string apellidos { get; set; }
        [Required(ErrorMessage = "El campo dirección es requerido")]
        public string direccion { get; set; }
        [MaxLength(17, ErrorMessage = "El número máximo de carácteres es 17")]
        [MinLength(9, ErrorMessage = "El minimo de carácteres es 9")]
        [Required(ErrorMessage = "El campo es requerido")]
        public string telefono { get; set; }
        [EmailAddress(ErrorMessage = "El correo electrónico no es valido")]
        public string correo { get; set; }
    }
}
