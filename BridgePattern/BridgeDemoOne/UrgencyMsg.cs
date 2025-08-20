using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgePattern.BridgeDemoOne
{
    /// <summary>
    /// 加急消息
    /// </summary>
    internal class UrgencyMsg : AbstractMessage
    {
        public UrgencyMsg(IMessage message) : base(message)
        {
        }

        public override void SendMsg(string message, string toUser)
        {
            message = $"[加急] {message}";
            base.SendMsg(message, toUser);
        }

        /// <summary>
        /// 扩展新功能（监控消息的处理过程）
        /// </summary>
        /// <param name="messageId">被监控的消息的编号</param>
        /// <returns>返回被监控到的数据对象</returns>
        public object Watch(string messageId)
        {
            //获取相应的数据，组织成监控的数据对象，然后返回
            return null;
        }
    }//Class_end
}
