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
        public GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        Player _player = new();
        EnemyController _enemyController = new();

        static public int ResolutionWidth;
        static public int ResolutionHeight;

        static public Texture2D ProjTexture;
        static public Texture2D Skull1Texture;
        static public Texture2D Skull2Texture;
        static public Texture2D Background;
        static public SpriteFont SpaceFont;



        private bool _gameOver = false;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            _graphics.IsFullScreen = true;
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
           
            ResolutionWidth = 1000;
            ResolutionHeight = 740;
            _graphics.PreferredBackBufferWidth = ResolutionWidth;
            _graphics.PreferredBackBufferHeight = ResolutionHeight;
            _graphics.ApplyChanges();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            _player.LoadContent(Content);
            ProjTexture = Content.Load<Texture2D>("Player/tracer");
            Skull1Texture = Content.Load<Texture2D>("Skulls/skull");
            Skull2Texture = Content.Load<Texture2D>("Skulls/skull2");
            Background = Content.Load<Texture2D>("Background/Cosmic_Frontier_-_VNM_02");
            SpaceFont = Content.Load<SpriteFont>("Fonts/spaceFont");
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            if (!_gameOver)
            {

                _enemyController.UpdateController(gameTime);
                _player.Update(gameTime);
                foreach (Projectile proj in Projectile.Projectiles)
                {
                    proj.Update(gameTime);
                }

                foreach (GameObject skulls in EnemyController.Skulls)
                {
                    skulls.Update(gameTime);
                    if (skulls.Position.Y > ResolutionWidth - 100)
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
                Projectile.Projectiles.RemoveAll(e => e.IsCollided);
                EnemyController.Skulls.RemoveAll(e => e.IsCollided);

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
            _spriteBatch.DrawString(SpaceFont, "SKELLY INVADERS", new Vector2(270,10), Color.White);
            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}