using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoPattern.MemoDemoTwo
{
    /// <summary>
    /// 定义命令接口
    /// </summary>
    internal interface ICommand
    {
        //执行命令
        void Execute();

        //撤销命令（恢复到备忘录对象记录的状态）
        void Undo(IMemo memo);

        //重做命令（恢复到备忘录对象记录的状态）
        void Redo(IMemo memo);

        //创建保存原触发器对象状态的备忘录对象
        IMemo CreateMemo();

    }//Interface_end
}
