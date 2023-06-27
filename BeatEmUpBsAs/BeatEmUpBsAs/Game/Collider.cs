using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class Collider
    {
        private Character _player;
        public bool collisionDetected = false;

        public bool CheckCollision(GameObject object1, GameObject object2)
        {
            if (object1 == null)
            {
                return false;
            }

            bool answer = false;

            Console.WriteLine("Objeto1: " + object1._transform == null);
            Console.WriteLine("Objeto2: " + object2._transform == null);


            float distanceX = Math.Abs(object1._transform.Position.X - object2._transform.Position.X);
            float distanceY = Math.Abs(object1._transform.Position.Y - object2._transform.Position.Y);

            float sumHalfWidths = object1._renderer.Texture.Width / 2 + object2._renderer.Texture.Width / 2;
            float sumHalfHeights = object1._renderer.Texture.Height / 2 + object2._renderer.Texture.Height / 2;

            if (distanceX <= sumHalfWidths && distanceY <= sumHalfHeights)
            {               
                answer = true;
                collisionDetected = true;
            }

            return answer;
        }
    }
}
