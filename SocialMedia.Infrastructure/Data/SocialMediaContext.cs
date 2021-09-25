using System;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using SocialMedia.Core.Entities;
using SocialMedia.Infrastructure.Data.Configurations;

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

            //modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");
            //Hace referencia a la configuracion de User
            //modelBuilder.ApplyConfiguration(new UserConfiguration());

            //Hace referencia a la configuracion de Comment
            //modelBuilder.ApplyConfiguration(new CommentConfiguration());

            //Hace referencia a la configuracion de Post
            //modelBuilder.ApplyConfiguration(new PostConfiguration());




            //esta podria ser otra manera
            //modelBuilder.ApplyConfigurationsFromAssembly(typeof(SocialMediaContext).Assembly);



            //OnModelCreatingPartial(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        //partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
