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
        public static float Gravity = 10;
        public static int _width;
        public static int _height;

        public static bool HitLeft(float x) { return x<=0; }
        public static bool HitRight(float x) { return x >= _width; }
        public static bool HitTop(float y) { return y <= 0; }
        public static bool HitBottom(float y) { return y >= _height; }

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            _graphics.PreferredBackBufferWidth = 1280;
            _graphics.PreferredBackBufferHeight = 720;
            _width = 1280;
            _height = 720;
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

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
                new Player(playerTexture)
                {
                    Position = new Vector2(0,_graphics.PreferredBackBufferHeight - playerTexture.Height),
                    Origin = new Vector2(0,0)
                },
                new Platform(platformTexture)
                {
                    Position = new Vector2(300,400),
                    Origin = new Vector2(0,0)
                },
                new Item(crateTexture) 
                {
                    Position = new Vector2(400,_graphics.PreferredBackBufferHeight - playerTexture.Height),
                    Origin = new Vector2(0,0)
                }
            };
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            foreach (var sprite in _sprites.ToArray()) sprite.Update(gameTime, _sprites);

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
