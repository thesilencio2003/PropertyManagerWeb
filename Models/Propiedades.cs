using System.ComponentModel.DataAnnotations.Schema;

namespace PropertyManagerWeb.Models
{
    public class Propiedades
    {
            public int Id { get; set; }
            public string Dirección { get; set; }
            public string TipoPropiedad{ get; set; }
            public int NumeroHabitaciones { get; set; }

            [Column(TypeName = "decimal(6,2)")]
            public decimal PrecioAlquiler { get; set; }
            public bool Disponible { get; set; }
    }
}
