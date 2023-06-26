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
        private float timer;


        public List<GameObject> gameObjects { get; set; } = new List<GameObject>();

        private static Character _player;
        private static Enemy _enemy;


        public static Character Player => _player;
        public static Enemy Enemy => _enemy;
        public void Initialization()
        {
            _time.Initialize();

            GameManager.instance.LevelController.gameObjects.Add(new Character(new Vector2(400, 850), new Vector2(4, 4), 0, 200));
            GameManager.instance.LevelController.gameObjects.Add(EnemyFactory.CreateEnemy(EnemyType.Punk, new Vector2(100, 950)));

            SoundPlayer musicPlayer = new SoundPlayer("Music/Music.wav");
            //musicPlayer.Play();
        }

        public void Update()
        {
            SetTimer(5f);
            timer -= Time.DeltaTime;

            _time.Update();
            foreach (GameObject Object in gameObjects) Object.Update();


            //for (int i = 0; i < gameObjects.Count; i++)
            //{
            //    gameObjects[i].Update();
            //}
            //_enemy.Update();
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

        public void SetTimer(float timer)
        {
            this.timer = timer;
        }
        public void IsTimerComplete()
        {
            if (timer <= 0f)
            {
                GameManager.instance.LevelController.gameObjects.Add(EnemyFactory.CreateEnemy(EnemyType.Punk, new Vector2(100, 900)));
                GameManager.instance.LevelController.gameObjects.Add(EnemyFactory.CreateEnemy(EnemyType.Punk, new Vector2(100, 800)));
                GameManager.instance.LevelController.gameObjects.Add(EnemyFactory.CreateEnemy(EnemyType.Punk, new Vector2(100, 950)));
                SetTimer(5f);
            }
            return;
        }

    }
}
