using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dong.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Dong.Infrastructure.dbContext
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<GetTogether> GetTogethers { get; set; }
        public DbSet<Expense> Expenses { get; set; }
        public DbSet<Participation> Participations { get; set; }
        public DbSet<Share> Shares { get; set; }
        public DbSet<Settlement> Settlements { get; set; }
        public DbSet<Payment> Payments { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=194.5.195.53,31433; Initial Catalog=Hosein;User ID=hosein;Password=hosein12345678@;Connection Timeout=300000;MultipleActiveResultSets=True;Encrypt=False");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // ===== Schema + Table Name =====

            modelBuilder.Entity<User>()
                .ToTable("Users", schema: "auth");

            modelBuilder.Entity<GetTogether>()
                .ToTable("GetTogethers", schema: "event");

            modelBuilder.Entity<Expense>()
                .ToTable("Expenses", schema: "finance");

            modelBuilder.Entity<Participation>()
                .ToTable("Participations", schema: "event");
            modelBuilder.Entity<Settlement>()
                .ToTable("Settlements", schema: "finance");

            modelBuilder.Entity<Share>()
                .ToTable("Shares", schema: "finance");


            modelBuilder.Entity<Payment>()
                .ToTable("Payment", schema: "finance");

            // Participation Composite Key
            modelBuilder.Entity<Participation>()
                .HasKey(p => new { p.UserId, p.GetTogetherId });

            // Relations with proper DeleteBehavior
            modelBuilder.Entity<Participation>()
                .HasOne(p => p.User)
                .WithMany(u => u.participations)
                .HasForeignKey(p => p.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Participation>()
                .HasOne(p => p.GetTogether)
                .WithMany(g => g.Participations)
                .HasForeignKey(p => p.GetTogetherId)
                .OnDelete(DeleteBehavior.Cascade);
            // Expense → GetTogether
            modelBuilder.Entity<Expense>()
                .HasOne(e => e.GetTogether)
                .WithMany(g => g.Expenses)
                .HasForeignKey(e => e.GetTogetherId)
                .OnDelete(DeleteBehavior.Restrict);

            // Expense → User
            modelBuilder.Entity<Expense>()
                .HasOne(e => e.User)
                .WithMany()
                .HasForeignKey(e => e.UserId)
                .OnDelete(DeleteBehavior.Restrict);
            // Share → User
            modelBuilder.Entity<Share>()
                .HasOne(s => s.User)
                .WithMany()
                .HasForeignKey(s => s.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            // Share → GetTogether
            modelBuilder.Entity<Share>()
                .HasOne(s => s.GetTogether)
                .WithMany(g => g.Shares)
                .HasForeignKey(s => s.GetTogetherId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Settlement>()
                .HasOne(s => s.Users)
                .WithMany()
                .HasForeignKey(s => s.FromUserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Payment>()
                .HasOne(p => p.Users)
                .WithMany()
                .HasForeignKey(p => p.FromUserId)
                .OnDelete(DeleteBehavior.Restrict);


            base.OnModelCreating(modelBuilder);
        }

    }
}