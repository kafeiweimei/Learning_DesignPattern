using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoPattern.MemoDemoTwo
{
    /// <summary>
    /// 具体的添加命令对象
    /// </summary>
    internal class AddCommand:AbstractCommand
    {
        private int operationNum = 0;

        public AddCommand(int operationNum)
        {
            this.operationNum = operationNum;
        }

        public override void Execute()
        {
            Console.WriteLine($"准备添加数字【{operationNum}】");
            this.operation.Add(operationNum);
        }

    }//Class_end
}
