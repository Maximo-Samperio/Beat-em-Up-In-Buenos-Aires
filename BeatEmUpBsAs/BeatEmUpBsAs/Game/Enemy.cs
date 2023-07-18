using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class Enemy : GameObject
    {

        // Enemy properties
        private Animation idleAnimation;
        private Transform _playerTransform;
        private Character _player;
        public int killedEnemies = 0;
        bool hasCollided = false;
        private bool killEnemy = false;

        private Collider colliderController = new Collider();


        //Movement values
        private float _movementSpeed = 30;
        // Movement values

        private float _rotationSpeed;

        // Events
        public event Action<Enemy> OnKill;



        #region PUBLIC_METODS

        public Enemy(Vector2 position, Vector2 scale, float angle, float movementSpeed) : base(position, scale, angle)
        {
            _player = LevelController.Player;

            _transform = new Transform(position, scale, angle);


            //CreateAnimations();
            _movementSpeed = movementSpeed;
            _rotationSpeed = 100f;

            _renderer = new Renderer(idleAnimation, scale);
        }

        protected override void CreateAnimations()
        {
            List<Texture> idleTextures = new List<Texture>();
            for (int i = 1; i < 5; i++)
            {
                Texture frame = Engine.GetTexture($"Textures/Punk/IdleAnim/{i}.png");
                idleTextures.Add(frame);
            }
            idleAnimation = new Animation("Idle", idleTextures, 0.1f, true, false);
            currentAnimation = idleAnimation;
        }

        public void Initialize() { }

        public override void Update()
        {

            _transform.Translate(new Vector2(1, 0), _movementSpeed);

            //if (_transform.Position.X >= 1920 + _renderer.Texture.Width)
            //    _transform.SetPositon(new Vector2(-_renderer.Texture.Width, _transform.Position.Y));

            currentAnimation.Update();

            

            if (GameManager.instance.CurrentState == GameState.Level)
            {
                CheckCollison();
                TrackPlayer();
            }
            
        }
        public void CheckCollison()
        {
            if (colliderController.CheckCollision(_player, this))
            {
                if (_player.isAttacking)
                {
                    DestroyEnemy();
                    killedEnemies++;
                    //enemiesToDelete.Add(Enemy);
                    //GameManager.Instance.ChangeGameState(GameState.WinScreen);
                }
                else
                {
                    GameManager.Instance.ChangeGameState(GameState.GameOverScreen);
                }
            }
        }

        public void TrackPlayer()
        {
            float distanceX = _player.Transform.Position.X - _transform.Position.X;
            float distanceY = _player.Transform.Position.Y - _transform.Position.Y;

            float normal = (float)Math.Sqrt(distanceX * distanceX + distanceY * distanceY);
            Vector2 direction = new Vector2(distanceX / normal, distanceY / normal);

            _transform.Translate(direction, _player._movementSpeed);
        }

        public void DestroyEnemy()
        {
            GameManager.Instance.LevelController.gameObjects.Remove(this);
            OnKill?.Invoke(this);

        }


        //public override void Render()
        //{
        //    _renderer.Render(_transform);
        //}


        #endregion


    }
}
