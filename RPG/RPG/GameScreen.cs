using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace RPG
{
    public class GameScreen: Screen
    {
        public Player Player1 { get; set; }
        private Vector2 bg2pos;
        private TextureMap enemyMap, laserMap, bossMap;
        private bool pressedPause;

        Random r;

        public GameScreen(ref SpriteBatch sb, ref Player p, TextureMap eMap, 
            params string[] bgNames)
        {
            bg2pos = new Vector2(0.0f, 0.0f);
            SB = sb;
            Player1 = p;
            pressedPause = false;
            Backgrounds = new List<TextureMap>();
            DrawableEntities = new List<GameEntity>();
            foreach (string bg in bgNames)
            {
                DrawableEntities.Add(new GameEntity(Vector2.Zero, Vector2.Zero, 
                    new TextureMap(Constants.content.Load<Texture2D>(".\\art\\" + bg), 1, 1), GameEntity.ENTITY_TYPE.AI));
            }

            enemyMap = eMap;
            r = new Random();
        }

        public void checkForEndGame()
        {
           
        }

        public override void draw()
        {
            foreach (GameEntity entity in DrawableEntities)
            {
                entity.draw();
            }
            Player1.draw();
            Constants.mAnimationManager.draw();
        }

        public override void update(GameTime t, KeyboardState k, MouseState m)
        {
            checkForEndGame();
           
            Constants.mAnimationManager.update(t);
           
            foreach (GameEntity g in DrawableEntities)
            {
                g.update();
            }
            Player1.update();
            Player1.control(k);
            controls(k);
        }

        public override void destroy()
        {
           
        }

        public override void addEntity(GameEntity e)
        {
            DrawableEntities.Add(e);
        }

        public override void addBackground(TextureMap t)
        {
            Backgrounds.Add(t);
        }

        public override void controls(KeyboardState k)
        {
            if (k.IsKeyDown(Keys.T))
            {
                pressedPause = true;
            }
            if (k.IsKeyUp(Keys.T) && pressedPause)
            {
                Constants.paused ^= Convert.ToBoolean(1);
                pressedPause = false;
            }
            if (k.IsKeyDown(Keys.R))
            {
               
            }
        }
    }
}
