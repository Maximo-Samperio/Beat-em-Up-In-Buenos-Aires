using System;
using System.Collections.Generic;
using System.Media;

namespace Game
{
    public class Program
    {
        /// Timeframe Calculation Properties
        private static Time _time;

        private static List<Character> characters = new List<Character>();

        private static Character _player;

        public static Character Player => _player;


        static void Main(string[] args)
        {
            Engine.Initialize("Game", 1920, 1080);
            Initialization();

            while (true)
            {
                Update();
                Render();
            }
        }

        private static void Initialization()
        {
            _time.Initialize();
    
            characters.Add( new Character("Textures/BG/IdleAnim/idle1.png", new Vector2(400, 850), new Vector2(4, 4), 0, 200));

        }

        private static void Update()
        {
            foreach (Character character in characters) character.Update();

            _time.Update();
        }

        private static void Render()
        {
            Engine.Clear();

            Engine.Draw("Textures/Backgrounds/Current_Avenue_1.png", 0, 0, 1, 1, 0, 0, 0);

            foreach (Character character in characters) character.Render();
            
            Engine.Show();
        }
    }
}