using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class GenericPool<T> where T : new()
    {
        private List<T> inUse = new List<T>();
        private List<T> available = new List<T>();

        public GenericPool()
        {

        }

        public T Get()
        {
            T pooledObject;
            if (available.Count() == 0)
            {
                T newObject = new T();
                pooledObject = newObject;
            }
            else
            {
                pooledObject = available[0];
                available.Remove(pooledObject);
            }

            inUse.Add(pooledObject);
            return pooledObject;

        }

        public void Recycle(T pooledObject)
        {
            if (inUse.Contains(pooledObject))
            {
                inUse.Remove(pooledObject);
                available.Add(pooledObject);
            }
        }

    }
}