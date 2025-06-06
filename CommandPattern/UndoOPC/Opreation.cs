using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandPattern.UndoOPC
{
    /// <summary>
    /// 运算类，真正实现加减法运算
    /// </summary>
    internal class Opreation : IOperation
    {
        //记录运算结果
        private int result = 0;

        public void Addition(int num)
        {
            //实现加法功能
            result += num;
        }

        public int GetResult()
        {
            return result;
        }

        public void SetResult(int result)
        {
            this.result = result;
        }

        public void Subtraction(int num)
        {
            //实现减法功能
            result -= num;
        }
    }//Class_end
}
