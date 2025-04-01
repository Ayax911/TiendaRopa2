
namespace lib_dominio.Entidades
{
    public class MetodosPagos
    {

        public int Id { get; set; }
        public string? Nombre { get; set; }
        public bool Estado { get; set; }


        public List<Compras>? Compras { get; set; }

    }

}
