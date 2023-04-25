using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Sistema_Viajes.Models
{
	public class Colaborador
	{
		[Key]
		public int IdColaborador { get; set; }

		[Required]
		[MaxLength(50)]
		[Display(Name = "Nombre Colaborador")]
		public string Nombre { get; set; }

		[Required]
		[MaxLength(50)]
		[Display(Name = "Apellido Colaborador")]
		public string Apellido { get; set; }

		[Required]
		[MaxLength(50)]
		[Display(Name = "Dirección Colaborador")]
		public string Direccion { get; set; }

		[Required]
		public int SucurrsalId { get; set; }

		[ForeignKey("SucurrsalId")]
		public Sucurrsal Sucurrsal { get; set; }
	}
}
