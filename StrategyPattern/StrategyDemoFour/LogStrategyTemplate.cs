using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyPattern.StrategyDemoFour
{
    /// <summary>
    /// 实现日志策略的抽象模板（实现为消息添加时间）
    /// </summary>
    internal abstract class LogStrategyTemplate : ILogStrategy
    {
        public void Log(string message)
        {
            //1-为消息添加记录的时间
            message = AddTimeOfMessage(message);
            //2-真正执行记录操作
            LogRecord(message);
        }

        //给消息前添加时间
        private string AddTimeOfMessage(string message)
        {
            string curTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            message = $"{curTime} {message}";
            return message ;
        }

        /// <summary>
        /// 真正执行日志记录，让子类去实现
        /// </summary>
        /// <param name="message">需记录的消息</param>
        protected abstract void LogRecord(string message);


    }//Class_end
}
