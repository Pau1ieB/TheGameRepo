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

        public static bool Collision(float x1, float x2) { return x1 <= x2; }

        public GameObject(Vector2 pos, Vector2 dim, int weight, int id)
        {
            Position = pos;
            Dimension = dim;
            _weight = weight;
            _id = id;
        }

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
