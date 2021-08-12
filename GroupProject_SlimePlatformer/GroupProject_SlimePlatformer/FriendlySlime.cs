using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace GroupProject_SlimePlatformer
{
    //Authors: Joshua Meyer
    //Purpose:
    //Known Errors/Restrictions:
    class FriendlySlime : GameObject
    {
        public FriendlySlime(Texture2D texture, int x, int y) : base(texture, x, y)
        {
            //Default contructor
        }

        /// <summary>
        /// Draws the friendly slime to the screen.
        /// </summary>
        /// <param name="spriteBatch">The sprite batch</param>
        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
        }
    }
}
