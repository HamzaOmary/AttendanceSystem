using AttendanceSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceSystem.Domain
{
    public class AppDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(Connections.sqlConnStr);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .Property(s => s.UserId)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<User>()
               .Property(s => s.FullName)
               .HasMaxLength(100)
               .IsRequired();




            modelBuilder.Entity<User>()
                .HasOne(s => s.Collage)
                .WithMany()
                .HasForeignKey(s => s.CollageId);
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Collage> Collages { get; set; }

    }
}
