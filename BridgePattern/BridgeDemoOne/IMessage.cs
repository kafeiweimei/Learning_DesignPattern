using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgePattern.BridgeDemoOne
{
    /// <summary>
    /// 发送消息的统一接口
    /// </summary>
    internal interface IMessage
    {
        /// <summary>
        /// 发送消息
        /// </summary>
        /// <param name="message">要发送的消息内容</param>
        /// <param name="toUser">消息发送给的人员</param>
        void Send(string message,string toUser);

    }//Interface_end
}
