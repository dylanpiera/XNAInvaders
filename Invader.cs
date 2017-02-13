using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XNAInvaders
{
    class Invader
    {
        public Vector2 position;
        public Vector2 velocity;
        public Texture2D texture;
        public Texture2D[] textures = { Global.content.Load<Texture2D>("blue_invader"),
        Global.content.Load<Texture2D>("green_invader"),
        Global.content.Load<Texture2D>("red_invader"),
        Global.content.Load<Texture2D>("yellow_invader")
    };

        public Invader(int randomTexture)
        {
            texture = textures[randomTexture];
            Reset();
        }

        public void Reset()
        {
            position.X = Global.Random(100, (Global.width - 100));
            position.Y = Global.Random(0, (Global.height - 300));

            velocity.X = 3;
            velocity.Y = 10;
        }

        public void Update()
        {
            position.X += velocity.X;

            if(position.X > (Global.width - texture.Width) || (position.X < 0))
            {
                position.X -= velocity.X;
                velocity.X = -velocity.X;
                position.Y += velocity.Y;
            }
        }

        public void Draw()
        {
            Global.spriteBatch.Draw(texture, position, Color.White);
        }

    
    }
}
