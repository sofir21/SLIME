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
    class Bat : Enemy
    {
        private Vector2 batPosition;
        private Rectangle batRectangle;
        private int batMovement;
        private int reverseDirection;
        private bool shouldReverseDirection;

        // Animation
        private Texture2D batTexture;
        private double secondsPerFrame;
        private double fps;
        private double timer;
        private int currentFrame;
        private int spriteNum;
        private int batWidth;
        private int batHeight;
        /// <summary>
        /// Delete "get" property after testing
        /// </summary>
        public int ReverseDirection
        {
            get { return reverseDirection; }
            set { reverseDirection = value; }
        }

        public bool ShouldReverse
        {
            get
            {
                return shouldReverseDirection;
            }
            set
            {
                shouldReverseDirection = value;
            }
        }

        public Bat(Texture2D texture, int x, int y) : base(texture, x, y)
        {
            batMovement = -2;
            reverseDirection = 1;
            batPosition = new Vector2(x, y);
            
            batRectangle = new Rectangle(x, y, 64, 28);
            batTexture = texture;
            fps = 8;
            secondsPerFrame = 1.0 / fps;
            timer = 0;
            currentFrame = 1;
        }

        /// <summary>
        /// Draws the bat to the screen
        /// </summary>
        /// <param name="spriteBatch"></param>
        public override void Draw(SpriteBatch spriteBatch)
        {
            batWidth = texture.Width / 10;
            batHeight = texture.Height - 9;

            Rectangle sourceRect;
            sourceRect = new Rectangle((currentFrame - 1) * batWidth + 5, 6, batWidth - 6, batHeight);
            spriteNum = 10;
            spriteBatch.Draw(batTexture, batRectangle, sourceRect, Color.White);
        }

        /// <summary>
        /// Moves the rat based on their collision with other objects.
        /// </summary>
        public override void Move()
        {
            //Possibly adjust this if stamement to also reverse direction if the bat collides with a wall.
           if(reverseDirection == 1)
           {
                batRectangle.Y -= batMovement;
                
           }   
           
           else if(reverseDirection == -1)
           {
                batRectangle.Y += batMovement;
           }

            ObjectRectangle = new Rectangle(batRectangle.X, batRectangle.Y, 48, 28);
        }
        public override void Update(GameTime gameTime)
        {
            UpdateAnimation(gameTime);
        }

        public void UpdateAnimation(GameTime gameTime)
        {
            timer += gameTime.ElapsedGameTime.TotalSeconds;

            if (timer >= secondsPerFrame)
            {
                currentFrame++;

                if (currentFrame > spriteNum)
                {
                    currentFrame = 1;
                }

                timer -= secondsPerFrame;
            }
        }
        /// <summary>
        /// Determines if the bat has collided with an object
        /// </summary>
        /// <param name="otherObject">The object whose collision is being checked.</param>
        /// <returns></returns>
        public override bool CollisionDetection(GameObject otherObject)
        {
            if (batRectangle.Intersects(otherObject.position))
            {
                return true;
            }

            return false;
        }
    }
}
