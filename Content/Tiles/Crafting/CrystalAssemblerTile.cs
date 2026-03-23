using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace Oreogenesis.Content.Tiles.Crafting
{
    public class CrystalAssemblerTile : ModTile
    {
        public override string Texture => $"Oreogenesis/Assets/Tiles/Crafting/{Name}";
        public override void SetStaticDefaults()
        {
            Main.tileFrameImportant[Type] = true;
            Main.tileNoAttach[Type] = true;
            Main.tileLavaDeath[Type] = false;

            TileObjectData.newTile.CopyFrom(TileObjectData.Style2x2);
            TileObjectData.addTile(Type);

            AddMapEntry(new Color(120, 180, 220), CreateMapEntryName());

            DustType = DustID.Glass;
            HitSound = SoundID.Tink;
        }
    }
}