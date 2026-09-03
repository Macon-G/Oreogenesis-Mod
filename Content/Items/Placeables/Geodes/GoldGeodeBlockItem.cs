using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Oreogenesis.Content.Tiles.Geodes;

namespace Oreogenesis.Content.Items.Placeables.Geodes
{
    public class CopperGeodeBlockItem : ModItem
    {
        public override Color ItemColor => new Color(185, 164, 23);
        public override int BaseItemID => ItemID.GoldOre;
        public override int GeodeTileID => ModContent.TileType<GoldGeodeBlock>();
    }
}