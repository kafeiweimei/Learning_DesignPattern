using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatePattern.StateDemoThree
{
    /// <summary>
    /// 公共状态接口
    /// </summary>
    internal interface IState
    {
        //执行状态对象的功能处理
        void Dowork(StateMachine stateMachine);
    }//Interface_end
}
