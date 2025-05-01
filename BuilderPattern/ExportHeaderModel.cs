using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuilderPattern
{
    /// <summary>
    /// 描述输出到文件头的内容对象
    /// </summary>
    internal class ExportHeaderModel
    {
        //分公司或门市店编号
        private string? depId;
        //导出数据的日期
        private string? exportDate;

        public string DepId { get => depId; set => depId = value; }
        public string ExportDate { get => exportDate; set => exportDate = value; }

    }//Class_end
}
