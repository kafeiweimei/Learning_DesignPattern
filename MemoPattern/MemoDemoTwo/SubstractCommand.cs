using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoPattern.MemoDemoTwo
{
    /// <summary>
    /// 具体的减法命令对象
    /// </summary>
    internal class SubstractCommand:AbstractCommand
    {
        private int operationNum = 0;

        public SubstractCommand(int operationNum)
        {
            this.operationNum = operationNum;
        }

        public override void Execute()
        {
            Console.WriteLine($"准备减去数字【{operationNum}】");
            this.operation.Substract(operationNum);
        }


    }//Class_end
}
