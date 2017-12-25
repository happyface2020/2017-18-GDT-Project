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
    public class Hero : Sprite //class inheritance: https://goo.gl/jShBNA (By. Sean)
    {
        
        public override void Update(GameTime gameTime) //overides the update to add movement
        {
            KeyboardState keyboardState = Keyboard.GetState();
            UserInput(keyboardState);
            position = velocity * (float)gameTime.ElapsedGameTime.TotalMilliseconds;
        }

        void UserInput(KeyboardState keyboardState)// moves the hero by key
        {
            if (keyboardState.IsKeyDown(Keys.Right))
            {
                velocity += new Vector2(speed, 0);
            }
            if (keyboardState.IsKeyDown(Keys.Left))
            {
                velocity += new Vector2(-speed, 0);
            }
            if (keyboardState.IsKeyDown(Keys.Up))
            {
                velocity += new Vector2(0, -speed);
            }
            if (keyboardState.IsKeyDown(Keys.Down))
            {
                velocity += new Vector2(0, speed);
            }
        }
    }
}

