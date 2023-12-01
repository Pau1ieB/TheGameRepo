using Microsoft.Xna.Framework.Graphics;

namespace TheGame.Sprites
{
    public class World:Sprite
    {
        public World(float width, float height) : base(0,0,width, height) { }

        public override bool isLevel(float y1, float y2) { return true; }

        public override bool HitRight(float x1, float x2) { return (x1 <= 0); }

        public override bool HitLeft(float x1, float x2) { return x2 >= Dimension.X; }

        public override float LeftSide() { return Dimension.X; }

        public override float RightSide() { return 0; }

        public override void Draw(SpriteBatch spriteBatch) { }
    }
}
