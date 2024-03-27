using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace SkellyInvaders.Enemies
{
    internal class Skull1 : GameObject
    {




        public Skull1(Vector2 position)
        {
            _position = position;
            _speed = 75;
            _skulls = Game1.Skull1Texture;
            _collider = new Rectangle((int)position.X, (int)position.Y, 32, 32);

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
            if (_position.X > Game1.ResolutionWidth - 100)
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

