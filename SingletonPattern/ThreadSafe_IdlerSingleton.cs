using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingletonPattern
{
    /// <summary>
    /// 线程安全的【饿汉式】单例（使用锁会耗费很多时间在线程同步上）
    /// </summary>
    internal class ThreadSafe_IdlerSingleton
    {
        //1、定义一个用于保存实例的静态变量
        private static ThreadSafe_IdlerSingleton instance;
        //2、定义一个保证线程同步的标识
        private static readonly object synchronized=new object();

        //3、私有构造函数（外界不能创建该类实例）
        private ThreadSafe_IdlerSingleton() { }

        //4、创建本类单例实例
        public static ThreadSafe_IdlerSingleton GetInstance()
        {
            //先检查实例是否存在，若不存在在加锁处理
            if (instance==null)
            {
                //同步块，加锁处理
                lock (synchronized)
                {
                    //再次判断实例是否存在，不存在才创建
                    if (instance == null)
                    {
                        instance = new ThreadSafe_IdlerSingleton();
                    }
                }
            }
            return instance;
        }

    }//Class_end
}
