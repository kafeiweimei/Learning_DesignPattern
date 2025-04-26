using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactoryPattern
{
    /// <summary>
    /// 创建CPU的简单工厂
    /// </summary>
    internal class CPUFactory
    {
        /// <summary>
        /// 创建CPU对象方法
        /// </summary>
        /// <param name="type">CPU类型【1表示Intel；2表示AMD】</param>
        /// <returns></returns>
        public static ICPU CreateCPU(int type)
        {
            ICPU cpu = null;
            switch (type)
            {
                case 1:
                    cpu = new IntelCPU();
                    break;
                case 2:
                    cpu = new AmdCPU();
                    break;
                default:
                    break;
            }
            return cpu;
        }



    }//Class_end
}
