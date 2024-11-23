using System.ComponentModel.DataAnnotations.Schema;

namespace PropertyManagerWeb.Models
{
    public class Contratos
    {
            public int Id { get; set; }
            public int IdPropiedad { get; set; }
             public Propiedades? Propiedad { get; set; } = default!;
            public int IdInquilino { get; set; }
            public DateTime FechaInicio { get; set; }
            public DateTime FechaFin { get; set; }

            [Column(TypeName ="decimal(6,2)")]
            public decimal Deposito { get; set; }
            public string Terminos { get; set; }
    }
}
