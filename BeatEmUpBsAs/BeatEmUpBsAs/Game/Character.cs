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
        private bool _isMovingUp;
        private bool _isMovingDown;
        private bool _isMovingRight;
        private bool _isMovingLeft;

        #region PUBLIC_METODS

        // Character class, allows me toeasily create characters
        public Character(string texturePath, Vector2 position, Vector2 scale, float angle, float movementSpeed)
        {
            _renderer = new Renderer(texturePath, scale);               // Relates render to render
            _transform = new Transform(position, scale, angle);         // Transform to transform              
            _movementSpeed = movementSpeed;                             // Movement speed to movement speed
            _rotationSpeed = 100f;                                      // Assigns a rotation speed
        }

        public void Initialize() { }

        public void Update() 
        {
            InputReading();

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
        }

        // Renders the entire thing
        public void Render() => _renderer.Render(_transform);

        #endregion

        #region PRIVATE_METHODS

        private void InputReading()
        {
            if (Engine.GetKey(Keys.W))
            {
                MoveUp();
                _isMovingUp = true;
            }

            if (Engine.GetKey(Keys.S))
            {
                MoveDown();
                _isMovingDown = true;

            }

            if (Engine.GetKey(Keys.A))
            {
                MoveLeft();
                _isMovingLeft = true;

            }

            if (Engine.GetKey(Keys.D))
            {
                MoveRight();
                _isMovingRight = true;

            }
        }

        private void MoveUp() => _transform.Translate(new Vector2(0, -1), _movementSpeed);
        private void MoveDown() => _transform.Translate(new Vector2(0, 1), _movementSpeed);
        private void MoveLeft() => _transform.Translate(new Vector2(-1, 0), _movementSpeed);
        private void MoveRight() => _transform.Translate(new Vector2(1, 0), _movementSpeed);

        #endregion
    }
}