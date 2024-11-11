namespace PropertyManagerWeb.Models
{
    public class Contratos
    {
            public int IdContrato { get; set; }
            public int IdPropiedad { get; set; }
            public Propiedades Propiedad { get; set; }
            public int IdInquilino { get; set; }
            public Inquilinos Inquilino { get; set; }
            public DateTime FechaInicio { get; set; }
            public DateTime FechaFin { get; set; }
            public decimal Deposito { get; set; }
            public string Terminos { get; set; }
    }
}
