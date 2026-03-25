using MemeCardGame.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace MemeCardGame.Infrastructure.Persistence.Configurations
{
    public class MatchConfiguration : IEntityTypeConfiguration<Match>
    {
        public void Configure(EntityTypeBuilder<Match> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.PlayerOne)
                .WithMany()
                .HasForeignKey(x => x.PlayerOneId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.PlayerTwo)
                .WithMany()
                .HasForeignKey(x => x.PlayerTwoId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Property(x => x.PlayerOneHp)
                .IsRequired();

            builder.Property(x => x.PlayerTwoHp)
                .IsRequired();

            builder.Property(x => x.TotalTurns)
                .IsRequired();

            builder.Property(x => x.StartedAt)
                .IsRequired();

             builder.Property(x => x.FinishedAt)
                .IsRequired();

            builder.Property(x => x.Winner)
                .IsRequired();
        }
    }
}
