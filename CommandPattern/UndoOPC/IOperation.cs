using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandPattern.UndoOPC
{
    /// <summary>
    /// 操作运算的接口
    /// </summary>
    internal interface IOperation
    {
        //获取计算完成后的结果
        int GetResult();

        //设置计算开始的初始值
        void SetResult(int result);

        //执行加法
        void Addition(int num);

        //执行减法
        void Subtraction(int num);

    }//Interface_end
}
