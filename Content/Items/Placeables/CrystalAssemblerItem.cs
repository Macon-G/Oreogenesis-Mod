using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Oreogenesis.Content.Tiles.Crafting;

namespace Oreogenesis.Content.Items.Placeables
{
    public class CrystalAssemblerItem : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 28;
            Item.height = 18;
            Item.maxStack = 9999;
            Item.useTurn = true;
            Item.autoReuse = true;
            Item.useAnimation = 15;
            Item.useTime = 10;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.consumable = true;
            Item.createTile = ModContent.TileType<CrystalAssemblerTile>();
            Item.rare = ItemRarityID.Blue;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.StoneBlock, 25)
                .AddIngredient(ItemID.Glass, 8)
                .AddTile(TileID.Anvils)
                .Register();
        }
    }
}