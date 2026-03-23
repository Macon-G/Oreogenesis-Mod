using Terraria.ID;
using Terraria.ModLoader;
using Oreogenesis.Content.Items.Materials;
using Oreogenesis.Content.Tiles.Crafting;
using Terraria;

namespace Oreogenesis.Common.Systems.Recipes
{
    internal class OreogenesisRecipes : ModSystem
    {
        public override void AddRecipes()
        {
            Recipe.Create(ItemID.CopperBar)
                .AddIngredient<CopperCrystalShard>(4)
                .AddTile<CrystalAssemblerTile>()
                .Register();
        }
    }
}