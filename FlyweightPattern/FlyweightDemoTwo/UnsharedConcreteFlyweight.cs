using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlyweightPattern.FlyweightDemoTwo
{
    /// <summary>
    /// 不需要共享的享元对象实现【即组合模式中的组合对象】
    /// </summary>
    internal class UnsharedConcreteFlyweight:IFlyweight
    {
        //记录每个组合对象所包含的子组件
        private List<IFlyweight> flyweightlist = new List<IFlyweight>();

        public void Add(IFlyweight fw)
        {
            flyweightlist.Add(fw);
        }

        public bool Math(string securityEntity, string permit)
        {
            foreach (var fw in flyweightlist)
            {
                //递归调用
                if (fw.Math(securityEntity,permit))
                {
                    return true;
                }
            }

            return false;
        }

        public override string ToString()
        {
            string str = "";
            if (flyweightlist!=null && flyweightlist?.Count>0)
            {
                foreach (var fw in flyweightlist)
                {
                    str+= $"{fw.ToString()}";
                }
            }

            return str;
        }

    }//Class_end
}
