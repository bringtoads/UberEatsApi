﻿using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using UberEats.Domain.User;
using UberEats.Domain.User.ValueObjects;

namespace UberEats.Infrastructure.Persistence.Configurations
{
    public sealed class UserConfigurations : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            ConfigureUsersTable(builder);
        }

        private void ConfigureUsersTable(EntityTypeBuilder<User> builder)
        {
            builder
                .ToTable("Users");

            builder
                .HasKey(u => u.Id);

            builder
                .Property(u => u.Id)
                .ValueGeneratedNever()
                .HasConversion(
                    id => id.Value,
                    value => UserId.Create(value));

            builder
                .Property(u => u.FirstName)
                .HasMaxLength(50);

            builder
                .Property(u => u.LastName)
                .HasMaxLength(50);

            builder
                .Property(u => u.Email)
                .HasMaxLength(150);

            builder
                .Property(u => u.Password);
        }
    }

}
