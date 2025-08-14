using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainOfResposibilityPattern.ChainOfResposibilityDemoThree
{
    /// <summary>
    /// 项目经理职责扩展
    /// 现在既可以处理一般的费用申请，还可以处理预支费用
    /// </summary>
    internal class ProjectManagerExtand : ProjectManager
    {
        /// <summary>
        /// 覆盖通用处理方法，按照业务类型调用自己的处理方法
        /// </summary>
        /// <param name="rm">请求对象</param>
        /// <returns></returns>
        public override object HandleRequest(RequestModel rm)
        {
            if (PreFeeRequestModel.FEE_TYPE.Equals(rm.GetCurType))
            {
                //返回处理的预支费用申请
                return HandlePreFeeRequest(rm);
            }
            else
            {
                //其他内容暂不处理使用父类逻辑
                return base.HandleRequest(rm);
            }
        }

        /// <summary>
        /// 处理预支费用申请
        /// </summary>
        /// <param name="rm">请求类型</param>
        /// <returns></returns>
        private object HandlePreFeeRequest(RequestModel rm)
        {
            //先把通用的对象显式转换回来
            PreFeeRequestModel preFeeRequestModel = (PreFeeRequestModel)rm;

            //项目经理的权限较小，只能在5000以内
            if (preFeeRequestModel.Fee < 5000)
            {
                //工作需要，全部同意
                string str = $"项目经理同意【{preFeeRequestModel.User}】聚餐费用【{preFeeRequestModel.Fee}】元的请求";
                Console.WriteLine(str);
                return true;
            }
            else
            {
                //超过5000的，继续传递给更高级别的人处理
                if (base.Successor!=null)
                {
                    return Successor.HandleRequest(rm);
                }
            }
            return false;
        }

    }//Class_end
}
