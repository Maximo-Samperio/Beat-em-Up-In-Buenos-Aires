using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class Transform
    {
        public Vector2 Position => _position;
        public Vector2 Scale => _scale;
        public float Angle => _angle;

        private Vector2 _position;
        private Vector2 _scale;
        private float _angle;

        public Transform(Vector2 position, Vector2 scale, float angle)
        {
            _position = position;
            _scale = scale;
            _angle = angle;
        }

        public void SetPositon(Vector2 position) => _position = position;
        public void SetScale(Vector2 scale) => _scale = scale;
        public void SetAngle(float angle) => _angle = angle;
        public void Rotate(float direction, float speed) => _angle += direction * speed * Time.DeltaTime;

        public void Translate(Vector2 direction, float speed = 0f)
        {
            _position.X += direction.X * speed * Time.DeltaTime;
            _position.Y += direction.Y * speed * Time.DeltaTime;
        }

        public override string ToString()
        {
            return $"Position - X : {_position.X} / Y : {_position.Y}\n" +
                    $"Rotation - Angle : {_angle}\n" +
                    $"Scale - X : {_scale.X} / Y : {_scale.Y}";
        }
    }
}
