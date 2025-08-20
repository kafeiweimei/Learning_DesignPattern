using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgePattern.BridgeDemoOne
{
    /// <summary>
    /// 普通消息
    /// </summary>
    internal class CommonMsg : AbstractMessage
    {
        public CommonMsg(IMessage message) : base(message)
        {
        }

        public override void SendMsg(string message, string toUser)
        {
            //【普通消息】直接调用父类方法，把消息发送出去就可以了
            base.SendMsg(message, toUser);
        }
    }//Class_end
}
