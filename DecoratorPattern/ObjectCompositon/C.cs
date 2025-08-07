using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecoratorPattern.ObjectCompositon
{
    internal class C
    {
        public void C1()
        {
            Console.WriteLine($"我是{this.GetType().Name}对象/C1()");
        }

    }//Class_end
}
