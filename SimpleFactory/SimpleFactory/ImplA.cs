using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleFactory
{
    /// <summary>
    /// 实现ITestApi接口的对象A
    /// </summary>
    internal class ImplA : ITestApi
    {
        public void TestPrint(string info)
        {
            //具体的实现功能代码
            string str = $"我是对象【A】实现的打印逻辑，打印内容是：{info}";
            Console.WriteLine(str);
        }
    }//Class_end
}
