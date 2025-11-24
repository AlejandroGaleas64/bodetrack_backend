namespace BodeTrack.API.Models.Inventario
{
    public class SalidasViewModel
    {
        public int Sali_Id { get; set; }

        public int Sucs_Id { get; set; }

        public DateTime Sali_FechaSalida { get; set; }

        public string Sali_EstadoSalida { get; set; }

        public decimal Sali_CostoTotal { get; set; }

        public int Sali_UsuarioEnvia { get; set; }

        public int? Sali_UsuarioRecibe { get; set; }

        public int? Vehi_Id { get; set; }

        public int? Sali_Transportista { get; set; }

        public DateTime? Sali_FechaRecepcion { get; set; }

        public string Sali_GuiaRemision { get; set; }

        public bool Sali_Estado { get; set; }

        public int Sali_Creacion { get; set; }

        public DateTime Sali_FechaCreacion { get; set; }

        public int? Sali_Modificacion { get; set; }

        public DateTime? Sali_FechaModificacion { get; set; }
    }
}