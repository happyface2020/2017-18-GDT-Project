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
        KeyboardState oldkey;
        public override void Update(GameTime gameTime) //overides the update to add movement
        {
            KeyboardState keyboardState = Keyboard.GetState();
            UserInput(keyboardState);
        }

        void UserInput(KeyboardState keyboardState)// moves the hero by key
        {
            Vector2 new_position;
            MouseState mouse = Mouse.GetState();
            new_position = position;
            if (keyboardState.IsKeyDown(Keys.Right))
            {
                new_position += new Vector2(speed, 0);
            }
            CheckCollision(new_position);

            new_position = position;
            if (keyboardState.IsKeyDown(Keys.Left))
            {
                new_position += new Vector2(-speed, 0);
            }
            CheckCollision(new_position);

            new_position = position;
            if (keyboardState.IsKeyDown(Keys.Up))
            {
                new_position += new Vector2(0, -speed);
            }
            CheckCollision(new_position);

            new_position = position;
            if (keyboardState.IsKeyDown(Keys.Down))
            {
                new_position += new Vector2(0, speed);
            }
            CheckCollision(new_position);
            
            if(keyboardState.IsKeyDown(Keys.E) && oldkey.IsKeyUp(Keys.E))
            {
                Game1.CurrentGameState= Game1.GameState.Inventory;
            }
            oldkey = keyboardState;
            
        }

        public void CheckCollision(Vector2 new_position)
        {
            // check if new position is valid
            int Scale = 48;
            int map = 0;

            bool HasCollided = false;

            for (int x = (int)(new_position.X / Scale); x <= (int)((new_position.X + texture.Width * 3) / Scale); x++)
            {
                for (int y = (int)(new_position.Y / Scale); y <= (int)((new_position.Y + texture.Height * 3) / Scale); y++)
                {
                    int tileNum = MapLoad.Maps(map, 1, y, x);

                    if (tileNum != 0 && tileNum != 4)
                    {
                        HasCollided = true;
                    }

                }
            }

            if (HasCollided == false)
            {
                position = new_position;
            }
        }



    }
}

