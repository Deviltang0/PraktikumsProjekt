using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace SkellyInvaders.Enemies
{
    internal abstract class GameObject
    {
        protected Vector2 _position; public Vector2 Position { get { return _position; } set { _position = value; } }
        protected Texture2D _skulls;
        protected int _speed;
        protected double _dt;
        protected Rectangle _collider; public Rectangle Collider { get { return _collider; } set { _collider = value; } }
        protected bool _isCollided = false; public bool IsCollided { get { return _isCollided; } set { _isCollided = value; } }
        public abstract void Update(GameTime gameTime);
        public abstract void Draw(SpriteBatch spriteBatch);

    }

}
