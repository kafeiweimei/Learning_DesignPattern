using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactoryPattern
{
    internal class AmdCPU : ICPU
    {
        private int pins = 940;

        public AmdCPU()
        {
            
        }
        public AmdCPU(int pins)
        {
            this.pins = pins;
        }
        public void Calculate()
        {
            Console.WriteLine($"AMD的CPU，针脚数为【{pins}】");
        }
    }//Class_end
}
