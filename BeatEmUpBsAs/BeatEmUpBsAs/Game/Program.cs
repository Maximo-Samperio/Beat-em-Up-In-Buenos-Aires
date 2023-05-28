using System;
using System.Collections.Generic;
using System.Media;

namespace Game
{
    public class Program
    {
        static void Main(string[] args)
        {
            Engine.Initialize("Beat Em Up in Buenos Aires", 1920, 1080);
            GameManager.Instance.Initialization();
            Initialization();

            while (true)
            {
                Update();
                Render();    
                
            }
        }

        private static void Initialization()
        {
            GameManager.Instance.Initialization();
        }

        private static void Update()
        {

            GameManager.Instance.Update();

        }

        public static void Render()
        {
            GameManager.Instance.Render();
        }
    }
}