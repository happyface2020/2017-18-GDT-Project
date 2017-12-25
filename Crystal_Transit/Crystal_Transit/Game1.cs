using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.IO;

namespace Crystal_Transit
{
    public class Game1 : Game
    {
        #region variables
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Hero hero = new Hero();
        public const int WindowWidth = 960; //64 * 15
        public const int WindowHeight = 640; // 64 * 10
        public const int SquaresDepth = 2;
        public const int SquareWidth = 15;
        public const int SquaresHeight = 10;
        public const int Scale = 64;
        #endregion
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            graphics.PreferredBackBufferWidth = WindowWidth; //set size of window
            graphics.PreferredBackBufferHeight = WindowHeight;
        }
        protected override void Initialize()
        {
            base.Initialize();
        }
        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            TileSet.TileSetTexture = Content.Load<Texture2D>("TileSet"); // loading tileset
            hero.texture = Content.Load<Texture2D>("Hero"); //change later
        }
        protected override void UnloadContent()
        {
        }  
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            hero.Update(gameTime);
            base.Update(gameTime);
        }
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.PointWrap);

            for (int z = 0; z < SquaresDepth; z++)
            {
                int layer = z;
                for (int y = 0; y < 50; y++)
                {
                    int row = y;
                    for (int x = 0; x < 100; x++)
                    {
                        int column = x;

                        spriteBatch.Draw(
                            TileSet.TileSetTexture,
                            new Rectangle((x * Scale), (y * Scale), Scale, Scale),
                            TileSet.GetSourceRectangle(MapLoad.Maps(0,layer, row, column)), //need to make variable fro map
                            Color.White,
                            0f,
                            Vector2.Zero,
                            SpriteEffects.None,
                            0f);

                    }
                }
            }

            hero.Draw(spriteBatch);
            base.Draw(gameTime);
            spriteBatch.End();
        }
    }
}
