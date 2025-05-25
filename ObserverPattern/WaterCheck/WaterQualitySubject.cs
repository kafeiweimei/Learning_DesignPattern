using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverPattern.WaterCheck
{
    /// <summary>
    /// 水质检测目标对象
    /// </summary>
    internal abstract class WaterQualitySubject
    {
        //保存注册的观察者对象
        protected List<IWatcherObserver> watcherObservers=new List<IWatcherObserver>();

        /// <summary>
        /// 注册观察者对象
        /// </summary>
        /// <param name="watcherObserver">观察者对象</param>
        public void Add(IWatcherObserver watcherObserver)
        {
            watcherObservers.Add(watcherObserver);
        }

        /// <summary>
        /// 删除观察者对象
        /// </summary>
        /// <param name="watcherObserver">观察者对象</param>
        public void Del(IWatcherObserver watcherObserver)
        {
            watcherObservers.Remove(watcherObserver);
        }

        /// <summary>
        /// 通知相应的观察者对象
        /// </summary>
        public abstract void NotifyWatchers();

        /// <summary>
        /// 获取水质的污染级别
        /// </summary>
        public abstract int GetPolluteLevel();


    }//Class_end
}
