using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgePattern.NoPattern
{
    /// <summary>
    /// 加急消息接口
    /// </summary>
    internal interface IUrgencyMessage:IMessage
    {
        /// <summary>
        /// 监控某消息的处理
        /// </summary>
        /// <param name="messageId">被监控消息的编号</param>
        /// <returns>返回监控到的数据对象</returns>
        object Watch(string messageId);

    }//Interface_end
}
