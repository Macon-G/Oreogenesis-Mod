using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Oreogenesis.Content.Items.Materials
{
    public class CopperCrystalShard : ModItem
    {
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
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(this, 4)
                .AddTile(ModContent.TileType<Tiles.Crafting.CrystalAssemblerTile>())
                .Register();
        }
    }
}