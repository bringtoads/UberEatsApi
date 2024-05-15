using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UberEats.Domain.Bill;
using UberEats.Domain.Bill.ValueObjects;
using UberEats.Domain.Dinner.ValueObjects;
using UberEats.Domain.Guest.ValuObjects;
using UberEats.Domain.Host.ValueObjects;

namespace UberEats.Infrastructure.Persistence.Configurations
{
    public class BillConfiguration : IEntityTypeConfiguration<Bill>
    {
        public void Configure(EntityTypeBuilder<Bill> builder)
        {
            ConfigureBillsTable(builder);
        }

        private void ConfigureBillsTable(EntityTypeBuilder<Bill> builder)
        {
            builder
             .ToTable("Bills");

            builder
                .HasKey(b => b.Id);

            builder
                .Property(b => b.Id)
                .ValueGeneratedNever()
                .HasConversion(
                    id => id.Value,
                    value => BillId.Create(value));

            builder
                .OwnsOne(b => b.Price);

            builder
                .Property(b => b.DinnerId)
                .HasConversion(
                    id => id.Value,
                    value => DinnerId.Create(value));

            builder
                .Property(b => b.GuestId)
                .HasConversion(
                    id => id.Value,
                    value => GuestId.Create(value));

            builder
                .Property(b => b.HostId)
                .HasConversion(
                    id => id.Value,
                    value => HostId.Create(value));
        }
    }
}
