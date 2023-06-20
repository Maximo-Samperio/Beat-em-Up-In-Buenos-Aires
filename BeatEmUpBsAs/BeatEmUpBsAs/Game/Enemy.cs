﻿using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class Enemy
    {

        // Enemy properties
        private Transform _transform;
        private Renderer _renderer;
        private Animation idleAnimation;
        private Animation currentAnimation;
        private Transform _playerTransform;
        private Character _player;
        bool hasCollided = false;

<<<<<<< HEAD
        //Movement values
        private float _movementSpeed = 30;
=======
        // Movement values
        private float _movementSpeed = 30;
>>>>>>> 8219a5c099c1a518d00cd33249f195f8805e4827
        private float _rotationSpeed;

        // Events
        //public event Action <bool> OnColliison;
        public delegate void KillEnemy(bool playerAttack);



        #region PUBLIC_METODS

        public Enemy(string texturePath, Vector2 position, Vector2 scale, float angle, float movementSpeed)
        {
            _player = LevelController.Player;
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
            idleAnimation = new Animation("Idle", idleTextures, 0.1f, true, false);

        }

        public void Initialize() { }

        public void Update()
        {

            _transform.Translate(new Vector2(1, 0), _movementSpeed);

            if (_transform.Position.X >= 1920 + _renderer.Texture.Width)
                _transform.SetPositon(new Vector2(-_renderer.Texture.Width, _transform.Position.Y));

            currentAnimation.Update();
            CheckCollision();

            if (GameManager.instance.CurrentState == GameState.Level)
            {
                //TrackPlayer();
            }
            
        }


        public void CheckCollision()
        {

            List<Enemy> enemiesToDelete = new List<Enemy>();

            float distanceX = Math.Abs(_player.Transform.Position.X - _transform.Position.X);
            float distanceY = Math.Abs(_player.Transform.Position.Y - _transform.Position.Y);

            float sumHalfWidths = _player.Renderer.Texture.Width / 2 + _renderer.Texture.Width / 2;
            float sumHalfHeights = _player.Renderer.Texture.Height / 2 + _renderer.Texture.Height / 2;

            if (distanceX <= sumHalfWidths && distanceY <= sumHalfHeights)
            {
                if (_player._kick == true || _player._jab == true || _player._punch == true)
                {
                    OnCollision();
                    //enemiesToDelete.Add(Enemy);
                    //GameManager.Instance.ChangeGameState(GameState.WinScreen);
                }
                else
                {
                    GameManager.Instance.ChangeGameState(GameState.GameOverScreen);
                }
            }
        }
        private void OnCollision()
        {
            //Delete Enemy
            GameManager.Instance.ChangeGameState(GameState.WinScreen);
            Debug.Write("Enemy dead");
        }

        public void TrackPlayer()
        {
            float distanceX = _player.Transform.Position.X - _transform.Position.X;
            float distanceY = _player.Transform.Position.Y - _transform.Position.Y;

            float normal = (float)Math.Sqrt(distanceX * distanceX + distanceY * distanceY);
            Vector2 direction = new Vector2(distanceX / normal, distanceY / normal);

            _transform.Translate(direction, _player._movementSpeed);
        }
       
        public void Render()
        {
            _renderer.Render(_transform);
        }


        #endregion


    }
}
