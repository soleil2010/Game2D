using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Monogame.Models;
using Monogame.Models.terrain;
using Monogame.Sprites;
using System;
using System.Collections.Generic;

namespace Monogame
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Sprite sprite;
        List<Plateform> plateforms;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferHeight = 900;
            graphics.PreferredBackBufferWidth = 900;
            Content.RootDirectory = "Content";
            this.IsMouseVisible = true;
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
            sprite = new Sprite(Content.Load<Texture2D>("crouch"))
            {
                Speed = 2,
                Input = new Input()
                {
                    Up = Keys.W,
                    Left = Keys.A,
                    Down = Keys.S,
                    Right = Keys.D,
                },
            };
            plateforms = new List<Plateform>()
            {
                { new Plateform(Content.Load<Texture2D>("rectangle"), new Vector2(20, 5))},
                { new Plateform(new Rectangle(100,500,50,20)) },
                { new Plateform( new Rectangle(300,200,50,20), Color.Red) },
                { new Plateform(Content.Load<Texture2D>("rectangle"), new Rectangle(10,this.graphics.PreferredBackBufferHeight-50,50,10)) },
            };
    }
        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
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
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            sprite.Update(gameTime);
            // TODO: Add your update logic here
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();

            // TODO: Add your drawing code here
            foreach (var plateform in plateforms)
                plateform.Draw(spriteBatch);

            sprite.Draw(spriteBatch);      
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
