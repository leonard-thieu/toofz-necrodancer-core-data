using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using toofz.NecroDancer.Data;

namespace toofz.Data
{
    internal sealed class ItemConfiguration : IEntityTypeConfiguration<Item>
    {
        public void Configure(EntityTypeBuilder<Item> builder)
        {
            builder.HasKey(i => i.Name);

            builder.Property(i => i.DisplayName)
                   .IsRequired();

            builder.Ignore(i => i.ChestChance);
            builder.Ignore(i => i.Flyaway);
            builder.Ignore(i => i.FrameCount);
            builder.Ignore(i => i.HideQuantity);
            builder.Ignore(i => i.Hint);
            builder.Ignore(i => i.LevelEditor);
            builder.Ignore(i => i.LockedChestChance);
            builder.Ignore(i => i.LockedShopChance);
            builder.Ignore(i => i.OffsetY);
            builder.Ignore(i => i.QuantityOffsetY);
            builder.Ignore(i => i.ScreenFlash);
            builder.Ignore(i => i.ScreenShake);
            builder.Ignore(i => i.ShopChance);
            builder.Ignore(i => i.SlotPriority);
            builder.Ignore(i => i.Sound);
            builder.Ignore(i => i.Spell);
            builder.Ignore(i => i.Unlocked);
            builder.Ignore(i => i.UrnChance);
        }
    }
}
