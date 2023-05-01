using System;
using System.Collections.Generic;
using System.Media;

namespace Game
{
    public class Program
    {
        // Timeframe Calculation Properties
        private static Time _time;

        private static List<Character> characters = new List<Character>();
        private static List<Enemy> enemies = new List<Enemy>();

        private static Character _player;
        private static Enemy _enemy;


        public static Character Player => _player;
        public static Enemy Enemy => _enemy;


        static void Main(string[] args)
        {
            Engine.Initialize("Game", 1920, 1080);
            GameManager.Instance.Initialization();
            Initialization();

            while (true)
            {
                Update();
                GameManager.Instance.Update();
                GameManager.Instance.Render();
            }
        }

        private static void Initialization()
        {
            _time.Initialize();

            _player = new Character("Textures/BG/IdleAnim/idle1.png", new Vector2(400, 850), new Vector2(4, 4), 0, 200);

            _enemy = new Enemy("Textures/Punk/IdleAnim/idle1.png", new Vector2(900, 850), new Vector2(4, 4), 0, 0);


        }

        private static void Update()
        {
            foreach (Enemy enemy in enemies) enemy.Update();
            foreach (Character character in characters) character.Update();


            _time.Update();
            _player.Update();
            _enemy.Update();
        }

        public static void Render()
        {
            Engine.Clear();

            Engine.Draw("Textures/Backgrounds/Current_Avenue_1.png", 0, 0, 1, 1, 0, 0, 0);

            foreach (Enemy enemy in enemies) enemy.Render();
            foreach (Character character in characters) character.Render();
            _player.Render();
            _enemy.Render();

            Engine.Show();
        }
    }
}