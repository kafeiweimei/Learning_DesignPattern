using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyPattern.StrategyDemoFour
{
    internal class FileLog : LogStrategyTemplate
    {
        protected override void LogRecord(string message)
        {
            Console.WriteLine($"现在把【{message}】记录到文件中\n");
        }
    }//Class_end
}
