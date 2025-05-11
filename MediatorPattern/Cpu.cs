using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediatorPattern
{
    /// <summary>
    /// CPU对象
    /// </summary>
    internal class Cpu : Colleague
    {
        //解析读取的视频数据
        private string videoDatas = string.Empty;
        //解析读取的声音数据
        private string soundDatas=string.Empty;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="mediator">中介者对象</param>
        public Cpu(IMediator mediator):base(mediator)
        {
            
        }

        /// <summary>
        /// 获取解析出来的视频数据
        /// </summary>
        /// <returns></returns>
        public string GetVideoDatas()
        {
            return videoDatas;
        }

        /// <summary>
        /// 获取解析出来的声音数据
        /// </summary>
        /// <returns></returns>
        public string GetSoundDatas()
        {
            return soundDatas;
        }

        /// <summary>
        /// 处理数据（解析出视频与音频内容）
        /// </summary>
        public void HandleDatas(string datas,char agreement=',')
        {
            //根据协议，将数据切分为视频与声音数据
            string[] temp = datas.Split(agreement);
            this.videoDatas = temp[0];
            this.soundDatas = temp[1];
            //让中介者通知主板，CPU处理数据工作完成
            this.GetMediator().Changed(this);
        }

    }//Class_end
}
