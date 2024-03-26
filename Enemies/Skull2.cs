using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SkellyInvaders.Enemies
{
    internal class Skull2 : GameObject
    {

        public Skull2(Vector2 position)
        {
            _position = position;
            _speed = 50;
            _skulls = Game1.Skull2Texture;
            _collider = new Rectangle((int)position.X, (int)position.Y, 16, 16);

        }



        public override void Update(GameTime gameTime)
        {
            _dt = gameTime.ElapsedGameTime.TotalSeconds;


            if (EnemyController.Dir == Direction.Left)
            {
                _position.X -= _speed * (float)_dt;
            }
            if (EnemyController.Dir == Direction.Right)
            {
                _position.X += _speed * (float)_dt;
            }
            if (_position.X < 100)
            {
                EnemyController.Dir = Direction.Right;
                EnemyController.Jump = true;
            }
            if (_position.X > 700)
            {
                EnemyController.Dir = Direction.Left;
                EnemyController.Jump = true;
            }
            _collider.X = (int)_position.X;
            _collider.Y = (int)_position.Y;

        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_skulls, _position, Color.White);
        }

    }
}
