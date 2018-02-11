using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Crystal_Transit
{
    class ClassButton
    {
        Texture2D Rtexture;
        Vector2 Rposition;
        Rectangle Rrectangle;

        Color Rcolour = new Color(100, 255, 100, 255);

        public Vector2 Rsize;

        public ClassButton(Texture2D newTexture, GraphicsDevice Rgraphics)
        {
            Rtexture = newTexture;

            //ScreenW = 1000, ScreenH = 1000
            //ImgW = 100, ImgH = 20
            Rsize = new Vector2(Rgraphics.Viewport.Width / 8, Rgraphics.Viewport.Height / 30);
        }

        bool down;
        public bool RisClicked;
        public void Update(MouseState Rmouse)
        {
            Rrectangle = new Rectangle((int)Rposition.X, (int)Rposition.Y,
                (int)Rsize.X, (int)Rsize.Y);
            Rectangle mouseRectangle = new Rectangle(Rmouse.X, Rmouse.Y, 1, 1);

            if (mouseRectangle.Intersects(Rrectangle))
            {
                if (Rcolour.A == 255) down = false;
                if (Rcolour.A == 0) down = true;
                if (down) Rcolour.A += 3; else Rcolour.A -= 3;
                if (Rmouse.LeftButton == ButtonState.Pressed) RisClicked = true;

            }
            else if (Rcolour.A < 255)
            {
                Rcolour.A += 3;
                RisClicked = false;
            }
        }

        public void setPosition(Vector2 newPosition)
        {
            Rposition = newPosition;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Rtexture, Rrectangle, Rcolour);
        }
    }
}
