using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Game3
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game3 : Game
    {
        GraphicsDeviceManager Rgraphics;
        SpriteBatch RspriteBatch;

        enum GameState
        {
            Game3,
            Options,
            Playing,
        }
        GameState CurrentGameState = GameState.Game3;

        int RscreenWidth = 800, RscreenHeight = 600;

        ClassButton btnPlay;

        public Game3()
        {
            Rgraphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            RspriteBatch = new SpriteBatch(GraphicsDevice);

            Rgraphics.PreferredBackBufferWidth = RscreenWidth;
            Rgraphics.PreferredBackBufferHeight = RscreenHeight;
            Rgraphics.ApplyChanges();

            IsMouseVisible = true;
            btnPlay = new ClassButton(Content.Load<Texture2D>("Pics//Start"), Rgraphics.GraphicsDevice);
            btnPlay.setPosition(new Vector2(350, 300));
            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            MouseState Rmouse = Mouse.GetState();
            // TODO: Add your update logic here

            switch (CurrentGameState)
            {
                case GameState.Game3:
                    if (btnPlay.RisClicked == true) CurrentGameState = GameState.Playing;
                    btnPlay.Update(Rmouse);
                    break;
                case GameState.Playing:
                    break;
            }
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            RspriteBatch.Begin();
            
            switch (CurrentGameState)
            {
                case GameState.Game3:
                    RspriteBatch.Draw(Content.Load<Texture2D>("Pics//MainMenu"), new Rectangle(0, 0, RscreenWidth, RscreenHeight), Color.White);
                    btnPlay.Draw(RspriteBatch);
                    break;
                case GameState.Playing:
                    break;
            }
            // TODO: Add your drawing code here
            RspriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
