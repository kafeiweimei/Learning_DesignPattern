using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethodPattern
{
    /// <summary>
    /// 具体的创建器实现对象，实现导出成本文本对象
    /// </summary>
    internal class ExportTxtFileOperate : ExportOperate
    {
        protected override IExportFile FactoryMethod()
        {
            //创建导出为文本的对象
            return new ExportTxtFile();
        }

    }//Class_end
}
