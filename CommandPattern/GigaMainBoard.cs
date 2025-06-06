using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandPattern
{
    /// <summary>
    /// 技嘉主板
    /// </summary>
    internal class GigaMainBoard : IMainBoard
    {
        /// <summary>
        /// 真正的开机命令实现
        /// </summary>
        public void Open()
        {
            Console.WriteLine("【技嘉】主板正在开机，请稍等");
            Console.WriteLine("接通电源。。。。。。");
            Console.WriteLine("设备检查。。。。。。");
            Console.WriteLine("装载系统。。。。。。");
            Console.WriteLine("设备正常启动。。。。");
            Console.WriteLine("系统已经启动完成，请登录");
        }

        /// <summary>
        /// 真正的重启命令实现
        /// </summary>
        public void Reboot()
        {
            Console.WriteLine("技嘉主板现在正在重启机器，请等候...");
            Console.WriteLine("机器已经正常启动，请登录。。。");
        }
    }//Class_end
}
