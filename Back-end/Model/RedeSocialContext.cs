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

    public virtual DbSet<HasResponsibility> HasResponsibilities { get; set; }

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
            entity.HasKey(e => e.Id).HasName("PK__COMMENTS__3214EC27FDEBD3BA");

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
                .HasConstraintName("FK__COMMENTS__ID_POS__48CFD27E");

            entity.HasOne(d => d.IdUserNavigation).WithMany(p => p.Comments)
                .HasForeignKey(d => d.IdUser)
                .HasConstraintName("FK__COMMENTS__ID_USE__47DBAE45");
        });

        modelBuilder.Entity<Comunity>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__COMUNITY__3214EC274435F5F1");

            entity.ToTable("COMUNITY");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Creator)
                .HasMaxLength(11)
                .IsUnicode(false)
                .HasColumnName("CREATOR");
            entity.Property(e => e.Description)
                .HasMaxLength(2000)
                .IsUnicode(false)
                .HasColumnName("DESCRIPTION");
            entity.Property(e => e.Title)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("TITLE");

            entity.HasOne(d => d.CreatorNavigation).WithMany(p => p.Comunities)
                .HasForeignKey(d => d.Creator)
                .HasConstraintName("FK__COMUNITY__CREATO__3B75D760");
        });

        modelBuilder.Entity<HasResponsibility>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__HAS_RESP__3214EC27D608EE08");

            entity.ToTable("HAS_RESPONSIBILITY");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.IdComunity).HasColumnName("ID_COMUNITY");
            entity.Property(e => e.IdResponsibility).HasColumnName("ID_RESPONSIBILITY");
            entity.Property(e => e.IdUser)
                .HasMaxLength(11)
                .IsUnicode(false)
                .HasColumnName("ID_USER");

            entity.HasOne(d => d.IdComunityNavigation).WithMany(p => p.HasResponsibilities)
                .HasForeignKey(d => d.IdComunity)
                .HasConstraintName("FK__HAS_RESPO__ID_CO__4BAC3F29");

            entity.HasOne(d => d.IdResponsibilityNavigation).WithMany(p => p.HasResponsibilities)
                .HasForeignKey(d => d.IdResponsibility)
                .HasConstraintName("FK__HAS_RESPO__ID_RE__4D94879B");

            entity.HasOne(d => d.IdUserNavigation).WithMany(p => p.HasResponsibilities)
                .HasForeignKey(d => d.IdUser)
                .HasConstraintName("FK__HAS_RESPO__ID_US__4CA06362");
        });

        modelBuilder.Entity<Like>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__LIKES__3214EC27A3549B13");

            entity.ToTable("LIKES");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.IdPost).HasColumnName("ID_POST");
            entity.Property(e => e.IdUser)
                .HasMaxLength(11)
                .IsUnicode(false)
                .HasColumnName("ID_USER");

            entity.HasOne(d => d.IdPostNavigation).WithMany(p => p.Likes)
                .HasForeignKey(d => d.IdPost)
                .HasConstraintName("FK__LIKES__ID_POST__44FF419A");

            entity.HasOne(d => d.IdUserNavigation).WithMany(p => p.Likes)
                .HasForeignKey(d => d.IdUser)
                .HasConstraintName("FK__LIKES__ID_USER__440B1D61");
        });

        modelBuilder.Entity<Permission>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__PERMISSI__3214EC2760E890D6");

            entity.ToTable("PERMISSION");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Description)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("DESCRIPTION");
        });

        modelBuilder.Entity<Post>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__POSTS__3214EC2703F5A85C");

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
                .HasConstraintName("FK__POSTS__ID_COMUNI__403A8C7D");

            entity.HasOne(d => d.IdUserNavigation).WithMany(p => p.Posts)
                .HasForeignKey(d => d.IdUser)
                .HasConstraintName("FK__POSTS__ID_USER__412EB0B6");
        });

        modelBuilder.Entity<Responsibility>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__RESPONSI__3214EC27720FF3D1");

            entity.ToTable("RESPONSIBILITY");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("NAME");
        });

        modelBuilder.Entity<ResponsibilityPermission>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__RESPONSI__3214EC275F139B50");

            entity.ToTable("RESPONSIBILITY_PERMISSION");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.IdPermission).HasColumnName("ID_PERMISSION");
            entity.Property(e => e.IdResponsibility).HasColumnName("ID_RESPONSIBILITY");

            entity.HasOne(d => d.IdPermissionNavigation).WithMany(p => p.ResponsibilityPermissions)
                .HasForeignKey(d => d.IdPermission)
                .HasConstraintName("FK__RESPONSIB__ID_PE__534D60F1");

            entity.HasOne(d => d.IdResponsibilityNavigation).WithMany(p => p.ResponsibilityPermissions)
                .HasForeignKey(d => d.IdResponsibility)
                .HasConstraintName("FK__RESPONSIB__ID_RE__52593CB8");
        });

        modelBuilder.Entity<Usertable>(entity =>
        {
            entity.HasKey(e => e.Cpf).HasName("PK__USERTABL__C1F8973004F1AA40");

            entity.ToTable("USERTABLE");

            entity.HasIndex(e => e.Email, "UQ__USERTABL__161CF72487C2B0AC").IsUnique();

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
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("EMAIL");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("NAME");
            entity.Property(e => e.Password)
                .HasMaxLength(120)
                .IsUnicode(false)
                .HasColumnName("PASSWORD");
            entity.Property(e => e.Salt)
                .HasMaxLength(120)
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
