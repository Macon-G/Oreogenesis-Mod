using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Oreogenesis.Content.Tiles.Crystals
{
    public abstract class BaseGeodeCrystal : ModTile
    {
        protected abstract int GeodeType { get; }
        protected abstract int ShardItemType { get; }
        protected abstract Color MapColor { get; }
        public override string Texture => $"Oreogenesis/Assets/Template/GeodeCrystalTile";
        protected virtual int FrameSize => 18;
        
        protected enum AttachDir
        {
            None = -1,
            SupportBelow = 0,
            SupportLeft = 1,
            SupportRight = 2,
            SupportAbove = 3
        }

        public override void SetStaticDefaults()
        {
            Main.tileFrameImportant[Type] = true;
            Main.tileNoAttach[Type] = true;
            Main.tileLighted[Type] = true;

            HitSound = SoundID.Shatter;
            DustType = DustID.GemTopaz;

            AddMapEntry(MapColor, CreateMapEntryName());
            RegisterItemDrop(ShardItemType);
        }

        protected AttachDir GetAttachmentDirection(int i, int j)
        {
            if (IsGeode(i, j + 1)) return AttachDir.SupportBelow;
            if (IsGeode(i - 1, j)) return AttachDir.SupportLeft;
            if (IsGeode(i + 1, j)) return AttachDir.SupportRight;
            if (IsGeode(i, j - 1)) return AttachDir.SupportAbove;

            return AttachDir.None;
        }

        public override bool CanPlace(int i, int j)
        {
            return GetAttachmentDirection(i, j) != AttachDir.None;
        }

        protected bool IsGeode(int i, int j)
        {
            if (!WorldGen.InWorld(i, j, 1))
                return false;

            Tile tile = Main.tile[i, j];
            return tile.HasTile && tile.TileType == GeodeType && !tile.IsActuated;
        }

        public override bool TileFrame(int i, int j, ref bool resetFrame, ref bool noBreak)
        {
            AttachDir dir = GetAttachmentDirection(i, j);

            if (dir == AttachDir.None)
            {
                WorldGen.KillTile(i, j);

                if (Main.netMode == NetmodeID.Server)
                    NetMessage.SendTileSquare(-1, i, j, 1);

                return false;
            }

            Tile tile = Main.tile[i, j];
            tile.TileFrameX = (short)((int)dir * FrameSize);
            tile.TileFrameY = 0;

            return true;
        }
    }
}