using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediatorPattern
{
    /// <summary>
    /// 光驱对象
    /// </summary>
    internal class CdDriver : Colleague
    {
        //光驱读取出来的数据
        private string data=string.Empty;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="mediator">中介者对象</param>
        public CdDriver(IMediator mediator) : base(mediator)
        {
        }

        /// <summary>
        /// 获取到读取光驱的数据
        /// </summary>
        /// <returns></returns>
        public string GetReadData()
        {
            //执行具体的读取光驱数据操作并返回
            return data;
        }

        /// <summary>
        /// 读取光盘
        /// </summary>
        public void ReadCD()
        {
            //这里为了简单（使用逗号区分视频数据与声音数据【逗号前是视频数据，逗号后是声音数据】）
            this.data = "23种设计模式,值得好好学习研究掌握";
            //通知主板，自己的状态改变了
            this.GetMediator().Changed(this);
        }

    }//Class_end
}
