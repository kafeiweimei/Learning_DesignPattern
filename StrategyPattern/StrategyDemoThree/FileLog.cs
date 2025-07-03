using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyPattern.StrategyDemoThree
{
    /// <summary>
    /// 把日志记录到文件中
    /// </summary>
    internal class FileLog : IlogStrategy
    {
        public void Log(string message)
        {
            Console.WriteLine($"现在把【{message}】记录到文件中");
        }
    }//Class_end
}
