using System.ComponentModel.DataAnnotations;

namespace CRUDCORE.Models
{
    public class ContactoModel
    {
        public int   IdContacto{ get; set; }

        [Required (ErrorMessage ="El campo Nombre completo es obligatorio")]
        public string? Nombre { get; set; }
        [Required (ErrorMessage = "El campo Teléfono es obligatorio")]
        public string? Telefono { get; set; }
        [Required (ErrorMessage = "El campo Correo es obligatorio")]
        public string? Correo { get; set; }
    }
}
