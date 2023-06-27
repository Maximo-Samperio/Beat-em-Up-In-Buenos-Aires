using Game;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class Character : GameObject
    {
        // Input Variables
        public static Action<bool> OnClick;

        private static bool clickState;

        // Movement related variables
        public float _movementSpeed;
        public bool _kick;
        public bool _jab;
        public bool _punch;
        public bool _jump;
        private bool _isMoving;
        public bool isAttacking;
        private Enemy _enemy;
        private Collider colliderController = new Collider();


        private float timer;
        private bool hasTimeElapsed;
        private static Time _time;
        private static DateTime spawnTime;
        private static DateTime currentTime;
        
        private Animation idleAnimation;
        private Animation walkAnimation;
        public Animation kickAnimation;
        public Animation jabAnimation;
        public Animation punchAnimation;
        public Animation jumpAnimation;

        #region PUBLIC_METODS

        // Character class, allows me toeasily create characters
        public Character(Vector2 position, Vector2 scale, float angle, float movementSpeed) : base(position, scale, angle)
        {
            //CreateAnimations();

            _enemy = LevelController.Enemy;
            //_transform = new Transform(position, scale, angle);         // Transform to transform
                                                                        // 
            _movementSpeed = movementSpeed;                             // Movement speed to movement speed

            //_renderer = new Renderer(idleAnimation, scale);

        }

        protected override void CreateAnimations()                                 // Creates animations
        {
            Texture frame;

            // Idle animation
            List<Texture> idleTextures = new List<Texture>();           // Creates a new list with all the sprites
            for (int i = 1; i < 5; i++)                                 // If the number of anims. that passed is < 4
            {
                frame = Engine.GetTexture($"Textures/BG/IdleAnim/{i}.png");     // Adress of the textures
                idleTextures.Add(frame);                                // Then move on to the next one
            }

            idleAnimation = new Animation("Idle", idleTextures, 0.1f, true, false);
            
            // Running animation
            List<Texture> walkTextures = new List<Texture>();

            for (int i = 1; i < 5; i++)
            {
               
                frame = Engine.GetTexture($"Textures/BG/WalkAnim/{i}.png");
                walkTextures.Add(frame);
            }

            walkAnimation = new Animation("Walk", walkTextures, 0.1f, true, false);

            // Kick Animation
            List<Texture> kickTextures = new List<Texture>();

            for (int i = 1; i < 6; i++)
            {
                frame = Engine.GetTexture($"Textures/BG/KickAnim/{i}.png");
                kickTextures.Add(frame);
            }

            kickAnimation = new Animation("Kick", kickTextures, 0.1f, false, true);

            // Jab Animation
            List<Texture> jabTextures = new List<Texture>();

            for (int i = 1; i < 4; i++)
            {
                frame = Engine.GetTexture($"Textures/BG/JabAnim/{i}.png");
                jabTextures.Add(frame);
            }

            jabAnimation = new Animation("Jab", jabTextures, 0.1f, false, true);

            // punch Animation
            List<Texture> punchTextures = new List<Texture>();

            for (int i = 1; i < 4; i++)
            {
                frame = Engine.GetTexture($"Textures/BG/PunchAnim/{i}.png");
                punchTextures.Add(frame);
            }

            punchAnimation = new Animation("punch", punchTextures, 0.1f, false, true);

            // jump Animation
            List<Texture> jumpTextures = new List<Texture>();

            for (int i = 1; i < 5; i++)
            {             
                frame = Engine.GetTexture($"Textures/BG/JumpAnim/{i}.png");
                jumpTextures.Add(frame);
            }
         
           jumpAnimation = new Animation("jump", jumpTextures, 0.5f, false, false);

            currentAnimation = idleAnimation;

        }
        public void Initialize() { }

        public override void Update()
        {
            timer -= Time.DeltaTime;

            if (Engine.GetKey(Keys.SPACE) && !clickState)
            {
                clickState = true;
                OnClick?.Invoke(clickState);
            }
            else if (!Engine.GetKey(Keys.SPACE) && clickState)
            {
                clickState = false;
                OnClick?.Invoke(clickState);
            }

            InputReading();
            currentAnimation.Update();



            // Checks if the character is colliding with the right margin so that it does not leave the screen
            if (_transform.Position.X >= 1920 + _renderer.Texture.Width)
            {
                GameManager.Instance.ChangeGameState(GameState.WinScreen);
            }

            // Checks if the character is colliding with the left margin so that it does not leave the screen
            if (_transform.Position.X < 0 + _renderer.Texture.Width)
            {
                _transform.SetPositon(new Vector2(0 + _renderer.Texture.Width, _transform.Position.Y));
            }

            // Prevents the character from moving up more than desired
            if (_transform.Position.Y < 800)
            {
                _transform.SetPositon(new Vector2(_transform.Position.X, 800));
            }

            // Checks if the character is colliding with the bottom margin so that it does not leave the screen
            if (_transform.Position.Y > 1000)
            {
                _transform.SetPositon(new Vector2(_transform.Position.X, 1000));
            }



        }
        #endregion

        #region PRIVATE_METHODS

        protected void InputReading()
        {

            // Checks for the W key for movement
            if (Engine.GetKey(Keys.W) && currentAnimation.interrupt == false)
            {
                //Engine.Debug("XXXXXXXX");
                MoveUp();
                currentAnimation = walkAnimation;
           
            }

            // Checks for the S key for movement
            else if (Engine.GetKey(Keys.S) && currentAnimation.interrupt == false)
            {
                MoveDown();
                currentAnimation = walkAnimation;
            }

            // Checks for the A key for movement
            else if (Engine.GetKey(Keys.A) && currentAnimation.interrupt == false)
            {
                MoveLeft();
                currentAnimation = walkAnimation;
            }

            // Checks for the D key for movement
            else if(Engine.GetKey(Keys.D) && currentAnimation.interrupt == false)
            {
                MoveRight();
                currentAnimation = walkAnimation;
                
            }

            // Checks for the K key to kick
            else if(Engine.GetKey(Keys.K) && currentAnimation.interrupt == false)
            {
                Kick();
                currentAnimation = kickAnimation;
            }

            // Checks for the J key to Jab
            else if(Engine.GetKey(Keys.J) && currentAnimation.interrupt == false)
            {
                Jab();
                currentAnimation = jabAnimation;
            }

            // Checks for the H key to punch
            else if(Engine.GetKey(Keys.H) && currentAnimation.interrupt == false)
            {
                Punch();
                currentAnimation = punchAnimation;
            }

            // Checks for the SPACE key to punch
            else if(Engine.GetKey(Keys.SPACE) && currentAnimation.interrupt == false)
            {
                Jump();
                currentAnimation = jumpAnimation;
            }
            else if (currentAnimation.interrupt == false) 
            {

                currentAnimation = idleAnimation;
                _renderer.ChangeAnimation(currentAnimation);
            }
       
        }

        // Moves the character up
        private void MoveUp()
        {
            _transform.Translate(new Vector2(0, -1), _movementSpeed);

            isAttacking = false;

            currentAnimation = walkAnimation;
            _renderer.ChangeAnimation(currentAnimation);
        }

        // Moves the character down
        private void MoveDown()
        {
            _transform.Translate(new Vector2(0, 1), _movementSpeed);

            isAttacking = false;

            currentAnimation = walkAnimation;
            _renderer.ChangeAnimation(currentAnimation);
        }

        // Moves the character to the left
        private void MoveLeft()
        {
            _transform.Translate(new Vector2(-1, 0), _movementSpeed);

            isAttacking = false;

            currentAnimation = walkAnimation;
            _renderer.ChangeAnimation(currentAnimation);
        }

        // Moves the character to the right
        private void MoveRight()
        {
            _transform.Translate(new Vector2(1, 0), _movementSpeed);

            isAttacking = false;

            currentAnimation = walkAnimation;
            
            _renderer.ChangeAnimation(currentAnimation);
        }

        // Makes the character throw a front kick
        private void Kick()
        {
            _kick = true;
            _jab = false;
            _punch = false;

            SetTimer(1f);
            isAttacking = true;
            currentAnimation = kickAnimation;
            currentAnimation.currentFrameIndex = 0;
            currentAnimation.interrupt = true;
            _renderer.ChangeAnimation(currentAnimation);
        }

        private void Jab()
        {
            _kick = false;
            _jab = true;
            _punch = false;

            SetTimer(1f);
            isAttacking = true;
            currentAnimation = jabAnimation;
            currentAnimation.currentFrameIndex = 0;
            currentAnimation.interrupt = true;
            _renderer.ChangeAnimation(currentAnimation);
        }

        private void Punch()
        {
            _kick = false;
            _jab = false;
            _punch = true;

            SetTimer(1f);
            isAttacking = true;
            currentAnimation = punchAnimation;
            currentAnimation.currentFrameIndex = 0;
            currentAnimation.interrupt = true;
            _renderer.ChangeAnimation(currentAnimation);
        }

        private void Jump()
        {
            _kick = false;
            _jab = false;
            _punch = false;
            _jump = true;

            currentAnimation = jumpAnimation;
            _renderer.ChangeAnimation(currentAnimation);
        }
        public void SetTimer(float timer)
        {
            this.timer = timer;
        }
        public void IsTimerComplete()
        {
            if (timer <= 0f)
            {
                isAttacking = false;
            }
            return;
        }
        #endregion
    }
}