using System;
using Microsoft.EntityFrameworkCore;
using VetryCuts.Models;

namespace VetryCuts.Data
{
    public class VetriCutsDbContext : DbContext
    {
        public VetriCutsDbContext(DbContextOptions<VetriCutsDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<BarberService> BarberServices { get; set; }
        public DbSet<Appointment> Appointments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>()
                .Property(u => u.Role)
                .IsRequired();

            modelBuilder.Entity<Service>()
                .Property(s => s.Name)
                .IsRequired()
                .HasMaxLength(100);

            modelBuilder.Entity<Service>()
                .Property(s => s.Price)
                .HasColumnType("decimal(10,2)");

            modelBuilder.Entity<BarberService>()
                .HasKey(bs => bs.Id);

            modelBuilder.Entity<BarberService>()
                .HasOne(bs => bs.Barber)
                .WithMany(b => b.AssignedServices)
                .HasForeignKey(bs => bs.BarberId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<BarberService>()
                .HasOne(bs => bs.Service)
                .WithMany(s => s.Barbers)
                .HasForeignKey(bs => bs.ServiceId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<BarberService>()
                .HasIndex(bs => new { bs.BarberId, bs.ServiceId })
                .IsUnique();

            modelBuilder.Entity<Appointment>()
                .HasKey(a => a.Id);

            modelBuilder.Entity<Appointment>()
                .HasOne(a => a.Customer)
                .WithMany(c => c.Appointments)
                .HasForeignKey(a => a.CustomerId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Appointment>()
                .HasOne(a => a.Barber)
                .WithMany()
                .HasForeignKey(a => a.BarberId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Appointment>()
                .HasOne(a => a.Service)
                .WithMany()
                .HasForeignKey(a => a.ServiceId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Appointment>()
                .HasIndex(a => new { a.BarberId, a.Date, a.Time })
                .IsUnique();
        }

    }
}
