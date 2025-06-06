using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandPattern
{
    /// <summary>
    /// 重启机器命令，继承ICommand接口
    /// 持有重启机器命令的真正实现，通过调用接收者方法来实现命令
    /// </summary>
    internal class RebootCommand : ICommand
    {
        //持有真正实现命令的接收者——主板对象
        private IMainBoard mainBoard = null;

        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="mainBoard">主板对象</param>
        public RebootCommand(IMainBoard mainBoard)
        {
            this.mainBoard = mainBoard;     
        }
        public void Execute()
        {
            //对于命令对象，根本不知道如何重启机器，会调用主板对象让主板去完成重启机器的功能
            this.mainBoard.Reboot();
        }
    }//Class_end
}
