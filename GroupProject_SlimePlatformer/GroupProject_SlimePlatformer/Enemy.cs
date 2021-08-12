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
    //Known Errors/Restrticions: This is kind of useless as a class and is really only here to designate the "Rat" and "Bat" as enemies.
    class Enemy : GameObject
    {
        public Enemy(Texture2D texture, int x, int y) : base(texture, x, y)
        {
        }
    }
}
