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
    public class Hero : Sprite //class inheritance: https://goo.gl/jShBNA
    {
        public override void Update(GameTime gameTime) //overides the update to add movement
        {
            KeyboardState keyboardState = Keyboard.GetState();
            UserInput(keyboardState);
        }

        void UserInput(KeyboardState keyboardState)// moves the hero by key
        {
            if (keyboardState.IsKeyDown(Keys.Right))
            {
                position += new Vector2(speed, 0);
            }
            if (keyboardState.IsKeyDown(Keys.Left))
            {
                position += new Vector2(-speed, 0);
            }
            if (keyboardState.IsKeyDown(Keys.Up))
            {
                position += new Vector2(0, -speed);
            }
            if (keyboardState.IsKeyDown(Keys.Down))
            {
                position += new Vector2(0, speed);
            }
        }
    }
}

