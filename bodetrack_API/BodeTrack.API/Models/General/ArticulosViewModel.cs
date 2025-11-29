namespace BodeTrack.API.Models.General
{
    public class ArticulosViewModel
    {
        public int Arti_Id { get; set; }

        public string Arti_Codigo { get; set; }

        public string Arti_CodigoBarras { get; set; }

        public string Arti_Descripcion { get; set; }

        public bool Arti_Estado { get; set; }

        public int Arti_Creacion { get; set; }

        public DateTime Arti_FechaCreacion { get; set; }

        public int? Arti_Modificacion { get; set; }

        public DateTime? Arti_FechaModificacion { get; set; }
    }
}