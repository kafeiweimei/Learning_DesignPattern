using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandPattern.UndoOPC
{
    internal class Calculator
    {
        //持有执行加法的命令对象
        private ICommand addCommand = null;
        //持有执行减法的命令对象
        private ICommand SubCommand = null;

        //命令的操作历史记录，在撤销的时候使用
        private List<ICommand> undoCommands = new List<ICommand>();
        //命令的操作记录，在恢复时使用
        private List<ICommand> redoCommands = new List<ICommand>();


        //设置执行加法的命令对象
        public void SetAddCommand(ICommand addCommand)
        {
            this.addCommand = addCommand;
        }

        /// <summary>
        /// 提供给客户使用，执行加法功能
        /// </summary>
        public void AddPressed()
        {
            this.addCommand.Execute();
            //把操作记录到历史记录里面
            undoCommands.Add(this.addCommand);
        }

        //设置减法命令对象
        public void SetSubCommand(ICommand subCommand)
        {
            this.SubCommand = subCommand;
        }

        /// <summary>
        /// 提供给客户使用，执行减法功能
        /// </summary>
        public void SubPressed()
        {
            this.SubCommand.Execute();
            //把操作记录到历史记录里面
            undoCommands.Add(this.SubCommand);
        }

        /// <summary>
        /// 提供给客户使用，执行撤销功能
        /// </summary>
        public void UndoPressed()
        {
            if (this.undoCommands.Count > 0)
            {
                //1-取出撤销记录表里的最后一个命令来撤销
                ICommand command = this.undoCommands[this.undoCommands.Count - 1];
                command.Undo();
                //2-如果还有恢复的功能，那就把这个命令记录到恢复的历史记录里面
                this.redoCommands.Add(command);

                //3-然后把撤销记录表里的最后一个命令删除
                this.undoCommands.Remove(command);
            }
            else
            {
                Console.WriteLine("很抱歉，没有可撤销的命令了！");
            }
        }


        /// <summary>
        /// 提供给客户使用，执行恢复功能
        /// </summary>
        public void RedoPressed()
        {
            if (this.redoCommands.Count>0)
            {
                //1-取出恢复命令记录表的最后一条记录来恢复
                ICommand command = this.redoCommands[this.redoCommands.Count-1];
                command.Execute();

                //2-把这个命令记录到可撤销的历史记录里面
                this.undoCommands.Add(command);

                //3-把恢复命令记录表里面的最后一个命令删除掉
                this.redoCommands.Remove(command);
                
            }
        }

    }//Class_end
}
