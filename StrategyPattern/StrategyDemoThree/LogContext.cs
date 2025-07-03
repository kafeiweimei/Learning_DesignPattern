using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyPattern.StrategyDemoThree
{
    /// <summary>
    /// 日志记录的上下文
    /// </summary>
    internal class LogContext
    {
        /// <summary>
        /// 记录日志的方法，提供给客户端使用
        /// </summary>
        /// <param name="message">需记录的消息</param>
        public void Log(string message)
        {
            //在上下文这里，自行实现对具体策略的选择(这里优先选用数据库策略)
            IlogStrategy strategy = new DbLog();
            try
            {
                strategy.Log(message);
            }
            catch (Exception ex)
            {
                //出错了，就记录到日志文件中
                Console.WriteLine($"记录日志【{message}】内容到数据库出错了，报错信息是【{ex.Message}】\n现在将日志记录到本地文件中");
                strategy = new FileLog();
                strategy.Log(message);
                //throw;
            }

        }

    }//Class_end
}
