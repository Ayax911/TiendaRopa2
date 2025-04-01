
namespace lib_dominio.Entidades
{

    public class Compras
    {

        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public string? Codigo { get; set; }
        public decimal ValorTotal { get; set; }

        //FK
        public int Clientes { get; set; }
        public int Sucursales { get; set; }
        public int MetodosPagos { get; set; }
        public int Lugares { get; set; }


        public Clientes? _Cliente { get; set; }
        public Sucursales? _Sucursal { get; set; }
        public MetodosPagos? _MetodoPago { get; set; }
        public Lugares? _Lugar { get; set; }


        public List<DetallesCompras>? DetallesCompras { get; set; }

    }

}
