using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgePattern.NoPattern
{
    /// <summary>
    /// 使用Email的方式发送普通消息
    /// </summary>
    internal class CommonMsgEmail : IMessage
    {
        public void Send(string message, string toUser)
        {
            Console.WriteLine($"现在使用【Email方式】发送消息【{message}】给【{toUser}】");
        }
    }//Class_end
}
