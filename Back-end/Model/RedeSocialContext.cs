using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Back_end.Model;

public partial class RedeSocialContext : DbContext
{
    public RedeSocialContext()
    {
    }

    public RedeSocialContext(DbContextOptions<RedeSocialContext> options)
        : base(options)
    {
    }

    public virtual DbSet<UserTable> UserTables { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=CT-C-00188\\SQLEXPRESS;Initial Catalog=redeSocial;Integrated Security=True;TrustServerCertificate=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<UserTable>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__UserTabl__3213E83FCC72C119");

            entity.ToTable("UserTable");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AssignDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("date");
            entity.Property(e => e.BornDate).HasColumnType("date");
            entity.Property(e => e.Cpf)
                .HasMaxLength(11)
                .IsUnicode(false)
                .HasColumnName("cpf");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Password)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("password");
            entity.Property(e => e.UserName)
                .HasMaxLength(25)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
