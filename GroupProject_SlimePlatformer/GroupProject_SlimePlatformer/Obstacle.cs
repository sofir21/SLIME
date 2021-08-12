using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace GroupProject_SlimePlatformer
{
    //Author: Josh M.
    //Purpose: Transitional class for the sake of understanding what the object falls under.
    //Known Errors/Restrticions: This is useless as a class and is really only here to designate the "Spike" and "Water" as Obstacles
    class Obstacle : GameObject
    {
        Rectangle obstacleRectangle;
        public Obstacle(Texture2D texture, int x, int y, int levelWidth, int levelHeight) : base(texture, x, y)
        {
            obstacleRectangle = new Rectangle(x, y, levelWidth, levelHeight);
        }
    }
}
