using System.Diagnostics.Contracts;

namespace PropertyManagerWeb.Models
{
    public class Pagos
    {
            public int IdPago { get; set; }
            public int IdContrato { get; set; }
            public Contratos Contrato { get; set; }
            public DateTime FechaPago { get; set; }
            public decimal Monto { get; set; }
            public string Estado { get; set; }

    }
}
