using Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Configuration;

public partial class EfCoreContext
{
    public class PokemonStatsConfiguration : IEntityTypeConfiguration<PokemonStats>
    {
        public void Configure(EntityTypeBuilder<PokemonStats> builder)
        {
            builder.ToTable("PokemonStats");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Experience);
            builder.Property(x => x.Height);
            builder.Property(x => x.Weight);
            builder.Property(x => x.Description);
        }
    }
}