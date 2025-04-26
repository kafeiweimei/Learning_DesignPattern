using System.Diagnostics;

namespace SingletonPattern
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //ReadAppConfig();
            //ReadAppConfig_HungrySingleton();
            //ReadAppConfig_IdlerSingleton();
            //ThreadSafe_IdlerSingletonTest();
            //ThreadSafe2_IdlerSingletonTest();
            ThreadSafe_MutiIdlerSingletonTest();

            Console.ReadLine();
        }



        /// <summary>
        /// 未使用任何模式读取配置文件
        /// </summary>
        private static void ReadAppConfig()
        {
            /*这里是直接使用new来实例化一个操作配置文件的对象AppConfig，会存在什么问题呢？
             *   若在系统运行的过程中，有很多地方都需要使用到这个配置内容，
             *   那么我们就要在很多地方创建AppConfig对象实例,此时系统就会存在多个AppConfig实例对象，
             *   这样会严重浪费内存资源；仔细看一下这些实例对象所包含的内容都是相同的
             *   （其实只需要一个实例就可以了），我们该如何实现呢？
             */
            Console.WriteLine("未使用任何模式读取配置文件");
            AppConfig appConfig=new AppConfig();
            string str = $"配置文件中 parameterA={appConfig.ParameterA} parameterB={appConfig.ParameterB}";
            Console.WriteLine(str);
            Console.WriteLine($"未使用任何模式读取配置文件 实例对象{appConfig}的编号={appConfig.GetHashCode()}");

            AppConfig appConfig2 = new AppConfig();
            string str2 = $"配置文件中 parameterA={appConfig2.ParameterA} parameterB={appConfig2.ParameterB}";
            Console.WriteLine(str2);
            Console.WriteLine($"未使用任何模式读取配置文件 实例对象{appConfig2}的编号={appConfig2.GetHashCode()}");

        }

        /// <summary>
        /// 【饿汉式】单例模式读取配置文件（线程安全）
        /// </summary>
        private static void ReadAppConfig_HungrySingleton()
        {
            Console.WriteLine("\n【饿汉式】单例模式读取配置文件（线程安全）");
            AppConfig_HungrySingleton appConfig = AppConfig_HungrySingleton.GetInstance();
            string str = $"配置文件中 parameterA={appConfig.ParameterA} parameterB={appConfig.ParameterB}";
            Console.WriteLine(str);
            Console.WriteLine($"【饿汉式】单例模式读取配置文件（线程安全） 实例对象{appConfig}的编号={appConfig.GetHashCode()}");

            AppConfig_HungrySingleton appConfig2 = AppConfig_HungrySingleton.GetInstance();
            string str2 = $"配置文件中 parameterA={appConfig2.ParameterA} parameterB={appConfig2.ParameterB}";
            Console.WriteLine(str2);
            Console.WriteLine($"【饿汉式】单例模式读取配置文件（线程安全） 实例对象{appConfig2}的编号={appConfig2.GetHashCode()}");

            for (int i = 0; i <7; i++)
            {
                Task task = Task.Run(() =>
                {
                    AppConfig_HungrySingleton appConfigTask = AppConfig_HungrySingleton.GetInstance();
                    Console.WriteLine($"【饿汉式】单例模式读取配置文件（线程安全）_{i} appConfig={appConfigTask.GetHashCode()}");
                });
            }
          
        }

        /// <summary>
        /// 【懒汉式】单例模式读取配置文件(线程不安全)
        /// </summary>
        private static void ReadAppConfig_IdlerSingleton()
        {
            Console.WriteLine("\n【懒汉式】单例模式读取配置文件(线程不安全)");
            AppConfig_IdlerSingleton appConfig = AppConfig_IdlerSingleton.GetInstance();
            string str = $"配置文件中 parameterA={appConfig.ParameterA} parameterB={appConfig.ParameterB}";
            Console.WriteLine(str);
            Console.WriteLine($"【懒汉式】单例模式读取配置文件(线程不安全) 实例对象{appConfig}的编号={appConfig.GetHashCode()}");

            AppConfig_IdlerSingleton appConfig2 = AppConfig_IdlerSingleton.GetInstance();
            string str2 = $"配置文件中 parameterA={appConfig2.ParameterA} parameterB={appConfig2.ParameterB}";
            Console.WriteLine(str2);
            Console.WriteLine($"【懒汉式】单例模式读取配置文件(线程不安全) 实例对象{appConfig2}的编号={appConfig2.GetHashCode()}");

            for (int i = 0; i < 7; i++)
            {
                int tmp = new Random(DateTime.Now.GetHashCode()).Next(1, 4);
                Task task =new Task(() =>
                {
                    Thread.Sleep(tmp);
                    AppConfig_IdlerSingleton appConfigTask = AppConfig_IdlerSingleton.GetInstance();
                    Console.WriteLine($"【懒汉式】单例模式读取配置文件(线程不安全)_{i} appConfig={appConfigTask.GetHashCode()}");
                });
                Thread.Sleep(1);
                task.Start();
            }

            Task task2 = Task.Run(() =>
            {
                AppConfig_IdlerSingleton appConfigTask2 = AppConfig_IdlerSingleton.GetInstance();
                Console.WriteLine($"【懒汉式】单例模式读取配置文件(线程不安全) appConfig2={appConfigTask2.GetHashCode()}");
            });

        }

        /// <summary>
        /// 【懒汉式】单例模式（线程安全）
        /// </summary>
        private static void ThreadSafe_IdlerSingletonTest()
        {
            Console.WriteLine("\n【懒汉式】单例模式(线程安全)");
            
            Task task = new Task(() =>
            {
                ThreadSafe_IdlerSingleton threadSafe_IdlerSingleton1 = ThreadSafe_IdlerSingleton.GetInstance();
                Console.WriteLine($"【懒汉式】单例模式(线程安全) threadSafe_IdlerSingleton1的编号是：{threadSafe_IdlerSingleton1.GetHashCode()}");
            });

            Task task2 = new Task(() =>
            {
                ThreadSafe_IdlerSingleton threadSafe_IdlerSingleton2 = ThreadSafe_IdlerSingleton.GetInstance();
                Console.WriteLine($"【懒汉式】单例模式(线程安全) threadSafe_IdlerSingleton2的编号是：{threadSafe_IdlerSingleton2.GetHashCode()}");
            });

            Task task3 = new Task(() =>
            {
                ThreadSafe_IdlerSingleton threadSafe_IdlerSingleton3 = ThreadSafe_IdlerSingleton.GetInstance();
                Console.WriteLine($"【懒汉式】单例模式(线程安全) threadSafe_IdlerSingleton3的编号是：{threadSafe_IdlerSingleton3.GetHashCode()}");
            });

            task.Start();
            task2.Start();
            task3.Start();

        }

        /// <summary>
        /// 【懒汉式】单例模式2（线程安全）
        /// </summary>
        private static void ThreadSafe2_IdlerSingletonTest()
        {
            Console.WriteLine("\n【懒汉式】单例模式2(线程安全)");
            
            Task task = new Task(() =>
            {
                ThreadSafe2_IdlerSingleton threadSafe2_IdlerSingleton1 = ThreadSafe2_IdlerSingleton.GetInstance();
                Console.WriteLine($"【懒汉式】单例模式2(线程安全) threadSafe2_IdlerSingleton1的编号是：{threadSafe2_IdlerSingleton1.GetHashCode()}");
            });

            Task task2 = new Task(() =>
            {
                ThreadSafe2_IdlerSingleton threadSafe2_IdlerSingleton2 = ThreadSafe2_IdlerSingleton.GetInstance();
                Console.WriteLine($"【懒汉式】单例模式2(线程安全) threadSafe2_IdlerSingleton2的编号是：{threadSafe2_IdlerSingleton2.GetHashCode()}");
            });

            Task task3 = new Task(() =>
            {
                ThreadSafe2_IdlerSingleton threadSafe2_IdlerSingleton3 = ThreadSafe2_IdlerSingleton.GetInstance();
                Console.WriteLine($"【懒汉式】单例模式2(线程安全) threadSafe2_IdlerSingleton3的编号是：{threadSafe2_IdlerSingleton3.GetHashCode()}");
            });

            task.Start();
            task2.Start();
            task3.Start();

        }

        /// <summary>
        /// 【懒汉式】可控数量的单例模式（线程安全）
        /// </summary>
        private static void ThreadSafe_MutiIdlerSingletonTest()
        {
            Console.WriteLine("\n【懒汉式】可控数量的单例模式（线程安全）");

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            for (int i = 0; i < 666; i++)
            {
                Task task = Task.Run(() =>
                {
                    //Thread.Sleep(10);
                    ThreadSafe_MutiIdlerSingleton threadSafe_MutiIdlerSingleton = ThreadSafe_MutiIdlerSingleton.GetInstance();
                    Console.WriteLine($"【懒汉式】可控数量的单例模式（线程安全） threadSafe_MutiIdlerSingleton_{i}的编号是：{threadSafe_MutiIdlerSingleton.GetHashCode()}");
                });

            }
            stopwatch.Stop();
            Console.WriteLine($"1--花费时间为：{stopwatch.ElapsedMilliseconds}\n");

            //stopwatch.Reset();
            //stopwatch.Start();
            //Parallel.For(0,666,i=>
            //Task.Run(() =>
            //{
            //    ThreadSafe_MutiIdlerSingleton threadSafe_MutiIdlerSingleton = ThreadSafe_MutiIdlerSingleton.GetInstance();
            //    Console.WriteLine($"【懒汉式】可控数量的单例模式（线程安全） threadSafe_MutiIdlerSingleton_{i}的编号是：{threadSafe_MutiIdlerSingleton.GetHashCode()}");
            //})
            //);
            //stopwatch.Stop();
            //Console.WriteLine($"2--花费时间为：{stopwatch.ElapsedMilliseconds}");
        }

    }//Class_end
}
