using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace toofz.Data
{
    internal sealed class RunConfiguration : IEntityTypeConfiguration<Run>
    {
        public void Configure(EntityTypeBuilder<Run> builder)
        {
            builder.HasKey(c => c.RunId);
            builder.Property(c => c.RunId)
                   .ValueGeneratedNever();

            builder.Property(c => c.Name)
                   .IsRequired()
                   .HasMaxLength(32);
            builder.HasIndex(c => c.Name)
                   .IsUnique();
            builder.Property(c => c.DisplayName)
                   .IsRequired();
        }
    }
}
