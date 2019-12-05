using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Monogame.Models;
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
        Character character;
        Texture2D spriteTexture2D;

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
            spriteTexture2D = Content.Load<Texture2D>("teste");
            sprite = new Character(spriteTexture2D);
            sprite = new Sprite(spriteTexture2D);
            sprite.Input = new Input();
            sprite.Input.Up = Keys.W;
            sprite.Input.Down = Keys.S;
            sprite.Input.Left = Keys.A;
            sprite.Input.Right = Keys.D;
            sprite.Input.Sprint = Keys.LeftShift;
            sprite.Input.Jump = Keys.Space;

            // TODO: use this.Content to load your game content here
            var animations = new Dictionary<string, Animation>();
            animations.Add("WalkUp", new Animation(Content.Load<Texture2D>("stop"), 17) { FrameSpeed = 0 }) ;
            animations.Add("WalkDown", new Animation(Content.Load<Texture2D>("stop"), 17) { FrameSpeed = 0 }) ;
            animations.Add("WalkRight", new Animation(Content.Load<Texture2D>("WalkRight"), 1) { FrameSpeed = 0 }) ;
            animations.Add("WalkLeft", new Animation(Content.Load<Texture2D>("stop"), 17) { FrameSpeed = 0f }) ;
            character = new Character(animations);
            character.Speed = 1.2f;
            character.Input = new Input();
            character.Input.Up = Keys.Up;
            character.Input.Down = Keys.Down;
            character.Input.Left = Keys.Left;
            character.Input.Right = Keys.Right;
            character.Input.Jump = Keys.RightShift;
            character.Input.Sprint = Keys.RightControl;

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
            sprite.Velocity.Y += sprite.Speed;
            // TODO: Add your update logic here
            sprite.Update(gameTime);
            sprite.Position = new Vector2  (Math.Min(Math.Max(0, sprite.Position.X), graphics.PreferredBackBufferWidth - sprite.Texture2D.Width),
                                            Math.Min(Math.Max(0, sprite.Position.Y), graphics.PreferredBackBufferHeight - sprite.Texture2D.Height));

            // TODO: Add your update logic here
            //character.Velocity.Y += character.Speed;
            character.Update(gameTime);
            character.Position = new Vector2  (Math.Min(Math.Max(0, character.Position.X), graphics.PreferredBackBufferWidth - character.AnimationManager.Animation.FrameWidth),
                                                Math.Min(Math.Max(0, character.Position.Y), graphics.PreferredBackBufferHeight - character.AnimationManager.Animation.FrameHeight));
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
            sprite.Draw(spriteBatch);
            character.Draw(spriteBatch);
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
