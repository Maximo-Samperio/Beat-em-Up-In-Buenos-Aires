using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class Character
    {
        // Character Properties
        private Transform _transform;       // Transform of the character
        public Transform Transform => _transform;

        private Renderer _renderer;         // Render of the character
        public Renderer Renderer => _renderer;


        // Movement related variables
        private float _movementSpeed;
        private bool _kick;

        private Animation idleAnimation;
        private Animation walkAnimation;
        private Animation kickAnimation;
        private Animation currentAnimation;

        #region PUBLIC_METODS

        // Character class, allows me toeasily create characters
        public Character(string texturePath, Vector2 position, Vector2 scale, float angle, float movementSpeed)
        {
            CreateAnimations();
            currentAnimation = idleAnimation;
            _renderer = new Renderer(idleAnimation, scale);

            //_renderer = new Renderer(texturePath, scale);               // Relates render to render
            _transform = new Transform(position, scale, angle);         // Transform to transform              
            _movementSpeed = movementSpeed;                             // Movement speed to movement speed
        }

        private void CreateAnimations()                                 // Creates animations
        {
            // Idle animation
            List<Texture> idleTextures = new List<Texture>();           // Creates a new list with all the sprites
            for (int i = 1; i < 5; i++)                                 // If the number of anims. that passed is < 4
            {
                Texture frame = Engine.GetTexture($"Textures/BG/IdleAnim/{i}.png");     // Adress of the textures
                idleTextures.Add(frame);                                // Then move on to the next one
            }

            idleAnimation = new Animation("Idle", idleTextures, 0.1f, true);

            // Running animation
            List<Texture> walkTextures = new List<Texture>();          
            
                for (int i = 1; i < 5; i++)                                 
                {
                    Texture frame = Engine.GetTexture($"Textures/BG/WalkAnim/{i}.png");     
                    walkTextures.Add(frame);                                
                }
  
            walkAnimation = new Animation("Walk", walkTextures, 0.1f, true);

            // Kick Animation
            List<Texture> kickTextures = new List<Texture>();          
            
                for (int i = 1; i < 6; i++)                                 
                {
                    Texture frame = Engine.GetTexture($"Textures/BG/KickAnim/{i}.png");     
                    kickTextures.Add(frame);                               
                }

            kickAnimation = new Animation("Kick", kickTextures, 0.1f, true);

        }
        public void Initialize() { }

        public void Update() 
        {
            InputReading();
            currentAnimation.Update();


            // Checks if the character is colliding with the right margin so that it does not leave the screen
            if (_transform.Position.X >= 1920 + _renderer.Texture.Width)
            {
                _transform.SetPositon(new Vector2(-_renderer.Texture.Width, _transform.Position.Y)); //Replace in a future with screen background change

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
            if (_transform.Position.Y > 1000 )
            {
                _transform.SetPositon(new Vector2(_transform.Position.X, 1000));
            }
        }

        // Renders the entire thing
        public void Render() => _renderer.Render(_transform);

        #endregion

        #region PRIVATE_METHODS

        private void InputReading()
        {
            // Checks for the W key for movement
            if (Engine.GetKey(Keys.W))
            {
                MoveUp();
                currentAnimation = walkAnimation;            
            }

            // Checks for the S key for movement
            if (Engine.GetKey(Keys.S))
            {
                MoveDown();
                currentAnimation = walkAnimation;
            }

            // Checks for the A key for movement
            if (Engine.GetKey(Keys.A))
            {
                MoveLeft();
                currentAnimation = walkAnimation;
            }

            // Checks for the D key for movement
            if (Engine.GetKey(Keys.D))
            {
                MoveRight();
                currentAnimation = walkAnimation;
            }

            // Checks for the F key to kick
            if (Engine.GetKey(Keys.F))
            {
                Kick();
                currentAnimation = kickAnimation;
            }
        }

        // Moves the character up
        private void MoveUp()
        {
            _transform.Translate(new Vector2(0, -1), _movementSpeed);
            currentAnimation = walkAnimation;

        }

        // Moves the character down
        private void MoveDown()
        {
            _transform.Translate(new Vector2(0, 1), _movementSpeed);
            currentAnimation = walkAnimation;
        }

        // Moves the character to the left
        private void MoveLeft()
        {
            _transform.Translate(new Vector2(-1, 0), _movementSpeed);
            currentAnimation = walkAnimation;
        }

        // Moves the character to the right
        private void MoveRight()
        {
            _transform.Translate(new Vector2(1, 0), _movementSpeed);
            currentAnimation = walkAnimation;
        }

        // Makes the character throw a front kick
        private void Kick()
        {
            _kick = true;
            currentAnimation = kickAnimation;
        }

        #endregion
    }
}