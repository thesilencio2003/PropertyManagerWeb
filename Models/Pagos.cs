using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Contracts;

namespace PropertyManagerWeb.Models
{
    public class Pagos
    {
            public int Id { get; set; }
            public int IdContrato { get; set; }
            public Contratos? Contrato { get; set; } = default!;
            public DateTime FechaPago { get; set; }

            [Column(TypeName = "decimal(6,2)")]
             public decimal Monto { get; set; }
            public string Estado { get; set; }

    }
}
