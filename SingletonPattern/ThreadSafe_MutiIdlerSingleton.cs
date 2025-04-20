using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingletonPattern
{
    /// <summary>
    /// 可控制实例数量的单例模式(线程安全)
    /// </summary>
    internal class ThreadSafe_MutiIdlerSingleton
    {
        //私有构造函数
        private ThreadSafe_MutiIdlerSingleton() { }
        //定义一个保证线程同步的标识
        private static readonly object synchronized = new object();

        //定义一个缺省的键前缀
        private static string defaultPreKey = "sn";

        //定义一个缓存实例的容器
        private static Dictionary<string, ThreadSafe_MutiIdlerSingleton> dic 
            = new Dictionary<string, ThreadSafe_MutiIdlerSingleton>();
        //定义一个用来记录当前正在使用第几个实例，用以控制最大实例数量，到最大实例数量后，又从1开始
        private static int number = 1;
        //定一个控制实例的最大数量
        private static int maxNum = 3;

        public static ThreadSafe_MutiIdlerSingleton GetInstance()
        {
            string strKey=defaultPreKey+number;
            ThreadSafe_MutiIdlerSingleton instance = null;

            if (dic.ContainsKey(strKey))
            {
                instance = dic[strKey];
            }
            if (instance == null)
            {
                //同步块，加锁处理
                lock (synchronized)
                {
                    //再次判断实例是否存在，不存在才创建
                    if (instance == null && !dic.ContainsKey(strKey))
                    {
                        instance = new ThreadSafe_MutiIdlerSingleton();
                        dic.TryAdd(strKey, instance);
                    }
                    else
                    {
                        instance = dic[strKey];
                    }
                }
            }
            number++;
            if (number>maxNum)
            {
                number = 1;
            }
            return instance;
        }

    }//Class_end
}
