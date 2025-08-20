using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgePattern.BridgeDemoOne
{
    /// <summary>
    /// 站内消息
    /// </summary>
    internal class MsgSMS : IMessage
    {
        public void Send(string message, string toUser)
        {
            Console.WriteLine($"使用站内消息的方式，发送消息【{message}】给【{toUser}】");
        }
    }//Class_end
}
