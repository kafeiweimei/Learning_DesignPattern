using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatePattern.StateDemoThree
{
    /// <summary>
    /// 项目经理审核（项目经理审核后可能对应部门经理审核；或者是审核结束后的一种）
    /// </summary>
    internal class ProjectManagerState2 : ILeaveRequestState
    {
        public void Dowork(StateMachine stateMachine)
        {
            //1-创建业务对象模型
            LeaveRequestModel model = (LeaveRequestModel)stateMachine.BusinessModel;
            
            //模拟用户处理界面，通过控制台读取和显示数据
            Console.WriteLine("项目经理审核中，请稍后。。。");
            Console.WriteLine($"【{model?.User}】申请从【{model?.BeginDate}】开始请假【{model?.LeaveDays}】天，请审核（1：同意；2：不同意）");
            string? strInput=Console.ReadLine();
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
            //2-业务处理，把审核结果保存到数据库中

            //3-分解选择的结果和条件设置下一步骤
            if ("同意".Equals(model?.AuditResult))
            {
                if (model.LeaveDays > 3)
                {
                    //如果请假天数大于3天，且项目经理同意则提交部门经理
                    stateMachine.State = new DepartmentManagerState2();
                    //为部门经理增加工作
                    stateMachine.Dowork();
                }
                else
                {
                    //如果请假天数在3天及其以内，就由项目经理做主审批后转为结束状态
                    stateMachine.State = new AuditOverState2();
                    stateMachine.Dowork();
                }
            }
            else
            {
                //项目经理不同意的话，也就不用提交给部门经理了，直接转为审核结束状态
                stateMachine.State = new AuditOverState2();
                stateMachine.Dowork();
            }

            //4-给申请人增加一个提示，让他可以查看当前的最新审核结果
        }
    }//Class_end
}
