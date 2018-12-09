using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bas.RedYarn.WebApp.Database
{
    public sealed class CharacterPlotElementJoinTable : JoinTable<Character, PlotElement>
    {
        public bool CharacterOwnsPlotElement { get; set; }

        internal new static void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<JoinTable<Character, PlotElement>>()
                .ToTable($"{typeof(Character).Name}{typeof(PlotElement).Name}")
                .HasKey(jt => new { jt.LeftEntityId, jt.RightEntityId });

            modelBuilder.Entity<JoinTable<Character, PlotElement>>()
                .HasOne(jt => jt.LeftEntity)
                .WithMany()
                .HasForeignKey(jt => jt.LeftEntityId);

            modelBuilder.Entity<JoinTable<Character, PlotElement>>()
                .HasOne(jt => jt.RightEntity)
                .WithMany()
                .HasForeignKey(jt => jt.RightEntityId);
        }
    }
}
