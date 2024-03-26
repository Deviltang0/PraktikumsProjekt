using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SharpDX.Direct2D1;
using SkellyInvaders.Enemies;
using SpriteBatch = Microsoft.Xna.Framework.Graphics.SpriteBatch;


namespace SkellyInvaders
{

    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        Player _player = new();

        static public Texture2D ProjTexture;
        static public Texture2D Skull1Texture;
        static public Texture2D Skull2Texture;
        static public Texture2D Background;
        private bool _gameOver = false;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
           
            _graphics.PreferredBackBufferWidth = 1600;
            _graphics.PreferredBackBufferHeight = 900;

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            _player.LoadContent(Content);
            ProjTexture = Content.Load<Texture2D>("Player/tracer");
            Skull1Texture = Content.Load<Texture2D>("Skulls/skull");
            Skull2Texture = Content.Load<Texture2D>("Skulls/skullnew");
            Background = Content.Load<Texture2D>("Background/bg");
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            if (!_gameOver)
            {


                _player.Update(gameTime);
                foreach (Projectile proj in Projectile.Projectiles)
                {
                    proj.Update(gameTime);
                }

                foreach (GameObject skulls in EnemyController.Skulls)
                {
                    skulls.Update(gameTime);
                    if (skulls.Position.Y > 500)
                    {
                        _gameOver = true;
                    }
                }
                foreach (Projectile _proj in Projectile.Projectiles)
                {
                    foreach (GameObject skull in EnemyController.Skulls)
                    {
                        if (_proj.Collider.Intersects(skull.Collider))
                        {
                            _proj.IsCollided = true;
                            skull.IsCollided = true;
                        }
                    }
                }


            }
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            _spriteBatch.Begin();

            _spriteBatch.Draw(Background, Vector2.Zero, null, Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, 0);


            _player.Draw(_spriteBatch);
            if (!_gameOver)
            {

                foreach (Projectile proj in Projectile.Projectiles)
                {
                    proj.Draw(_spriteBatch);
                }
                foreach (GameObject skulls in EnemyController.Skulls)
                {
                    skulls.Draw(_spriteBatch);
                }
            }
            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}