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
        public static GameManager instance;

        public const string GAMEOVER_PATH = "Textures/Screens/GameOver.png";
        public const string WIN_PATH = "Textures/Screens/Win.png";
        public const string CREDITS_PATH = "Textures/Screens/Credits.png";
        public const string MAINMENU_PATH = "Textures/Screens/MainMenu.png";

        public StaticScreen GameOverScreen = new StaticScreen("Textures/Screens/GameOver.png");
        public StaticScreen WinScreen = new StaticScreen("Textures/Screens/Win.png");
        public StaticScreen CreditsScreen = new StaticScreen("Textures/Screens/Credits.png");
        public StaticScreen MainScreen = new StaticScreen("Textures/Screens/MainMenu.png");

        public LevelController LevelController { get; private set; }
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
            LevelController = new LevelController();
            LevelController.Initialization();
            ChangeGameState(GameState.MainMenu);
            
        }

        public void Update()
        {
            LevelController.Update();
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

                if (CurrentState == GameState.WinScreen)
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
                    MainScreen.Render();
                    break;

                case GameState.Credits:
                   CreditsScreen.Render();
                    break;

                case GameState.GameOverScreen:
                    GameOverScreen.Render();
                    break;

                case GameState.WinScreen:
                    WinScreen.Render();
                    break;

                case GameState.Level:
                    LevelController.Render();
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

