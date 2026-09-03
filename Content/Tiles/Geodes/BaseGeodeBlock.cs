using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Oreogenesis.Content.Tiles.Geodes
{
    public abstract class BaseGeodeBlock : ModTile
    {
        protected abstract int CrystalType { get; }
        protected abstract Color MapColor { get; }
        public override string Texture => $"Oreogenesis/Assets/Template/GeodeBlockTile";
        protected virtual int GrowthChanceDenominator => 4;
        protected virtual int MaxNearbyCrystals => 10;
        protected virtual int NeighborhoodRadius => 2;

        public override void SetStaticDefaults()
        {
            Main.tileSolid[Type] = true;
            Main.tileBlockLight[Type] = true;
            Main.tileBrick[Type] = true;
            Main.tileMergeDirt[Type] = true;

            HitSound = SoundID.Tink;
            DustType = DustID.Stone;

            AddMapEntry(MapColor, CreateMapEntryName());
        }

        public override void RandomUpdate(int i, int j)
        {
            if (!CanGrowAt(i, j))
                return;

            switch (WorldGen.genRand.Next(4))
            {
                case 0: TryGrow(i, j, 0, -1); break;
                case 1: TryGrow(i, j, -1, 0); break;
                case 2: TryGrow(i, j, 1, 0); break;
                case 3: TryGrow(i, j, 0, 1); break;
            }
        }

        protected virtual bool CanGrowAt(int i, int j)
        {
            bool isBelowSurface = j > Main.worldSurface;
            bool isAboveUnderworld = j < Main.UnderworldLayer;
            bool isNotActuated = !Main.tile[i, j].IsActuated;
            bool isBelowCrystalDensityLimit = CountNearbyCrystals(i, j) < MaxNearbyCrystals;

            return isBelowSurface && isAboveUnderworld && isNotActuated && isBelowCrystalDensityLimit;
        }

        protected uint CountNearbyCrystals(int i, int j)
        {
            uint count = 0;

            for (int dx = -NeighborhoodRadius; dx <= NeighborhoodRadius; dx++)
            {
                for (int dy = -NeighborhoodRadius; dy <= NeighborhoodRadius; dy++)
                {
                    if (dx == 0 && dy == 0)
                        continue;

                    int x = i + dx;
                    int y = j + dy;

                    if (!WorldGen.InWorld(x, y, 1))
                        continue;

                    Tile tile = Main.tile[x, y];
                    if (tile.HasTile && tile.TileType == CrystalType)
                        count++;
                }
            }

            return count;
        }

        protected void TryGrow(int i, int j, int offX, int offY)
        {
            int x = i + offX;
            int y = j + offY;

            if (!WorldGen.InWorld(x, y, 1))
                return;

            if (Main.tile[x, y].HasTile)
                return;

            if (!WorldGen.genRand.NextBool(GrowthChanceDenominator))
                return;

            WorldGen.PlaceTile(x, y, CrystalType, mute: true);

            if (!Main.tile[x, y].HasTile || Main.tile[x, y].TileType != CrystalType)
                return;

            if (Main.netMode == NetmodeID.Server)
                NetMessage.SendTileSquare(-1, x, y, 1);
        }
    }
}