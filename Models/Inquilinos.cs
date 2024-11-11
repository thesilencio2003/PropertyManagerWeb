namespace PropertyManagerWeb.Models
{
    public class Inquilinos
    {
            public int Id { get; set; }
            public string Nombre { get; set; }
            public string Apellido { get; set; }
            public string Telefono { get; set; }
            public string Email { get; set; }

            // Propiedad de navegación para la relación con Propiedad
            public int IdPropiedad { get; set; }
            public Propiedades Propiedad { get; set; }        
    }
}
