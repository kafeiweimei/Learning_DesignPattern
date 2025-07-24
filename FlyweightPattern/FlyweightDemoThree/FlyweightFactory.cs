using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace FlyweightPattern.FlyweightDemoThree
{
    /// <summary>
    /// 享元工厂【实现为单例】实现垃圾回收和引用计数功能
    /// </summary>
    internal class FlyweightFactory
    {
        //本类实例
        private static readonly Lazy<FlyweightFactory> lazy= new Lazy<FlyweightFactory>(() => new FlyweightFactory());
        //本类单例
        public static FlyweightFactory Instance { get { return lazy.Value; } }
        //禁止本类被外部new
        private FlyweightFactory() 
        {
            //启动清除缓存值的线程
            Task task = Task.Run(() =>
            {
                ClearCache();
            });
        }

        //缓存多个IFlyweight对象
        private Dictionary<string,IFlyweight> fwDic= new Dictionary<string,IFlyweight>();
        //缓存被共享对象的缓存配置
        private Dictionary<string,CacheConfModel>cacheConfDic= new Dictionary<string,CacheConfModel>();
        //记录缓存对象被引用的次数
        private Dictionary<string,int> countDic= new Dictionary<string,int>();

        //默认6秒钟,单位是毫秒【这个时间可以根据应用的要求来设置】
        private readonly long DURABLE_TIME = 6 * 1000L;

        private readonly object useCountLock = new object();
        //获取某个享元被使用的次数
        public int GetUseTimes(string key)
        {
            lock (useCountLock)
            {
                if (countDic.ContainsKey(key))
                {
                    int count = countDic[key];
                    return count;
                }
                else
                {
                    return -1;
                }
                
            }
        }

        private readonly object flyweightLock = new object();
        //获取state对应的享元对象
        public IFlyweight GetIFlyweight(string state)
        {
            lock(flyweightLock)
            {
                if (!fwDic.ContainsKey(state))
                {
                    IFlyweight flyweight = new AuthorizationFlyweight(state);
                    AddInfoToDic(ref fwDic, state, flyweight);
                    //同时设置引用计数
                    AddInfoToDic(ref countDic, state, 1);

                    //同时设置缓存配置数据
                    CacheConfModel ccm = new CacheConfModel();
                    //指获取当前时间与1970年1月1日00:00:00 GMT之间所差的毫秒数
                    ccm.BeginTime = GetCurrentMills();
                    ccm.Forever = false;
                    ccm.DurableTime = DURABLE_TIME;
                    AddInfoToDic(ref cacheConfDic,state,ccm);

                    return flyweight;
                }
                else
                {
                    IFlyweight flyweight = fwDic[state];
                    //表示还在使用，那么应该重新设置缓存配置
                    CacheConfModel ccm = cacheConfDic[state];
                    ccm.BeginTime = GetCurrentMills();
                    //设置回容器中
                    AddInfoToDic(ref cacheConfDic, state, ccm);
                    //同时计数加1
                    int count = countDic[state];
                    count++;
                    AddInfoToDic(ref countDic,state,count);

                    return flyweight;

                }
            }
        }

        private readonly object opcFlyweightLock = new object();
        //删除state对应的享元对象，且清除对应的缓存配置和引用次数记录
        private void RemoveFlyweight(string state)
        {
            lock(opcFlyweightLock)
            {
                fwDic.Remove(state);
                cacheConfDic.Remove(state);
                countDic.Remove(state);
            }
        }

        //维护清除缓存的方法
        private void ClearCache()
        {
            List<string> tmpList = new List<string>();
            while (true)
            {
                foreach (var item in cacheConfDic)
                {
                    CacheConfModel ccm = item.Value;
                    //比较是否需要清除
                    long tmpTime = GetCurrentMills() - ccm.BeginTime;
                    if (tmpTime >= ccm.DurableTime)
                    {
                        //可以清除，先缓存下来
                        tmpList.Add(item.Key);
                    }
                }

                //真正清除
                for (int i = 0; i < tmpList.Count; i++)
                {
                    string state = tmpList[i];
                    FlyweightFactory.Instance.RemoveFlyweight(state);
                }

                string strState = string.Empty;
                fwDic.ToList().ForEach(item => strState += $"【{item.Key}】");
                Console.WriteLine($"现在 缓存多个IFlyweight容器数量是【{fwDic.Count}】内容是{strState}");
                

                //休息2秒后再重新判断
                try
                {
                    Thread.Sleep(1000);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"清除缓存的方法异常,异常内容是【{ex.Message}】");

                }
            }
        }

        //添加信息到字典中
        private void AddInfoToDic<T1,T2>(ref Dictionary<T1,T2> dic,T1 key, T2 value)
        {
            if (key==null || key.Equals("") ||value==null || value.Equals("") || dic==null)
            {
                return;
            }

            if (dic.ContainsKey(key))
            {
                dic[key] = value;
            }
            else
            {
                dic.Add(key, value);
            }
        }

        /// <summary>
        /// 获取当前时间与1970年1月1日00:00:00 GMT之间所差的毫秒数
        /// </summary>
        /// <returns></returns>
        private long GetCurrentMills()
        {
            //DateTime startDT = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            //long currentMills = (long)(DateTime.UtcNow-startDT).TotalMilliseconds;
            long currentMills = (long)DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds;
            return currentMills;
        }

    }//Class_end
}
