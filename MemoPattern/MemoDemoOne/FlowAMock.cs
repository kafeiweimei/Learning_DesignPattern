using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoPattern.MemoDemoOne
{
    /// <summary>
    /// 模拟运行流程A（这是这是一个示意，用于指代具体流程）【备忘录模式的原发器对象】
    /// </summary>
    internal class FlowAMock
    {
        //流程名称（不用额外存储的状态数据）
        private string flowName = string.Empty;
        //示意：代指某个中间的结果（需要外部存储的状态数据）
        private int tempResult = 0;
        //示意：代指某个中间结果（需要外部存储的状态数据）
        private string tempState = string.Empty;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="flowName">流程名称</param>
        public FlowAMock(string flowName)
        {
            this.flowName = flowName;
        }

        /// <summary>
        /// 示意：运行流程的第一个阶段
        /// </summary>
        public void RunPhaseOne()
        {
            //在这个阶段可能产生了中间结果，这里仅作示意
            tempResult = 3;
            tempState = "PhaseOne";
        }

        /// <summary>
        /// 示意：按照方案一运行流程后半部分
        /// </summary>
        public void SchemaOne()
        {
            //示意：需要使用第一阶段产生的数据
            this.tempState += "[SchemaOne]";
            Console.WriteLine($"方案一目前的状态是【{tempState}】结果是【{tempResult}】");
            tempResult += 11;
        }

        /// <summary>
        /// 示意：按照方案二运行流程后半部分
        /// </summary>
        public void SchemaTwo()
        {
            //示意：需要使用第一阶段产生的数据
            this.tempState += "[SchemaTwo]";
            Console.WriteLine($"方案二目前的状态是【{tempState}】结果是【{tempResult}】");
            tempResult += 22;
        }

        #region 备忘录内容

        /// <summary>
        /// 继承备忘录接口实现真正的备忘录功能（实现内部私有类，不让外部访问）
        /// </summary>
        private class MemoImpl : IFlowAMockMemo
        {
            //保存中间的某个结果（此处仅做示意）
            private int tempResult=0;
            //保存某个中间状态
            private string tempState = string.Empty;

            /// <summary>
            /// 结果内容外部只读
            /// </summary>
            public int TempResult { get { return tempResult; } }
            /// <summary>
            /// 状态内容外部只读
            /// </summary>
            public string TempState { get { return tempState; } }

            public MemoImpl(int tempResult,string tempState)
            {
                this.tempResult = tempResult;
                this.tempState = tempState;
            }

        }

        /// <summary>
        /// 创建保存原发器对象的备忘录对象
        /// </summary>
        /// <returns>返回创建好的备忘录对象</returns>
        public IFlowAMockMemo CreateMemo()
        {
            return new MemoImpl(this.tempResult,this.tempState);
        }

        /// <summary>
        /// 重新设置原发器对象状态，让其回到备忘录对象记录的状态
        /// </summary>
        /// <param name="flowAMockMemo"></param>
        public void SetMemo(IFlowAMockMemo flowAMockMemo)
        {
            MemoImpl memoImpl = (MemoImpl)flowAMockMemo;
            this.tempResult = memoImpl.TempResult;
            this.tempState = memoImpl.TempState;
        }

        #endregion


    }//Class_end
}
