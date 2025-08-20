using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgePattern.BridgeDemoOne
{
    internal class AbstractMessage4
    {
        //持有一个实现消息的对象
        protected IMessage message;

        /// <summary>
        /// 构造函数
        /// </summary>
        public AbstractMessage4()
        {
            //创建一个默认的实现
            this.message = new MsgSMS();
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
