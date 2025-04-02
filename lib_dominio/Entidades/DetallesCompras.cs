
using System.ComponentModel.DataAnnotations.Schema;

namespace lib_dominio.Entidades
{

    public class DetallesCompras
    {
        public int Id { get; set; }
        public int Cantidad { get; set; }
        public decimal ValorBruto { get; set; }
        //public decimal ValorBruto => (Cantidad * (_Producto?.ValorUnitario ?? 0m));


        //FK
        public int Compra { get; set; }
        public int Producto { get; set; }


        [ForeignKey("Compra")] public Compras? _Compra { get; set; }
        [ForeignKey("Producto")] public Productos? _Producto { get; set; }

        public decimal calcularValorBruto()
        {
            return Cantidad * (_Producto?.ValorUnitario ?? 0m);
        }

    }


}
