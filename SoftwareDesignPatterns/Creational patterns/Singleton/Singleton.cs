using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareDesignPatterns.Creational_patterns.Singleton
{
    public class Singleton
    {
        private static Singleton instance;

        private Singleton()
        { }

        public static Singleton getInstance()
        {
            if (instance == null)
                instance = new Singleton();
            return instance;
        }
    }
    public class SingletonThreadSafe
    {
        private static SingletonThreadSafe instance;
        private static object syncRoot = new object();

        private SingletonThreadSafe()
        { }

        public static SingletonThreadSafe getInstance()
        {
            if (instance == null)
            {
                lock (syncRoot)
                {
                    if (instance == null)
                        instance = new SingletonThreadSafe();
                }
            }
            return instance;
        }
    }
}
