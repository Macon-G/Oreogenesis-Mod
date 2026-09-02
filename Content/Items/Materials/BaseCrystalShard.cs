using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Oreogenesis.Content.Items.Materials
{
    public abstract class BaseCrystalShard : ModItem
    {
        public override string Texture => $"Oreogenesis/Assets/Template/CrystalShard";
        
        public abstract Color CrystalColor { get; }
        
        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 25;
        }

        public override void SetDefaults()
        {
            Item.width = 20;
            Item.height = 20;
            Item.maxStack = 9999;
            Item.value = Item.buyPrice(copper: 2);
            Item.rare = ItemRarityID.White;
            Item.color = CrystalColor;
        }
    }
}
