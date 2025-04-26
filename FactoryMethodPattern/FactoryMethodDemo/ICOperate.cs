using FactoryMethodPattern.IOC_DI_Demo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethodPattern.FactoryMethodDemo
{
    abstract class ICOperate
    {
        //定义一个抽象方法作为工厂
        protected abstract IC CreateC();

        //这里需要使用C,但是不知道用哪一个，就不主动创建C了，直接使用，然后让子类实现，客户端选择
        public void MSGNotify(string info)
        {
            CreateC().Notify(info);
        }

    }//Class_end
}
