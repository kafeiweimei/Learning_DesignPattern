using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainOfResposibilityPattern.ChainOfResposibilityDemoOne
{
    /// <summary>
    /// 项目经理
    /// </summary>
    internal class ProjectManager : Handler
    {
        public override string HandleRequest(string user, double fee)
        {
            string str=string.Empty;
            //项目经理的权限比较小，只能在500以内
            if (fee < 500)
            {
                //为了测试简单，只同意张三的请求
                if ("张三".Equals(user))
                {
                    str = $"项目经理同意【{user}】聚餐费用【{fee}】元的请求";
                }
                else
                {
                    str = $"项目经理不同意【{user}】聚餐费用【{fee}】元的请求";
                }
            }
            else
            {
                //超过500继续传递给更高级别的人处理
                if (this.Successor!=null)
                {
                    return Successor.HandleRequest(user, fee);
                }
            }
            return str;
        }
    }//Class_end
}
