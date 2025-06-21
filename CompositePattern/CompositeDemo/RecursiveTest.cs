using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace CompositePattern.CompositeDemo
{
    /// <summary>
    /// 递归测试
    /// </summary>
    internal class RecursiveTest
    {
        //递归算法求阶乘【简单示意】
        public BigInteger Recursive(BigInteger num)
        {
            if (num == 1)
            {
                return 1;
            }
            return num * Recursive(num-1);
        }

    }//Class_end
}
