using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class Enemy
    {

        //Enemy properties
        private Transform _transform;
        private Renderer _renderer;
        private Animation idleAnimation;
        private Animation currentAnimation;
        private Transform _playerTransform;
        private Character _player;

        //Movement values
        private float _movementSpeed;
        private float _rotationSpeed;

        #region PUBLIC_METODS

        public Enemy(string texturePath, Vector2 position, Vector2 scale, float angle, float movementSpeed)
        {
            _player = Program.Player;
            _transform = new Transform(position, scale, angle);


            CreateAnimations();
            currentAnimation = idleAnimation;
            _movementSpeed = movementSpeed;
            _rotationSpeed = 100f;

            _renderer = new Renderer(idleAnimation, scale);

        }

        private void CreateAnimations()
        {
            List<Texture> idleTextures = new List<Texture>();
            for (int i = 1; i < 5; i++)
            {
                Texture frame = Engine.GetTexture($"Textures/Punk/IdleAnim/{i}.png");
                idleTextures.Add(frame);
            }
            idleAnimation = new Animation("Idle", idleTextures, 0.1f, true);

        }

        public void Initialize() { }

        public void Update()
        {

            _transform.Translate(new Vector2(1, 0), _movementSpeed);

            if (_transform.Position.X >= 1920 + _renderer.Texture.Width)
                _transform.SetPositon(new Vector2(-_renderer.Texture.Width, _transform.Position.Y));

            currentAnimation.Update();
           CheckCollision();
        }


        public void CheckCollision()
        {

            float distanceX = Math.Abs(_player.Transform.Position.X - _transform.Position.X);
            float distanceY = Math.Abs(_player.Transform.Position.Y - _transform.Position.Y);

            float sumHalfWidths = _player.Renderer.Texture.Width / 2 + _renderer.Texture.Width / 2;
            float sumHalfHeights = _player.Renderer.Texture.Height / 2 + _renderer.Texture.Height / 2;

            if (distanceX <= sumHalfWidths && distanceY <= sumHalfHeights)
            {
                if (_player._kick == true)
                {
                    GameManager.Instance.ChangeGameState(GameState.WinScreen);
                }
                else
                {
                    GameManager.Instance.ChangeGameState(GameState.GameOverScreen);
                }
            }
        }


        public void Render()
        {
            _renderer.Render(_transform);
        }

        #endregion


    }
}
