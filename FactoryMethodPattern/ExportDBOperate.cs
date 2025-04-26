using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethodPattern
{
    /// <summary>
    /// 具体的创建器实现对象，实现创建导出数据库对象
    /// </summary>
    internal class ExportDBOperate : ExportOperate
    {
        protected override IExportFile FactoryMethod()
        {
            //创建导出数据库对象
            return new ExportDB();
        }
    }//Class_end
}
