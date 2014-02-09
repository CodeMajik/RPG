using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace RPG
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        SoundManager mSoundMgr;
        TextureMap plrMap, enemyMap;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.IsFullScreen = false;
            graphics.PreferredBackBufferWidth = 800;
            graphics.PreferredBackBufferHeight = 600;
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
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

        void startGame()
        {
            Constants.mMenuScreen.destroy();
            Constants.mScreenStack.pop();
            Constants.mScreenStack.push(Constants.mMainGameScreen);
        }

        void back()
        {
            Constants.mScreenStack.pop();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            Constants.init(ref graphics, ref spriteBatch, Content);
            plrMap = new TextureMap(Content.Load<Texture2D>(".\\art\\player1"), 4, 3);
            enemyMap = new TextureMap(Content.Load<Texture2D>(".\\art\\enemy1"), 1, 1);

            Constants.player = new Player(Constants.DEFAULT_POSITION, plrMap);

            Constants.mMainGameScreen = new GameScreen(ref spriteBatch, ref Constants.player, enemyMap, "grass");
            Constants.mSplashScreen = new SplashScreen(".\\art\\opening_splashscreen", ref spriteBatch);
            //Constants.mEndScreenLose = new SplashScreen("splashscreen3", ref spriteBatch, "Press Escape To Exit");
            //Constants.mEndScreenWin = new SplashScreen("splashscreen2", ref spriteBatch, "Press Escape To Exit");

            Vector2 menuPos = new Vector2((graphics.PreferredBackBufferWidth / 2) - 56, (graphics.PreferredBackBufferHeight * 0.50f)-64);
            List<Button> btns = new List<Button>();
            btns.Add(new Button(new TextureMap(Content.Load<Texture2D>(".\\art\\ButtonStart"), 1, 1),
               new Vector2(menuPos.X, menuPos.Y), this.startGame));
            btns.Add(new Button(new TextureMap(Content.Load<Texture2D>(".\\art\\ButtonQuit"), 1, 1),
               new Vector2(menuPos.X, menuPos.Y + 76), this.Exit));

            Constants.mMenuScreen = new MenuScreen(ref spriteBatch, btns);
            Constants.mScreenStack.push(Constants.mSplashScreen);

            mSoundMgr = new SoundManager();
            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
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
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                this.Exit();

            mSoundMgr.update(Keyboard.GetState());
            // TODO: Add your update logic here
            if (!Constants.paused)
                Constants.mScreenStack.update(gameTime, Keyboard.GetState(), Mouse.GetState());
            else
                Constants.mMainGameScreen.controls(Keyboard.GetState());

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();
            Constants.mScreenStack.draw();
            if (Constants.paused)
                spriteBatch.DrawString(Constants.mUiManager.Font, Constants.pauseString, new Vector2(graphics.PreferredBackBufferWidth / 2 - 64, graphics.PreferredBackBufferHeight / 2 - 32), Color.Yellow
                    , 0.0f, Vector2.Zero, 2.0f, SpriteEffects.None, 1.0f);

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
