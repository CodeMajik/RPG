﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace RPG
{
    public class TextureMap
    {
        public Texture2D Texture { get; set; }
        public int Rows { get; set; }
        public int Columns { get; set; }
        public int currentFrame, totalFrames, width, height;
        Rectangle sourceRectangle, destinationRectangle;
        public bool Flipped { get; set; }

        public TextureMap()
        {

        }

        public TextureMap(Texture2D texture, int rows, int columns)
        {
            Texture = texture;
            Rows = rows;
            Columns = columns;
            currentFrame = 0;
            totalFrames = Rows * Columns;
            sourceRectangle = new Rectangle();
            destinationRectangle = new Rectangle();
            width = Texture.Width / Columns;
            height = Texture.Height / Rows;
            sourceRectangle.Width = width;
            sourceRectangle.Height = height;
            destinationRectangle.Width = width;
            destinationRectangle.Height = height;
        }

        public TextureMap(Texture2D texture, int rows, int columns, bool flipped)
        {
            Flipped = flipped;
            Texture = texture;
            Rows = rows;
            Columns = columns;
            currentFrame = 0;
            totalFrames = Rows * Columns;
            sourceRectangle = new Rectangle();
            destinationRectangle = new Rectangle();
            width = Texture.Width / Columns;
            height = Texture.Height / Rows;
            sourceRectangle.Width = width;
            sourceRectangle.Height = height;
            destinationRectangle.Width = width;
            destinationRectangle.Height = height;
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 position)
        {
           
            int row = (int)((float)currentFrame / (float)Columns);
            int column = currentFrame % Columns;

            sourceRectangle.X = width * column;
            sourceRectangle.Y = height * row;

            destinationRectangle.X = (int)position.X;
            destinationRectangle.Y = (int)position.Y;

            if (Flipped)
                spriteBatch.Draw(Texture, destinationRectangle, sourceRectangle, Color.White, 0.0f, Vector2.Zero, SpriteEffects.FlipHorizontally, 1.0f);
            else
                spriteBatch.Draw(Texture, destinationRectangle, sourceRectangle, Color.White);
        }
    }
}
