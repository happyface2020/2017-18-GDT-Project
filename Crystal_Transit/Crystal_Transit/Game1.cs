using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.IO;

namespace Crystal_Transit
{
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        public static string mapOne;
        public const int WindowWidth = 960;
        public const int WindowHeight = 640;
        public static string output = Path.Combine(Directory.GetCurrentDirectory(), "PlayerOutput.txt");
        public const int SquaresDepth = 2;
        public const int SquareWidth = 15;
        public const int SquaresHeight = 10;
        public const int Scale = 64;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            graphics.PreferredBackBufferWidth = WindowWidth;
            graphics.PreferredBackBufferHeight = WindowHeight;
        }
        protected override void Initialize()
        {
            base.Initialize();
        }
        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            TileSet.TileSetTexture = Content.Load<Texture2D>("TileSet");
        }
        protected override void UnloadContent()
        {
        }
        
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
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
                        // batch.Draw(SpriteTexture, position, null, Color.White, 0f, Vector2.Zero, scale, SpriteEffects.None, 0f);

                        spriteBatch.Draw(
                            TileSet.TileSetTexture,
                            new Rectangle((x * Scale), (y * Scale), Scale, Scale),
                            //Tile.GetSourceRectangle(myMap.Rows[y].Columns[x].TileID),
                            //Color.White);
                            TileSet.GetSourceRectangle(MapLoad.Maps(1,layer, row, column)),
                            Color.White,
                            0f,
                            Vector2.Zero,
                            SpriteEffects.None,
                            0f);

                    }
                }
            }
            base.Draw(gameTime);
            spriteBatch.End();
        }
    }
}
