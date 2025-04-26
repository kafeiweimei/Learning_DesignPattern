using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethodPattern
{
    internal class ExtandParameterExportOperate:ParameterExportOperate
    {
        protected override IExportFile FactoryMethod(int type)
        {
            IExportFile exportFile = null;
            //可以全部覆盖重写，也可以直接添加类型实现拓展
            if (type == 3)
            {
                exportFile = new ExportXml();
            }
            else
            {
                exportFile=base.FactoryMethod(type);
            }
            return exportFile;
        }


    }//Class_end
}
