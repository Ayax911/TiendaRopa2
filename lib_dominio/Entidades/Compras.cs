
using System.ComponentModel.DataAnnotations.Schema;

namespace lib_dominio.Entidades
{

    public class Compras
    {

        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public string? Codigo { get; set; }
        public decimal ValorTotal { get; set; }

        //FK
        public int Cliente { get; set; }
        public int Sucursal { get; set; }
        public int MetodoPago { get; set; }
        public int Lugar { get; set; }

        /*public Clientes? _Cliente { get; set; }
        public Sucursales? _Sucursal { get; set; }
        public MetodosPagos? _MetodoPago { get; set; }
        public Lugares? _Lugar { get; set; }*/

        [ForeignKey("Cliente")] public Clientes? _Cliente { get; set; }
        [ForeignKey("Sucursal")] public Sucursales? _Sucursal { get; set; }
        [ForeignKey("MetodoPago")] public MetodosPagos? _MetodoPago { get; set; }
        [ForeignKey("Lugar")] public Lugares? _Lugar { get; set; }


        public List<DetallesCompras>? DetallesCompras { get; set; }

    }

}
