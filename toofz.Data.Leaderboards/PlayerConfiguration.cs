using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace toofz.Data
{
    internal sealed class PlayerConfiguration : IEntityTypeConfiguration<Player>
    {
        public void Configure(EntityTypeBuilder<Player> builder)
        {
            builder.HasKey(p => p.SteamId);
            builder.Property(p => p.SteamId)
                   .ValueGeneratedNever();

            builder.Property(p => p.Name)
                   .HasMaxLength(64);
            builder.HasIndex(p => p.Name);
        }
    }
}
