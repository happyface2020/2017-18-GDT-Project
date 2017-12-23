using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace Crystal_Transit
{
    static class TileSet
    {
        static public Texture2D TileSetTexture;
        static public int TilesetScale = 16; //tileset, pixel by one tile

        static public Rectangle GetSourceRectangle(int tileIndex)
        {
            int tileY = tileIndex / (TileSetTexture.Width / TilesetScale);
            int tileX = tileIndex % (TileSetTexture.Width / TilesetScale);

            return new Rectangle(tileX * TilesetScale, tileY * TilesetScale, TilesetScale, TilesetScale);
        }


    }
}
