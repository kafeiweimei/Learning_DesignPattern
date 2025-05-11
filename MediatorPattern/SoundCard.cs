using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediatorPattern
{
    /// <summary>
    /// 声卡对象
    /// </summary>
    internal class SoundCard:Colleague
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="mediator">中介者对象</param>
        public SoundCard(IMediator mediator):base(mediator)
        {
                
        }

        /// <summary>
        /// 按照声频数据发出声音
        /// </summary>
        /// <param name="datas"></param>
        public void SoundDatas(string datas)
        {
            Console.WriteLine($"当前播放的音频是【{datas}】");
        }

    }//Class_end
}
