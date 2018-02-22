﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crystal_Transit
{
    class Inventory
    {
        public Texture2D texture;
        public Vector2 position;
        public const float speed = 2f; //can change speed; set speed 

        public virtual void Update(GameTime gameTime) //virtual can be overridden by any inherted class
        {
            
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, null, Color.White, 0f, Vector2.Zero, 3, SpriteEffects.None, 0f); //CHANGES THE SCALE OF THE HERO
        }
    }
}
