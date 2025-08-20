using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgePattern.BridgeDemoOne
{
    /// <summary>
    /// 手机短信的方式发送消息
    /// </summary>
    internal class MsgMobile : IMessage
    {
        public void Send(string message, string toUser)
        {
            Console.WriteLine($"使用手机短信的方式，发送消息【{message}】给【{toUser}】");
        }
    }//Class_end
}
