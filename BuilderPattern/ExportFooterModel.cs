using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuilderPattern
{
    /// <summary>
    /// 描述输出到文件尾的内容对象
    /// </summary>
    internal class ExportFooterModel
    {
        //输出人
        private string? exportUser;

        public string ExportUser { get => exportUser; set => exportUser = value; }

    }//Class_end
}
