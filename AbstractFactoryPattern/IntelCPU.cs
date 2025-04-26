using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactoryPattern
{
    /// <summary>
    /// Intel的CPU
    /// </summary>
    internal class IntelCPU : ICPU
    {
        private int pins = 1151;

        public IntelCPU()
        {
            
        }
        public IntelCPU(int pins)
        {
            this.pins = pins;
        }
        public void Calculate()
        {
            Console.WriteLine($"Intel的CPU，针脚数为【{pins}】");
        }

    }//Class_end
}
