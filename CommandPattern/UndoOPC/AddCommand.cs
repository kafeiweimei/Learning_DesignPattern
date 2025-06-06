using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandPattern.UndoOPC
{
    /// <summary>
    /// 具体的加法命令实现对象
    /// </summary>
    internal class AddCommand : ICommand
    {
        //持有具体执行计算的对象
        private IOperation operation = null;
        //需操作的数据
        private int num = 0;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="operation">操作对象</param>
        /// <param name="num">需操作的数据</param>
        public AddCommand(IOperation operation, int num)
        {
            this.operation = operation;
            this.num = num;
        }


        public void Execute()
        {
            //转调接收者去真正执行功能，此处的命令是做加法
            this.operation.Addition(num);
        }

        public void Undo()
        {
            //转调接收者去真正执行功能,命令本身是做加法，那么撤销的时候就是做减法了
            this.operation.Subtraction(num);
        }

    }//Class_end
}
