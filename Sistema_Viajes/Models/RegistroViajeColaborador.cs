namespace Sistema_Viajes.Models
{
    public class RegistroViajeColaborador
    {
        public int ViajeId { get; set; }
        public int ColaboradorId { get; set; }

        public virtual RegistroViaje RegistroViaje { get; set; }
        public virtual Colaborador Colaborador { get; set; }
    }
}
