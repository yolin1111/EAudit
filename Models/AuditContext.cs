﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace EAudit.Models
{
    public partial class AuditContext : DbContext
    {
        public AuditContext()
        {
        }

        public AuditContext(DbContextOptions<AuditContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AuditHeaderAll> AuditHeaderAlls { get; set; }
        public virtual DbSet<AuditLineAll> AuditLineAlls { get; set; }

        // public virtual DbSet<AuditPenalty> AuditPenaltys { get; set; }
        // public virtual DbSet<AuditSource> AuditSources { get; set; }
        // public virtual DbSet<AuditViolation> AuditViolations { get; set; }
        public virtual DbSet<Org> Orgs { get; set; }
        public virtual DbSet<DropDownData.AuditPenalty> AuditPenaltys { get; set; }
        public virtual DbSet<DropDownData.AuditSource> AuditSources { get; set; }
        public virtual DbSet<DropDownData.AuditViolation> AuditViolations { get; set; }
        public virtual DbSet<AuditAttchment> AuditAttchments { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AuditLineAll>(entity =>
            {
                entity.HasOne(d => d.Header)
                    .WithMany(p => p.AuditLineAlls)
                    .HasForeignKey(d => d.HeaderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AuditLineAlls_AuditHeaderAlls_AuditHeaderAllsHeaderId");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}