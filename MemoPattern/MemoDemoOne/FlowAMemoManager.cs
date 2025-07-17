using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoPattern.MemoDemoOne
{
    /// <summary>
    /// 负责保存模拟运行流程A对象的备忘录管理者对象
    /// </summary>
    internal class FlowAMemoManager
    {
        //记录保存的备忘录对象
        private IFlowAMockMemo flowAMockMemo = null;

        /// <summary>
        /// 保存备忘录对象
        /// </summary>
        /// <param name="flowAMockMemo"></param>
        public void SaveMemo(IFlowAMockMemo flowAMockMemo)
        {
            this.flowAMockMemo = flowAMockMemo;
        }

        /// <summary>
        /// 获取被保存的备忘录对象
        /// </summary>
        /// <returns></returns>
        public IFlowAMockMemo RetriveMemo()
        {
            return this.flowAMockMemo;
        }

    }//Class_end
}
