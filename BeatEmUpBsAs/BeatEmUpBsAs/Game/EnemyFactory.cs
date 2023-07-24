﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;


namespace Game
{
  
    public enum EnemyType
    {
        Punk = 0,
    }

    public class EnemyFactory
    {
        public EnemyFactory()
        {
            pool = new NotDynamicEnemyPool(10);
        }

        private NotDynamicEnemyPool pool;
        
        public Enemy CreateEnemy(EnemyType enemy, Vector2 position)
        {
            switch (enemy)
            {
                case EnemyType.Punk:
                    Enemy enemy1 = pool.getEnemy();
                    enemy1.Initialize(position, new Vector2(3.5f, 3.5f), 0, 100);
                    return enemy1;

                        //return new Enemy(position, new Vector2(3.5f, 3.5f), 0, 100);  
            }
            return null;
        }
    }
}
