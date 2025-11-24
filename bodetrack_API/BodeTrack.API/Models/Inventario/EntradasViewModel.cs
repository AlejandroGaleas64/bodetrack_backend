namespace BodeTrack.API.Models.Inventario
{
    public class EntradasViewModel
    {
        public int Entr_Id { get; set; }

        public string Entr_NumeroFactura { get; set; }

        public DateTime Entr_FechaEntrada { get; set; }

        public string Entr_Observacion { get; set; }

        public bool Entr_Estado { get; set; }

        public int Entr_Creacion { get; set; }

        public DateTime Entr_FechaCreacion { get; set; }

        public int? Entr_Modificacion { get; set; }

        public DateTime? Entr_FechaModificacion { get; set; }
    }
}