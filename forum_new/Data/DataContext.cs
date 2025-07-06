using forum_new.Entities;
using Microsoft.EntityFrameworkCore;

namespace forum_new.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)

        {

            optionsBuilder.UseNpgsql("User ID=postgres;Password=M522ot988;Server=localhost;Port=5432;Database=forum;Pooling=true;");

        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)

        {

            modelBuilder.Entity<User>(entity =>
            {

                entity.ToTable("User");
                entity.HasKey(p => p.Id).HasName("PK_User");

                entity.Property(p => p.Id)
                    .HasColumnName("id")
                    .HasColumnType("int")
                    .UseIdentityAlwaysColumn();

                entity.Property(p => p.Username)

                .HasColumnName("username");

            });

            modelBuilder.Entity<Post>(entity =>
            {

                entity.ToTable("Post");
                entity.HasKey(p => p.Id).HasName("PK_Post");

                entity.Property(p => p.Id)
                    .HasColumnName("id")
                    .HasColumnType("int")
                    .UseIdentityAlwaysColumn();

                entity.Property(p => p.Title)

                .HasColumnName("title");

            });

            modelBuilder.Entity<Comment>(entity =>
            {

                entity.ToTable("Comment");
                entity.HasKey(p => p.Id).HasName("PK_Comment");

                entity.Property(p => p.Id)
                    .HasColumnName("id")
                    .HasColumnType("int")
                    .UseIdentityAlwaysColumn();

                entity.Property(p => p.Content)

                .HasColumnName("content");

            });

        }
    }
}
