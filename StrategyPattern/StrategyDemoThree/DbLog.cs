using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyPattern.StrategyDemoThree
{
    /// <summary>
    /// 把日志记录到数据库
    /// </summary>
    internal class DbLog : IlogStrategy
    {
        public void Log(string message)
        {
           //人为模拟错误情况(如：数据库连接断开等错误情况)
           if (message != null && message.Length>=6)
           {
                throw new Exception("数据库异常");
           }
           Console.WriteLine($"现在将【{message}】记录到数据库中");
        }
    }//Class_end
}
