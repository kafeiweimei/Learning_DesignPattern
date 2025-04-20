using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingletonPattern
{
    /// <summary>
    /// 单例模式的懒汉式还体现了缓存的思想
    /// 1、当某些资源或数据被频繁使用，而这些资源或数据存在系统外部（如数据库、硬盘文件等）每次操作
    ///     这些数据的时候都得从数据库或磁盘上获取，速度会很慢，造成性能问题
    /// 2、一个简单的解决办法就是：把这些数据缓存到内存里面，每次操作的时候，先到内存里面找
    ///     （看看是否存在这些数据，若有则直接使用；没有就获取它并设置到缓存中，
    ///       下次访问就可以直接从内存获取，节省大量时间）缓存是一个种典型的空间换时间的方案
    /// </summary>
    internal class Cache
    {
        //定义缓存数据容器
        private Dictionary<string,object> _Dic=new Dictionary<string,object>();

        /// <summary>
        /// 从缓存中获取值
        /// </summary>
        /// <param name="key">键</param>
        /// <returns></returns>
        public object GetValue(string key)
        {
            //先从缓存里面获取值
            object obj = _Dic[key];
            if (obj==null)
            {
                //若缓存里面没有，那就去获取对应的数据（如读取数据库或磁盘文件获取）
                //我们这里仅作示意，虚拟一个值
                obj = $"{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}_{new Random().Next(0,99)}";
                //将获取的值设置到缓存里面
                _Dic[key] = obj ;
            }
            //若有值则直接返回
            return obj;
        }

    }//Class_end
}
