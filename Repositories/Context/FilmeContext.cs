﻿using Microsoft.EntityFrameworkCore;
using Models.Tables;

namespace Repositories.Context
{
    public class FilmeContext : DbContext
    {

        public DbSet<Filme> Filme { get; set; }

        public FilmeContext(DbContextOptions<FilmeContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Ator>().Property(ator => ator.Papel).HasConversion<string>();
        }

    }
}