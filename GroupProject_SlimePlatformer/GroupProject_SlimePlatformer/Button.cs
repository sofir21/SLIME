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
    class Button : GameObject
    {
        //fields
        private Rectangle rect;
        private bool selected;
       
        public Button(Texture2D texture, int x, int y, int width, int height) : base(texture, x, y)
        {
            rect = new Rectangle(x, y, width, height);
            selected = false;
        }

        /// <summary>
        /// makes button be selected
        /// </summary>
        public void Select()
        {
            selected = true;
        }

        /// <summary>
        /// makes button be deselect
        /// </summary>
        public void Deselect()
        {
            selected = false;
        }

        /// <summary>
        /// checks if button is selected
        /// </summary>
        public bool IsSelected()
        {
            if (selected)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Draws buttons
        /// </summary>
        /// <param name="sb"></param>
        public override void Draw(SpriteBatch sb)
        {
            if (selected)
            {
                sb.Draw(texture, rect, Color.Green);
            }
            else
            {
                sb.Draw(texture, rect, Color.White);
            }
        }


    }
}
