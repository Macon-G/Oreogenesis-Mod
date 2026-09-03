using Microsoft.Xna.Framework;
using Oreogenesis.Content.Tiles.Geodes;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Oreogenesis.Content.Items.Placeables.Geodes
{
    public abstract class BaseGeodeBlockItem : ModItem
    {
        public override string Texture => $"Oreogenesis/Assets/Template/GeodeBlockItem";
        
        public abstract Color ItemColor { get; }
        public abstract int BaseItemID { get; }
        public abstract int GeodeTileID { get; }


        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 1;
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
            Item.createTile = Geode;
            Item.rare = ItemRarityID.White;
            Item.value = Item.buyPrice(copper: 1);
            Item.color = ItemColor;
        }

        public override void AddRecipes()
        {
            CreateRecipe(10)
                .AddIngredient(BaseItemID, 10)
                .AddIngredient(ItemID.ManaCrystal)
                .AddTile(TileID.Bottles)
                .Register();
        }
    }
}
