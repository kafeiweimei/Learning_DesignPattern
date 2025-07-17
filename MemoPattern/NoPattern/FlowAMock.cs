using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoPattern.NoPattern
{
    /// <summary>
    /// 模拟运行流程A（这是这是一个示意，用于指代具体流程）
    /// </summary>
    internal class FlowAMock
    {
        //流程名称（不用额外存储的状态数据）
        public string FlowName { get; set; }=string.Empty;
        //示意：代指某个中间的结果（需要外部存储的状态数据）
        public int TempResult { get; set; } = 0;
        //示意：代指某个中间结果（需要外部存储的状态数据）
        public string TempState { get; set; } = string.Empty;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="flowName">流程名称</param>
        public FlowAMock(string flowName)
        {
            this.FlowName = flowName;
        }

        /// <summary>
        /// 示意：运行流程的第一个阶段
        /// </summary>
        public void RunPhaseOne()
        {
            //在这个阶段可能产生了中间结果，这里仅作示意
            TempResult = 3;
            TempState = "PhaseOne";
        }

        /// <summary>
        /// 示意：按照方案一运行流程后半部分
        /// </summary>
        public void SchemaOne()
        {
            //示意：需要使用第一阶段产生的数据
            this.TempState += "[SchemaOne]";
            Console.WriteLine($"方案一目前的状态是【{TempState}】结果是【{TempResult}】");
            TempResult += 11;
        }

        /// <summary>
        /// 示意：按照方案二运行流程后半部分
        /// </summary>
        public void SchemaTwo()
        {
            //示意：需要使用第一阶段产生的数据
            this.TempState += "[SchemaTwo]";
            Console.WriteLine($"方案二目前的状态是【{TempState}】结果是【{TempResult}】");
            TempResult += 22;
        }

    }//Class_end
}
