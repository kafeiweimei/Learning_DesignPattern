using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandPattern
{
    /// <summary>
    /// 命令接口
    /// </summary>
    internal interface ICommand
    {
        //执行命令的操作
        void Execute();

    }//Interface_end
}
