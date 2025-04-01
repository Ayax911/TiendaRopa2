
namespace lib_dominio.Entidades
{
    public class Lugares
    {

        public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? CodigoPostal { get; set; }


        public List<Compras>? Compras { get; set; }


    }

}
