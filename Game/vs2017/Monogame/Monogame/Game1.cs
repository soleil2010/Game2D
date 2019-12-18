using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Monogame.Manages;
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
        Gravity gravityClass;
        List<Plateform> plateforms;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferHeight = 1000;
            graphics.PreferredBackBufferWidth = 1900;
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
            gravityClass = new Gravity();
            // TODO: use this.Content to load your game content here
            sprite = new Sprite(Content.Load<Texture2D>("crouch"))
            {
                Looking = Sprite.Direction.Right,
                gravity = gravityClass.GravityValue,
                Speed = 11,
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
                { new Plateform(Content.Load<Texture2D>("rectangle"), new Rectangle(200,this.graphics.PreferredBackBufferHeight-50,50,20)) },
                { new Plateform(Content.Load<Texture2D>("rectangle"), new Rectangle(300,this.graphics.PreferredBackBufferHeight-100,50,20)) },
                { new Plateform(new Rectangle(400,this.graphics.PreferredBackBufferHeight-150,50,20)) },
                { new Plateform(new Rectangle(500,this.graphics.PreferredBackBufferHeight-100,50,20), Color.SandyBrown) },
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
            //sprite has gravity
            sprite.Update(gameTime);

            //sprite has gravity
            sprite.grounded = false;

            foreach (var plateform in plateforms)
            {
                if(Collision(sprite, plateform) && sprite.Looking != Sprite.Direction.Up)
                {
                    Console.WriteLine(sprite.Rectangle.Bottom);
                    //sprite is on the top of plateform
                    if (sprite.Rectangle.Bottom >= plateform.Rectangle.Top &&
                        sprite.Rectangle.Bottom <= plateform.Rectangle.Bottom - plateform.Rectangle.Height*0.85)
                    {
                        //replace sprite on the top of plateform
                        sprite.Position = new Vector2(sprite.Position.X, plateform.Rectangle.Top-sprite.Texture.Height);
                        //sprite no longer undergoes gravity
                        sprite.grounded = true;
                    }
                }
            }

            if ((sprite.Position.Y + sprite.Texture.Height) == graphics.PreferredBackBufferHeight)
            {
                sprite.grounded = true;
            }
            // Update gravity of the sprite
            gravityClass.Timer = gameTime.ElapsedGameTime.TotalSeconds;
            if (sprite.grounded == true)
            {
                gravityClass.PreviousSpeed = 0;
                gravityClass.PreviousTimer = (int)gameTime.TotalGameTime.TotalSeconds;
            }
            else
                sprite.Position += new Vector2(0, gravityClass.SpeedChange());

            //sprite can't leave the area of game
            sprite.Position = new Vector2(Math.Min(Math.Max(0, sprite.Position.X), graphics.PreferredBackBufferWidth - sprite.Texture.Width),
                                          Math.Min(Math.Max(0, sprite.Position.Y), graphics.PreferredBackBufferHeight - sprite.Texture.Height));

            base.Update(gameTime);
        }

        /// <summary>
        /// Check if sprite is on top of terrain
        /// </summary>
        /// <param name="sprite">all objects which is inheritance of the sprite</param>
        /// <param name="terrain">all objects which is inheritance of the terrain</param>
        /// <returns>true when the bottom of sprite is on the platform and at the top of it</returns>
        private bool Collision(Sprite sprite, Terrain terrain)
        {
            bool collision = false;
            //coordinate of x positions of sprite
            float xSpriteLeft = sprite.Position.X;
            float xSpriteRight = sprite.Position.X + sprite.Texture.Width;
            //coordinate of y positions of sprite
            float ySpriteTop = sprite.Position.Y;
            float ySpriteBottom = sprite.Position.Y + sprite.Texture.Height;

            //coordinate of x positions of terrain
            float xTerrainLeft = terrain.Position.X;
            float xTerrainRight = terrain.Position.X + terrain.Size.X;
            //coordinate of y positions of terrain
            float yTerrainTop = terrain.Position.Y;

            if (ySpriteBottom > yTerrainTop && ySpriteBottom < yTerrainTop + terrain.Size.Y)
            {
                if (xSpriteLeft > xTerrainLeft && xSpriteLeft < xTerrainRight)
                    collision = true;
                if(xSpriteRight > xTerrainLeft && xSpriteRight < xTerrainRight)
                    collision = true;
                if (xTerrainLeft > xSpriteLeft - xSpriteLeft * 0.1 && xSpriteRight + xSpriteRight * 0.1 > xTerrainRight)
                    collision = true;
            }

            return collision;
        }
        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();

            //Draw platforms
            foreach (var plateform in plateforms)
                plateform.Draw(spriteBatch);

            sprite.Draw(spriteBatch);      
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
