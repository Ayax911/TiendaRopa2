
using System.ComponentModel.DataAnnotations.Schema;

namespace lib_dominio.Entidades
{

    public class Compras
    {

        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public string? Codigo { get; set; }
        public decimal ValorTotal { get; set; }
        /*[NotMapped] // Evita que se guarde en la base de datos
        public decimal ValorTotal => DetallesCompras?.Sum(d => d.ValorBruto) ?? 0m;*/

        //FK
        public int Cliente { get; set; }
        public int Sucursal { get; set; }
        public int MetodoPago { get; set; }
        public int Lugar { get; set; }

       

        [ForeignKey("Cliente")] public Clientes? _Cliente { get; set; }
        [ForeignKey("Sucursal")] public Sucursales? _Sucursal { get; set; }
        [ForeignKey("MetodoPago")] public MetodosPagos? _MetodoPago { get; set; }
        [ForeignKey("Lugar")] public Lugares? _Lugar { get; set; }


        public List<DetallesCompras>? DetallesCompras { get; set; }

        public decimal calcularValorTotal()
        {
            return DetallesCompras?.Sum(d => d.ValorBruto) ?? 0m;
        }

    }

}
