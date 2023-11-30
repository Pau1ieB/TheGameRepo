using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using tutorial2.Models;

namespace TheGame.Sprites
{
    public class Sprite : ICloneable
    {
        protected Texture2D _texture;
        protected int _width;
        protected int _height;
        protected float _rotation;
        protected KeyboardState _currentKey;
        protected KeyboardState _previousKey;
        protected SpriteEffects _spriteEffects = SpriteEffects.None;
        public Vector2 Position;
        public Vector2 Origin;


        public Vector2 Direction;
        public float RotationVelocity = 3f;

        public float LinearVelocity = 4f;
        public int _facing = 1;

        public float VerticalVelocity = 0;
        protected bool _isJumping = false;

        public Sprite Parent;

        public Input Input;

        public float LifeSpan = 0f;
        public bool IsRemoved = false;

        public Sprite(Texture2D texture)
        {
            _texture = texture;
            _width= texture.Width;
            _height= texture.Height;
        }

        public Rectangle Rectangle
        {
            get
            {
                return new Rectangle((int)Position.X, (int)Position.Y, _texture.Width, _texture.Height);
            }
        }

        public virtual void Update(GameTime gameTime, List<Sprite> sprites) { }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_texture, Position, null, Color.White, _rotation, Origin, 1, _spriteEffects, 0);
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
