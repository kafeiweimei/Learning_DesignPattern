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
    internal class AbstractMessage3
    {
        //持有一个实现部分的对象
        protected IMessage message;

        public AbstractMessage3()
        {
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

        //根据消息的长度来选择合适的实现
        protected IMessage GetImpl(string message)
        {
            IMessage msg = null;
            if (string.IsNullOrEmpty(message))
            {
                //若没有任何消息则默认使用站内消息
                msg = new MsgSMS();
            }
            else if (message.Length < 100)
            {
                //如消息长度在100以内，则使用手机短信
                msg = new MsgMobile();
            }
            else if (message.Length < 1000)
            {
                //如消息长度在100-1000以内，则使用站内消息
                msg = new MsgSMS();
            }
            else
            {
                //如消息长度在1000以上，则使用Email
                msg = new MsgEmail();
            }
            return msg;
        }

    }//Class_end
}
