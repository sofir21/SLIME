using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace GroupProject_SlimePlatformer
{
    //Authors: Sofia Rivas
    //Purpose:
    //Known Errors/Restrictions:
    class Air : GameObject
    {
        // Constructor
        public Air(Texture2D texture, int x, int y, int screenWidth, int screenHeight) : base(texture, x, y)
        {
            // Sizing it to the curent screen
            position = new Rectangle(x, y, screenWidth / 24, screenHeight / 20);
        }

    }
}