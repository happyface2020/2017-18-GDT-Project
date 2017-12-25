using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crystal_Transit //BE CAREFUL ADDING A NEW CLASS TO THE FOULDER; THE NAMESPACE CHANGES!!!!
{
    public class Sprite //default fps is 60
    {
        public Texture2D texture;
        public Vector2 position;
        public Vector2 velocity;
        public const float speed = .16f; //can change speed; set speed 

        public virtual void Update(GameTime gameTime) //virtual can be overridden by any inherted class
        {
            
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, null, Color.White, 0f, Vector2.Zero, 4, SpriteEffects.None, 0f); //CHANGES THE SCALE OF THE HERO
        }
    }
}

