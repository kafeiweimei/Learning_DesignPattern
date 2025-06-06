using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandPattern.Macros
{
    /// <summary>
    /// 后厨管理类
    /// </summary>
    internal class CookerManager
    {
        //用来控制是否需要创建厨师，如果已经创建就不要执行了
        private static bool runFlag = false;

        //运行后厨管理，创建厨师对象并启动他们相应的线程（无论运行多少次，创建厨师对象和启动线程的工作只做一次）
        public static void RunCookerManager()
        {
            if (!runFlag)
            {
                runFlag = true;
                //创建三位厨师
                HotCooker hotCooker1 = new HotCooker("张三");
                HotCooker hotCooker2 = new HotCooker("李四");
                HotCooker hotCooker3 = new HotCooker("王五");

                //启动各位厨师做菜
                hotCooker1.Run();
                hotCooker2.Run();
                hotCooker3.Run();

            }
        }


    }//Class_end
}
