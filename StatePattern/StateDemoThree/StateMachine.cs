using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatePattern.StateDemoThree
{
    /// <summary>
    /// 公共状态处理（相当于状态模式的Context上下文）
    /// 包含所有流程使用状态模式时的公共功能
    /// </summary>
    internal class StateMachine
    {
        /// <summary>
        /// 持有的状态对象
        /// </summary>
        public IState? State { get; set; }

        /// <summary>
        /// 创建流处理所需的业务数据模型（这里不知道具体类型，可使用泛型或object）
        /// </summary>
        public object? BusinessModel { get; set; }

        /// <summary>
        /// 执行工作，在客户完成自己的业务工作后调用
        /// </summary>
        public void Dowork()
        {
            this.State.Dowork(this);
        }


    }//Class_end
}
