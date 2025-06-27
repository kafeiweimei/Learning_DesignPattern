using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemplateMethodPattern
{
    /// <summary>
    /// 工作人员的模型
    /// </summary>
    internal class WorkerModel
    {
        public string? Uuid { get; set; }
        public string? WorkerId { get; set; }
        public string? UserName { get; set; }
        public string? Password { get; set; }

    }//Class_end
}
