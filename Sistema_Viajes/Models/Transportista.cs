using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Sistema_Viajes.Models
{
    public class Transportista
    {
        [Key]
        public int IdTransportista { get; set; }

        [Required]
        [MaxLength(100)]
        [Display(Name = "Nombre Transportista")]
        public string FTransportista { get; set; }
    }
}
