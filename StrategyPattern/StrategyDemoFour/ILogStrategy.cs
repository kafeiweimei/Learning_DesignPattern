using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyPattern.StrategyDemoFour
{
    /// <summary>
    /// 日志记录策略接口
    /// </summary>
    internal interface ILogStrategy
    {
        /// <summary>
        /// 记录日志
        /// </summary>
        /// <param name="message">需记录的消息</param>
        void Log(string message);

    }//Interface_end
}
