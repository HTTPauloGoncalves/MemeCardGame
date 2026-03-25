using MemeCardGame.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace MemeCardGame.Infrastructure.Persistence
{
    public class MemeCardGameDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Card> Cards { get; set; }
        public DbSet<Match> Matchs { get; set; }

        public MemeCardGameDbContext(DbContextOptions<MemeCardGameDbContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(
                typeof(MemeCardGameDbContext).Assembly
            );
        }
    }
}
