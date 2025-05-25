using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverPattern.WaterCheck
{
    /// <summary>
    /// 具体的水质监测对象
    /// </summary>
    internal class WaterQuality : WaterQualitySubject
    {
        //水质污染级别【0表示正常，1表示轻度污染，2表示中度污染，3表示高度污染】
        private int polluteLevel = 0;

        /// <summary>
        /// 获取水质污染级别
        /// </summary>
        /// <returns></returns>
        public override int GetPolluteLevel()
        {
            return this.polluteLevel;
        }

        /// <summary>
        /// 当检测水质情况后，设置水质的污染级别
        /// </summary>
        /// <param name="polluteLevel">水质污染级别</param>
        public void SetPolluteLevel(int polluteLevel)
        {
            this.polluteLevel = polluteLevel;
            //发出通知
            this.NotifyWatchers();

        }

        /// <summary>
        /// 通知订阅了水质污染情况的所有观察者
        /// </summary>
        public override void NotifyWatchers()
        {
            foreach (var watcherObserver in base.watcherObservers)
            {
                //根据水质的污染级别判断是否需要通知
                if (this.polluteLevel>=0)
                {
                    //通知检测人员做记录
                    if ("检测人员".Equals(watcherObserver.GetJob()))
                    {
                        watcherObserver.Pull(this);
                    }
                }

                if (this.polluteLevel >= 1)
                {
                    //通知预警人员做记录
                    if ("预警人员".Equals(watcherObserver.GetJob()))
                    {
                        watcherObserver.Pull(this);
                    }
                }

                if (this.polluteLevel >= 2)
                {
                    //通知检测部门领导
                    if ("检测部门领导".Equals(watcherObserver.GetJob()))
                    {
                        watcherObserver.Pull(this);
                    }
                }
            }
        }

    }//Class_end
}
