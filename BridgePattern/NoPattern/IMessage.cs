using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgePattern.NoPattern
{
    /// <summary>
    /// 消息统一接口
    /// </summary>
    internal interface IMessage
    {
        /// <summary>
        /// 发送消息
        /// </summary>
        /// <param name="message">需要发生的消息</param>
        /// <param name="toUser">消息要发送给的人员</param>
        void Send(string message,string toUser);

    }//Interface_end
}
