using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace RPG
{
    public static class Constants
    {
        public static GraphicsDeviceManager graphics;
        public static SpriteBatch sb;
        public static ContentManager content;
        public static int LIVES_LEFT = 1;
        public static int ENEMIES_DEFEATED = 0;
        public static bool GAME_OVER = false;
        public static bool paused = false;
        public static int MAX_X;
        public static int MAX_Y;
        public static int MIN_X;
        public static int MIN_Y;
        public const float PLAYER_MOVEMENT_SPEED = 2.8f;
        public const float GRAVITY = 9.81f;
        public static Vector2 DEFAULT_POSITION, DEFAULT_PROJECTILE_VELOCITY;
        public static Vector2 DEFAULT_VELOCITY = Vector2.Zero;
        public static Vector2 DEFAULT_ENEMY_VELOCITY = new Vector2(0.0f, 3.0f);
        public static Player player;
        public static AnimationManager mAnimationManager;
       
        public static UIManager mUiManager;
        public static ScreenStack mScreenStack;
        public static GameScreen mMainGameScreen;
        public static MenuScreen mMenuScreen;
        public static SplashScreen mSplashScreen, mEndScreenLose, mEndScreenWin;
        public static string pauseString;

        public static void init(ref GraphicsDeviceManager g, ref SpriteBatch s, ContentManager c)
        {
            sb = s;
            content = c;
            graphics = g;
            DEFAULT_POSITION = new Vector2((float)(graphics.PreferredBackBufferWidth / 2)-32, (float)graphics.PreferredBackBufferHeight-100.0f );
            DEFAULT_PROJECTILE_VELOCITY = new Vector2(0.0f, -25.0f);
            mAnimationManager = new AnimationManager(ref sb);
            
            mUiManager = new UIManager("MyFont", ref sb);
            mScreenStack = new ScreenStack();
            pauseString = "PAUSED";
            MAX_X = graphics.PreferredBackBufferWidth - 64;
            MAX_Y = graphics.PreferredBackBufferHeight - 64;
            MIN_X = 64;
            MIN_Y = 64;
        }
    }
}
