namespace BodeTrack.API.Models.General
{
    public class SucursalesViewModel
    {
        public int Sucs_Id { get; set; }

        public string Sucs_Descripcion { get; set; }

        public string Muni_Codigo { get; set; }

        public bool Sucs_Estado { get; set; }

        public int Sucs_Creacion { get; set; }

        public DateTime Sucs_FechaCreacion { get; set; }

        public int? Sucs_Modificacion { get; set; }

        public DateTime? Sucs_FechaModificacion { get; set; }
    }
}