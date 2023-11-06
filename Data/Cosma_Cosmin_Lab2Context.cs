using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Cosma_Cosmin_Lab2.Models;

namespace Cosma_Cosmin_Lab2.Data
{
    public class Cosma_Cosmin_Lab2Context : DbContext
    {
        public Cosma_Cosmin_Lab2Context (DbContextOptions<Cosma_Cosmin_Lab2Context> options)
            : base(options)
        {
        }

        public DbSet<Cosma_Cosmin_Lab2.Models.Book> Book { get; set; } = default!;

        public DbSet<Cosma_Cosmin_Lab2.Models.Publisher>? Publisher { get; set; }

        public DbSet<Cosma_Cosmin_Lab2.Models.Author>? Author { get; set; }

        public DbSet<Cosma_Cosmin_Lab2.Models.Category>? Category { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>()
                .HasOne(e => e.Borrowing)
            .WithOne(e => e.Book)
                .HasForeignKey<Borrowing>("BookID");
        }

        public DbSet<Cosma_Cosmin_Lab2.Models.Member>? Member { get; set; }

        public DbSet<Cosma_Cosmin_Lab2.Models.Borrowing>? Borrowing { get; set; }
    }
}
