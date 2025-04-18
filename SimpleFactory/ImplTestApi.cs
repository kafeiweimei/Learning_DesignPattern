using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleFactory
{
    /// <summary>
    /// 实现接口的测试类
    /// </summary>
    internal class ImplTestApi : ITestApi
    {
        public void TestPrint(string info)
        {
           if (string.IsNullOrEmpty(info)) { return; }

            string str = $"实现接口定义传递一个参数的打印方法,打印内容是：{info}";
            Console.WriteLine(str);
        }


    }//Class_end
}
