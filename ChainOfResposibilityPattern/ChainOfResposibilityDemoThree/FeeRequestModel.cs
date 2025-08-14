using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainOfResposibilityPattern.ChainOfResposibilityDemoThree
{
    /// <summary>
    /// 费用申请业务相关数据模型
    /// </summary>
    internal class FeeRequestModel:RequestModel
    {
        /// <summary>
        /// 约定具体的业务类型
        /// </summary>
        public readonly static string FEE_TYPE = "fee";

        public FeeRequestModel() : base(FEE_TYPE)
        {
        }

        /// <summary>
        /// 申请人
        /// </summary>
        public string User { get; set; }

        /// <summary>
        /// 申请金额
        /// </summary>
        public double Fee { get; set; }

    }//Class_end
}
