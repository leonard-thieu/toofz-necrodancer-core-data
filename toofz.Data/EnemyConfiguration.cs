using System.Data.Entity.ModelConfiguration;
using toofz.NecroDancer.Data;

namespace toofz.Data
{
    internal sealed class EnemyConfiguration : EntityTypeConfiguration<Enemy>
    {
        public EnemyConfiguration()
        {
            this.HasKey(e => new { e.Name, e.Type });
            this.Property(e => e.Name)
                .HasColumnOrder(0);
            this.Property(e => e.Type)
                .HasColumnOrder(1);

            this.Property(e => e.DisplayName)
                .IsRequired();

            this.Ignore(e => e.LevelEditor);
            this.Ignore(e => e.SpriteSheet);
            this.Ignore(e => e.Frames);
            this.Ignore(e => e.Shadow);
            this.Ignore(e => e.Bouncer);
            this.Ignore(e => e.Tweens);
            this.Ignore(e => e.Particle);
        }
    }
}
