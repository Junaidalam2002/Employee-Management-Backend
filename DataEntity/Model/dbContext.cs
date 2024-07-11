using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DataEntity.Model
{
    public partial class dbContext : DbContext
    {
        public dbContext()
        {
        }
        public dbContext(DbContextOptions<dbContext> options) : base(options) { }

        public virtual DbSet<tblEmployee> tblEmployee { get; set; } = null;
        public virtual DbSet<tblDepartment> tblDepartments { get; set; } = null;
        public virtual DbSet<tblDesignation> tblDesignation { get; set; } = null;
        public virtual DbSet<tblAccessGroupMaster> tblAccessGroupMaster { get; set; } = null;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(
                    "Server=LAPTOP-RK3BIHNG\\SQLEXPRESS;Initial Catalog=eBMR_DB;Integrated Security=True;Trust Server Certificate=True"
                    );
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<tblEmployee>(entity =>
            {
                entity.ToTable("tblEmployee");

                entity.Property(e => e.id)
                .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.name).HasColumnName("name");

                entity.Property(e => e.contact).HasColumnName("contact");

                entity.Property(e => e.email).HasColumnName("email");

                entity.Property(e => e.address).HasColumnName("address");

                entity.Property(e => e.departmentId).HasColumnName("departmentId");

                entity.Property(e => e.designationId).HasColumnName("designationId");

                entity.Property(e => e.groupId).HasColumnName("groupId");

                entity.Property(e => e.userId).HasColumnName("userId");

                entity.Property(e => e.password).HasColumnName("password");

                entity.Property(e => e.status).HasColumnName("status");

                entity.Property(e => e.isFirstTimeLogin).HasColumnName("isFirstTimeLogin");

                entity.Property(e => e.passExpDate).HasColumnType("datetime").HasColumnName("passExpDate");

                entity.Property(e => e.isPasswordExp).HasColumnName("isPasswordExp");

                entity.Property(e => e.isLock).HasColumnName("isLock");

                entity.Property(e => e.isLogged).HasColumnName("isLogged");

                entity.Property(e => e.isLoggedId).HasColumnName("isLoggedId");

                entity.Property(e => e.createdBy).HasColumnName("createdBy");

                entity.Property(e => e.createdDateTime).HasColumnType("datetime").HasColumnName("createdDateTime");

                entity.Property(e => e.siteId).HasColumnName("siteId");

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.tblEmployee)
                    .HasForeignKey(d => d.departmentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblEmployee_tblDepartment");

                entity.HasOne(d => d.Designation)
                    .WithMany(p => p.tblEmployee)
                    .HasForeignKey(d => d.designationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblEmployee_tblDesignation");

                entity.HasOne(d => d.AccessGroupMaster)
                    .WithMany(p => p.tblEmployee)
                    .HasForeignKey(d => d.groupId)
                    .HasConstraintName("FK_tblEmployee_tblAccessGroupMaster");
            });

            modelBuilder.Entity<tblDepartment>(entity =>
            {
                entity.ToTable("tblDepartment");

                entity.Property(e => e.id).ValueGeneratedNever();

                entity.Property(e => e.departmentName).HasColumnName("name");

                entity.Property(e => e.head).HasColumnName("head");

                entity.Property(e => e.status).HasColumnName("status");

                entity.Property(e => e.createdBy).HasColumnName("createdBy");

                entity.Property(e => e.createdDateTime)
                    .HasColumnType("datetime")
                    .HasColumnName("createdDateTime");

                entity.Property(e => e.siteId).HasColumnName("siteId");
            });

            modelBuilder.Entity<tblDesignation>(entity =>
            {
                entity.ToTable("tblDesignation");

                entity.Property(e => e.id).ValueGeneratedNever();

                entity.Property(e => e.designationName).HasColumnName("name");

                entity.Property(e => e.status).HasColumnName("status");

                entity.Property(e => e.createdBy).HasColumnName("createdBy");

                entity.Property(e => e.createdDateTime)
                    .HasColumnType("datetime")
                    .HasColumnName("createdDateTime");

                entity.Property(e => e.siteId).HasColumnName("siteId");
            });

            modelBuilder.Entity<tblAccessGroupMaster>(entity =>
            {
                entity.ToTable("tblAccessGroupMaster");

                entity.Property(e => e.id).ValueGeneratedNever();

                entity.Property(e => e.groupName).HasColumnName("name");

                entity.Property(e => e.description).HasColumnName("description");

                entity.Property(e => e.status).HasColumnName("status");

                entity.Property(e => e.createdBy).HasColumnName("createdBy");

                entity.Property(e => e.createdDateTime)
                    .HasColumnType("datetime")
                    .HasColumnName("createdDateTime");

                entity.Property(e => e.siteId).HasColumnName("siteId");
            });
            OnModelCreatingPartial(modelBuilder);
        }
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}