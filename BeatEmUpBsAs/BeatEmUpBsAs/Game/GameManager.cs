using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public enum GameState
    {
        MainMenu,
        Credits,
        GameOverScreen,
        WinScreen,
        Level
    }

    public class GameManager
    {
        private static GameManager instance;

        public const string GAMEOVER_PATH = "Textures/Screens/GameOver.png";
        public const string WIN_PATH = "Textures/Screens/Win.png";
        public const string CREDITS_PATH = "Textures/Screens/Credits.png";
        public const string MAINMENU_PATH = "Textures/Screens/MainMenu.png";



        public static GameManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new GameManager();
                }
                return instance;
            }
        }

        public GameState CurrentState { get; private set; }

        public void Initialization()
        {
            ChangeGameState(GameState.MainMenu);
        }

        public void Update()
        {
            if (Engine.GetKey(Keys.SPACE))
            {
                if (CurrentState == GameState.MainMenu)
                {
                    ChangeGameState(GameState.Level);

                }

                if (CurrentState == GameState.GameOverScreen)
                {
                    ChangeGameState(GameState.MainMenu);

                }
            }
        }

        public void Render()
        {   Engine.Clear();

            switch (CurrentState)
            {
                case GameState.MainMenu:
                    Engine.Draw(MAINMENU_PATH, 0, 0);
                    break;

                case GameState.Credits:
                    Engine.Draw(CREDITS_PATH, 0, 0);
                    break;

                case GameState.GameOverScreen:
                    Engine.Draw(GAMEOVER_PATH, 0, 0);
                    break;

                case GameState.WinScreen:
                    Engine.Draw(WIN_PATH, 0, 0);
                    break;

                case GameState.Level:
                    Program.Render();
                    break;
                default:
                    break;
            }
            Engine.Show();
        }

        public void ChangeGameState(GameState newState)
        {
            CurrentState = newState;
        }
    }
}

