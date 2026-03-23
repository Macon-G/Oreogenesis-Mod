using Microsoft.Xna.Framework;
using Terraria.ModLoader;
using Oreogenesis.Content.Items.Materials;

namespace Oreogenesis.Content.Tiles.Crystals
{
    public class CopperGeodeCrystal : BaseGeodeCrystal
    {
        protected override int GeodeType => ModContent.TileType<Geodes.CopperGeodeBlock>();
        protected override int ShardItemType => ModContent.ItemType<CopperCrystalShard>();
        protected override Color MapColor => new Color(210, 130, 70);
    }
}