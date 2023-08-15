using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{

    public abstract class GameObject
    {
        public Transform _transform;
        public  Renderer _renderer;
        public Animation currentAnimation;
        public Transform Transform => _transform;
        public Renderer Renderer => _renderer;

        public GameObject()
        {
            _transform = new Transform(new Vector2(0,0), new Vector2(0, 0), 0);
            CreateAnimations();
            _renderer = new Renderer(currentAnimation, new Vector2(0, 0));
        }

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
