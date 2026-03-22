using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.WorldBuilding;
using Terraria.Net;
using Terraria.Localization;

namespace Oreogenesis.Content.Tiles.Geodes
{
    public class CopperGeodeBlock : ModTile
    {
        public override void SetStaticDefaults()
        {
            Main.tileSolid[Type] = true;
            Main.tileBlockLight[Type] = true;
            Main.tileMergeDirt[Type] = true;

            HitSound = SoundID.Tink;
            DustType = DustID.Stone;

            AddMapEntry(new Color(110, 85, 130), Language.GetText("Mods.Oreogenesis.Tiles.CopperGeodeBlock.MapEntry"));
        }

        public override void RandomUpdate(int i, int j)
        {
            if (!CanGrowAt(i, j))
                return;

            TryGrow(i, j, 0, -1);
            TryGrow(i, j, -1, 0);
            TryGrow(i, j, 1, 0);
        }

        private bool CanGrowAt(int i, int j)
        {
            // Underground/cavern only for MVP
            return j > Main.worldSurface;
        }

        private void TryGrow(int i, int j, int offX, int offY)
        {
            int x = i + offX;
            int y = j + offY;

            if (!WorldGen.InWorld(x, y, 1))
                return;

            Tile target = Main.tile[x, y];

            if (target.HasTile)
                return;

            // extra chance gate so growth isn't too fast
            if (!WorldGen.genRand.NextBool(4))
                return;

            WorldGen.PlaceTile(x, y, ModContent.TileType<Crystals.CopperGeodeCrystal>(), mute: true);

            // Always verify placement happened
            if (!Main.tile[x, y].HasTile || Main.tile[x, y].TileType != ModContent.TileType<Crystals.CopperGeodeCrystal>())
                return;

            if (Main.netMode != NetmodeID.SinglePlayer)
                NetMessage.SendTileSquare(-1, x, y, 1);
        }
    }
}