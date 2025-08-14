using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainOfResposibilityPattern.ChainOfResposibilityDemoOne
{
    /// <summary>
    /// 部门经理职责
    /// </summary>
    internal class DepmentManager : Handler
    {
        public override string HandleRequest(string user, double fee)
        {
            string str = string.Empty;
            //部门经理的权限只能在1000以内
            if (fee < 1000)
            {
                //为了测试简单只同意张三的申请
                if ("张三".Equals(user))
                {
                    str = $"部门经理同意【{user}】聚餐费用【{fee}】元的请求";
                }
                else
                {
                    str = $"部门经理不同意【{user}】聚餐费用【{fee}】元的请求";
                }
            }
            else
            {
                //超过1000元，继续传递给更高级别的人处理
                if (this.Successor!=null)
                {
                    return this.Successor.HandleRequest(user, fee);
                }
            }
            return str;
        }
    }//Class_end
}
