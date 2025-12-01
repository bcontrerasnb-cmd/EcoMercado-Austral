using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Examen_BastianContreras_NicoleAlegria.Models
{
    public class EcoMercadoEntities : DbContext
    {
        public EcoMercadoEntities() : base("DefaultConnection")
        {
            Database.SetInitializer<EcoMercadoEntities>(null);
        }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Ciudad> Ciudades { get; set; }
        public DbSet<SegmentoCliente> SegmentosClientes { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);
        }
    }
}