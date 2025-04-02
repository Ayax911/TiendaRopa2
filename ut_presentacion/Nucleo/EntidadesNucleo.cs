
using lib_dominio.Entidades;
using lib_repositorios.Interfaces;

namespace ut_presentacion.Nucleo
{
    public class EntidadesNucleo
    {
        public static Clientes? Clientes()
        {
            var entidad = new Clientes();
            entidad.Cedula = "Pruebas-" + DateTime.Now.ToString("yyyyMMddhhmmss");
            entidad.Nombre = "Sujeto Prueba 2";
            entidad.Telefono = "3105254987";
            return entidad;
        }

        
        public static Marcas? Marcas()
        {
                var entidad = new Marcas();
                entidad.Nit = "222222";
                entidad.Nombre = "Marca Prueba 2";

                return entidad;
        }

        public static Productos? Productos(IConexion conexion)
        {
            var marca = conexion.Marcas!.FirstOrDefault(x => x.Nombre == "RopaFina");

            var entidad = new Productos();
            entidad.Nombre = "ArturoCalle";
            entidad.Material = "Lino";
            entidad.ValorUnitario = 100000;
            entidad.Marca = marca!.Id;

            return entidad;
        }

        public static MetodosPagos? MetodosPagos()
        {
            
            var entidad = new MetodosPagos();
            entidad.Nombre = "Nequi";
            entidad.Estado = true;
            

            return entidad;
        }

        public static Lugares? Lugares()
        {
            var entidad = new Lugares();
            entidad.Nombre = "Medellin prueba";
            entidad.CodigoPostal = "20025";

            return entidad;
        }

        public static Sucursales? Sucursales()
        {
            var entidad = new Sucursales();
            entidad.Nombre = "Rifle la central";
            entidad.Direccion = "Calle 20 # 50";

            return entidad;
        }

    }
}
