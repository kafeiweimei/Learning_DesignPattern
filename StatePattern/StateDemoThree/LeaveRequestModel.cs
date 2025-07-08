using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatePattern.StateDemoThree
{
    /// <summary>
    /// 请假单
    /// </summary>
    internal class LeaveRequestModel
    {
        /// <summary>
        /// 请假人
        /// </summary>
        public string? User { get; set; }

        /// <summary>
        /// 请假开始时间
        /// </summary>
        public string? BeginDate { get; set; }

        /// <summary>
        /// 请假天数
        /// </summary>
        public int? LeaveDays { get;set; }

        /// <summary>
        /// 审核结果
        /// </summary>
        public string? AuditResult { get; set; }


    }//Class_end
}
