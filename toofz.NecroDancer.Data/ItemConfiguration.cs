using System.Data.Entity.ModelConfiguration;
using toofz.NecroDancer.Data;

namespace toofz.NecroDancer
{
    internal sealed class ItemConfiguration : EntityTypeConfiguration<Item>
    {
        public ItemConfiguration()
        {
            this.HasKey(i => i.Name);

            this.Property(i => i.DisplayName)
                .IsRequired();

            this.Ignore(i => i.ChestChance);
            this.Ignore(i => i.Flyaway);
            this.Ignore(i => i.FrameCount);
            this.Ignore(i => i.HideQuantity);
            this.Ignore(i => i.Hint);
            this.Ignore(i => i.LevelEditor);
            this.Ignore(i => i.LockedChestChance);
            this.Ignore(i => i.LockedShopChance);
            this.Ignore(i => i.OffsetY);
            this.Ignore(i => i.QuantityOffsetY);
            this.Ignore(i => i.ScreenFlash);
            this.Ignore(i => i.ScreenShake);
            this.Ignore(i => i.ShopChance);
            this.Ignore(i => i.SlotPriority);
            this.Ignore(i => i.Sound);
            this.Ignore(i => i.Spell);
            this.Ignore(i => i.Unlocked);
            this.Ignore(i => i.UrnChance);
        }
    }
}
