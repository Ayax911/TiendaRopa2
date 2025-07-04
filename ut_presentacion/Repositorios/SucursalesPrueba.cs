﻿

using lib_dominio.Entidades;
using lib_repositorios.Implementaciones;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
using ut_presentacion.Nucleo;
using Configuracion = ut_presentacion.Nucleo.Configuracion;

namespace ut_presentacion.Repositorios
{
    [TestClass]
    public class SucursalesPrueba
    {
        private readonly IConexion? iConexion;
        private List<Sucursales>? lista;
        private Sucursales? entidad;
        public SucursalesPrueba()
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
            this.lista = this.iConexion!.Sucursales!.ToList();
            return lista.Count > 0;
        }
        public bool Guardar()
        {
            this.entidad = EntidadesNucleo.Sucursales();
            this.iConexion!.Sucursales!.Add(this.entidad);
            this.iConexion!.SaveChanges();
            return true;
        }
        public bool Modificar()
        {
            this.entidad!.Nombre = "Rifle Viva Envigado";

            var entry = this.iConexion!.Entry<Sucursales>(this.entidad);
            entry.State = EntityState.Modified;
            this.iConexion!.SaveChanges();
            return true;
        }
        public bool Borrar()
        {
            this.iConexion!.Sucursales!.Remove(this.entidad!);
            this.iConexion!.SaveChanges();
            return true;
        }
    }

}
