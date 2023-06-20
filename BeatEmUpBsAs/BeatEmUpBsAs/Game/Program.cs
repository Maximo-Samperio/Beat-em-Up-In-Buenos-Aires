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

            //try
            //{
            //    string s = null;
            //    ProcessString(s);
            //}

            ////More specific
            //catch (ArgumentException e)
            //{
            //    Console.WriteLine("{0} First exception caught.", e);
            //}

            //catch (Exception e)
            //{
            //    Console.WriteLine("{0} Second exception caught.", e);
            //}
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

        static void ProcessString(string s )
        { 
            if (s == null)
	        {
                throw new ArgumentNullException();
	        }
        }

    }
}