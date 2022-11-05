using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedSingleton
{
    public class SharedData : ISharedData
    {
        private ConcurrentQueue<string> concurrentQueue;
        private object lockObject;

        public SharedData()
        {
            lockObject = new object();
            concurrentQueue = new ConcurrentQueue<string>();
        }
        public string Dequque()
        {
            /*lock (lockObject)
            {
                if (concurrentQueue.TryDequeue(out string str))
                {
                    return str;
                }
                else
                {
                    return null;
                }
            }*/
            if (concurrentQueue.TryDequeue(out string str))
            {
                return str;
            }
            else
            {
                return null;
            }
        }

        public void Enquque(string v)
        {
            /*lock (lockObject)
            {
                concurrentQueue.Enqueue(v);
            }*/
            concurrentQueue.Enqueue(v);
        }
    }
}
