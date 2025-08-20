using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgePattern.NoPattern
{
    /// <summary>
    /// 使用Email的方式发送加急消息
    /// </summary>
    internal class UrgencyMsgEmail : IUrgencyMessage
    {
        public void Send(string message, string toUser)
        {
            message = $"[加急] {message}";
            Console.WriteLine($"现在使用【Email方式】发送消息【{message}】给【{toUser}】");
        }

        public object Watch(string messageId)
        {
            //获取相应的数据，组织成为监控的数据对象，然后返回
            return null;
        }
    }//Class_end
}
