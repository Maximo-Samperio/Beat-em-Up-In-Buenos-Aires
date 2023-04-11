using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class Character
    {
        /* Character Properties */
        private Transform _transform;
        private Renderer _renderer;

        /* Speed Valudwes */
        private float _movementSpeed;
        private float _rotationSpeed;
        private bool _isMovingUp;
        private bool _isMovingDown;
        private bool _isMovingRight;
        private bool _isMovingLeft;

        #region PUBLIC_METODS

        public Character(string texturePath, Vector2 position, Vector2 scale, float angle, float movementSpeed)
        {
            _renderer = new Renderer(texturePath, scale);
            _transform = new Transform(position, scale, angle);

            _movementSpeed = movementSpeed;
            _rotationSpeed = 100f;
        }

        public void Initialize() { }

        public void Update() 
        {
            InputReading();

            //_transform.Translate(new Vector2(1, 0), _movementSpeed);
            //_transform.Rotate(0, _rotationSpeed);

            if (_transform.Position.X >= 1920 + _renderer.Texture.Width)
            {
                _transform.SetPositon(new Vector2(-_renderer.Texture.Width, _transform.Position.Y)); //Replace in a future with screen background change

            }
            
            if (_transform.Position.X <= 0 + _renderer.Texture.Width && _isMovingLeft == true)
            {
                _movementSpeed = 0;
                /*if (_isMovingUp == true || _isMovingRight == true || _isMovingDown == true)
                {
                    _movementSpeed = 200;

                }*/
            }
        }

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