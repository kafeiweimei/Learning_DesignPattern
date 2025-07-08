using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatePattern.StateDemoThree
{
    /// <summary>
    /// 处理审核结束状态
    /// </summary>
    internal class AuditOverState : ILeaveRequestState
    {
        public void Dowork(StateMachine stateMachine)
        {
            //1-先把业务模型创建出来
            LeaveRequestModel model = (LeaveRequestModel)stateMachine.BusinessModel;

            //2-业务处理，在数据中记录整个流程结束
        }
    }//Class_end
}
