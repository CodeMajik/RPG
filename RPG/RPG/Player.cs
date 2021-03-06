﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace RPG
{
    public class Player: GameEntity
    {
        public Player(Vector2 position, TextureMap map)
            :base(position, map, ENTITY_TYPE.PLAYER)
        {
            
        }

        public void control(KeyboardState k)
        {
            if (mAlive)
            {
                /*if (k.IsKeyDown(Keys.W))
                    if (Position.Y > Constants.MIN_Y)
                        Velocity = new Vector2(Velocity.X, -Constants.PLAYER_MOVEMENT_SPEED);
                if (k.IsKeyDown(Keys.A))
                    if (Position.X > Constants.MIN_X)
                        Velocity = new Vector2(-Constants.PLAYER_MOVEMENT_SPEED, Velocity.Y);
                if (k.IsKeyDown(Keys.S))
                    if (Position.Y < Constants.MAX_Y)
                        Velocity = new Vector2(Velocity.X, Constants.PLAYER_MOVEMENT_SPEED);
                if (k.IsKeyDown(Keys.D))
                    if (Position.X < Constants.MAX_X)
                        Velocity = new Vector2(Constants.PLAYER_MOVEMENT_SPEED, Velocity.Y);
                */
                if (k.IsKeyDown(Keys.W))
                    if (Position.Y > Constants.MIN_Y)
                        Constants.mCamera.scroll(Camera_Emulator.DIRECTION.UP);
                if (k.IsKeyDown(Keys.A))
                    if (Position.X > Constants.MIN_X)
                        Constants.mCamera.scroll(Camera_Emulator.DIRECTION.LEFT);
                if (k.IsKeyDown(Keys.S))
                    if (Position.Y < Constants.MAX_Y)
                        Constants.mCamera.scroll(Camera_Emulator.DIRECTION.DOWN);
                if (k.IsKeyDown(Keys.D))
                    if (Position.X < Constants.MAX_X)
                        Constants.mCamera.scroll(Camera_Emulator.DIRECTION.RIGHT);
                if (k.IsKeyDown(Keys.Space))
                { //shoot 
                    this.destroy();
                }
            }
        }

        public override void reset()
        {
            mPosition = Constants.DEFAULT_POSITION;
            mVelocity = Constants.DEFAULT_VELOCITY;
            mHealth = 100;
            mAlive = true;
        }

        public override void destroy()
        {
            if (mAlive)
            {
                Constants.mAnimationManager.addAnimation(
                    new Animation(new AnimatedSprite(Constants.content.Load<Texture2D>(".\\art\\explosion2"), 1, 16, 60), mPosition)
                    );
                Constants.LIVES_LEFT--;
                mAlive = false;
            }
            if (Constants.LIVES_LEFT > 0)
            {
                reset();
            }
            else
            {
                //Constants.GAME_OVER = true;
                //Constants.mScreenStack.push(Constants.mEndScreenLose);
            }
        }

        public override void update()
        {
            if (mAlive)
            {
                mPosition += mVelocity;
                mVelocity.X *= 0.94f;
                mVelocity.Y *= 0.94f;
                mMidPoint = new Vector2(mPosition.X + mTexture.width / 2, mPosition.Y + mTexture.height / 2);

                if (mHealth <= 0)
                {
                    this.destroy();
                    if (Constants.LIVES_LEFT > 0)
                    {
                        this.reset();
                        Constants.LIVES_LEFT--;
                    }
                    else
                    {
                        Constants.GAME_OVER = true;
                        mAlive = false;
                    }
                }
            }
        }
    }
}
