using Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Configuration;

public partial class EfCoreContext
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("Order");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Email);
            builder.Property(x => x.CardDetails);
            builder.Property(x => x.SocialSecurity);
            builder.Property(x => x.OrderDate);

            builder.HasOne(x => x.CustomerInformation)
                .WithOne(x => x.Order)
                .HasForeignKey<CustomerInformation>(x => x.OrderId)
                .IsRequired();

            builder
                .HasMany<Pokemon>(x => x.Pokemon);
        }
    }
}