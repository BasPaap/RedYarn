using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bas.RedYarn.WebApp.Database
{
    public sealed class RedYarnDbContext : DbContext
    {
        public DbSet<Diagram> Diagrams { get; set; }
        public DbSet<Node> Nodes { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Diagram>().Property<Guid>(ShadowPropertyNames.Id)
                                          .ValueGeneratedOnAdd()
                                          .HasAnnotation("Key", 0);
        }
    }
}
