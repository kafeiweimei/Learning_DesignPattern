using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactoryPattern
{
    /// <summary>
    /// 内存接口
    /// </summary>
    internal interface IMemory
    {
        //内存具有缓存数据的能力，仅示意
        void CacheDatas();

    }//Interface_end
}
