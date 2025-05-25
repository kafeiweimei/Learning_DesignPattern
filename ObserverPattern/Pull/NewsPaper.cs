using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverPattern.Pull
{
    /// <summary>
    /// 具体的报纸对象
    /// </summary>
    internal class NewsPaper:Subject
    {
        //报纸内容
        private string info;

        /// <summary>
        /// 设置报纸内容（相当于印刷报纸内容进行出版）
        /// </summary>
        /// <param name="info">报纸信息</param>
        public void SetInfo(string info)
        {
            this.info = info;
            //报纸有内容来了，就通知所有订阅的读者
            NotifyObservers();
        }

        /// <summary>
        /// 获取报纸的具体内容
        /// </summary>
        /// <returns></returns>
        public string GetInfo()
        {
            return info;
        }



    }//Class_end
}
