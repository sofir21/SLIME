using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace GroupProject_SlimePlatformer
{
    //Authors: Joshua Meyer, Riley Procopio & Gianluigi Aponte
    //Purpose:
    //Known Errors/Restrictions:
    enum PlayerState
    {
        Idle,
        Jump,
        Death
    }
    class Player : GameObject
    {
        private const int PlayerMovementSpeed = 3;
        private Rectangle playerRectangle;

        private Vector2 playerVelocity;
        private Vector2 jumpVelocity;
        private Vector2 gravity;
        private Vector2 playerPosition;

        //These fields aren't changing as intended for some reason.
        private bool isSticking;
        private bool inAir;
            
        // Keeps track of the direction where the player landed on a wall, false = left and true = right
        private bool jumpDirection;

        // Keeps track of the time between sticking again (Default is .38 seconds)
        double unstuckTimer;

        //Temporary variables for key pressed once to work.
        KeyboardState keys;
        KeyboardState lastKbState;

        // Variables for higher jumps
        private Vector2 higherJumpVelocity;

        //Animation
        private PlayerState playerState;
        private Texture2D spriteIdle;
        //private Texture2D spriteDeath;
        //private Texture2D spriteJump;

        private double secondsPerFrame;
        private double fps;
        private double timer;
        private int currentFrame;
        private int spriteNum;
        private int slimeWidth;
        private int slimeHeight;

        public int PlayerRectangleX
        {
            get { return playerRectangle.X; }

            set { playerRectangle.X = value; }
        }

        public int PlayerRectangleY
        {
            get { return playerRectangle.Y; }

            set { playerRectangle.Y = value; }
        }

        public Rectangle PlayerRectangle
        {
            get { return playerRectangle; }

            set { playerRectangle = value; }
        }

        public Vector2 PlayerVelocity
        {
            get { return playerVelocity;  }

            set { playerVelocity = value; }
        }

        //Get Values for the bool properties will probably be removed after testing.
        public bool IsSticking
        {
            get { return isSticking; }

            set { isSticking = value; }
        }

        public bool InAir
        {
            get { return inAir; }

            set { inAir = value; }
        }

        public double Timer
        {
            get
            {
                return unstuckTimer;
            }
            set
            {
                unstuckTimer = value;
            }
        }

        public Player(Texture2D texture, int x, int y) : base(texture, x, y)
        {
            playerPosition = new Vector2(x, y);
            playerRectangle = new Rectangle(x, y, 28, 17);

            playerVelocity = Vector2.Zero;
            //Likely adjust the velocity to something around -7.0f later. This limit is merely for testing.
            jumpVelocity = new Vector2(0, -7.0f);
            gravity = new Vector2(0, 0.5f);
            // Meant to be lower than gravity and can be adjusted for balance
            higherJumpVelocity = new Vector2(0, -0.25f);
            isSticking = false;
            unstuckTimer = 0;
            inAir = false;
            spriteIdle = texture;

            fps = 5;
            secondsPerFrame = 1.0 / fps;
            timer = 0;
            currentFrame = 1;
            //slimeWidth = texture.Width / 4 - 46;
            //slimeHeight = texture.Height - 30;
        }

        //public Player(Texture2D texture, int x, int y) : base(texture, x, y)
        //{
        //    playerPosition = new Vector2(x, y);
        //    playerRectangle = new Rectangle(x, y, 24, 17);
        //
        //    playerVelocity = Vector2.Zero;
        //    //Likely adjust the velocity to something around -7.0f later. This limit is merely for testing.
        //    jumpVelocity = new Vector2(0, -7.0f);
        //    gravity = new Vector2(0, 0.5f);
        //    // Meant to be lower than gravity and can be adjusted for balance
        //    higherJumpVelocity = new Vector2(0, -0.25f);
        //    isSticking = false;
        //    unstuckTimer = 0;
        //    inAir = false;
        //    spritesheet = texture;
        //    fps = 5;
        //    secondsPerFrame = 1.0 / fps;
        //    timer = 0;
        //    currentFrame = 1;
        //    slimeWidth = texture.Width / 4 - 46;
        //    slimeHeight = texture.Height - 30;
        //    playerState = PlayerState.Idle;
        //}

        /// <summary>
        /// Determines the player's movement based on the Player's input and state.
        /// </summary>
        public override void Move()
        {
            if (unstuckTimer < 0)
            {
                unstuckTimer = 0;
            }
            //Moves the player left or right a certain amount, as well as allowing for the player to jump and fall down if sticking on walls. 
            //Sticking will allow the fall option to happen, and allow for jumping. 
            keys = Keyboard.GetState();

            if (playerVelocity.Y > 1)
            {
                inAir = true;
            }
            
            //I think the current texture would also change based upon movement.
            if(!isSticking)
            {
                if (keys.IsKeyDown(Keys.A) || keys.IsKeyDown(Keys.Left))
                {
                    playerRectangle.X -= PlayerMovementSpeed;
                    jumpDirection = true;
                    
                }

                if (keys.IsKeyDown(Keys.D) || keys.IsKeyDown(Keys.Right))
                {
                    playerRectangle.X += PlayerMovementSpeed;
                    jumpDirection = false;
                }
            }

            //Player will only be able to fall when sticking on wall (can change later). At the moment, this isn't working as the variable is continually changing.
            if(isSticking)
            {
                //A redundancy for the player falling but immediately sticking back onto the wall should be accounted for (maybe changing position by a few pixels?)
                if (keys.IsKeyDown(Keys.S) || keys.IsKeyDown(Keys.Down))
                {
                    unstuckTimer = .3;
                    isSticking = false;
                }
            }

            //Will need to create gravity for the player, which can only work when the player is colliding with a "wall" (so that the player only has one jump, 
            //rather than a continual jump)
            if (!inAir)
            {
                if (IsKeyPressedOnce(Keys.W) || IsKeyPressedOnce(Keys.Up))
                {
                    playerState = PlayerState.Jump;
                    inAir = true;
                    playerVelocity.Y = jumpVelocity.Y;
                    playerState = PlayerState.Jump;
                    if (isSticking)
                    {
                        unstuckTimer = .3;
                        isSticking = false;

                        // Spacing the jumps from the wall
                        if (jumpDirection)
                        {
                            playerRectangle.X += 6;
                        }
                        else
                        {
                            playerRectangle.X -= 6;
                        }
                    }
                }

                playerState = PlayerState.Idle;
            }
            else
            {
                // Hold for higher jumps or floaty landing
                if ((keys.IsKeyDown(Keys.W) || keys.IsKeyDown(Keys.Up)) && playerVelocity.Y < 0)
                {
                    playerVelocity += higherJumpVelocity;
                }
            }
            lastKbState = keys;

            //If nothing, then "Idle Animation" texture.
            playerState = PlayerState.Idle;
        }

        /// <summary>
        /// Will draw the player to the screen.
        /// </summary>
        /// <param name="sb">The sprite batch</param>
        public override void Draw(SpriteBatch sb)
        {

            Rectangle sourceRect;

            //Rectangle sourceRect = new Rectangle((currentFrame - 1) * texture.Width / 4 + 24, 30, slimeWidth, slimeHeight);

            slimeWidth = texture.Width / 4;
            slimeHeight = texture.Height;
            sourceRect = new Rectangle((currentFrame - 1) * slimeWidth + 5, 11, slimeWidth - 12, slimeHeight - 12);
            spriteNum = 4;
            sb.Draw(spriteIdle, playerRectangle, sourceRect, Color.White);
        }

        public override void Update(GameTime gameTime)
        {
            UpdateAnimation(gameTime);
        }

        /// <summary>
        /// Updates the animation of the player.
        /// </summary>
        /// <param name="gameTime"></param>
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
        /// Determines if the player has collided with an object.
        /// </summary>
        /// <param name="otherObject">The other object the player may be interescting with.</param>
        /// <returns></returns>
        public override bool CollisionDetection(GameObject otherObject)
        {
            if (playerRectangle.Intersects(otherObject.position))
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Applies gravity to the player.
        /// </summary>
        public void ApplyGravity()
        {
            playerVelocity += gravity;
            playerRectangle.X += (int)playerVelocity.X;
            playerRectangle.Y += (int)playerVelocity.Y;
        }

        //public bool IsSticking()
        //{
        //    //If hits the left or right side of a wall, return true. If this method is true, moving is restricted to "W" and "S" to jump and fall down
        //    return true;
        //}

        /// <summary>
        /// Determines if the key is pressed once, to avoid multiple jumps at once.
        /// </summary>
        /// <param name="keySelected">Determines the last key selected.</param>
        /// <returns></returns>
        public bool IsKeyPressedOnce(Keys keySelected)
        {
            KeyboardState keys = Keyboard.GetState();

            if (lastKbState.IsKeyUp(keySelected) && keys.IsKeyDown(keySelected))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Subtracts the unstuck timer if it is greater than 0
        /// </summary>
        /// <param name="amount"> The amount to subtract the timer (usually GameTime.TotalSeconds </param>
        public void SubtractTimer (double amount)
        {
            if (unstuckTimer > 0)
            {
                unstuckTimer -= amount;
            }
        }
    }
}
