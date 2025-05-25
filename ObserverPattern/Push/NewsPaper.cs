using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverPattern.Push
{
    /// <summary>
    /// 报纸对象
    /// </summary>
    internal class NewsPaper:Subject
    {
        //报纸内容
        private string info;

        /// <summary>
        /// 获取报纸信息
        /// </summary>
        /// <returns></returns>
        private string GetInfo()
        {
            return this.info;
        }

        //设置报纸内容，相当于印刷发版报纸
        public void SetInfo(string info)
        {
            this.info = info;
            //报纸有内容了，就通知所有读者
            base.NotifyObservers(info);
        }

    }//Class_end
}
