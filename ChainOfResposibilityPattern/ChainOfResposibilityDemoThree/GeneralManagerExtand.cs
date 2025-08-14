using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainOfResposibilityPattern.ChainOfResposibilityDemoThree
{
    /// <summary>
    /// 总经理职责拓展
    /// </summary>
    internal class GeneralManagerExtand : GeneralManager
    {
        public override object HandleRequest(RequestModel rm)
        {
            if (PreFeeRequestModel.FEE_TYPE.Equals(rm.GetCurType))
            {
                //返回处理的费用申请
                return HandlePreFeeRequest(rm);
            }
            else
            {
                //其他内容暂不处理使用默认逻辑
                return base.HandleRequest(rm);
            }
        }

        //处理费用申请
        private object HandlePreFeeRequest(RequestModel rm)
        {
            //先把通用的对象显式转换回来
            PreFeeRequestModel preFeeRequestModel = (PreFeeRequestModel)rm;

            //总经理权限很大，只要到了这里都可以处理
            if (preFeeRequestModel.Fee >= 10000)
            {
                //工作需要全部同意
                string str = $"总经理同意【{preFeeRequestModel.User}】预支费用【{preFeeRequestModel.Fee}】元的请求";
                Console.WriteLine(str);
                return true;
            }
            else
            {
                //若还有后续处理对象，则继续传递
                if (base.Successor!=null)
                {
                    return base.Successor.HandleRequest(rm);
                }
            }

            return false;
        }

    }//Class_end
}
