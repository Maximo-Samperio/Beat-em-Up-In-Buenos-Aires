using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;


namespace Game
{

    public class GenericEnemyFactory
    {
        public GenericEnemyFactory()
        {
            pool = new GenericPool<Enemy>();
        }

        private GenericPool<Enemy> pool;

        public Enemy CreateEnemy(EnemyType enemy, Vector2 position)
        {
            switch (enemy)
            {
                case EnemyType.Punk:
                    Enemy enemy1 = pool.Get();
                    enemy1.Initialize(position, new Vector2(3.5f, 3.5f), 0, 100);
                    return enemy1;

                    //return new Enemy(position, new Vector2(3.5f, 3.5f), 0, 100);  
            }
            return null;
        }
    }
}