using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgePattern.BridgeDemoOne
{
    /// <summary>
    /// 抽象的消息对象
    /// </summary>
    internal class AbstractMessage2
    {
        //持有一个实现部分的对象
        protected IMessage message;

        public AbstractMessage2(int type)
        {
            switch (type)
            {
                case 1:
                    message = new MsgSMS();
                    break;
                case 2:
                    message = new MsgEmail();
                    break;
                case 3:
                    message = new MsgMobile();
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// 发送消息
        /// </summary>
        /// <param name="message">需要发送的消息内容</param>
        /// <param name="toUser">消息发送的给的人员</param>
        public virtual void SendMsg(string message, string toUser)
        {
            this.message.Send(message, toUser);
        }

    }//Class_end
}
