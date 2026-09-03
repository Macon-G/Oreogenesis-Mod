using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Oreogenesis.Content.Tiles.Geodes;

namespace Oreogenesis.Content.Items.Placeables.Geodes
{
	public class CopperGeodeBlockItem : ModItem
	{
        public override Color ItemColor => new Color(150, 67, 22);
        public override int BaseItemID => ItemID.CopperOre;
        public override int GeodeTileID => ModContent.TileType<CopperGeodeBlock>();
    }
}