using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;



namespace SkellyInvaders
{
    internal class Player
    {


        private Vector2 _position = new Vector2(500, 650);
        KeyboardState _kState;
        double _dt;
        float _speed = 300;
        Texture2D _playerTexture;
        private double _cdTime = 0.0;




        public void LoadContent(ContentManager contentManager)
        {
            _playerTexture = contentManager.Load<Texture2D>("Player/ship");

        }


        public void Update(GameTime gameTime)
        {
            _kState = Keyboard.GetState();
            _dt = gameTime.ElapsedGameTime.TotalSeconds;

            // move player left...
            if (_kState.IsKeyDown(Keys.A) && _position.X > 10)
            {

                _position.X -= _speed * (float)_dt;


            }
            // move player right...
            if (_kState.IsKeyDown(Keys.D) && _position.X < Game1.ResolutionWidth - 10)
            {

                _position.X += _speed * (float)_dt;

            }

            if (_kState.IsKeyDown(Keys.Space) && _cdTime < 0)
            {
                Projectile.Projectiles.Add(new Projectile(_position));
                _cdTime = 0.5;

            }
            _cdTime -= _dt;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_playerTexture, _position, Color.White);
        }

    }
}
