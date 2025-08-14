using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainOfResposibilityPattern.ChainOfResposibilityDemoThree
{
    /// <summary>
    /// 部门经理职责拓展
    /// </summary>
    internal class DepmentManagerExtand : DepmentManager
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
                //其他内容暂不处理使用默认逻辑
                return base.HandleRequest(rm);
            }
        }


        //处理预支费用申请
        private object HandlePreFeeRequest(RequestModel rm)
        {
            //先把通用的对象显式转换回来
            PreFeeRequestModel preFeeRequestModel = (PreFeeRequestModel)rm;

            //部门经理的权限只能在10000以内
            if (preFeeRequestModel.Fee < 10000)
            {
                //工作需要，全部同意
                string str = $"部门经理同意【{preFeeRequestModel.User}】预支费用【{preFeeRequestModel.Fee}】元的请求";
                Console.WriteLine(str);
                return true;
            }
            else
            {
                //超过10000的，继续传递给更高级别的人处理
                if (base.Successor != null)
                {
                    return Successor.HandleRequest(rm);
                }
            }
            return false;
        }
        

    }//Class_end
}
