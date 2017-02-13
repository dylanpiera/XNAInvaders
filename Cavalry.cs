using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XNAInvaders
{
    class Cavalry
    {
        public Vector2 position;
        public Vector2 velocity;
        public Texture2D texture;
        public int lives;

        public Cavalry()
        {
            texture = Global.content.Load<Texture2D>("enemy_ship");
            Reset();
        }

        public void Reset()
        {
            position.X = Global.Random(100, (Global.width - 100));
            position.Y = Global.Random(0, 100);
            lives = 2;
            velocity.X = 3;
        }

        public void Update()
        {
            if(lives == 0)
            {
                Reset();
            }
            position.X += velocity.X;

            if (position.X > (Global.width - texture.Width) || (position.X < 0))
            {
                position.X -= velocity.X;
                velocity.X = -velocity.X;
            }
        }

        public void Draw()
        {
            if(lives == 2)
            {
                texture.GraphicsDevice.BlendFactor = Color.SlateGray;
            } else
            {
                texture.GraphicsDevice.BlendFactor = Color.White;
            }
            Global.spriteBatch.Draw(texture, position,texture.GraphicsDevice.BlendFactor);
        }
    }
}
