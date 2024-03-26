using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.Security.Policy;

namespace SkellyInvaders
{
    internal class Projectile
    {
        static List<Projectile> _projectiles = new();
        public static List<Projectile> Projectiles { get { return _projectiles; } set { _projectiles = value; } }
        private Vector2 _position;
        private Texture2D _projectileTexture = Game1.ProjTexture;
        private int _speed = 300;
        private float _rotation; public float Rotation { get { return (_rotation); } set { _rotation = value; } }
        private double _dt;
        private Rectangle _collider; public Rectangle Collider { get { return _collider; } set { _collider = value; } }
        private bool _isCollided = false; public bool IsCollided { get { return _isCollided; } set { _isCollided = value; } }


        public Projectile(Vector2 position)
        {
            _position = position;
            _rotation = 90;
            _collider = new Rectangle((int)position.X, (int)position.Y, 8, 8);
        }


        public void Update(GameTime gameTime)
        {
            _dt = gameTime.ElapsedGameTime.TotalSeconds;
            _position.Y -= _speed * (float)_dt;
            _collider.X = (int)_position.X;
            _collider.Y = (int)_position.Y;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_projectileTexture, _position, Color.White);
        }

    }
}
