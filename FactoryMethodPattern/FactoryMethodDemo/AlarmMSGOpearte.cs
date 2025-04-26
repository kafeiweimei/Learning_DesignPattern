using FactoryMethodPattern.IOC_DI_Demo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethodPattern.FactoryMethodDemo
{
    internal class AlarmMSGOpearte : ICOperate
    {
        protected override IC CreateC()
        {
            //直接在具体的报警消息操作里面使用对应的对象
            return new Alarm();
        }
    }//Class_end
}
