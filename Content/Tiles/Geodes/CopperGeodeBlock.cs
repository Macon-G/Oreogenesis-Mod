using Microsoft.Xna.Framework;
using Terraria.ModLoader;

namespace Oreogenesis.Content.Tiles.Geodes
{
    public class CopperGeodeBlock : BaseGeodeBlock
    {
        protected override int CrystalType => ModContent.TileType<Crystals.CopperGeodeCrystal>();
        protected override Color MapColor => new Color(110, 85, 130);
    }
}