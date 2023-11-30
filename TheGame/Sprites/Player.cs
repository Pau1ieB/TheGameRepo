using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace TheGame.Sprites
{
    public class Player:Sprite
    {
        public Player(Texture2D texture) : base(texture)
        {

        }
        public override void Update(GameTime gameTime, List<Sprite> sprites)
        {
            _previousKey = _currentKey;
            _currentKey = Keyboard.GetState();
            float _move = 0;
            if (!_isJumping && _currentKey.IsKeyDown(Keys.P))
            {
                VerticalVelocity = 60;
                _isJumping = true;
            }

            if (_currentKey.IsKeyDown(Keys.Q))
            {
                _facing = -1;
                _spriteEffects = SpriteEffects.FlipHorizontally;
                 _move = _facing;
           }
            else if (_currentKey.IsKeyDown(Keys.W))
            {
                _facing = 1;
                _spriteEffects = SpriteEffects.None;
                _move = _facing;
            }
            Position.X += _move * LinearVelocity;
            Position.Y -= VerticalVelocity - Game1.Gravity;
            if(VerticalVelocity > 0)VerticalVelocity-=5;
            if(Game1.HitLeft(Position.X))Position.X = 0;
            else if(Game1.HitRight(Position.X+_width)) Position.X = Game1._width-_width;

            if (Game1.HitBottom(Position.Y + _height)) { 
                Position.Y = Game1._height - _height; 
                _isJumping=false;
            }
        }
    }
}
