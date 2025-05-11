using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediatorPattern
{
    /// <summary>
    /// 显卡对象
    /// </summary>
    internal class VideoCard : Colleague
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="mediator">中介者对象</param>
        public VideoCard(IMediator mediator) : base(mediator)
        {
        }

        /// <summary>
        /// 显示视频数据信息
        /// </summary>
        /// <param name="datas">视频数据</param>
        public void ShowDatas(string datas)
        {
            Console.WriteLine($"您正在观看的视频是【{datas}】");
        }


    }//Class_end
}
