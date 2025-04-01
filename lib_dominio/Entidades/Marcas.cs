
namespace lib_dominio.Entidades
{

    public class Marcas
    {

        public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? Nit { get; set; }


        public List<Productos>? Productos { get; set; }

    }

}
