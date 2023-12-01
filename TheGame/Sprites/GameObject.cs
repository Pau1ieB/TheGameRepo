using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace TheGame.Sprites
{
    public class GameObject : ICloneable
    {
        public Vector2 Position;
        public Vector2 Dimension;
        public int _weight;
        public int _id;

        public GameObject(Vector2 pos, Vector2 dim, int weight, int id)
        {
            Position = pos;
            Dimension = dim;
            _weight = weight;
            _id = id;
        }

        public virtual bool isLevel(float y1, float y2) 
        {
            return !(y2 < Position.Y || y1 > Position.Y + Dimension.Y);
        }

        public virtual bool HitLeft(float x1, float x2){ return (x2 >= Position.X && x1<Position.X);}

        public virtual bool HitRight(float x1, float x2) {
            float right = RightSide();
            return (x1<= right && x2> right);
        }

        public virtual float LeftSide() { return Position.X;}
        public virtual float RightSide() { return Position.X + Dimension.Y;}


        public Rectangle Rectangle
        {
            get
            {
                return new Rectangle((int)Position.X, (int)Position.Y, (int)Dimension.X, (int)Dimension.Y);
            }
        }

        public virtual void OnCollision() {}

        object ICloneable.Clone()
        {
            throw new NotImplementedException();
        }
    }
}
