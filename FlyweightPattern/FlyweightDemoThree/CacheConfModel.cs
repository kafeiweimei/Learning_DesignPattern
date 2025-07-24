using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlyweightPattern.FlyweightDemoThree
{
    /// <summary>
    /// 缓存配置文件模型对象
    /// </summary>
    internal class CacheConfModel
    {
        /// <summary>
        /// 缓存开始计时的开始时间
        /// </summary>
        public long BeginTime { get; set; } = 0;

        /// <summary>
        /// 缓存对象存放的持续时间【即：最长不被使用的时间】
        /// </summary>
        public long DurableTime { get; set; }=0;

        /// <summary>
        /// 缓存对象需要被永久存储【不需要从缓存中删除】
        /// </summary>
        public bool Forever { get; set; }=false;


    }//Class_end
}
