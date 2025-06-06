using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandPattern
{
    /// <summary>
    /// 主板接口
    /// </summary>
    internal interface IMainBoard
    {
        //具有开机功能
        void Open();

        //2-主板具有重启功能
        void Reboot();

    }//Interface_end
}
