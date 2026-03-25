using MemeCardGame.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace MemeCardGame.Infrastructure.Persistence.Configurations
{
    public class CardConfiguration : IEntityTypeConfiguration<Card>
    {
        public void Configure(EntityTypeBuilder<Card> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(x => x.MemeDescription)
                .IsRequired()
                .HasMaxLength(500);

            builder.Property(x => x.FollowersCost)
                .IsRequired();

            builder.Property(x => x.Type)
                .IsRequired();

            builder.Property(x => x.Defense)
                .IsRequired();

            builder.Property(x => x.Attack)
                .IsRequired();

            builder.Property(x => x.ImageUrl)
                .IsRequired()
                .HasMaxLength(600);

            builder.Property(x => x.Rarity)
                .IsRequired();

            builder.Property(x => x.Effect)
                .IsRequired();

            builder.Property(x => x.MemePhrase)
                .IsRequired()
                .HasMaxLength(300);

        }
    }
}
