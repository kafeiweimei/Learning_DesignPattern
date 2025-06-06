using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandPattern
{
    /// <summary>
    /// 机箱对象，本身有按钮，持有按钮对应的命令对象
    /// </summary>
    internal class Box
    {
        //开机命令对象
        private ICommand openCommand = null;

        /// <summary>
        /// 设置开机命令对象
        /// </summary>
        /// <param name="command">命令对象</param>
        public void SetOpenCommand(ICommand openCommand)
        {
            this.openCommand = openCommand;
        }

        /// <summary>
        /// 提供给客户使用，接收并响应用户请求，相当于开机按钮被按下的方法
        /// </summary>
        public void OpenButtonPressed()
        {
            //按下按钮，执行命令
            this.openCommand.Execute();
        }


        //重启机器命令对象
        private ICommand rebootCommand = null;

        //设置重启命令对象
        public void SetRebootCommand(ICommand rebootCommand)
        {
            this.rebootCommand = rebootCommand;
        }

        /// <summary>
        /// 提供给客户使用，接收并响应用户请求，相当于重启按钮被按下的方法
        /// </summary>
        public void RebootButtonPressed()
        {
            //按下按钮，执行命令
            this.rebootCommand.Execute();
        }

    }//Class_end
}
