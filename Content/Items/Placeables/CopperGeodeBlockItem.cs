using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Oreogenesis.Content.Tiles.Geodes;

namespace Oreogenesis.Content.Items.Placeables
{
    public class CopperGeodeBlockItem : ModItem
    {
        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 100;
        }

        public override void SetDefaults()
        {
            Item.width = 12;
            Item.height = 12;
            Item.maxStack = 9999;
            Item.useTurn = true;
            Item.autoReuse = true;
            Item.useAnimation = 15;
            Item.useTime = 10;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.consumable = true;
            Item.createTile = ModContent.TileType<CopperGeodeBlock>();
            Item.rare = ItemRarityID.White;
            Item.value = Item.buyPrice(copper: 1);
        }

        public override void AddRecipes()
        {
            CreateRecipe(10)
                .AddIngredient(ItemID.StoneBlock, 10)
                .AddIngredient(ItemID.CopperOre, 2)
                .AddTile(TileID.WorkBenches)
                .Register();
        }
    }
}