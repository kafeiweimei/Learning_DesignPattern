using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactoryPattern.ExtandAbstractFactory
{
    internal class Schema3 : IExtandAbstractFacoty
    {
        /// <summary>
        /// 创建产品
        /// </summary>
        /// <param name="type">这里的类型是表示对应的产品对象（如：1表示CPU;2表示主板；3表示内存条）</param>
        /// <returns>返回具体的产品对象</returns>
        public object CreateProduct(int type)
        {
            object obj = null;
            switch (type)
            {
                case 1:
                    obj = new AmdCPU(1151);
                    break;
                case 2:
                    obj = new MSIMainboard(1151);
                    break;
                case 3:
                    obj = new SanDiskMemory(3200);
                    break;
                default:
                    break;
            }
            return obj;
        }

    }//Class_end
}
