using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainOfResposibilityPattern.ChainOfResposibilityDemoThree
{
    /// <summary>
    /// 部门经理职责
    /// </summary>
    internal class DepmentManager:Handler
    {
        /// <summary>
        /// 覆盖通用处理方法，按照业务类型调用自己的处理方法
        /// </summary>
        /// <param name="rm">请求对象</param>
        /// <returns></returns>
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

            string str=string.Empty;
            //部门经理的权限只能在1000以内
            if (feeRequestModel.Fee < 1000)
            {
                //为了测试简单只同意张三的申请
                if ("张三".Equals(feeRequestModel.User))
                {
                    str = $"部门经理同意【{feeRequestModel.User}】聚餐费用【{feeRequestModel.Fee}】元的请求";
                }
                else
                {
                    str = $"部门经理不同意【{feeRequestModel.User}】聚餐费用【{feeRequestModel.Fee}】元的请求";
                }
            }
            else
            {
                //超过1000的，继续传递给更高级别的人处理
                if (base.Successor != null)
                {
                    return Successor.HandleRequest(rm);
                }
            }
            return str;
        }
        

    }//Class_end
}
