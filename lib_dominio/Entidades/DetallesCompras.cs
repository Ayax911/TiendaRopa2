
using System.ComponentModel.DataAnnotations.Schema;

namespace lib_dominio.Entidades
{

    public class DetallesCompras
    {
        public int Id { get; set; }
        public int Cantidad { get; set; }
        public decimal ValorBruto { get; set; }

        //FK
        public int Compra { get; set; }
        public int Producto { get; set; }


        [ForeignKey("Compra")] public Compras? _Compra { get; set; }
        [ForeignKey("Producto")] public Productos? _Producto { get; set; }

    }


}
