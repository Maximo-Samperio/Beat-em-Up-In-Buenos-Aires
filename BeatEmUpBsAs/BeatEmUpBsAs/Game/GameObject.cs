using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public abstract class GameObject
    {
        protected Transform _transform;
        protected Renderer _renderer;
        protected Animation currentAnimation;
        public Transform Transform => _transform;
        public Renderer Renderer => _renderer;

        public GameObject(Vector2 position, Vector2 scale, float angle)
        {
            _transform = new Transform(position, scale, angle);
            CreateAnimations();
            _renderer = new Renderer(currentAnimation, scale);
        }
        public virtual void Update()
        {

        }

        public void Render()
        {
            _renderer.Render(_transform);
        }

        protected abstract void CreateAnimations();

        public virtual void GetDamage(int damage)
        {

        }
        public virtual void Destroy()
        {

        }
    }


}
