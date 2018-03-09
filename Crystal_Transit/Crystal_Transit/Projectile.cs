using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crystal_Transit
{
    class Projectile : Sprite
    {
        MouseState oldmouse;
        Vector2 movement;
        MouseState mouse = Mouse.GetState();
        Vector2 mousePosition;
        bool update = false;
        float projectilespeed = 150f;

        public Projectile(Texture2D texture, Vector2 position)
        {
            this.position = position;
            this.texture = texture;
            mousePosition = new Vector2(mouse.X + position.X, mouse.Y+ position.Y);
        }

        public override void Update(GameTime gameTime) //virtual can be overridden by any inherted class
        {

            if (mouse.LeftButton == ButtonState.Pressed && oldmouse.LeftButton == ButtonState.Released)
            {
                movement = mousePosition - position; //checks for position on screen not in game
                if (movement != Vector2.Zero)
                {
                    movement.Normalize();
                }
                update = true;
            }
            if (update == true)
            {
                position += movement * projectilespeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            }
            oldmouse = mouse;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {

            if (update == true)
            {
                spriteBatch.Draw(texture, position, null, Color.White, 0f, Vector2.Zero, 1, SpriteEffects.None, 0f); //CHANGES THE SCALE OF THE HERO
            }
        }
    }
}
