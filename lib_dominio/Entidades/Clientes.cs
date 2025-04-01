
namespace lib_dominio.Entidades
{
    public class Clientes
    {

        public int Id{ get; set; }
        public string? Cedula { get; set; }
        public string? Nombre { get; set; }
        public string? Telefono { get; set; }

        public List<Compras>? Compras { get; set; }


    }
}
