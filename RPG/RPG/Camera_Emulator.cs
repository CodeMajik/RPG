using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace RPG
{
    public class Camera_Emulator
    {
        public enum DIRECTION{LEFT, RIGHT, UP, DOWN};
        float scrollSpeed;
        public Camera_Emulator(float speed)
        {
            scrollSpeed = speed;
        }
        public void scroll(DIRECTION dir)
        {
            switch (dir)
            {
                case DIRECTION.LEFT:
                    {
                        for (int i = 0; i < Constants.mMainGameScreen.DrawableEntities.Count;++i )
                            Constants.mMainGameScreen.DrawableEntities[i].mPosition =
                                new Vector2(Constants.mMainGameScreen.DrawableEntities[i].mPosition.X+scrollSpeed,
                                    Constants.mMainGameScreen.DrawableEntities[i].mPosition.Y);
                    }
                    break;
                case DIRECTION.DOWN:
                    {
                        for (int i = 0; i < Constants.mMainGameScreen.DrawableEntities.Count; ++i)
                            Constants.mMainGameScreen.DrawableEntities[i].mPosition =
                                new Vector2(Constants.mMainGameScreen.DrawableEntities[i].mPosition.X,
                                    Constants.mMainGameScreen.DrawableEntities[i].mPosition.Y - scrollSpeed);
                    }
                    break;
                case DIRECTION.RIGHT:
                    {
                        for (int i = 0; i < Constants.mMainGameScreen.DrawableEntities.Count; ++i)
                            Constants.mMainGameScreen.DrawableEntities[i].mPosition =
                                new Vector2(Constants.mMainGameScreen.DrawableEntities[i].mPosition.X - scrollSpeed,
                                    Constants.mMainGameScreen.DrawableEntities[i].mPosition.Y);
                    }
                    break;
                case DIRECTION.UP:
                    {
                        for (int i = 0; i < Constants.mMainGameScreen.DrawableEntities.Count; ++i)
                            Constants.mMainGameScreen.DrawableEntities[i].mPosition =
                                new Vector2(Constants.mMainGameScreen.DrawableEntities[i].mPosition.X,
                                    Constants.mMainGameScreen.DrawableEntities[i].mPosition.Y + scrollSpeed);
                    }
                    break;
                default:
                    {
                        //do nothing
                    }
                    break;
            }
        }
    }
}
