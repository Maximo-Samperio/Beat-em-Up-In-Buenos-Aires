using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class NotDynamicEnemyPool
    {
        private List<Enemy> enemyInUse = new List<Enemy>();
        private List<Enemy> enemyAvailable = new List<Enemy>();

        public NotDynamicEnemyPool(int capacity) 
        {
          for (int i = 0; i < capacity; i++)
            {
                //Enemy enemy = new Enemy(new Vector2(0, 0), new Vector2(1f, 1f), 0, 250);
                Enemy enemy = new Enemy();
                enemyAvailable.Add(enemy);
                
            }
           

        }

        public Enemy getEnemy()
        {
            Enemy enemyToReturn = null;

            if(enemyAvailable.Count > 0)
            {
                enemyToReturn = enemyAvailable[0];
                enemyAvailable.RemoveAt(0);
                enemyInUse.Add(enemyToReturn);
                

                //return new Enemy(position, new Vector2(3.5f, 3.5f), 0, 100);
            }
            return enemyToReturn;

        }

        private void RecycleEnemy(Enemy enemy)
        {
            if (enemyInUse.Contains(enemy))
            {
                enemyInUse.Remove(enemy);
                enemyAvailable.Add(enemy);
            }
        }

    }


}
