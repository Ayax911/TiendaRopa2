
namespace lib_dominio.Entidades
{
    public class Sucursales
    {

        public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? Direccion { get; set; }

        public List<Compras>? Compras { get; set; }

    }
}
