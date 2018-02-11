using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;
using System.IO;

namespace Crystal_Transit
{
    public class Game1 : Game
    {

        enum GameState
        {
            Game1,
            Options,
            Playing,
        }

        GameState CurrentGameState = GameState.Game1;

        ClassButton btnPlay;

        #region variables
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Hero hero = new Hero();
        Archer archer;
        SpriteFont font;
        private Camera camera= new Camera();

        public const int WindowWidth = 960; //64 * 15
        public const int WindowHeight = 640; // 64 * 10
        public const int SquaresDepth = 2;
        public const int SquareWidth = 15;
        public const int SquaresHeight = 10;
        public const int Scale = 48;
        public static int map = 0;
        #endregion
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            
        }
        protected override void Initialize()
        {
            TileSet.TileSetTexture = Content.Load<Texture2D>("TileSet"); // loading tileset
            hero.texture = Content.Load<Texture2D>("Hero"); //change later  
            hero.position = new Vector2(100, 100);

            archer = new Archer(hero, 10f, 25f, 2f, 30f);
            archer.texture = Content.Load<Texture2D>("Archer");
            archer.position = new Vector2(20, 20);

            font = Content.Load<SpriteFont>("Font");

            base.Initialize();
        }
        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            graphics.PreferredBackBufferWidth = WindowWidth; //set size of window
            graphics.PreferredBackBufferHeight = WindowHeight;
            graphics.ApplyChanges();
            IsMouseVisible = true;
            btnPlay = new ClassButton(Content.Load<Texture2D>("Start"), graphics.GraphicsDevice);
            btnPlay.setPosition(new Vector2(350, 300));
        }
        protected override void UnloadContent()
        {
            
        }  
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            MouseState mouse = Mouse.GetState();

            switch (CurrentGameState)
            {
                case GameState.Game1:
                    if (btnPlay.RisClicked == true) CurrentGameState = GameState.Playing;
                    btnPlay.Update(mouse);
                    break;
                case GameState.Playing:
                    hero.Update(gameTime);
                    camera.Follow(hero);
                    if (hero.position.X < 0) //basic unloading
                    {
                        UnloadContent();
                        map = 1;
                        hero.position.X = 64 * 74;
                        LoadContent();
                    }

                    archer.Update(gameTime);
                    archer.targetMovedTo(hero.position);

                    
                    break;
                
            }
            base.Update(gameTime);
        }
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            

            switch (CurrentGameState)
            {
                case GameState.Game1:
                    spriteBatch.Begin();
                    spriteBatch.Draw(Content.Load<Texture2D>("MainMenu"), new Rectangle(0, 0, WindowWidth, WindowHeight), Color.White);
                    btnPlay.Draw(spriteBatch);
                    break;
                case GameState.Playing:
                    spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.PointWrap, null, null, null, transformMatrix: camera.Transfrom);
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
                                    TileSet.GetSourceRectangle(MapLoad.Maps(map, layer, row, column)), //need to make variable fro map
                                    Color.White,
                                    0f,
                                    Vector2.Zero,
                                    SpriteEffects.None,
                                    0f);

                            }
                        }
                    }

                    hero.Draw(spriteBatch);
                    archer.Draw(spriteBatch);

                    int tileNumNW = MapLoad.Maps(map, 1, (int)(hero.position.Y / Scale), (int)(hero.position.X / Scale));
                    int tileNumSW = MapLoad.Maps(map, 1, (int)((hero.position.Y + hero.texture.Height * 3) / Scale), (int)(hero.position.X / Scale));
                    int tileNumNE = MapLoad.Maps(map, 1, (int)(hero.position.Y / Scale), (int)((hero.position.X + hero.texture.Width * 3) / Scale));
                    int tileNumSE = MapLoad.Maps(map, 1, (int)((hero.position.Y + hero.texture.Height * 3) / Scale), (int)((hero.position.X + hero.texture.Width * 3) / Scale));

                    //((int)(hero.position.X/Scale)).ToString() + "," + ((int)(hero.position.Y / Scale)).ToString()  

                    spriteBatch.DrawString(font, tileNumNW.ToString(), hero.position, Color.Black);
                    spriteBatch.DrawString(font, tileNumSW.ToString(), new Vector2(hero.position.X, hero.position.Y + hero.texture.Height * 3), Color.Black);
                    spriteBatch.DrawString(font, tileNumNE.ToString(), new Vector2(hero.position.X + hero.texture.Width * 3, hero.position.Y), Color.Black);
                    spriteBatch.DrawString(font, tileNumSE.ToString(), new Vector2(hero.position.X + hero.texture.Width * 3, hero.position.Y + hero.texture.Height * 3), Color.Black);


                    break;
                
                
            }
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
