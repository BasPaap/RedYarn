using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bas.RedYarn.WebApp.Database
{
    public sealed class RedYarnDbContext : DbContext
    {
        public DbSet<Diagram> Diagrams { get; set; }
        public DbSet<Storyline> Storylines { get; set; }
        public DbSet<Character> Characters { get; set; }
        public DbSet<StorylineNode> StorylineNodes { get; set; }
        public DbSet<CharacterNode> CharacterNodes { get; set; }

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
