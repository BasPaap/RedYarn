using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace Bas.RedYarn.WebApp.Database
{
    public sealed class JoinTable<LeftType, RightType> where LeftType: class
                         where RightType: class
    {
        public Guid LeftEntityId { get; set; }
        public LeftType LeftEntity { get; set; }
        public Guid RightEntityId { get; set; }
        public RightType RightEntity { get; set; }

        internal static void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<JoinTable<LeftType, RightType>>()
                .ToTable($"{typeof(LeftType).Name}{typeof(RightType).Name}")
                .HasKey(jt => new { jt.LeftEntityId, jt.RightEntityId });

            modelBuilder.Entity<JoinTable<LeftType, RightType>>()
                .HasOne(jt => jt.LeftEntity)
                .WithMany()
                .HasForeignKey(jt => jt.LeftEntityId);

            modelBuilder.Entity<JoinTable<LeftType, RightType>>()
                .HasOne(jt => jt.RightEntity)
                .WithMany()
                .HasForeignKey(jt => jt.RightEntityId);
        }
    }
}
