using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Sistema_Viajes.Models
{
	public class Sucurrsal
	{
		[Key]
		public int IdSucurrsal { get; set; }

		[Required]
		[MaxLength(50)]
		[Display(Name = "Nombre Sucurrsal")]
		public string FSucurrsal { get; set; }

		[Required]
		[MaxLength(100)]
		[Display(Name = "Ubicacióm Sucurrsal")]
		public string SUbicacion { get; set; }

	}
}
