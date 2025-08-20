using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgePattern.BridgeDemoOne
{
    /// <summary>
    /// 特急消息
    /// </summary>
    internal class SpecialUrgencyMsg : AbstractMessage
    {
        public SpecialUrgencyMsg(IMessage message) : base(message)
        {
        }

        public override void SendMsg(string message, string toUser)
        {
            message = $"[特急] {message}";
            base.SendMsg(message, toUser);
        }

        public void Hurry(string messageId)
        {
            //执行催促的业务，发出催促消息
        }

    }//Class_end
}
