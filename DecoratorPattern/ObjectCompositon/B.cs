using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecoratorPattern.ObjectCompositon
{
    /// <summary>
    /// 【使用继承方式】实现对A对象A1方法的扩展
    /// </summary>
    internal class B:A
    {
        public void B1()
        {
            Console.WriteLine($"我是继承自A的B对象");
            base.A1();
            Console.WriteLine($"{this.GetType().Name}/B1()");
        }

        public void B2()
        {
            Console.WriteLine($"{this.GetType().Name}/这是扩展的功能B2");
        }

    }//Class_end
}
