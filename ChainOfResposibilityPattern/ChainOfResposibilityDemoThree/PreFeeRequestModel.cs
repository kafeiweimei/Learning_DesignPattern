using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainOfResposibilityPattern.ChainOfResposibilityDemoThree
{
    /// <summary>
    /// 预支费用申请模型
    /// </summary>
    internal class PreFeeRequestModel : RequestModel
    {
        /// <summary>
        /// 约定具体的业务类型
        /// </summary>
        public readonly static string FEE_TYPE="preFee";

        public PreFeeRequestModel() : base(FEE_TYPE)
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
