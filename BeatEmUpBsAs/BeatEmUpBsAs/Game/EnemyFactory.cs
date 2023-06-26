using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public enum EnemyType
    {
        Slow = 0,
        Fast = 1,
        SuperFast = 2
    }

    public static class EnemyFactory
    {
        public static Enemy CreateEnemy(EnemyType enemy, Vector2 position)
        {
            new Enemy(position, new Vector2(.75f, .75f), 0, 100);
        }
    }
}
