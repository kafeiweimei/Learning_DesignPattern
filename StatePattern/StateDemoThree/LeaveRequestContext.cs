using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatePattern.StateDemoThree
{
    /// <summary>
    /// 客户端请求的上下文【虽然这里并不需要扩展状态机，但还是继承一下状态机，表示可以添加自己的处理】
    /// </summary>
    /// <typeparam name="T"></typeparam>
    internal class LeaveRequestContext:StateMachine
    {
        //在上下文这里可以扩展与自己流程相关的处理

    }//Class_end
}
