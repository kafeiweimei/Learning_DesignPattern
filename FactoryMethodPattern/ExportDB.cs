using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethodPattern
{
    /// <summary>
    /// 导出为数据库格式的对象
    /// </summary>
    internal class ExportDB : IExportFile
    {
        public bool Export(string data)
        {
            //简单示意
            Console.WriteLine($"导出【{data}】数据到数据库中");
            return true;
        }
    }//Class_end
}
