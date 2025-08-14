using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainOfResposibilityPattern.ChainOfResposibilityDemoTwo
{
    /// <summary>
    /// 总经理职责
    /// </summary>
    internal class GeneralManager : Handler
    {
        public override string HandleFeeRequest(string user, double fee)
        {
            string str = string.Empty;
            //总经理权限很大，只要到了这里都可以处理
            if (fee >= 1000)
            {
                //为了测试简单只同意张三的申请
                if ("张三".Equals(user))
                {
                    str = $"总经理同意【{user}】聚餐费用【{fee}】元的请求";
                }
                else
                {
                    str = $"总经理不同意【{user}】聚餐费用【{fee}】元的请求";
                }
            }
            else
            {
                //若还有后续的处理对象，则继续传递
                if (Successor != null)
                {
                    return Successor.HandleFeeRequest(user, fee);
                }
            }
            return str;
        }

        public override bool HandlePreFeeRequest(string user, double fee)
        {
            string str = string.Empty;
            //总经理权限很大，只要到了这里都可以处理
            if (fee >= 10000)
            {
                str = $"总经理同意【{user}】预支费用【{fee}】元的请求";
                Console.WriteLine(str);
                return true;
            }
            else
            {
                //若还有后续的处理对象，则继续传递
                if (Successor != null)
                {
                    return Successor.HandlePreFeeRequest(user, fee);
                }
            }
            return false;
        }
    }//Class_end
}
