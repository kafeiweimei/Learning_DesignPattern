using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleFactory
{
    /// <summary>
    /// 实现ITestApi接口的对象B
    /// </summary>
    internal class ImplB : ITestApi
    {
        public void TestPrint(string info)
        {
            //具体的实现功能代码
            if (info.Contains('，'))
            {
                string[] tmpStr = info.Split('，');

                Console.WriteLine("我是对象【B】实现的打印逻辑，打印内容是：");
                foreach (string s in tmpStr)
                {
                    Console.WriteLine(s);
                }

            }

        }

    }//Class_end
}
