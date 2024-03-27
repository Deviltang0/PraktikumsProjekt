using Microsoft.Xna.Framework;
using System.Collections.Generic;


namespace SkellyInvaders.Enemies
{
    enum Direction { Left, Right }

    internal class EnemyController
    {
        private double _dt;
        static List<GameObject> _skulls = new();
        static public List<GameObject> Skulls { get { return _skulls; } set { _skulls = value; } }
        static Direction _dir = Direction.Left;
        static bool _jump = false; static public bool Jump { get { return _jump; } set { _jump = value; } }


        //Enemyspawn
        int totalEnemiesX = 10;
        int totalEnemiesY = 10;
        int spacingX = 40;
        int spacingY = 30;
        Vector2 startSpawnPos = new Vector2(100, 100);

        static public Direction Dir
        {
            get { return _dir; }
            set { _dir = value; }
        }

        public void UpdateController(GameTime gameTime)
        {
            _dt = gameTime.ElapsedGameTime.TotalSeconds;
            //all enemies cleared, spawn new
            if (_skulls.Count == 0)
            {
                for (int i = 0; i < totalEnemiesY; i++)
                    for (int j = 0; j < totalEnemiesX; j++)
                    {
                        if (i < 7)
                        {
                            SpawnSkull1(new Vector2(startSpawnPos.X + j * spacingX, startSpawnPos.Y + i * spacingY));
                        }
                        else
                        {
                            SpawnSkull2(new Vector2(startSpawnPos.X + j * spacingX, startSpawnPos.Y + i * spacingY));
                        }
                    }

            }
            if (_jump)
            {
                foreach (GameObject Skulls in _skulls)
                {
                    Skulls.Position = new Vector2(Skulls.Position.X, Skulls.Position.Y + 20);
                }
                _jump = false;
            }
        }
        public void SpawnSkull1(Vector2 spawnPosition)
        {
            EnemyController._skulls.Add(new Skull1(spawnPosition));
        }
        public void SpawnSkull2(Vector2 spawnPosition)
        {
            EnemyController._skulls.Add(new Skull2(spawnPosition));
        }
    }

}
