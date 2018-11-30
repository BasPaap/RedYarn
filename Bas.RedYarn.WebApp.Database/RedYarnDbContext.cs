using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;

namespace Bas.RedYarn.WebApp.Database
{
    public sealed class RedYarnDbContext : DbContext
    {
        public DbSet<Diagram> Diagrams { get; set; }
        public DbSet<Storyline> Storylines { get; set; }
        public DbSet<PlotElement> PlotElements { get; set; }
        public DbSet<Character> Characters { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Alias> Aliases { get; set; }
        public DbSet<StorylineNode> StorylineNodes { get; set; }
        public DbSet<CharacterNode> CharacterNodes { get; set; }
        public DbSet<PlotElementNode> PlotElementNodes { get; set; }
        public DbSet<Node> Nodes { get; set; }
        public DbSet<JoinTable<Character, Author>> CharacterAuthors { get; set; }
        public DbSet<JoinTable<Character, Storyline>> CharacterStorylines { get; set; }
        public DbSet<JoinTable<Character, Tag>> CharacterTags { get; set; }
        public DbSet<JoinTable<Storyline, Author>> StorylineAuthors { get; set; }
        public DbSet<JoinTable<Storyline, PlotElement>> StorylinePlotElements { get; set; }
        public DbSet<Relationship> Relationships { get; set; }

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

            CreateModelForJoinTableEntities(modelBuilder);
            CreateRelationshipModel(modelBuilder);

            modelBuilder.Entity<Character>().Ignore(c => c.Relationships);
        }

        private static void CreateRelationshipModel(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Relationship>()
                .HasOne(r => r.FirstCharacter)
                .WithMany();

            modelBuilder.Entity<Relationship>()
                .HasOne(r => r.SecondCharacter)
                .WithMany();

            modelBuilder.Entity<Relationship>()
                .Property<Guid>(ShadowPropertyNames.FromNodeId)
                .HasConversion<string>();
            modelBuilder.Entity<Relationship>()
                .Property<Guid>(ShadowPropertyNames.ToNodeId)
                .HasConversion<string>();

            modelBuilder.Entity<Relationship>()
                .HasKey(ShadowPropertyNames.FromNodeId, ShadowPropertyNames.ToNodeId);
        }

        private void CreateModelForJoinTableEntities(ModelBuilder modelBuilder)
        {
            var joinTableTypes = GetJoinTableTypes();

            foreach (var joinTableType in joinTableTypes)
            {
                var onModelCreatingMethod = joinTableType.GetMethod("OnModelCreating", BindingFlags.NonPublic | BindingFlags.Static);
                onModelCreatingMethod.Invoke(null, new [] { modelBuilder });                
            }
        }

        private IEnumerable<Type> GetJoinTableTypes()
        {
            return from p in this.GetType().GetProperties()
                                      where p.PropertyType.IsGenericType &&
                                            p.PropertyType.Name.StartsWith("DbSet") &&
                                            p.PropertyType.GenericTypeArguments.Length == 1 &&
                                            p.PropertyType.GenericTypeArguments.Single().IsGenericType &&
                                            p.PropertyType.GenericTypeArguments.Single().GenericTypeArguments.Length == 2 &&
                                            p.PropertyType.GenericTypeArguments.Single().Name.StartsWith("JoinTable")
                                      select p.PropertyType.GenericTypeArguments.Single();
        }

        /// <summary>
        /// Adds a primary key "Id" shadow property of type <see cref="Guid"/> to the given type <typeparamref name="T"/>. 
        /// </summary>
        /// <typeparam name="T">The type to which the primary key shadow property should be added.</typeparam>
        /// <param name="modelBuilder">The <see cref="ModelBuilder"/> for this <see cref="DbContext"/>.</param>
        private static void AddIdShadowProperty<T>(ModelBuilder modelBuilder) where T : class
        {
            modelBuilder.Entity<T>().Property<Guid>(ShadowPropertyNames.Id) // The shadow property is a Guid named "Id"...
                                    .ValueGeneratedOnAdd()                  // ...will get a value when added to the database...
                                    .HasConversion<string>()                // ...will be saved to the database as a string (for readability)...
                                    .HasAnnotation("Key", 0);               // ...and is a primary key.
        }
    }
}
