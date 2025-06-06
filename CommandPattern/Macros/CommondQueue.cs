using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandPattern.Macros
{
    /// <summary>
    /// 命令队列类
    /// </summary>
    internal class CommondQueue
    {
        //用来存储命令对象的队列
        private static List<ICommand> commands = new List<ICommand>();


        /// <summary>
        /// 服务员传过来一个新的菜单，需要同步（因为同时会有很多的服务员传入菜单，而同时又有很多厨师从队列里取菜单）
        /// </summary>
        /// <param name="menuCommand">菜单命令</param>
        public static void AddMenu(MenuCommand menuCommand)
        {
            //一个菜单对象包含很多命令对象
            foreach (var command in menuCommand.GetCommandList())
            {
                lock (command)
                {
                    commands.Add(command);
                }
            }

        }


        //厨师从命令队列里面获取命令对象进行处理,也需要同步
        public static ICommand GetOneCommand()
        {
            ICommand command = null;
            if (commands.Count>0)
            {
                lock (commands.First())
                {
                    //模拟队列的先进先出
                    command = commands.First();

                    //同时从队列里面去掉这个命令对象
                    commands.RemoveAt(0);
                }
            }
            return command;
        }


    }//Class_end
}
