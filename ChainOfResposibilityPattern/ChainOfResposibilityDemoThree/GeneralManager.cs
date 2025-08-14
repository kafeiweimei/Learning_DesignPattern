using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainOfResposibilityPattern.ChainOfResposibilityDemoThree
{
    /// <summary>
    /// 总经理职责
    /// </summary>
    internal class GeneralManager:Handler
    {
        public override object HandleRequest(RequestModel rm)
        {
            if (FeeRequestModel.FEE_TYPE.Equals(rm.GetCurType))
            {
                //返回处理的费用申请
                return HandleFeeRequest(rm);
            }
            else
            {
                //其他内容暂不处理使用默认逻辑
                return base.HandleRequest(rm);
            }
        }

        //处理费用申请
        private object HandleFeeRequest(RequestModel rm)
        {
            //先把通用的对象显式转换回来
            FeeRequestModel feeRequestModel = (FeeRequestModel)rm;

            string str = string.Empty;
            //总经理权限很大，只要到了这里都可以处理
            if (feeRequestModel.Fee >= 1000)
            {
                //为了测试简单只同意张三的申请
                if ("张三".Equals(feeRequestModel.User))
                {
                    str = $"总经理同意【{feeRequestModel.User}】聚餐费用【{feeRequestModel.Fee}】元的请求";
                }
                else
                {
                    str = $"总经理不同意【{feeRequestModel.User}】聚餐费用【{feeRequestModel.Fee}】元的请求";
                }
            }
            else
            {
                //若还有后续处理对象，则继续传递
                if (base.Successor!=null)
                {
                    return base.Successor.HandleRequest(rm);
                }
            }

            return str;
        }

    }//Class_end
}
