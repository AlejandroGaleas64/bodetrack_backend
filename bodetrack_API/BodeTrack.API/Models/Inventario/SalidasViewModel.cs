namespace BodeTrack.API.Models.Inventario
{
    public class SalidaDetalleItemViewModel
    {
        public int Sade_Id { get; set; }
        public string Arti_Codigo { get; set; }
        public string Articulo { get; set; }
        public string Lote_Codigo { get; set; }
        public int Sade_Cantidad { get; set; }
        public decimal Sade_CostoUnitario { get; set; }
        public DateTime Sade_FechaVencimiento { get; set; }
        public decimal Subtotal { get; set; }
        public int Sade_Creacion { get; set; }
        public string UsuaCreacionDetalle { get; set; }
        public DateTime Sade_FechaCreacion { get; set; }
    }

    public class SalidaCompletaViewModel
    {
        public int Code_Status { get; set; }
        public string Message_Status { get; set; }
        public int? Sali_Id { get; set; }
        public DateTime? Sali_FechaSalida { get; set; }
        public string Sali_EstadoSalida { get; set; }
        public decimal? Sali_CostoTotal { get; set; }
        public string SucursalDestino { get; set; }
        public string Vehiculo { get; set; }
        public string Transportista { get; set; }
        public string UsuarioEnvia { get; set; }
        public string UsuarioRecibe { get; set; }
        public DateTime? Sali_FechaRecepcion { get; set; }
        public string DetalleSalida { get; set; } // JSON string
        public int? Sali_Creacion { get; set; }
        public string UsuaCreacionNombre { get; set; }
        public DateTime? Sali_FechaCreacion { get; set; }
        public int? Sali_Modificacion { get; set; }
        public string UsuaModificacionNombre { get; set; }
        public DateTime? Sali_FechaModificacion { get; set; }
    }

    public class SalidaDetalleViewModel
    {
        public int Arti_Id { get; set; }
        public int Sade_Cantidad { get; set; }
    }

    public class SalidaInsertarViewModel
    {
        public int Sucs_Id { get; set; }
        public int Sali_UsuarioEnvia { get; set; }
        public int? Vehi_Id { get; set; }
        public int? Sali_Transportista { get; set; }
        public int Sali_Creacion { get; set; }
        public DateTime Sali_FechaCreacion { get; set; }
        public List<SalidaDetalleViewModel> Detalles { get; set; }
    }

    public class RecibirSalidaViewModel
    {
        public int Sali_Id { get; set; }
        public int Usua_Creacion { get; set; } // Usuario que recibe
    }
}