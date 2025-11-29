namespace BodeTrack.API.Models.Inventario
{
    public class EntradaDetalleViewModel
    {
        public int Arti_Id { get; set; }
        public string Lote_Codigo { get; set; }
        public int Ende_Cantidad { get; set; }
        public decimal Ende_CostoUnitario { get; set; }
        public DateTime Ende_FechaVencimiento { get; set; }
        public DateTime Ende_FechaFabricacion { get; set; }
        public string Lote_Atributo1 { get; set; }
        public string Lote_Atributo2 { get; set; }
    }

    public class EntradaInsertarViewModel
    {
        public string Entr_NumeroFactura { get; set; }
        public string Entr_Observacion { get; set; }
        public int Entr_Creacion { get; set; }
        public DateTime Entr_FechaCreacion { get; set; }
        public List<EntradaDetalleViewModel> Detalles { get; set; }
    }
}