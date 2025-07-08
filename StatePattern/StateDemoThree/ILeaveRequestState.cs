using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatePattern.StateDemoThree
{
    /// <summary>
    /// 请假状态接口【虽然这里不需要扩展状态功能，但还是继承一下状态，表示可以添加自己的处理】
    /// </summary>
    /// <typeparam name="T"></typeparam>
    internal interface ILeaveRequestState: IState
    {
       //这里可以扩展与自己流程相关的处理

    }//Interface_end
}
