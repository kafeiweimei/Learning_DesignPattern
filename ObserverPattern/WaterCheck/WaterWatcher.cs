using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverPattern.WaterCheck
{
    /// <summary>
    /// 具体水质观察者
    /// </summary>
    internal class WaterWatcher : IWatcherObserver
    {
        //职务
        private string job;

        public string GetJob()
        {
            return this.job;
        }

        public void SetJob(string job)
        {
            this.job = job;
        }

        public WaterWatcher(string job)
        {
            this.job= job;
        }

        public void Pull(WaterQualitySubject waterQualitySubject)
        {
            //主动拉取水质监测消息
            string str = waterQualitySubject.GetPolluteLevel().ToString();

            Console.WriteLine($"【{job}】收到通知，当前的水质污染级别是【{str}】");
        }


    }//Class_end
}
