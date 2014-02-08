using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace RPG
{
    public class MenuScreen: Screen
    {
        public Menu _Menu { get; set; }
        private List<TextureMap> fish;
        private List<Vector2> fishPos, fishVel;

        private List<TextureMap> clouds;
        private List<Vector2> cloudPos;

        private Animation radio;
        private Vector2 radioPos;

        public MenuScreen(ref SpriteBatch sb)
        {
            int height = Constants.graphics.PreferredBackBufferHeight;
            int width = Constants.graphics.PreferredBackBufferWidth;

            SB = sb;
            Backgrounds = new List<TextureMap>();
            fish = new List<TextureMap>();
            fishPos = new List<Vector2>();
            fishPos.Add(new Vector2((width / 2), height / 2));
            fishPos.Add(new Vector2((width / 2) + 122, (height / 2) + 122));
            fishPos.Add(new Vector2((width / 2) - 122, (height / 2) - 45));
            fishVel = new List<Vector2>();
            fishVel.Add(new Vector2(-1.2f, 0.0f));
            fishVel.Add(new Vector2(2.6f, 0.0f));
            fishVel.Add(new Vector2(-1.8f, 0.0f));
            Backgrounds.Add(new TextureMap(Constants.content.Load<Texture2D>(".\\art\\menuscreenbackground_layer3"), 1, 1));
            Backgrounds.Add(new TextureMap(Constants.content.Load<Texture2D>(".\\art\\menuscreenbackground_layer2"), 1, 1));
            Backgrounds.Add(new TextureMap(Constants.content.Load<Texture2D>(".\\art\\menuscreenbackground_layer1"), 1, 1));
            fish.Add(new TextureMap(Constants.content.Load<Texture2D>(".\\art\\fish1"), 1, 1, true));
            fish.Add(new TextureMap(Constants.content.Load<Texture2D>(".\\art\\fish2"), 1, 1, false));
            fish.Add(new TextureMap(Constants.content.Load<Texture2D>(".\\art\\fish3"), 1, 1, true));

            clouds = new List<TextureMap>();
            cloudPos = new List<Vector2>();
            cloudPos.Add(new Vector2((width / 2) - 320, height - (height - 32)));
            cloudPos.Add(new Vector2((width / 2) + 40, height - (height - 39)));
            cloudPos.Add(new Vector2((width / 2) + 340, height - (height - 28)));
            clouds.Add(new TextureMap(Constants.content.Load<Texture2D>(".\\art\\cloud1"), 1, 1, true));
            clouds.Add(new TextureMap(Constants.content.Load<Texture2D>(".\\art\\cloud2"), 1, 1, false));
            clouds.Add(new TextureMap(Constants.content.Load<Texture2D>(".\\art\\cloud3"), 1, 1, true));

            radioPos = new Vector2(370.0f, 47.0f);
            Constants.mAnimationManager.addAnimation(
                   new Animation(new AnimatedSprite(Constants.content.Load<Texture2D>(".\\art\\music_anim"), 1, 5, 600), radioPos)
                   );
            

            DrawableEntities = new List<GameEntity>();
        }

        public MenuScreen(ref SpriteBatch sb, List<Button> b)
        {
            int height = Constants.graphics.PreferredBackBufferHeight;
            int width = Constants.graphics.PreferredBackBufferWidth;

            SB = sb;
            Backgrounds = new List<TextureMap>();
            fish = new List<TextureMap>();
            fishPos = new List<Vector2>();
            fishPos.Add(new Vector2((width / 2), height / 2));
            fishPos.Add(new Vector2((width / 2) + 122, (height / 2) + 122));
            fishPos.Add(new Vector2((width / 2) - 122, (height / 2) - 45));
            fishVel = new List<Vector2>();
            fishVel.Add(new Vector2(-1.2f, 0.0f));
            fishVel.Add(new Vector2(2.6f, 0.0f));
            fishVel.Add(new Vector2(-1.8f, 0.0f));
            Backgrounds.Add(new TextureMap(Constants.content.Load<Texture2D>(".\\art\\menuscreenbackground_layer3"), 1, 1));
            Backgrounds.Add(new TextureMap(Constants.content.Load<Texture2D>(".\\art\\menuscreenbackground_layer2"), 1, 1));
            Backgrounds.Add(new TextureMap(Constants.content.Load<Texture2D>(".\\art\\menuscreenbackground_layer1"), 1, 1));
            fish.Add(new TextureMap(Constants.content.Load<Texture2D>(".\\art\\fish1"), 1, 1, true));
            fish.Add(new TextureMap(Constants.content.Load<Texture2D>(".\\art\\fish2"), 1, 1, false));
            fish.Add(new TextureMap(Constants.content.Load<Texture2D>(".\\art\\fish3"), 1, 1, true));

            clouds = new List<TextureMap>();
            cloudPos = new List<Vector2>();
            cloudPos.Add(new Vector2((width / 2) - 320, height - (height - 32)));
            cloudPos.Add(new Vector2((width / 2) + 40, height - (height - 39)));
            cloudPos.Add(new Vector2((width / 2) + 340, height - (height - 28)));
            clouds.Add(new TextureMap(Constants.content.Load<Texture2D>(".\\art\\cloud1"), 1, 1, true));
            clouds.Add(new TextureMap(Constants.content.Load<Texture2D>(".\\art\\cloud2"), 1, 1, false));
            clouds.Add(new TextureMap(Constants.content.Load<Texture2D>(".\\art\\cloud3"), 1, 1, true));

            radioPos = new Vector2(374.0f, 58.0f);
            Constants.mAnimationManager.addAnimation(
                   new Animation(new AnimatedSprite(Constants.content.Load<Texture2D>(".\\art\\music_anim"), 1, 5, 120, true), radioPos));

            DrawableEntities = new List<GameEntity>();
            _Menu = new Menu(ref sb);
            this._Menu.addButtons(b);
        }

        public override void draw()
        {
            Backgrounds.ElementAt(2).Draw(Constants.sb, Vector2.Zero);
            for (int i=0;i<fish.Count;++i)
            {
                fish.ElementAt(i).Draw(Constants.sb, fishPos.ElementAt(i));
                clouds.ElementAt(i).Draw(Constants.sb, cloudPos.ElementAt(i));
            }
            Backgrounds.ElementAt(1).Draw(Constants.sb, Vector2.Zero);
            Backgrounds.ElementAt(0).Draw(Constants.sb, Vector2.Zero);
            Constants.mAnimationManager.draw();
            _Menu.draw();
        }

        public override void update(GameTime t, KeyboardState k, MouseState m)
        {
            for (int i = 0; i < fishPos.Count;++i )
            {
                if (fishPos[i].X+64 <= Constants.MIN_X || fishPos[i].X-64 >= Constants.MAX_X)
                {
                    fishVel[i] = new Vector2(fishVel[i].X * -1.0f, fishVel[i].Y);
                    fish[i].Flipped ^= Convert.ToBoolean(1);
                }
                fishPos[i] += fishVel[i];
                //
                if (cloudPos[i].X >= Constants.MAX_X + 128)
                {
                    cloudPos[i] = new Vector2(Constants.MIN_X - 128, cloudPos[i].Y);
                }
                cloudPos[i] = new Vector2(cloudPos[i].X + 0.5f, cloudPos[i].Y);

            }
            Constants.mAnimationManager.update(t);
            _Menu.update(m);
        }

        public override void destroy()
        {
            unsafe
            {
                fixed (int* ptr = &Constants.LIVES_LEFT)
                {
                    Constants.mUiManager.addString(new UIElement("Score: ", *ptr));
                    Constants.mUiManager.Display.Last().ptr = ptr;
                }
            } 
        }

        public override void addEntity(GameEntity e)
        {
            
        }

        public override void addBackground(TextureMap t)
        {
            
        }

        public override void controls(KeyboardState k)
        {
            
        }
    }
}
