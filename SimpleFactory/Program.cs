

namespace SimpleFactory
{
    internal class Program
    {
        /// <summary>
        /// 客户端：测试使用ITestApi接口
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Console.WriteLine("1-接口与实现类的示例");
            //仔细查看这里：我们只知到ITestApi接口，而不知道是哪个类实现了它，这样就得不到接口对象，无法使用接口，应该怎么办？
            ITestApi testApi=new ImplTestApi();
            testApi.TestPrint("你好，这是一个简单的测试");


            Console.WriteLine("\n2-学习设计模式——简单工厂");
            /***
             * 通过简单工厂来获取ITestApi接口对象
             * （这里客户端只知道通过简单工厂创建了一个接口的对象，面向接口编程：
             * 从客户端这里来看，它其实根本不知道具体的实现是什么，也不知道是如何实现的，
             * 它只知道通过工厂获得了一个接口对象，然后通过这个接口来获取想要的功能）
             * 
             * 在这里通过简单工厂帮助我们真正的面向接口编程，
             * 上面的【接口与实现类的示例】做法，只用到了接口的多态功能；
             * 而最重要的【封装隔离性】并没有体现出来
             * ***/
            ITestApi testApi1 = TestApiFactory.BuildTestApi(0);
            testApi1.TestPrint("你好，这是一个简单的测试");
            
            testApi1=TestApiFactory.BuildTestApi(1);
            testApi1.TestPrint("你好，这是一个简单的测试");

            testApi1 = TestApiFactory.BuildTestApi(2);
            testApi1.TestPrint("你好，这是一个简单的测试");

            Console.ReadLine();
        }

    }//Class_end
}
