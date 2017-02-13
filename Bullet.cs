/* Empty version of the class *//*

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace XNAInvaders
{
    class Bullet
    {
        public Boolean isFired = false;
        public Vector2 position;
        public Vector2 velocity;
        public Texture2D texture;
        public const float speed = -3;

        //Constructor - Runs when a bullet is initialised.
        public Bullet()
        {
            texture = Global.content.Load<Texture2D>("bullet");
            Init();
        }

        //A random method. 
        public void Init()
        {
            isFired = false;
            position.X = -1000;
            velocity.Y = 0;
        }

        //Update the current instance of this class.
        public void Update()
        {
            if(isFired)
            {
                if(position.Y < 0)
                {
                    Init();
                }
            }
            position += velocity;
        }

        //Draw the current instance of this class.
        public void Draw()
        {
            Global.spriteBatch.Draw(texture, position, Color.White);
        }

        //Fire the bullet using the Player's posistion as the startPosistion.
        public void Fire(Vector2 startPosition)
        {
            if (!isFired)
            {
                isFired = true;
                position = startPosition;
                velocity.Y = speed;
            }
        }

        //There should be collision code here.
        //        public Boolean OverlapsInvader(Invader anInvader)
        //        {
        //        }

    }
}*/




///* Working Code *//*

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace XNAInvaders
{
    class Bullet
    {
        public bool isFired = false;
        public Vector2 position;
        public Vector2 velocity;
        public Texture2D texture;
        public const float speed = -8;

        public Bullet()
        {
            texture = Global.content.Load<Texture2D>("bullet");
            Reset();
        }

        public void Update()
        {
            if (isFired)
            {
                if (position.Y < 0)
                {
                    Reset();
                }
            }
            position.Y += velocity.Y;
        }

        public void Reset()
        {
            isFired = false;
            position.X = -1000;
            velocity.Y = 0;
        }

        public void Draw()
        {
            Global.spriteBatch.Draw(texture, position, Color.White);
        }

        public void Fire(Vector2 startPosition)
        {
            if (!isFired)
            {
                isFired = true;
                position.X = startPosition.X;
                position.Y = startPosition.Y;
                velocity.Y = speed;
            }            
        }

        public Boolean OverlapsInvader(Invader anInvader)
        {
            Rectangle bulletRect = new Rectangle((int)position.X, (int)position.Y, texture.Width, texture.Height);
            Rectangle invaderRect = new Rectangle((int)anInvader.position.X,(int)anInvader.position.Y,anInvader.texture.Width,anInvader.texture.Height);
            if (bulletRect.Intersects(invaderRect))
            {
                Reset();
                return true;
            }
            return false;
        }
        public Boolean OverlapsCavalry(Cavalry aCavalry)
        {
            Rectangle bulletRect = new Rectangle((int)position.X, (int)position.Y, texture.Width, texture.Height);
            Rectangle cavalryRect = new Rectangle((int)aCavalry.position.X, (int)aCavalry.position.Y, aCavalry.texture.Width, aCavalry.texture.Height);
            if (bulletRect.Intersects(cavalryRect))
            {
                Reset();
                return true;
            }
            return false;
        }

    }
}
//*/
