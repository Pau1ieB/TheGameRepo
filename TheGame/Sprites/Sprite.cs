using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using tutorial2.Models;

namespace TheGame.Sprites
{
    public class Sprite : GameObject
    {
        protected Texture2D _texture;
        protected float _rotation;
        protected KeyboardState _currentKey;
        protected KeyboardState _previousKey;
        protected SpriteEffects _spriteEffects = SpriteEffects.None;
        public Vector2 Origin;

        public float LinearVelocity = 4f;
        public float CurrentLinearVelocity = 0;
        public bool _isLinearMoving = false;
        public int _facing = 1;

        public float VerticalVelocity = 0;
        protected bool _isVerticalMoving = false;

        public Vector2 Direction;
        public float RotationVelocity = 3f;
        public Sprite Parent;

        public Sprite(Texture2D texture, float top, float left, int id):base( new Vector2(top, left), new Vector2(texture.Width, texture.Height),1,id)
        {
            _texture = texture;
        }

        public Sprite(float top, float left, float width, float height) : base(new Vector2(top, left), new Vector2(width, height), 50, -1)
        {

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
