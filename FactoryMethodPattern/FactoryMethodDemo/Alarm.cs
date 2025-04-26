using FactoryMethodPattern.IOC_DI_Demo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethodPattern.FactoryMethodDemo
{
    /// <summary>
    /// 具体实现IC接口的报警类
    /// </summary>
    internal class Alarm : IC
    {
        public void Notify(string info)
        {
            Console.WriteLine($"具体实现接口方法的C1类对象，内容是【{info}】");
        }

    }//Class_end
}
