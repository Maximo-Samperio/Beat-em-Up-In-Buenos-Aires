using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class Renderer
    {
        public Texture Texture => _texture;
        public Vector2 Offset => _offset;

        private Texture _texture;
        private Animation _anim;
        private Vector2 _offset;

        public Renderer(Animation anim, Vector2 scale)
        {
            //_texture = Engine.GetTexture(texturePath);

            _anim = anim;
            _texture = _anim.CurrentFrame;
            _offset = new Vector2(
            (scale.X * _texture.Width) / 2,
            (scale.Y * _texture.Height) / 2);
        }

        public void Render(Transform transform)
        {
            _texture = _anim.CurrentFrame;

            Engine.Draw(
                _texture,
                transform.Position.X, transform.Position.Y,
                transform.Scale.X, transform.Scale.Y,
                transform.Angle,
                _offset.X, _offset.Y);
        }

        public override string ToString()
        {
            return $"Texture : {_texture}\n" +
                    $"Width : {_texture.Width} / Height : {_texture.Height}\n" +
                    $"Offset - X : {_offset.X} / Y : {_offset.Y}";



        }
        public void ChangeAnimation(Animation anim)
        {
            _anim = anim;
            _texture = _anim.CurrentFrame;
        }
    }
}
