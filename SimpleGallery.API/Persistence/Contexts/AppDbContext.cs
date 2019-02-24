using Microsoft.EntityFrameworkCore;
using SimpleGallery.API.Domain.Models;
using System;

namespace SimpleGallery.API.Persistence.Contexts
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Album> Albums { get; set; }
        public DbSet<Photo> Photos { get; set; }
        public DbSet<Image> Images { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Album>().ToTable("Albums");
            builder.Entity<Album>().HasKey(p => p.Id);
            builder.Entity<Album>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Album>().Property(p => p.Name).HasMaxLength(30);
            builder.Entity<Album>().Property(p => p.Description).HasMaxLength(50);
            builder.Entity<Album>().HasMany(p => p.Photos).WithOne(p => p.Album).HasForeignKey(p => p.AlbumId);

            builder.Entity<Album>().HasData
            (
                new Album
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Album 1",
                    Description = "Desc 1",
                    NumberOfVisitor = 1
                },

                new Album
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Album 2",
                    NumberOfVisitor = 2
                }
            );

            builder.Entity<Photo>().ToTable("Photos");
            builder.Entity<Photo>().HasKey(p => p.Id);
            builder.Entity<Photo>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Photo>().HasOne(p => p.Image).WithOne(p => p.Photo).HasForeignKey<Image>(p => p.PhotoId);

            builder.Entity<Image>().ToTable("Images");
            builder.Entity<Image>().HasKey(p => p.Id);
            builder.Entity<Image>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        }
    }
}