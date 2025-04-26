using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactoryPattern.AbstractFactory
{
    /// <summary>
    /// 装机方案二：AMD的CPU+微星的主板
    /// 这里创建CPU和主板的时候，统一为940接口匹配对应上的，不会出问题
    /// </summary>
    internal class InstallationSchema2 : IInstallationSchema
    {
        public ICPU CreateCPU()
        {
            return new AmdCPU(940);
        }

        public IMainboard CreateMainboard()
        {
            return new MSIMainboard(940);
        }

    }//Class_end
}
