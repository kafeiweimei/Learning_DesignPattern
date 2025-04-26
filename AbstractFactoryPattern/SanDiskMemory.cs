using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactoryPattern
{
    /// <summary>
    /// 闪迪内存条
    /// </summary>
    internal class SanDiskMemory:IMemory
    {
        //定义内存条的频率(HZ)
        private int memoryRate = 2133;

        public SanDiskMemory()
        {
            
        }

        public SanDiskMemory(int memoryRate)
        {
            this.memoryRate = memoryRate;
        }

        public void CacheDatas()
        {
            Console.WriteLine($"现在使用闪迪内存条，内存条频率是【{memoryRate}】");
        }
    }//Class_end
}
