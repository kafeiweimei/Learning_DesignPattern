using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingletonPattern
{
    /// <summary>
    /// 线程安全的【饿汉式】单例方案二（使用锁会耗费很多时间在线程同步上）
    /// </summary>
    internal class ThreadSafe2_IdlerSingleton
    {
        //1、私有化个构造方法
        private ThreadSafe2_IdlerSingleton() { }

        //2、定义一个没有与该类进行绑定的静态类，只有被调用时才会被装载，从而实现延迟加载
        private static class SingletonHolder
        {
            /*
             * 静态初始化【即：只有这个类被装载并被初始化时，会初始化为静态域，从而创建ThreadSafe2_IdlerSingleton的实例】
             * 由于是静态域，因此只会在程序装载类时初始化一次，并由AppDomain来保证它的线程安全
             */
            internal static readonly ThreadSafe2_IdlerSingleton instance = new ThreadSafe2_IdlerSingleton();
        }

        //3、创建本类的单例方法
        public static ThreadSafe2_IdlerSingleton GetInstance()
        {
            return SingletonHolder.instance;
        }
       
    }//Class_end
}
