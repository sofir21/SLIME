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
    class Rat : Enemy
    {
        private Rectangle ratRectangle;
        private Rectangle atEdgeRectangle;
        private Rectangle wallRectangle;
        private int ratMovement;

        private bool atEdge;
        private int reverseDirection;

        /// <summary>
        /// Delete "get" property after testing
        /// </summary>
        public bool AtEdge
        {
            get { return atEdge; }
            set { atEdge = value; }
        }

        /// <summary>
        /// Delete "get" property after testing
        /// </summary>
        public int ReverseDirection
        {
            get { return reverseDirection; }
            set { reverseDirection = value; }
        }

        public Rat(Texture2D texture, int x, int y) : base(texture, x, y)
        {
            ratMovement = 1;
            reverseDirection = 1;
            ratRectangle = new Rectangle(x, y + 6, 25, 18);
            position = ratRectangle;
            atEdgeRectangle = new Rectangle(ratRectangle.X, (ratRectangle.Y + (480 / 20) + 6), 816 / 40, 480 / 40);
            wallRectangle = new Rectangle(ratRectangle.X, (ratRectangle.Y - 6), 816 / 40, 480 / 40);
        }

        /// <summary>
        /// Draws the rat to the screen. 
        /// </summary>
        /// <param name="spriteBatch">The sprite batch</param>
        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, ratRectangle, Color.White);
        }

        /// <summary>
        /// Moves the rat based on its position (and its collision rectangles)
        /// </summary>
        public override void Move()
        {
            //Will need to flip the rat's sprite every time the direction is reversed.
            if (reverseDirection == 1)
            {
                ratRectangle.X += ratMovement;
                atEdgeRectangle = new Rectangle(ratRectangle.X + 8, (ratRectangle.Y + (480 / 20) + 6), 816 / 40, 480 / 40);
                wallRectangle = new Rectangle(ratRectangle.X + 8, (ratRectangle.Y - 6), 816 / 40, 480 / 40);
            }

            else if (reverseDirection == -1)
            {
                ratRectangle.X -= ratMovement;
                atEdgeRectangle = new Rectangle(ratRectangle.X - 1, (ratRectangle.Y + (480 / 20) + 6), 816 / 40, 480 / 40);
                wallRectangle = new Rectangle(ratRectangle.X - 4, (ratRectangle.Y - 6), 816 / 40, 480 / 40);
            }

            ObjectRectangle = new Rectangle(ratRectangle.X, (ratRectangle.Y + texture.Height), texture.Width, texture.Height);
        }

        /// <summary>
        /// This will specifically be used to check if the rat is colliding with the player
        /// </summary>
        /// <param name="otherObject"></param>
        /// <returns></returns>
        public override bool CollisionDetection(GameObject otherObject)
        {
            //This may create the issue of the player dying whenever the Rat collides with a wall.
            if (ratRectangle.Intersects(otherObject.position))
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Determines if the rat's wall collision rectangle intersects with a wall.
        /// </summary>
        /// <param name="otherObject">A wall being checked</param>
        /// <returns></returns>
        public bool WallCollision(GameObject otherObject)
        {
            if (wallRectangle.Intersects(otherObject.position))
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Checks if atEdge rect is colliding with air
        /// </summary>
        /// <param name="otherObject">An object being checked for interesection</param>
        /// <returns></returns>
        public bool AirCollision(GameObject otherObject)
        {
            if (atEdgeRectangle.Intersects(otherObject.position))
            {
                return true;
            }

            return false;
        }
    }
}
