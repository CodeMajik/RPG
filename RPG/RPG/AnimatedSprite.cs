using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace RPG
{
    public class AnimatedSprite
    {
        public TextureMap mTextureMap;
        private int animationTime, count;
        private bool mDone, mLoops;
        public AnimatedSprite(Texture2D texture, int rows, int columns, int time)
        {
            mTextureMap = new TextureMap(texture, rows, columns);
            animationTime = time / mTextureMap.totalFrames;
            count = 0;
            mDone = false;
            mLoops = false;
        }

        public AnimatedSprite(Texture2D texture, int rows, int columns, int time, bool loops)
        {
            mTextureMap = new TextureMap(texture, rows, columns);
            animationTime = time / mTextureMap.totalFrames;
            count = 0;
            mDone = false;
            mLoops = loops;
        }

        public void Update()
        {
            count++;
            if (count >= animationTime)
            {
                if (mTextureMap.currentFrame < mTextureMap.totalFrames - 1)
                {
                    mTextureMap.currentFrame++;
                }
                else
                {
                    if (!mLoops)
                    {
                        mTextureMap.currentFrame = 0;
                        mDone = true;
                    }
                    else
                    {
                        mTextureMap.currentFrame = 0;
                    }
                }
                count = 0;
            }
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            mTextureMap.Draw(spriteBatch, location);
        }

        public bool Done
        {
            get { return mDone; }
            set { mDone = value; }
        }
    }
}
