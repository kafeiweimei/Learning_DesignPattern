using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainOfResposibilityPattern.ChainOfResposibilityDemoTwo
{
    /// <summary>
    /// 职责对象接口
    /// </summary>
    abstract internal class Handler
    {
        /// <summary>
        /// 下一个处理请求对象
        /// </summary>
        public Handler Successor { get; set; }

        /// <summary>
        /// 费用申请
        /// </summary>
        /// <param name="user">申请人</param>
        /// <param name="fee">申请的费用</param>
        /// <returns>返回申请结果</returns>
        public abstract string HandleFeeRequest(string user,double fee);

        /// <summary>
        /// 预支费用申请
        /// </summary>
        /// <param name="user">申请人</param>
        /// <param name="fee">预支费用</param>
        /// <returns>true表示同意</returns>
        public abstract bool HandlePreFeeRequest(string user,double fee);

    }//Class_end
}
