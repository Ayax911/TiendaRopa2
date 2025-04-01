using lib_dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace lib_repositorios.Interfaces
{
    public interface IConexion
    {
        string? StringConexion { get; set; }

         DbSet<Clientes>? Clientes { get; set; }
         DbSet<Compras>? Compras { get; set; }
         DbSet<DetallesCompras>? DetallesCompras { get; set; }
         DbSet<Lugares>? Lugares { get; set; }
         DbSet<Marcas>? Marcas { get; set; }
         DbSet<MetodosPagos>? MetodosPagos { get; set; }
         DbSet<Productos>? Productos { get; set; }
         DbSet<Sucursales>? Sucursales { get; set; }

        EntityEntry<T> Entry<T>(T entity) where T : class;
        int SaveChanges();
    }
}