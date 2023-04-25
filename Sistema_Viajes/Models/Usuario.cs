using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sistema_Viajes.Models
{
    public class Usuario
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdUsuario { get; set; }

        [Required]
        [MaxLength(120)]
        [Display(Name = "Correo Usuario")]
        public string Correo { get; set; }

        [Required]
        [MaxLength(500)]
        [Display(Name = "Password")]
        public string Password { get; set; }
    }
}
