using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class LevelController
    {
        private static Time _time;
        private static DateTime spawnTime;
        private static DateTime currentTime;
        private static float TotalSeconds;
        public int killedEnemies = 0;
        private float timer;
        Random _random = new Random();


        public List<GameObject> gameObjects { get; set; } = new List<GameObject>();
        private Vector2 RandomVector2() => new Vector2(_random.Next(1200, 1900), _random.Next(800, 1000));
        private Vector2 RandomVector2Left() => new Vector2(_random.Next(0, 300), _random.Next(800, 1000));



        private static Character _player;
        private static Enemy _enemy;


        public static Character Player => _player;
        public static Enemy Enemy => _enemy;

        private GenericEnemyFactory factory;
        public void Initialization()
        {
            _time.Initialize();
            GameManager.Instance.wave1 = true;
            GameManager.Instance.wave2 = false;
            GameManager.Instance.wave3 = false;


            factory = new GenericEnemyFactory();

            _player = new Character(new Vector2(400, 850), new Vector2(4, 4), 0, 200);
            GameManager.instance.LevelController.gameObjects.Add(_player);
            GameManager.instance.LevelController.gameObjects.Add(factory.CreateEnemy(EnemyType.Punk, new Vector2(1900, 900)));
            GameManager.instance.LevelController.gameObjects.Add(factory.CreateEnemy(EnemyType.Punk, new Vector2(1800, 950)));
            GameManager.instance.LevelController.gameObjects.Add(factory.CreateEnemy(EnemyType.Punk, new Vector2(1600, 850)));
            GameManager.instance.LevelController.gameObjects.Add(factory.CreateEnemy(EnemyType.Punk, new Vector2(1250, 800)));
            GameManager.instance.LevelController.gameObjects.Add(factory.CreateEnemy(EnemyType.Punk, new Vector2(800, 850)));


            SoundPlayer musicPlayer = new SoundPlayer("Music/MusicTheme.wav");
            //musicPlayer.Play();
        }

        public void Update()
        {
            //SetTimer(5f);
            timer -= Time.DeltaTime;

            _time.Update();
            //foreach (GameObject Object in gameObjects) Object.Update();


            for (int i = 0; i < gameObjects.Count; i++)
            {
                gameObjects[i].Update();
            }

            if (killedEnemies == 5 && GameManager.Instance.wave1 == true)
            {
                SpawnWave();
                GameManager.Instance.wave1 = false;
                GameManager.Instance.wave2 = true;

            }

            if (killedEnemies == 10 && GameManager.Instance.wave2 == true)
            {
                SpawnWave();
                GameManager.Instance.wave2 = false;
                GameManager.Instance.wave3 = true;

                if (GameManager.Instance.wave3 == true)
                {
                    Game.Engine.Debug("Wave 3\n");
                }
                
            }

            if(killedEnemies == 15)
            {
                GameManager.Instance.wave3 = false;
                GameManager.Instance.ChangeGameState(GameState.WinScreen);
            }
        }

        public void Render()
        {
            Engine.Clear();

            Engine.Draw("Textures/Backgrounds/Current_Avenue_1.png", 0, 0, 1, 1, 0, 0, 0);

            //foreach (Enemy enemy in enemies) enemy.Render();
            foreach (GameObject Object in gameObjects) Object.Render();
            //foreach (Character character in characters) character.Render();

            Engine.Show();
        }

        //public void SetTimer(float timer)
        //{
        //    this.timer = timer;
        //}

        //public void IsTimerComplete()
        //{
        //    if (timer <= 0f)
        //    {
        //        GameManager.instance.LevelController.gameObjects.Add(factory.CreateEnemy(EnemyType.Punk, new Vector2(100, 900)));
        //        GameManager.instance.LevelController.gameObjects.Add(factory.CreateEnemy(EnemyType.Punk, new Vector2(100, 800)));
        //        GameManager.instance.LevelController.gameObjects.Add(factory.CreateEnemy(EnemyType.Punk, new Vector2(100, 950)));
        //        SetTimer(5f);
        //    }
        //    return;
        //}


        public void SumKilledEnemies()
        {
            killedEnemies += 1;
        }

        public void SpawnWave()
        {
            for (int i = 0; i < 5; i++)
            {
                GameManager.instance.LevelController.gameObjects.Add(factory.CreateEnemy(EnemyType.Punk, RandomVector2()));         
            }
        }
    }
}
