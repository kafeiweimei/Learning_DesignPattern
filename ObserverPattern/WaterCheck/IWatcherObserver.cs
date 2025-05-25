using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverPattern.WaterCheck
{
    /// <summary>
    /// 水质观察者接口
    /// </summary>
    internal interface IWatcherObserver
    {
        /// <summary>
        /// 主动拉取通知内容方法
        /// </summary>
        /// <param name="waterQualitySubject">被观察的目标对象</param>
        void Pull(WaterQualitySubject waterQualitySubject);

        //设置观察人员的职务
        void SetJob(string job);

        //获取观察人员的职务
        string GetJob();

    }//Interface_end
}
