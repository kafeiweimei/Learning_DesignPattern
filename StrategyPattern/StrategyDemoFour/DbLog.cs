using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyPattern.StrategyDemoFour
{
    /// <summary>
    /// 日志记录到数据库中
    /// </summary>
    internal class DbLog : LogStrategyTemplate
    {
        protected override void LogRecord(string message)
        {
            //人为模拟错误情况(如：数据库连接断开等错误情况)
            if (message != null && message.Length >= 6)
            {
                throw new Exception("数据库异常");
            }
            Console.WriteLine($"现在将【{message}】记录到数据库中\n");
        }
    }//Class_end
}
