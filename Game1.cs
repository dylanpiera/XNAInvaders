
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.GamerServices;
using System.Collections;

namespace XNAInvaders
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Texture2D background, scanlines;
        List<Invader> invaders = new List<Invader>();
        List<Cavalry> theCavalry = new List<Cavalry>();
        int nInvaders = 15, nCavalry = 1;

        Player thePlayer;
        Bullet theBullet;

        //TODO: Add multiple invaders here

        public Game1()
            : base()
        {
            graphics = new GraphicsDeviceManager(this);            
            graphics.PreferredBackBufferHeight = 600;
            graphics.PreferredBackBufferWidth = 800;
 
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // Pass often referenced variables to Global
            Global.GraphicsDevice = GraphicsDevice;            
            Global.content = Content;

            // Create and Initialize game objects
            thePlayer = new Player();
            theBullet = new Bullet();

            ///* Spawning in off the enemies - Uncomment when enemies are implemented.
            for (int i = 0;i < nInvaders;i++)
            {
                invaders.Add(new Invader(Global.Random(0,4)));
            }
            for (int i = 0; i < nCavalry; i++)
            {
                theCavalry.Add(new Cavalry());
            }//*/

            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            Global.spriteBatch = spriteBatch;
            background = Content.Load<Texture2D>("background");
            scanlines = Content.Load<Texture2D>("scanlines");
            base.Initialize();
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            // Pass keyboard state to Global so we can use it everywhere
            Global.keys = Keyboard.GetState();
            if (Global.keys.IsKeyDown(Keys.Space)) theBullet.Fire(thePlayer.position);
            // Update the game objects
            thePlayer.Update();
            theBullet.Update();

            base.Update(gameTime);

            ///* Collision code - Uncomment when Bullet collision has been implemented.
            foreach (Invader invader in invaders)
            {
                invader.Update();
                if(theBullet.OverlapsInvader(invader))
                {
                    invader.Reset();
                }
            }
            foreach (Cavalry cavalry in theCavalry)
            {
                cavalry.Update();
                if (theBullet.OverlapsCavalry(cavalry))
                {
                    cavalry.lives--;
                }
            }//*/
        }
    

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {            
            spriteBatch.Begin();
            // Draw the background (and clear the screen)
            spriteBatch.Draw(background, Global.screenRect, Color.White);

            // Draw the game objects
            thePlayer.Draw();
            theBullet.Draw();

            ///* Draw enemies - Uncomment when enemies are implemented.
            foreach (Invader invader in invaders)
            {
                invader.Draw();
            }
            foreach (Cavalry cavalry in theCavalry)
            {
                cavalry.Draw();
            }//*/

            spriteBatch.Draw(scanlines, Global.screenRect, Color.White);
            spriteBatch.End();

            base.Draw(gameTime);

            
        }
    }
}
