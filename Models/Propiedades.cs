namespace PropertyManagerWeb.Models
{
    public class Propiedades
    {
            public int IdPropiedad { get; set; }
            public string Dirección { get; set; }
            public string TipoPropiedad{ get; set; }
            public int NumeroHabitaciones { get; set; }
            public decimal PrecioAlquiler { get; set; }
            public bool Disponible { get; set; }
    }
}
