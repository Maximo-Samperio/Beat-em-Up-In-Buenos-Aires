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
        Punk = 0,
    }

    public static class EnemyFactory
    {
        public static Enemy CreateEnemy(EnemyType enemy, Vector2 position)
        {
            switch (enemy)
            {
                case EnemyType.Punk:
                    return new Enemy(position, new Vector2(.75f, .75f), 0, 100);
            }
            return null;
        }
    }
}
