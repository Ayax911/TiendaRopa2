
using lib_dominio.Entidades;
using lib_repositorios.Implementaciones;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
using ut_presentacion.Nucleo;
using Configuracion = ut_presentacion.Nucleo.Configuracion;

namespace ut_presentacion.Repositorios
{
    [TestClass]
    public class LugaresPrueba
    {
        private readonly IConexion? iConexion;
        private List<Lugares>? lista;
        private Lugares? entidad;
        public LugaresPrueba()
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
            this.lista = this.iConexion!.Lugares!.ToList();
            return lista.Count > 0;
        }
        public bool Guardar()
        {
            this.entidad = EntidadesNucleo.Lugares();
            this.iConexion!.Lugares!.Add(this.entidad);
            this.iConexion!.SaveChanges();
            return true;
        }
        public bool Modificar()
        {
            this.entidad!.Nombre = "Bogota";

            var entry = this.iConexion!.Entry<Lugares>(this.entidad);
            entry.State = EntityState.Modified;
            this.iConexion!.SaveChanges();
            return true;
        }
        public bool Borrar()
        {
            this.iConexion!.Lugares!.Remove(this.entidad!);
            this.iConexion!.SaveChanges();
            return true;
        }
    }

}
