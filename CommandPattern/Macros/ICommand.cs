using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandPattern.Macros
{
    /// <summary>
    /// 命令接口
    /// </summary>
    internal interface ICommand
    {
        //执行命令对应的操作
        void Execute();

        //设置命令的接收者
        void SetCooker(ICooker cooker);

        //返回发起请求的桌号【即；点菜的桌号】
        int GetTableNumber();


    }//Interface_end
}
