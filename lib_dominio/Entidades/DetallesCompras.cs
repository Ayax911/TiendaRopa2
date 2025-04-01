
namespace lib_dominio.Entidades
{

    public class DetallesCompras
    {
        public int Id { get; set; }
        public int Cantidad { get; set; }
        public decimal ValorBruto { get; set; }

        //FK
        public int Compras { get; set; }
        public int Productos { get; set; }


        public Compras? _Compra { get; set; }
        public Productos? _Producto { get; set; }

    }


}
