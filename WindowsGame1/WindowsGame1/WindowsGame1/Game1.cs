using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using WindowsGame1.Classes;

namespace WindowsGame1
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        SpriteFont font;
        
        public static int score1;
        public static int score2;
        
        public static int screenWidth;
        public static int screenHeight;

        const  int PADDLE_OFFSET = 70;
         public const float BALL_START_SPEED = 3f;

        Jogador jogador1;
        Jogador jogador2;

        Bola bola;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        public void getScreenSize()
        {
            screenWidth = GraphicsDevice.Viewport.Width;
            screenHeight = GraphicsDevice.Viewport.Height;
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            getScreenSize();
            jogador1 = new Jogador(290);
            jogador2 = new Jogador(290);
            font = Content.Load<SpriteFont>("Content/SpriteFont1");
            bola = new Bola();

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
                
            // TODO: use this.Content to load your game content here
            jogador1.Texture = Content.Load<Texture2D>("Content/Paddle");
            jogador2.Texture = Content.Load<Texture2D>("Content/Paddle");

            jogador1.Position = new Vector2(PADDLE_OFFSET, screenHeight / 2 - jogador1.Texture.Height / 2);
            jogador2.Position = new Vector2(screenWidth - jogador2.Texture.Width - PADDLE_OFFSET, screenHeight / 2 - jogador2.Texture.Height / 2);

            bola.Texture = Content.Load<Texture2D>("Content/Ball");
            bola.Lauch(BALL_START_SPEED);
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();
            
            // TODO: Add your update logic here
            getScreenSize();
            bola.Move(bola.Velocity);
            jogador1.Move(Keys.W, Keys.S);
            jogador2.Move(Keys.Up, Keys.Down);
            bola.CheckWallCollision();
            bola.CheckCollisionJog(jogador1);
            bola.CheckCollisionJog(jogador2);
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);
            // TODO: Add your drawing code here
            spriteBatch.Begin();
            jogador1.Draw(spriteBatch);
            jogador2.Draw(spriteBatch);
            bola.Draw(spriteBatch);
            spriteBatch.DrawString(font,score1.ToString(),new Vector2((screenWidth / 2) - 35,45),Color.White);
            spriteBatch.DrawString(font, score2.ToString(), new Vector2((screenWidth / 2) + 15, 45), Color.White);
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}