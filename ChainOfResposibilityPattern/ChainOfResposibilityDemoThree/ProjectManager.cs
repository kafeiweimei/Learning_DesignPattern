using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainOfResposibilityPattern.ChainOfResposibilityDemoThree
{
    /// <summary>
    /// 项目经理职责
    /// </summary>
    internal class ProjectManager:Handler
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

        /// <summary>
        /// 处理费用申请
        /// </summary>
        /// <param name="rm">请求类型</param>
        /// <returns></returns>
        private object HandleFeeRequest(RequestModel rm)
        {
            //先把通用的对象显式转换回来
            FeeRequestModel feeRequestModel = (FeeRequestModel)rm;

            string str=string.Empty;
            //项目经理的权限较小，只能在500以内
            if (feeRequestModel.Fee < 500)
            {
                //为了测试简单，只同意张三的请求
                if ("张三".Equals(feeRequestModel.User))
                {
                    str = $"项目经理同意【{feeRequestModel.User}】聚餐费用【{feeRequestModel.Fee}】元的请求";
                }
                else
                {
                    //其他人一律不同意
                    str = $"项目经理不同意【{feeRequestModel.User}】聚餐费用【{feeRequestModel.Fee}】元的请求";
                }
            }
            else
            {
                //超过500的，继续传递给更高级别的人处理
                if (base.Successor!=null)
                {
                    return Successor.HandleRequest(rm);
                }
            }
            return str;
        }

    }//Class_end
}
