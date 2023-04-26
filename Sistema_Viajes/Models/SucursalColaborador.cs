namespace Sistema_Viajes.Models
{
    public class SucursalColaborador
    {
        public int ColaboradorId { get; set; }
        public int SucursalId { get; set; }
        public int Distancia { get; set; }

        public virtual Sucursal? Sucursal { get; set; }
        public virtual Colaborador? Colaborador { get; set; }
    }
}
