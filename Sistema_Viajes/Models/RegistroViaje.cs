using System.ComponentModel.DataAnnotations;

namespace Sistema_Viajes.Models
{
    public class RegistroViaje
    {
        [Key]
        public int IdRegistroViaje { get; set; }

        public int UsuarioId { get; set; }
        public int SucursalId { get; set; }
        public int TransportistaId { get; set; }

        [Required]
        [Display(Name = "Fecha de Viaje")]
        public DateTime FechaViaje { get; set; }

        public virtual Sucursal Sucursal { get; set; }
        public virtual Transportista Transportista { get; set; }
        public virtual ICollection<RegistroViajeColaborador> RegistroViajeColaboradores { get; set; }

    }
}
