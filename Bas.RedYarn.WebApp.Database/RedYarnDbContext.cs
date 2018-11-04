﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bas.RedYarn.WebApp.Database
{
    public sealed class RedYarnDbContext : DbContext
    {
        public DbSet<Diagram> Diagrams { get; set; }
        public DbSet<Storyline> Storylines { get; set; }
        public DbSet <PlotElement> PlotElements { get; set; }
        public DbSet<Character> Characters { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Alias> Aliases { get; set; }
        public DbSet<StorylineNode> StorylineNodes { get; set; }
        public DbSet<CharacterNode> CharacterNodes { get; set; }
        public DbSet<PlotElementNode> PlotElementNodes { get; set; }
        public DbSet<Node> Nodes { get; set; }

        public RedYarnDbContext(DbContextOptions<RedYarnDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            AddIdShadowProperty<Diagram>(modelBuilder);
            AddIdShadowProperty<Storyline>(modelBuilder);
            AddIdShadowProperty<PlotElement>(modelBuilder);
            AddIdShadowProperty<Character>(modelBuilder);
            AddIdShadowProperty<Author>(modelBuilder);
            AddIdShadowProperty<Tag>(modelBuilder);
            AddIdShadowProperty<Alias>(modelBuilder);
        }

        private static void AddIdShadowProperty<T>(ModelBuilder modelBuilder) where T : class
        {
            modelBuilder.Entity<T>().Property<Guid>(ShadowPropertyNames.Id)
                                    .ValueGeneratedOnAdd()
                                    .HasConversion<string>()
                                    .HasAnnotation("Key", 0);
        }
    }
}
