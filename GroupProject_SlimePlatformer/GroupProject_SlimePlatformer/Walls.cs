using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace GroupProject_SlimePlatformer
{
    //Authors: Riley Procopio & Joshua Meyer
    //Purpose:
    //Known Errors/Restrictions:
    class Walls : GameObject
    {
        public Walls(Texture2D texture, int x, int y, int screenWidth, int screenHeight) : base(texture, x, y)
        {
            // Sizing it to the curent screen
            position = new Rectangle(x, y, screenWidth / 24, screenHeight / 20);
        }

        /// <summary>
        /// Draws a wall tile to the screen.
        /// </summary>
        /// <param name="spriteBatch">The sprite batch</param>
        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
        }
    }
}
