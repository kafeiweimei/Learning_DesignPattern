using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactoryPattern
{
    internal class GAMainboard : IMainboard
    {
        private int cpuHoles = 940;

        public GAMainboard()
        {
            
        }
        public GAMainboard(int cpuHoles)
        {
            this.cpuHoles = cpuHoles;     
        }

        public void InstallCPU()
        {
            Console.WriteLine($"技嘉主板，主板插槽数为【{cpuHoles}】");
        }

    }//Class_end
}
