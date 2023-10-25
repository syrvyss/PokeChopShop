using Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Configuration;

public partial class EfCoreContext
{
    public class PokemonConfiguration : IEntityTypeConfiguration<Pokemon>
    {
        public void Configure(EntityTypeBuilder<Pokemon> builder)
        {
            builder.ToTable("Pokemon");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name);
            builder.Property(x => x.Url);

            builder
                .HasOne(x => x.PokemonStats)
                .WithOne(x => x.Pokemon)
                .HasForeignKey<PokemonStats>(x => x.PokemonId)
                .IsRequired();
        }
    }
}