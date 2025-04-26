using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactoryPattern.ExtandAbstractFactory
{
    /// <summary>
    /// 装机方案二：AMD的CPU+微星的主板
    /// 该方案里面创建的CPU与主板是可以匹配对应上的
    /// </summary>
    internal class Schema2 : IExtandAbstractFacoty
    {
        /// <summary>
        /// 创建产品
        /// </summary>
        /// <param name="type">这里的类型是表示对应的产品对象（如：1表示CPU;2表示主板）</param>
        /// <returns></returns>
        public object CreateProduct(int type)
        {
            object obj = null;
            switch (type)
            {
                case 1:
                    obj = new AmdCPU(940);
                    break;
                case 2:
                    obj = new MSIMainboard(940);
                    break;
                default:
                    break;
            }

            return obj;
        }

    }//Class_end
}
