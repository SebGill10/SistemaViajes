using System.ComponentModel.DataAnnotations;

namespace Sistema_Viajes.Models
{
    public class SucursalColaborador
    {
        public int ColaboradorId { get; set; }
        public int SucursalId { get; set; }

        [Range(1, 50, ErrorMessage = "La distancia debe ser mayor a 1 y menor a 50")]
        public int Distancia { get; set; }


        public virtual Sucursal? Sucursal { get; set; }
        public virtual Colaborador? Colaborador { get; set; }
    }
}
