using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using toofz.NecroDancer.Data;

namespace toofz.Data
{
    internal sealed class EnemyConfiguration : IEntityTypeConfiguration<Enemy>
    {
        public void Configure(EntityTypeBuilder<Enemy> builder)
        {
            builder.HasKey(e => new { e.Name, e.Type });

            builder.Property(e => e.DisplayName)
                   .IsRequired();

            builder.OwnsOne(e => e.OptionalStats);
            builder.OwnsOne(e => e.Stats)
                   .Ignore(s => s.Priority);

            builder.Ignore(e => e.LevelEditor);
            builder.Ignore(e => e.SpriteSheet);
            builder.Ignore(e => e.Frames);
            builder.Ignore(e => e.Shadow);
            builder.Ignore(e => e.Bouncer);
            builder.Ignore(e => e.Tweens);
            builder.Ignore(e => e.Particle);
        }
    }
}
