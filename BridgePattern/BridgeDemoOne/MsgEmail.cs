using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgePattern.BridgeDemoOne
{
    /// <summary>
    /// 使用Email方式发送消息
    /// </summary>
    internal class MsgEmail : IMessage
    {
        public void Send(string message, string toUser)
        {
            Console.WriteLine($"使用Email消息的方式，发送消息【{message}】给【{toUser}】");
        }
    }//Class_end
}
