using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyPattern.StrategyDemoThree
{
    /// <summary>
    /// 日志策略接口
    /// </summary>
    internal interface IlogStrategy
    {
        /// <summary>
        /// 记录日志
        /// </summary>
        /// <param name="message">需记录的日志消息</param>
        void Log(string message);

    }//Interface_end
}
