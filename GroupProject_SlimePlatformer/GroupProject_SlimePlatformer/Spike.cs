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
    class Spike : Obstacle
    {
        public Spike(Texture2D texture, int x, int y, int levelWidth, int levelHeight) : base(texture, x, y, levelWidth, levelHeight)
        {
            this.position = new Rectangle(x, y, levelWidth/24, levelHeight/20);
        }

        //Will be used to kill the player if interacted with (may be unnecessary).
        public override bool CollisionDetection(GameObject otherObject)
        {
            if (this.position.Intersects(otherObject.position))
            {
                return true;
            }

            return false;
        }
    }
}
