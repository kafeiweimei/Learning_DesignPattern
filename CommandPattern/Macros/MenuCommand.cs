using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandPattern.Macros
{
    /// <summary>
    /// 菜单对象【是宏命令对象（包含多个命令）】
    /// </summary>
    internal class MenuCommand : ICommand
    {
        //用来记录组合本菜单的多道菜品（即多个命令对象）
        private List<ICommand> commands = new List<ICommand>();

        /// <summary>
        /// 点菜，把菜品加入到菜单中
        /// </summary>
        /// <param name="dishCommand">菜品</param>
        public void AddCommand(ICommand command)
        {
            commands.Add(command);
        }

        public void SetCooker(ICooker cooker)
        {
            //什么也不用做
        }


        public int GetTableNumber()
        {
            //什么也不做
            return 0;
        }


        /// <summary>
        /// 获取菜单中的多个命令对象
        /// </summary>
        /// <returns></returns>
        public List<ICommand> GetCommandList()
        {
            return this.commands;
        }

        public void Execute()
        {
            //执行菜单就是把菜单传递给后厨（即添加到命令队列中，供后厨厨师自取）
            CommondQueue.AddMenu(this);
        }

    }//Class_end
}
