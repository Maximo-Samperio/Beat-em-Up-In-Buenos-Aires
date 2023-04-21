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
        private Renderer _renderer;         // Render of the character

        // Movement related variables
        private float _movementSpeed;
        private float _rotationSpeed;
        //private bool _isMovingUp;
        //private bool _isMovingDown;
        //private bool _isMovingRight;
        //private bool _isMovingLeft;

        private Animation idleAnimation;
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
            _rotationSpeed = 100f;                                      // Assigns a rotation speed

            

        }
        private void CreateAnimations()                                 // Creates animations
        {
            List<Texture> idleTextures = new List<Texture>();           // Creates a new list with all the sprites
            for (int i = 1; 1 < 5; i++)                                 // If the number of anims. that passed is < 4
            {
                Texture frame = Engine.GetTexture($"Textures/BG/IdleAnim/{i}.png");     // Adress of the textures
                idleTextures.Add(frame);                                // Then move on to the next one
            }

            idleAnimation = new Animation("Idle", idleTextures, 0.1f, true);            

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
            if (_transform.Position.Y + _renderer.Texture.Height > 1080 )
            {
                _transform.SetPositon(new Vector2(_transform.Position.X, 1080 + _renderer.Texture.Height));
            }
        }

        // Renders the entire thing
        public void Render() => _renderer.Render(_transform);

        #endregion

        #region PRIVATE_METHODS

        private void InputReading()
        {
            // Checks for the W key
            if (Engine.GetKey(Keys.W))
            {
                MoveUp();
                //_isMovingUp = true;
            }

            // Checks for the S key
            if (Engine.GetKey(Keys.S))
            {
                MoveDown();
                //_isMovingDown = true;

            }

            // Checks for the A key
            if (Engine.GetKey(Keys.A))
            {
                MoveLeft();
                //_isMovingLeft = true;

            }

            // Checks for the D key
            if (Engine.GetKey(Keys.D))
            {
                MoveRight();
                //_isMovingRight = true;

            }
        }

        // Moves the character up
        private void MoveUp() => _transform.Translate(new Vector2(0, -1), _movementSpeed);

        // Moves the character down
        private void MoveDown() => _transform.Translate(new Vector2(0, 1), _movementSpeed);

        // Moves the character to the left
        private void MoveLeft() => _transform.Translate(new Vector2(-1, 0), _movementSpeed);

        // Moves the character to the right
        private void MoveRight() => _transform.Translate(new Vector2(1, 0), _movementSpeed);

        #endregion
    }
}