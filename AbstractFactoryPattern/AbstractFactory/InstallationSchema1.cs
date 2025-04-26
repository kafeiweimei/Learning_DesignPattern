using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactoryPattern.AbstractFactory
{
    /// <summary>
    /// 装机方案一：Intel的CPU+技嘉的主板
    /// 这里创建CPU和主板的时候，统一为1151接口匹配对应上的，不会出问题
    /// </summary>
    internal class InstallationSchema1 : IInstallationSchema
    {
        public ICPU CreateCPU()
        {
            return new IntelCPU(1151);
        }

        public IMainboard CreateMainboard()
        {
            return new GAMainboard(1151);
        }


    }//Class_end
}
