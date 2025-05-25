using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverPattern.Push
{
    /// <summary>
    /// 观察者接口
    /// </summary>
    internal interface IObserver
    {
        /// <summary>
        /// 观察者自己被推送消息
        /// </summary>
        /// <param name="info">被推送的信息</param>
       void Push(string info);
        

    }//Interface_end
}
