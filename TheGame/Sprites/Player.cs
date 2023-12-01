using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace TheGame.Sprites
{
    public class Player:Sprite
    {
        public Player(Texture2D texture,float top,float left, int id) : base(texture,top,left, id){}

        public override void Update(GameTime gameTime, List<Sprite> sprites)
        {
            _previousKey = _currentKey;
            _currentKey = Keyboard.GetState();
            if (!_isVerticalMoving && _currentKey.IsKeyDown(Keys.P))
            {
                VerticalVelocity = 40;
                _isVerticalMoving = true;
            }
            if (!_isVerticalMoving)
            {
                if (_currentKey.IsKeyDown(Keys.Q))
                {
                    if (!_isLinearMoving)
                    {
                        _isLinearMoving = true;
                        _facing = -1;
                        _spriteEffects = SpriteEffects.FlipHorizontally;
                    }
                    if (_facing == 1) CurrentLinearVelocity -= 0.1f;
                    else CurrentLinearVelocity = LinearVelocity;
                }
                else if (_currentKey.IsKeyDown(Keys.W))
                {
                    if (!_isLinearMoving)
                    {
                        _isLinearMoving = true;
                        _facing = 1;
                        _spriteEffects = SpriteEffects.None;
                    }
                    if (_facing == -1) CurrentLinearVelocity -= 0.1f;
                    else CurrentLinearVelocity = LinearVelocity;
                }
            }
            Position.X += _facing * CurrentLinearVelocity;
            if (!_isVerticalMoving && _isLinearMoving)
            {
                CurrentLinearVelocity -= 0.03f;
                if(CurrentLinearVelocity <= 0.0f)_isLinearMoving = false;
            }
            Position.Y -= VerticalVelocity - Game1.Gravity;
            if(VerticalVelocity > 0)VerticalVelocity-=2;
            if (GameObject.Collision(Position.X, sprites[0].Position.X))
            {
                Position.X = 0;
                _isLinearMoving = false;
                CurrentLinearVelocity = 0;
            }
            else if (GameObject.Collision(sprites[0].Dimension.X - Dimension.X, Position.X)) 
            { 
                Position.X = sprites[0].Dimension.X - Dimension.X;
                _isLinearMoving = false;
                CurrentLinearVelocity = 0;
            }
            if(GameObject.Collision(sprites[0].Dimension.Y - Dimension.Y, Position.Y))
            { 
                Position.Y = sprites[0].Dimension.Y - Dimension.Y;
                _isVerticalMoving = false;
            }
        }
    }
}
