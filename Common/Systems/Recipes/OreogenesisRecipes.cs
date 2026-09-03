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
            Recipe.Create(ItemID.TinBar)
                .AddIngredient<TinCrystalShard>(4)
                .AddTile<CrystalAssemblerTile>()
                .Register();
            Recipe.Create(ItemID.IronBar)
                .AddIngredient<IronCrystalShard>(4)
                .AddTile<CrystalAssemblerTile>()
                .Register();
            Recipe.Create(ItemID.LeadBar)
                .AddIngredient<LeadCrystalShard>(4)
                .AddTile<CrystalAssemblerTile>()
                .Register();
            Recipe.Create(ItemID.SilverBar)
                .AddIngredient<SilverCrystalShard>(4)
                .AddTile<CrystalAssemblerTile>()
                .Register();
            Recipe.Create(ItemID.TungstenBar)
                .AddIngredient<TungstenCrystalShard>(4)
                .AddTile<CrystalAssemblerTile>()
                .Register();
            Recipe.Create(ItemID.GoldBar)
                .AddIngredient<GoldCrystalShard>(4)
                .AddTile<CrystalAssemblerTile>()
                .Register();
            Recipe.Create(ItemID.PlatinumBar)
                .AddIngredient<PlatinumCrystalShard>(4)
                .AddTile<CrystalAssemblerTile>()
                .Register();
        }
    }
}