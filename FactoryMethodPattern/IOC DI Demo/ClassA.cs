using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethodPattern.IOC_DI_Demo
{
    /// <summary>
    /// 我们需要再类A里面使用C,正常情况下我们是直接创建C的实例使用；
    /// 但我们让类A不在主动获取C,而是被动等待IOC/DI的容器获取一个C的实例，在注入到A类中
    /// </summary>
    internal class ClassA
    {
        //定义IC，但不实例化创建，等待被注入
        private IC c = null;

        public ClassA(IC c)
        {
            //在这里等待IC对象实例的注入
            this.c = c;
        }

        public void Test(string info)
        {
            //这里需要使用IC,但是并不主动实例化创建IC,直接从外部获取
            c.Notify(info);
        }


    }//Class_end
}
