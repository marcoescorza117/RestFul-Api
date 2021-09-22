using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using SocialMedia.Core.Entities;

#nullable disable

namespace SocialMedia.Infrastructure.Data
{
    public partial class SocialMediaContext : DbContext
    {
        public SocialMediaContext()
        {
        }

        public SocialMediaContext(DbContextOptions<SocialMediaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Comment> Comments { get; set; }
        public virtual DbSet<Post> Posts { get; set; }
        public virtual DbSet<User> Users { get; set; }

        //elimando para uso de dependendencias
        /*protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=SocialMedia;Integrated Security = true");
            }
        }*/

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Comment>(entity =>

            {
                entity.ToTable("Comentario");
                entity.HasKey(e => e.CommentId);

                //entity.ToTable("Comment");

                entity.Property(e => e.CommentId)
                    .HasColumnName("IdComentario")
                    .ValueGeneratedNever();

                entity.Property(e => e.PostId)
                    .HasColumnName("IdPublicacion")
                    .ValueGeneratedNever();

                entity.Property(e => e.UserId)
                    .HasColumnName("IdUsuario")
                    .ValueGeneratedNever();
                
                
                entity.Property(e => e.IsActive)
                    .HasColumnName("Activo")
                    .ValueGeneratedNever();




                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("Descripcion")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Date)
                .HasColumnName("Fecha")
                .HasColumnType("datetime");

                entity.HasOne(d => d.Post)
                    .WithMany(p => p.Comments)
                    .HasForeignKey(d => d.PostId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Comentario_Publicacion");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Comments)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Comentario_Usuario");
            });

            modelBuilder.Entity<Post>(entity =>
            {
                entity.HasKey(e => e.PostId);

                entity.ToTable("Publicacion");

                entity.Property(e => e.PostId)
                    .HasColumnName("IdPublicacion")
                    .ValueGeneratedNever();


                entity.Property(e => e.UserId)
                    .HasColumnName("IdUsuario")
                    .ValueGeneratedNever();


                entity.Property(e => e.Description)
                    .HasColumnName("Descripcion")
                    .IsRequired()
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.Date)
                .HasColumnName("Fecha")
                .HasColumnType("datetime");

                entity.Property(e => e.Image)
                    .HasColumnName("Imagen")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Post)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Publicacion_Usuario");
            });

            modelBuilder.Entity<User>(entity =>
            {


                entity.ToTable("Usuario");
                entity.HasKey(e => e.UserId);

                

                entity.Property(e => e.UserId)
                .HasColumnName("IdUsuario");


                entity.Property(e => e.FirstName)
                    .HasColumnName("Nombres")
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);


                entity.Property(e => e.LastName)
                    .HasColumnName("Apellidos")
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.DateBirth)
                .HasColumnName("FechaNacimiento")
                .HasColumnType("date");

                

                entity.Property(e => e.Telephone)
                    .HasColumnName("Telefono")
                    .HasMaxLength(10)
                    .IsUnicode(false);


                entity.Property(e => e.IsActive)
                    .HasColumnName("Activo")
                    .ValueGeneratedNever();
            });

            //OnModelCreatingPartial(modelBuilder);
        }

        //partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
