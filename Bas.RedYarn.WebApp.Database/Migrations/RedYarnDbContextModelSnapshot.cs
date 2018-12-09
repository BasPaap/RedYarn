﻿// <auto-generated />
using System;
using Bas.RedYarn.WebApp.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Bas.RedYarn.WebApp.Database.Migrations
{
    [DbContext(typeof(RedYarnDbContext))]
    partial class RedYarnDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024");

            modelBuilder.Entity("Bas.RedYarn.Alias", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasConversion(new ValueConverter<string, string>(v => default(string), v => default(string), new ConverterMappingHints(size: 36)))
                        .HasAnnotation("Key", 0);

                    b.Property<string>("CharacterId")
                        .HasConversion(new ValueConverter<string, string>(v => default(string), v => default(string), new ConverterMappingHints(size: 36)));

                    b.Property<string>("DiagramId")
                        .HasConversion(new ValueConverter<string, string>(v => default(string), v => default(string), new ConverterMappingHints(size: 36)));

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.HasIndex("CharacterId");

                    b.HasIndex("DiagramId");

                    b.ToTable("Aliases");
                });

            modelBuilder.Entity("Bas.RedYarn.Author", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasConversion(new ValueConverter<string, string>(v => default(string), v => default(string), new ConverterMappingHints(size: 36)))
                        .HasAnnotation("Key", 0);

                    b.Property<string>("DiagramId")
                        .HasConversion(new ValueConverter<string, string>(v => default(string), v => default(string), new ConverterMappingHints(size: 36)));

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.HasIndex("DiagramId");

                    b.ToTable("Authors");
                });

            modelBuilder.Entity("Bas.RedYarn.Character", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasConversion(new ValueConverter<string, string>(v => default(string), v => default(string), new ConverterMappingHints(size: 36)))
                        .HasAnnotation("Key", 0);

                    b.Property<string>("Description");

                    b.Property<string>("DiagramId")
                        .HasConversion(new ValueConverter<string, string>(v => default(string), v => default(string), new ConverterMappingHints(size: 36)));

                    b.Property<string>("ImagePath");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.HasIndex("DiagramId");

                    b.ToTable("Characters");
                });

            modelBuilder.Entity("Bas.RedYarn.Diagram", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasConversion(new ValueConverter<string, string>(v => default(string), v => default(string), new ConverterMappingHints(size: 36)))
                        .HasAnnotation("Key", 0);

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Diagrams");
                });

            modelBuilder.Entity("Bas.RedYarn.PlotElement", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasConversion(new ValueConverter<string, string>(v => default(string), v => default(string), new ConverterMappingHints(size: 36)))
                        .HasAnnotation("Key", 0);

                    b.Property<string>("Description");

                    b.Property<string>("DiagramId")
                        .HasConversion(new ValueConverter<string, string>(v => default(string), v => default(string), new ConverterMappingHints(size: 36)));

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.HasIndex("DiagramId");

                    b.ToTable("PlotElements");
                });

            modelBuilder.Entity("Bas.RedYarn.Relationship", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasConversion(new ValueConverter<string, string>(v => default(string), v => default(string), new ConverterMappingHints(size: 36)))
                        .HasAnnotation("Key", 0);

                    b.Property<string>("FirstCharacterId")
                        .IsRequired()
                        .HasConversion(new ValueConverter<string, string>(v => default(string), v => default(string), new ConverterMappingHints(size: 36)));

                    b.Property<bool>("IsDirectional");

                    b.Property<string>("Name");

                    b.Property<string>("SecondCharacterId")
                        .IsRequired()
                        .HasConversion(new ValueConverter<string, string>(v => default(string), v => default(string), new ConverterMappingHints(size: 36)));

                    b.HasKey("Id");

                    b.HasIndex("FirstCharacterId");

                    b.HasIndex("SecondCharacterId");

                    b.ToTable("Relationships");
                });

            modelBuilder.Entity("Bas.RedYarn.Storyline", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasConversion(new ValueConverter<string, string>(v => default(string), v => default(string), new ConverterMappingHints(size: 36)))
                        .HasAnnotation("Key", 0);

                    b.Property<string>("Description");

                    b.Property<string>("DiagramId")
                        .HasConversion(new ValueConverter<string, string>(v => default(string), v => default(string), new ConverterMappingHints(size: 36)));

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.HasIndex("DiagramId");

                    b.ToTable("Storylines");
                });

            modelBuilder.Entity("Bas.RedYarn.Tag", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasConversion(new ValueConverter<string, string>(v => default(string), v => default(string), new ConverterMappingHints(size: 36)))
                        .HasAnnotation("Key", 0);

                    b.Property<string>("Category");

                    b.Property<string>("DiagramId")
                        .HasConversion(new ValueConverter<string, string>(v => default(string), v => default(string), new ConverterMappingHints(size: 36)));

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.HasIndex("DiagramId");

                    b.ToTable("Tags");
                });

            modelBuilder.Entity("Bas.RedYarn.WebApp.Database.JoinTable<Bas.RedYarn.Character, Bas.RedYarn.Author>", b =>
                {
                    b.Property<string>("LeftEntityId")
                        .HasConversion(new ValueConverter<string, string>(v => default(string), v => default(string), new ConverterMappingHints(size: 36)));

                    b.Property<string>("RightEntityId")
                        .HasConversion(new ValueConverter<string, string>(v => default(string), v => default(string), new ConverterMappingHints(size: 36)));

                    b.HasKey("LeftEntityId", "RightEntityId");

                    b.HasIndex("RightEntityId");

                    b.ToTable("CharacterAuthor");
                });

            modelBuilder.Entity("Bas.RedYarn.WebApp.Database.JoinTable<Bas.RedYarn.Character, Bas.RedYarn.PlotElement>", b =>
                {
                    b.Property<string>("LeftEntityId")
                        .HasConversion(new ValueConverter<string, string>(v => default(string), v => default(string), new ConverterMappingHints(size: 36)));

                    b.Property<string>("RightEntityId")
                        .HasConversion(new ValueConverter<string, string>(v => default(string), v => default(string), new ConverterMappingHints(size: 36)));

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.HasKey("LeftEntityId", "RightEntityId");

                    b.HasIndex("RightEntityId");

                    b.ToTable("CharacterPlotElement");

                    b.HasDiscriminator<string>("Discriminator").HasValue("JoinTable<Character, PlotElement>");
                });

            modelBuilder.Entity("Bas.RedYarn.WebApp.Database.JoinTable<Bas.RedYarn.Character, Bas.RedYarn.Tag>", b =>
                {
                    b.Property<string>("LeftEntityId")
                        .HasConversion(new ValueConverter<string, string>(v => default(string), v => default(string), new ConverterMappingHints(size: 36)));

                    b.Property<string>("RightEntityId")
                        .HasConversion(new ValueConverter<string, string>(v => default(string), v => default(string), new ConverterMappingHints(size: 36)));

                    b.HasKey("LeftEntityId", "RightEntityId");

                    b.HasIndex("RightEntityId");

                    b.ToTable("CharacterTag");
                });

            modelBuilder.Entity("Bas.RedYarn.WebApp.Database.JoinTable<Bas.RedYarn.Storyline, Bas.RedYarn.Author>", b =>
                {
                    b.Property<string>("LeftEntityId")
                        .HasConversion(new ValueConverter<string, string>(v => default(string), v => default(string), new ConverterMappingHints(size: 36)));

                    b.Property<string>("RightEntityId")
                        .HasConversion(new ValueConverter<string, string>(v => default(string), v => default(string), new ConverterMappingHints(size: 36)));

                    b.HasKey("LeftEntityId", "RightEntityId");

                    b.HasIndex("RightEntityId");

                    b.ToTable("StorylineAuthor");
                });

            modelBuilder.Entity("Bas.RedYarn.WebApp.Database.JoinTable<Bas.RedYarn.Storyline, Bas.RedYarn.Character>", b =>
                {
                    b.Property<string>("LeftEntityId")
                        .HasConversion(new ValueConverter<string, string>(v => default(string), v => default(string), new ConverterMappingHints(size: 36)));

                    b.Property<string>("RightEntityId")
                        .HasConversion(new ValueConverter<string, string>(v => default(string), v => default(string), new ConverterMappingHints(size: 36)));

                    b.HasKey("LeftEntityId", "RightEntityId");

                    b.HasIndex("RightEntityId");

                    b.ToTable("StorylineCharacter");
                });

            modelBuilder.Entity("Bas.RedYarn.WebApp.Database.JoinTable<Bas.RedYarn.Storyline, Bas.RedYarn.PlotElement>", b =>
                {
                    b.Property<string>("LeftEntityId")
                        .HasConversion(new ValueConverter<string, string>(v => default(string), v => default(string), new ConverterMappingHints(size: 36)));

                    b.Property<string>("RightEntityId")
                        .HasConversion(new ValueConverter<string, string>(v => default(string), v => default(string), new ConverterMappingHints(size: 36)));

                    b.HasKey("LeftEntityId", "RightEntityId");

                    b.HasIndex("RightEntityId");

                    b.ToTable("StorylinePlotElement");
                });

            modelBuilder.Entity("Bas.RedYarn.WebApp.Database.Node", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<float>("XPosition");

                    b.Property<float>("YPosition");

                    b.HasKey("Id");

                    b.ToTable("Nodes");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Node");
                });

            modelBuilder.Entity("Bas.RedYarn.WebApp.Database.CharacterPlotElementJoinTable", b =>
                {
                    b.HasBaseType("Bas.RedYarn.WebApp.Database.JoinTable<Bas.RedYarn.Character, Bas.RedYarn.PlotElement>");

                    b.Property<bool>("CharacterOwnsPlotElement");

                    b.ToTable("CharacterPlotElementJoinTable");

                    b.HasDiscriminator().HasValue("CharacterPlotElementJoinTable");
                });

            modelBuilder.Entity("Bas.RedYarn.WebApp.Database.CharacterNode", b =>
                {
                    b.HasBaseType("Bas.RedYarn.WebApp.Database.Node");

                    b.Property<string>("CharacterId")
                        .HasConversion(new ValueConverter<string, string>(v => default(string), v => default(string), new ConverterMappingHints(size: 36)));

                    b.HasIndex("CharacterId");

                    b.ToTable("CharacterNode");

                    b.HasDiscriminator().HasValue("CharacterNode");
                });

            modelBuilder.Entity("Bas.RedYarn.WebApp.Database.PlotElementNode", b =>
                {
                    b.HasBaseType("Bas.RedYarn.WebApp.Database.Node");

                    b.Property<string>("PlotElementId")
                        .HasConversion(new ValueConverter<string, string>(v => default(string), v => default(string), new ConverterMappingHints(size: 36)));

                    b.HasIndex("PlotElementId");

                    b.ToTable("PlotElementNode");

                    b.HasDiscriminator().HasValue("PlotElementNode");
                });

            modelBuilder.Entity("Bas.RedYarn.WebApp.Database.StorylineNode", b =>
                {
                    b.HasBaseType("Bas.RedYarn.WebApp.Database.Node");

                    b.Property<string>("StorylineId")
                        .HasConversion(new ValueConverter<string, string>(v => default(string), v => default(string), new ConverterMappingHints(size: 36)));

                    b.HasIndex("StorylineId");

                    b.ToTable("StorylineNode");

                    b.HasDiscriminator().HasValue("StorylineNode");
                });

            modelBuilder.Entity("Bas.RedYarn.Alias", b =>
                {
                    b.HasOne("Bas.RedYarn.Character")
                        .WithMany("Aliases")
                        .HasForeignKey("CharacterId");

                    b.HasOne("Bas.RedYarn.Diagram")
                        .WithMany("Aliases")
                        .HasForeignKey("DiagramId");
                });

            modelBuilder.Entity("Bas.RedYarn.Author", b =>
                {
                    b.HasOne("Bas.RedYarn.Diagram")
                        .WithMany("Authors")
                        .HasForeignKey("DiagramId");
                });

            modelBuilder.Entity("Bas.RedYarn.Character", b =>
                {
                    b.HasOne("Bas.RedYarn.Diagram")
                        .WithMany("Characters")
                        .HasForeignKey("DiagramId");
                });

            modelBuilder.Entity("Bas.RedYarn.PlotElement", b =>
                {
                    b.HasOne("Bas.RedYarn.Diagram")
                        .WithMany("PlotElements")
                        .HasForeignKey("DiagramId");
                });

            modelBuilder.Entity("Bas.RedYarn.Relationship", b =>
                {
                    b.HasOne("Bas.RedYarn.Character", "FirstCharacter")
                        .WithMany()
                        .HasForeignKey("FirstCharacterId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Bas.RedYarn.Character", "SecondCharacter")
                        .WithMany()
                        .HasForeignKey("SecondCharacterId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Bas.RedYarn.Storyline", b =>
                {
                    b.HasOne("Bas.RedYarn.Diagram")
                        .WithMany("Storylines")
                        .HasForeignKey("DiagramId");
                });

            modelBuilder.Entity("Bas.RedYarn.Tag", b =>
                {
                    b.HasOne("Bas.RedYarn.Diagram")
                        .WithMany("Tags")
                        .HasForeignKey("DiagramId");
                });

            modelBuilder.Entity("Bas.RedYarn.WebApp.Database.JoinTable<Bas.RedYarn.Character, Bas.RedYarn.Author>", b =>
                {
                    b.HasOne("Bas.RedYarn.Character", "LeftEntity")
                        .WithMany()
                        .HasForeignKey("LeftEntityId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Bas.RedYarn.Author", "RightEntity")
                        .WithMany()
                        .HasForeignKey("RightEntityId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Bas.RedYarn.WebApp.Database.JoinTable<Bas.RedYarn.Character, Bas.RedYarn.PlotElement>", b =>
                {
                    b.HasOne("Bas.RedYarn.Character", "LeftEntity")
                        .WithMany()
                        .HasForeignKey("LeftEntityId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Bas.RedYarn.PlotElement", "RightEntity")
                        .WithMany()
                        .HasForeignKey("RightEntityId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Bas.RedYarn.WebApp.Database.JoinTable<Bas.RedYarn.Character, Bas.RedYarn.Tag>", b =>
                {
                    b.HasOne("Bas.RedYarn.Character", "LeftEntity")
                        .WithMany()
                        .HasForeignKey("LeftEntityId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Bas.RedYarn.Tag", "RightEntity")
                        .WithMany()
                        .HasForeignKey("RightEntityId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Bas.RedYarn.WebApp.Database.JoinTable<Bas.RedYarn.Storyline, Bas.RedYarn.Author>", b =>
                {
                    b.HasOne("Bas.RedYarn.Storyline", "LeftEntity")
                        .WithMany()
                        .HasForeignKey("LeftEntityId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Bas.RedYarn.Author", "RightEntity")
                        .WithMany()
                        .HasForeignKey("RightEntityId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Bas.RedYarn.WebApp.Database.JoinTable<Bas.RedYarn.Storyline, Bas.RedYarn.Character>", b =>
                {
                    b.HasOne("Bas.RedYarn.Storyline", "LeftEntity")
                        .WithMany()
                        .HasForeignKey("LeftEntityId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Bas.RedYarn.Character", "RightEntity")
                        .WithMany()
                        .HasForeignKey("RightEntityId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Bas.RedYarn.WebApp.Database.JoinTable<Bas.RedYarn.Storyline, Bas.RedYarn.PlotElement>", b =>
                {
                    b.HasOne("Bas.RedYarn.Storyline", "LeftEntity")
                        .WithMany()
                        .HasForeignKey("LeftEntityId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Bas.RedYarn.PlotElement", "RightEntity")
                        .WithMany()
                        .HasForeignKey("RightEntityId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Bas.RedYarn.WebApp.Database.CharacterNode", b =>
                {
                    b.HasOne("Bas.RedYarn.Character", "Character")
                        .WithMany()
                        .HasForeignKey("CharacterId");
                });

            modelBuilder.Entity("Bas.RedYarn.WebApp.Database.PlotElementNode", b =>
                {
                    b.HasOne("Bas.RedYarn.PlotElement", "PlotElement")
                        .WithMany()
                        .HasForeignKey("PlotElementId");
                });

            modelBuilder.Entity("Bas.RedYarn.WebApp.Database.StorylineNode", b =>
                {
                    b.HasOne("Bas.RedYarn.Storyline", "Storyline")
                        .WithMany()
                        .HasForeignKey("StorylineId");
                });
#pragma warning restore 612, 618
        }
    }
}
