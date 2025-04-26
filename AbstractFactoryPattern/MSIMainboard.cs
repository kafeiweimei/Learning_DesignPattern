using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactoryPattern
{
    internal class MSIMainboard : IMainboard
    {
        private int cpuHoles = 1151;

        public MSIMainboard()
        {
            
        }
        public MSIMainboard(int cpuHoles)
        {
            this.cpuHoles = cpuHoles;
        }
        public void InstallCPU()
        {
            Console.WriteLine($"微星主板，主板插槽数为【{cpuHoles}】");
        }

    }//Class_end
}
