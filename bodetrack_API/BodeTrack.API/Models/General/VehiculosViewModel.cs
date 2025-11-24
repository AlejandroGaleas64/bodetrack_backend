namespace BodeTrack.API.Models.General
{
    public class VehiculosViewModel
    {
        public int Vehi_Id { get; set; }

        public string Vehi_Codigo { get; set; }

        public string Vehi_Marca { get; set; }

        public string Vehi_Modelo { get; set; }

        public string Vehi_Placa { get; set; }

        public int Vehi_Anio { get; set; }

        public bool Vehi_Estado { get; set; }

        public int Vehi_Creacion { get; set; }

        public DateTime Vehi_FechaCreacion { get; set; }

        public int? Vehi_Modificacion { get; set; }

        public DateTime? Vehi_FechaModificacion { get; set; }
    }
}