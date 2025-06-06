using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandPattern.UndoOPC
{
    /// <summary>
    /// 命令接口
    /// </summary>
    internal interface ICommand
    {
        //执行命令对应的操作
        void Execute();

        //执行撤销命令
        void Undo();

    }//Interface_end
}
