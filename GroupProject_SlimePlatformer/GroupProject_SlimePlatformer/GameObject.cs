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
    class GameObject
    {
        public int x;
        public int y;
        public Texture2D texture;
        public Rectangle position;

        public int X
        {
            get { return x; }

            set { x = value; }
        }

        public int Y
        {
            get { return y; }

            set { y = value; }
        }

        public Rectangle ObjectRectangle
        {
            get { return position; }

            set { position = value; }
        }


        public GameObject(Texture2D texture, int x, int y)
        {
            this.x = x;
            this.y = y;
            this.texture = texture;

            position = new Rectangle(x, y, texture.Width, texture.Height);
        }

        /// <summary>
        /// Draws the object to the screen. Overridden based on the texture.
        /// </summary>
        /// <param name="spriteBatch">The spirtebatch in the program</param>
        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, Color.White);
        }

        /// <summary>
        /// A class to be overridden. Simply here to avoid confusion by avvoiding different
        /// "Move" method names.
        /// </summary>
        public virtual void Move()
        {
            
        }

        public virtual void Update(GameTime gameTime)
        {

        }

        /// <summary>
        /// Determines collisions between objects. Overridden in subclasses
        /// </summary>
        /// <param name="otherObject">The object being compared to</param>
        /// <returns></returns>
        public virtual bool CollisionDetection(GameObject otherObject)
        {
            if (position.Intersects(otherObject.position))
            {
                return true;
            }

            return false;
        }
    }
}
