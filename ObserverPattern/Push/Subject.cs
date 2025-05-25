using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverPattern.Push
{
    /// <summary>
    /// 目标对象
    /// </summary>
    internal class Subject
    {
        //观察者列表（即：订阅报纸的读者）
        private List<IObserver> observers = new List<IObserver>();

        /// <summary>
        /// 订阅报纸（即：读者需要向报社订阅付费后，后续才能收到报纸内容）
        /// </summary>
        /// <param name="observer">报纸的读者</param>
        public void Add(IObserver observer)
        {
            observers.Add(observer);
        }

        /// <summary>
        /// 报纸的读者取消订阅
        /// </summary>
        /// <param name="observer">报纸的读者</param>
        public void Del(IObserver observer)
        {
            observers.Remove(observer);
        }

        /// <summary>
        /// 当每期的报纸印刷出来后，就要迅速主动地被送到读者手中;相当于通知读者，让读者知道新报纸来了可以阅读
        /// </summary>
        /// <param name="info">要推送的消息</param>
        protected void NotifyObservers(string info)
        {
            foreach (IObserver observer in observers)
            {
                observer.Push(info);
            }
        }


    }//Class_end
}
