using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlyweightPattern.FlyweightDemoTwo
{
    /// <summary>
    /// 享元工厂【实现为单例】
    /// </summary>
    internal class FlyweightFactory
    {
        //本类实例
        private static readonly Lazy<FlyweightFactory> lazy = new Lazy<FlyweightFactory>(() => new FlyweightFactory());

        //本类单例
        public static FlyweightFactory Instance { get { return lazy.Value; } }

        //禁止本类被外部new
        private FlyweightFactory()
        {

        }

        //缓存多个Flyweight对象
        private Dictionary<string, IFlyweight> flyweightDic = new Dictionary<string, IFlyweight>();

        //获取state对应的享元对象
        public IFlyweight GetIFlyweight(string state)
        {
            IFlyweight fw = null;
            if (string.IsNullOrEmpty(state)) return fw;

            if (flyweightDic.ContainsKey(state))
            {
                fw = flyweightDic[state];
            }
            else
            {
                fw = new AuthorizationFlyweight(state);
                AddInfoToDic(state, fw);
            }
            return fw;
        }

        //添加信息到字典中
        private void AddInfoToDic(string needAddKey, IFlyweight flyweight)
        {
            if (string.IsNullOrEmpty(needAddKey) || flyweight == null)
            {
                return;
            }

            if (flyweightDic != null && flyweightDic.ContainsKey(needAddKey))
            {
                flyweightDic.Add(needAddKey, flyweight);
            }
            else
            {
                flyweightDic[needAddKey] = flyweight;
            }
        }

    }//Class_end
}
