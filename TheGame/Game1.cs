using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using TheGame.Sprites;

namespace TheGame
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private List<Sprite> _sprites;
        public static float Gravity = 5;
        public int objectCount;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            _graphics.PreferredBackBufferWidth = 1280;
            _graphics.PreferredBackBufferHeight = 720;
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            objectCount = 0;
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            var playerTexture = Content.Load<Texture2D>("Player");
            var platformTexture = Content.Load<Texture2D>("Platform");
            var crateTexture = Content.Load<Texture2D>("Crate");
            var poisonTexture = Content.Load<Texture2D>("Poison");

            _sprites = new List<Sprite>()
            {
                new Player(playerTexture,0,_graphics.PreferredBackBufferHeight - playerTexture.Height,objectCount++),
                new Platform(platformTexture,300,400,objectCount++),
                new Item(crateTexture,400,_graphics.PreferredBackBufferHeight - playerTexture.Height,objectCount++), 
                new World(_graphics.PreferredBackBufferWidth, _graphics.PreferredBackBufferHeight)
            };
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            int count = 1;
            foreach (var sprite in _sprites.ToArray()) sprite.Update(gameTime, _sprites,count++);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            _spriteBatch.Begin();
            foreach (var sprite in _sprites) sprite.Draw(_spriteBatch);
            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
