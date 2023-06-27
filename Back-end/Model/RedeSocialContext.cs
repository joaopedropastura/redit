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

    public virtual DbSet<Comment> Comments { get; set; }

    public virtual DbSet<Comunity> Comunities { get; set; }

    public virtual DbSet<Like> Likes { get; set; }

    public virtual DbSet<Permission> Permissions { get; set; }

    public virtual DbSet<Post> Posts { get; set; }

    public virtual DbSet<Responsibility> Responsibilities { get; set; }

    public virtual DbSet<ResponsibilityPermission> ResponsibilityPermissions { get; set; }

    public virtual DbSet<Usertable> Usertables { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=CT-C-00188\\SQLEXPRESS;Initial Catalog=redeSocial;Integrated Security=True;TrustServerCertificate=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Comment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__COMMENTS__3214EC27AFCC330D");

            entity.ToTable("COMMENTS");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CommentData)
                .HasMaxLength(300)
                .IsUnicode(false)
                .HasColumnName("COMMENT_DATA");
            entity.Property(e => e.IdPost).HasColumnName("ID_POST");
            entity.Property(e => e.IdUser)
                .HasMaxLength(11)
                .IsUnicode(false)
                .HasColumnName("ID_USER");

            entity.HasOne(d => d.IdPostNavigation).WithMany(p => p.Comments)
                .HasForeignKey(d => d.IdPost)
                .HasConstraintName("FK__COMMENTS__ID_POS__71D1E811");

            entity.HasOne(d => d.IdUserNavigation).WithMany(p => p.Comments)
                .HasForeignKey(d => d.IdUser)
                .HasConstraintName("FK__COMMENTS__ID_USE__70DDC3D8");
        });

        modelBuilder.Entity<Comunity>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__COMUNITY__3214EC273AEEFD02");

            entity.ToTable("COMUNITY");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("NAME");
        });

        modelBuilder.Entity<Like>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__LIKES__3214EC2766E73682");

            entity.ToTable("LIKES");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.IdPost).HasColumnName("ID_POST");
            entity.Property(e => e.IdUser)
                .HasMaxLength(11)
                .IsUnicode(false)
                .HasColumnName("ID_USER");

            entity.HasOne(d => d.IdPostNavigation).WithMany(p => p.Likes)
                .HasForeignKey(d => d.IdPost)
                .HasConstraintName("FK__LIKES__ID_POST__6E01572D");

            entity.HasOne(d => d.IdUserNavigation).WithMany(p => p.Likes)
                .HasForeignKey(d => d.IdUser)
                .HasConstraintName("FK__LIKES__ID_USER__6D0D32F4");
        });

        modelBuilder.Entity<Permission>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__PERMISSI__3214EC2773ED2412");

            entity.ToTable("PERMISSION");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Description)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("DESCRIPTION");
        });

        modelBuilder.Entity<Post>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__POSTS__3214EC276E8D1B84");

            entity.ToTable("POSTS");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.DatePublish)
                .HasColumnType("date")
                .HasColumnName("DATE_PUBLISH");
            entity.Property(e => e.IdComunity).HasColumnName("ID_COMUNITY");
            entity.Property(e => e.IdUser)
                .HasMaxLength(11)
                .IsUnicode(false)
                .HasColumnName("ID_USER");
            entity.Property(e => e.PostData)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("POST_DATA");
            entity.Property(e => e.Title)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("TITLE");

            entity.HasOne(d => d.IdComunityNavigation).WithMany(p => p.Posts)
                .HasForeignKey(d => d.IdComunity)
                .HasConstraintName("FK__POSTS__ID_COMUNI__693CA210");

            entity.HasOne(d => d.IdUserNavigation).WithMany(p => p.Posts)
                .HasForeignKey(d => d.IdUser)
                .HasConstraintName("FK__POSTS__ID_USER__6A30C649");
        });

        modelBuilder.Entity<Responsibility>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__RESPONSI__3214EC27BE1F75AE");

            entity.ToTable("RESPONSIBILITY");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("NAME");
        });

        modelBuilder.Entity<ResponsibilityPermission>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__RESPONSI__3214EC275BB80A14");

            entity.ToTable("RESPONSIBILITY_PERMISSION");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.IdPermission).HasColumnName("ID_PERMISSION");
            entity.Property(e => e.IdResponsibility).HasColumnName("ID_RESPONSIBILITY");

            entity.HasOne(d => d.IdPermissionNavigation).WithMany(p => p.ResponsibilityPermissions)
                .HasForeignKey(d => d.IdPermission)
                .HasConstraintName("FK__RESPONSIB__ID_PE__66603565");

            entity.HasOne(d => d.IdResponsibilityNavigation).WithMany(p => p.ResponsibilityPermissions)
                .HasForeignKey(d => d.IdResponsibility)
                .HasConstraintName("FK__RESPONSIB__ID_RE__656C112C");
        });

        modelBuilder.Entity<Usertable>(entity =>
        {
            entity.HasKey(e => e.Cpf).HasName("PK__USERTABL__C1F8973047A822D9");

            entity.ToTable("USERTABLE");

            entity.Property(e => e.Cpf)
                .HasMaxLength(11)
                .IsUnicode(false)
                .HasColumnName("CPF");
            entity.Property(e => e.Assigndate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("date")
                .HasColumnName("ASSIGNDATE");
            entity.Property(e => e.Borndate)
                .HasColumnType("date")
                .HasColumnName("BORNDATE");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("NAME");
            entity.Property(e => e.Password)
                .HasMaxLength(36)
                .IsUnicode(false)
                .HasColumnName("PASSWORD");
            entity.Property(e => e.Salt)
                .HasMaxLength(12)
                .IsUnicode(false)
                .HasColumnName("SALT");
            entity.Property(e => e.Username)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("USERNAME");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
