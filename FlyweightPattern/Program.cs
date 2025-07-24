
namespace FlyweightPattern
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TestNoPattern();
            TestFlyweightDemoOne();
            TestFlyweightDemoTwo();
            Test();
            TestFlyweightDemoThree();

            Console.ReadLine();
        }

        /// <summary>
        /// 不使用模式的测试
        /// </summary>
        private static void TestNoPattern()
        {
            Console.WriteLine("------不使用模式的测试------");

            //先登录，然后判断是否有权限
            NoPattern.SecurityMgr.Instance.Login("张三");
            NoPattern.SecurityMgr.Instance.Login("李四");

            bool f1 = NoPattern.SecurityMgr.Instance.HasPermit("张三","薪资数据","查看");
            Console.WriteLine($"【张三】对【薪资数据】拥有【查看】权限 结果【{f1}】\n");

            bool f2 = NoPattern.SecurityMgr.Instance.HasPermit("李四","薪资数据","查看");
            Console.WriteLine($"【李四】对【薪资数据】拥有【查看】权限 结果【{f2}】\n");

            //然后检查是否具有其他内容的
            for (int i = 0; i < 3; i++)
            {
                string user = $"张三{i}";
                NoPattern.SecurityMgr.Instance.Login(user);
                bool res = NoPattern.SecurityMgr.Instance.HasPermit($"{user}","人员列表","查看");
                Console.WriteLine($"【{user}】对【人员列表】拥有【查看】权限结果是【{res}】\n");
            }

        }

        /// <summary>
        /// 测试享元模式示例一
        /// </summary>
        private static void TestFlyweightDemoOne()
        {
            Console.WriteLine("------测试享元模式示例一------");
            FlyweightDemoOne.SecurityMgr securityMgr = FlyweightDemoOne.SecurityMgr.Instance;
            securityMgr.Login("张三");
            securityMgr.Login("李四");
            bool f1 = securityMgr.HasPermit("张三","薪资数据","查看");
            Console.WriteLine($"【张三】对【薪资数据】拥有【查看】权限 结果【{f1}】\n");

            bool f2 = securityMgr.HasPermit("李四","薪资数据","查看");
            Console.WriteLine($"【李四】对【薪资数据】拥有【查看】权限 结果【{f2}】\n");

            //然后检查是否具有其他内容的
            for (int i = 0; i < 3; i++)
            {
                string user = $"张三{i}";
                securityMgr.Login(user);
                bool res = securityMgr.HasPermit($"{user}", "人员列表", "查看");
                Console.WriteLine($"【{user}】对【人员列表】拥有【查看】权限结果是【{res}】\n");
            }

        }

        /// <summary>
        /// 测试享元模式示例二
        /// </summary>
        private static void TestFlyweightDemoTwo()
        {
            Console.WriteLine("------测试享元模式示例二------");

            //先登录，然后在判断是否有权限
            FlyweightDemoTwo.SecurityMgr securityMgr= FlyweightDemoTwo.SecurityMgr.Instance;
            securityMgr.Login("张三");
            securityMgr.Login("李四");
            bool f1 = securityMgr.HasPermit("张三","薪资数据","查看");
            Console.WriteLine($"【张三】对【薪资数据】拥有【查看】权限 结果【{f1}】\n");

            bool f2 = securityMgr.HasPermit("李四","薪资数据","查看");
            Console.WriteLine($"【李四】对【薪资数据】拥有【查看】权限 结果【{f2}】\n");

            bool f3 = securityMgr.HasPermit("李四", "薪资数据", "修改");
            Console.WriteLine($"【李四】对【薪资数据】拥有【修改】权限 结果【{f3}】\n");

            //然后检查是否具有其他内容的
            for (int i = 0; i < 3; i++)
            {
                string user = $"张三{i}";
                securityMgr.Login(user);
                bool res = securityMgr.HasPermit($"{user}", "人员列表", "查看");
                Console.WriteLine($"【{user}】对【人员列表】拥有【查看】权限结果是【{res}】\n");
            }
        }

        private static void Test()
        {
            DateTime curTime = DateTime.UtcNow;

            long tmp1 =(long)curTime.Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds;
            Console.WriteLine($"1-获取当前时间与1970年1月1日00:00:00 GMT之间所差的毫秒数是【{tmp1}】\n");

            DateTime startDT = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            long currentMills = (long)(curTime - startDT).TotalMilliseconds;
            Console.WriteLine($"2-获取当前时间与1970年1月1日00:00:00 GMT之间所差的毫秒数是【{currentMills}】\n");
        }

        /// <summary>
        /// 测试享元模式示例三
        /// </summary>
        private static void TestFlyweightDemoThree()
        {
            Console.WriteLine("------测试享元模式示例三------");
            FlyweightDemoThree.SecurityMgr securityMgr=FlyweightDemoThree.SecurityMgr.Instance;

            bool f1 = securityMgr.HasPermit("张三","薪资数据","查看");
            Console.WriteLine($"【张三】对【薪资数据】拥有【查看】权限 结果【{f1}】\n");

            bool f2 = securityMgr.HasPermit("李四","薪资数据","查看");
            Console.WriteLine($"【李四】对【薪资数据】拥有【查看】权限 结果【{f2}】\n");

            bool f3 = securityMgr.HasPermit("李四","薪资数据","修改");
            Console.WriteLine($"【李四】对【薪资数据】拥有【修改】权限 结果【{f3}】\n");

            //然后检查是否具有其他内容的
            for (int i = 0; i < 3; i++)
            {
                string user = $"张三{i}";
                bool res = securityMgr.HasPermit($"{user}", "人员列表", "查看");
                Console.WriteLine($"【{user}】对【人员列表】拥有【查看】权限结果是【{res}】\n");
            }

            //查看引用次数【这里的引用次数是指SecurityMgr里面的QueryByUser方法通过享元工厂区获取享元对象的次数】
            FlyweightDemoThree.FlyweightFactory flyweightFactory=FlyweightDemoThree.FlyweightFactory.Instance;
            string state1 = "薪资数据,查看";
            Console.WriteLine($"【{state1}】被引用了【{flyweightFactory.GetUseTimes(state1)}】次");

            string state2 = "薪资数据,修改";
            Console.WriteLine($"【{state2}】被引用了【{flyweightFactory.GetUseTimes(state2)}】次");

            string state3 = "人员列表,查看";
            Console.WriteLine($"【{state3}】被引用了【{flyweightFactory.GetUseTimes(state3)}】次");

        }

    }//Class_end
}
