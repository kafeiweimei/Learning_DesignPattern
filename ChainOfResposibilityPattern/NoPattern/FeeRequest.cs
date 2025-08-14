using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainOfResposibilityPattern.NoPattern
{
    /// <summary>
    /// 费用申请
    /// </summary>
    internal class FeeRequest
    {
        /// <summary>
        /// 提交聚餐费用申请给项目经理
        /// </summary>
        /// <param name="user">申请人</param>
        /// <param name="fee">申请费用</param>
        /// <returns></returns>
        public string RequestToProjectManager(string user, double fee)
        {
            string str=string.Empty;
            if (fee < 500)
            {
                //项目经理的权限比较小，只能在500以内
                str =ProjectManagerHandle(user,fee);

            }
            else if (fee < 1000)
            {
                //部门经理的权限只能在1000以内
                str =DepmentManagerHandle(user,fee);
            }
            else if (fee >= 1000)
            {
                //总经理权限较大，只要请求到了这里都可以处理
                str=GeneralManagerHandle(user,fee);
            }

            return str;
        }

        //项目经理审批费用
        private string ProjectManagerHandle(string user, double fee)
        {
            string str = string.Empty;
            //为了测试简单只同意张三
            if ("张三".Equals(user))
            {
                str = $"项目经理同意【{user}】聚餐费用【{fee}】元的请求";
            }
            else
            {
                //其他人一律不同意
                str = $"项目经理不同意【{user}】聚餐费用【{fee}】元的请求";
            }
            return str;
        }

        //部门经理审批费用
        private string DepmentManagerHandle(string user, double fee)
        {
            string str = string.Empty;
            //为了测试简单只同意张三
            if ("张三".Equals(user))
            {
                str = $"部门经理同意【{user}】聚餐费用【{fee}】元的请求";
            }
            else
            {
                //其他人一律不同意
                str = $"部门经理不同意【{user}】聚餐费用【{fee}】元的请求";
            }
            return str;
        }

        //总经理审批费用
        private string GeneralManagerHandle(string user, double fee)
        {
            string str = string.Empty;
            //为了测试简单只同意张三
            if ("张三".Equals(user))
            {
                str = $"总经理同意【{user}】聚餐费用【{fee}】元的请求";
            }
            else
            {
                //其他人一律不同意
                str = $"总经理不同意【{user}】聚餐费用【{fee}】元的请求";
            }
            return str;
        }

    }//Class_end
}
