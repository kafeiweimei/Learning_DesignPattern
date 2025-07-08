using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatePattern.StateDemoThree
{
    /// <summary>
    /// 处理部门经理的审核（处理后对应审核结束状态）
    /// </summary>
    internal class DepartmentManagerState2 : ILeaveRequestState
    {
        public void Dowork(StateMachine stateMachine)
        {
            //1-先把业务模型创建出来
            LeaveRequestModel model = (LeaveRequestModel)stateMachine.BusinessModel;
            //模拟用户处理界面
            Console.WriteLine("部门经理审核中，请稍后。。。");
            Console.WriteLine($"【{model?.User}】申请从【{model?.BeginDate}】开始请假【{model?.LeaveDays}】天，请审核（1：同意；2：不同意）");
            string? strInput = Console.ReadLine();
            if (!string.IsNullOrEmpty(strInput))
            {
                //设置会上下文中
                string result = "不同意";
                if ("1".Equals(strInput))
                {
                    result = "同意";
                }
                model.AuditResult = result;
            }

            //2-业务处理，将审核结果保存到数据库中

            //3-部门经理审核通过后，直接转向审核结束状态
            stateMachine.State = new AuditOverState2();
            stateMachine.Dowork();
            //4-给申请人增加一个提示，让他可以查看当前的最新审核结果


        }
    }//Class_end
}
