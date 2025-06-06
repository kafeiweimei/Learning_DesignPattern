using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandPattern.Macros
{
    /// <summary>
    /// 服务员对象
    /// </summary>
    internal class Waiter
    {
        //持有一个宏命令对象【菜单】
        private MenuCommand menuCommand = new MenuCommand();


        /// <summary>
        /// 客户点菜
        /// </summary>
        /// <param name="command">菜品</param>
        public void OrderDish(ICommand command)
        {
            //添加到菜单中
            menuCommand.AddCommand(command);

        }

        /// <summary>
        /// 客户点菜完毕，表示需要执行命令了，这里执行这个菜单的组合命令【即厨师真正开始做菜了】
        /// </summary>
        public void OrderOver()
        {
            this.menuCommand.Execute();
        }

    }//Class_end
}
