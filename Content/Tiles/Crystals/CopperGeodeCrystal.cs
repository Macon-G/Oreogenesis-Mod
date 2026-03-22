using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Oreogenesis.Content.Items.Materials;

namespace Oreogenesis.Content.Tiles.Crystals
{
    public class CopperGeodeCrystal : ModTile
    {
        public override void SetStaticDefaults()
        {
            Main.tileFrameImportant[Type] = true;
            Main.tileNoAttach[Type] = true;
            Main.tileLighted[Type] = true;

            HitSound = SoundID.Shatter;
            DustType = DustID.GemTopaz;

            AddMapEntry(new Color(210, 130, 70), CreateMapEntryName());
            RegisterItemDrop(ModContent.ItemType<CopperCrystalShard>());
        }

        public override bool CanPlace(int i, int j)
        {
            return IsAttachedToGeode(i, j);
        }

        public override bool TileFrame(int i, int j, ref bool resetFrame, ref bool noBreak)
        {
            if (!IsAttachedToGeode(i, j))
            {
                WorldGen.KillTile(i, j);
                if (Main.netMode != NetmodeID.SinglePlayer)
                    NetMessage.SendTileSquare(-1, i, j, 1);
            }

            return true;
        }

        private bool IsAttachedToGeode(int i, int j)
        {
            return IsGeode(i, j + 1) || IsGeode(i - 1, j) || IsGeode(i + 1, j) || IsGeode(i, j - 1);
        }

        private bool IsGeode(int i, int j)
        {
            if (!WorldGen.InWorld(i, j, 1))
                return false;

            Tile tile = Main.tile[i, j];
            return tile.HasTile && tile.TileType == ModContent.TileType<Geodes.CopperGeodeBlock>();
        }
    }
}