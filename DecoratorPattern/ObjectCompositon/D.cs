using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecoratorPattern.ObjectCompositon
{
    internal class D
    {
        public void D1()
        {
            Console.WriteLine($"我是{this.GetType().Name}对象/D1()");
        }

    }//Class_end
}
