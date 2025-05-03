
using lib_dominio.Entidades;
using lib_repositorios.Implementaciones;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
using ut_presentacion.Nucleo;
using Configuracion = ut_presentacion.Nucleo.Configuracion;

namespace ut_presentacion.Repositorios
{
    [TestClass]
    public class DetallesComprasPrueba
    {
        private readonly IConexion? iConexion;
        private List<DetallesCompras>? lista;
        private DetallesCompras? entidad;
        public DetallesComprasPrueba()
        {
            iConexion = new Conexion();
            iConexion.StringConexion = Configuracion.ObtenerValor("StringConexion");
        }
        [TestMethod]
        public void Ejecutar()
        {
            Assert.AreEqual(true, Guardar());
            Assert.AreEqual(true, Modificar());
            Assert.AreEqual(true, Listar());
            Assert.AreEqual(true, Borrar());
        }
        public bool Listar()
        {
            this.lista = this.iConexion!.DetallesCompras!.ToList();
            return lista.Count > 0;
        }
        public bool Guardar()
        {
            this.entidad = EntidadesNucleo.DetallesCompras(this.iConexion!);
            this.iConexion!.DetallesCompras!.Add(this.entidad);
            this.iConexion!.SaveChanges();
            return true;
        }
        public bool Modificar()
        {
            this.entidad!.ValorBruto = 11500.10m;

            var entry = this.iConexion!.Entry<DetallesCompras>(this.entidad);
            entry.State = EntityState.Modified;
            this.iConexion!.SaveChanges();
            return true;
        }
        public bool Borrar()
        {
            this.iConexion!.DetallesCompras!.Remove(this.entidad!);
            this.iConexion!.SaveChanges();
            return true;
        }
    }

}
