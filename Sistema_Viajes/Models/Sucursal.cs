using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Sistema_Viajes.Models
{
	public class Sucursal
	{
		[Key]
		public int IdSucursal { get; set; }

		[Required]
		[MaxLength(50)]
		[Display(Name = "Nombre Sucursal")]
		public string? FSucursal { get; set; }

		[Required]
		[MaxLength(100)]
		[Display(Name = "Ubicacióm Sucursal")]
		public string? SUbicacion { get; set; }

		[Required]
        [Display(Name = "Distancia de Sucursal")]
        public int? Distancia { get; set; }
		public virtual ICollection<SucursalColaborador>? SucursalColaboradores { get; set; }

	}
}
