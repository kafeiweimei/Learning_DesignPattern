/***
*	Title："设计模式" 项目
*		主题：【饿汉式】单例模式（线程安全）
*	Description：
*	    基础概念：单例模式的本质【控制实例数目】
*	        单例模式：是用来保证这个类在运行期间只会被创建一个类实例；
*	                  单例模式还提供了一个全局唯一访问这个类实例的访问点（即Instance属性）
*	                  单例模式只关心类实例的创建问题，并不关心具体的业务功能
*	                  
*	        单例模式的范围：在C#中单例模式的范围是指在每个AppDomain之中只能存在一个实例的类
*	                        在Java中单例的范围是一个虚拟机的范围（因为装载类的功能是虚拟机，一个虚拟机通过自己的ClassLoader装载单例）
*	    
*	        单例模式的命名：建议使用GetInstance()作为单例模式的方法名；GetInstance()方法可以有参数
*	    
*	        单例模式的优点：
*	                    1、时间与空间
*	                    （懒汉式是典型的时间换空间【每次获取实例都会进行判断是否需要创建实例，浪费判断的时间，若一直没有人使用就不会创建实例，节约内存】
*	                      饿汉式是典型的空间换时间，当类装载的时候就会创建类实例，不管你用不用先创建出来，每次调用时就不需要再判断了，节省运行时间）
*	                    2、线程安全
*	                    （饿汉式是线程安全的，因为在装载的时候只会装载一次，且在装载类的时候不会发生并发；
*	                      从线程安全性上来讲，不加同步的懒汉式线程是不安全的【即；有多个线程同时调用GetInstance方法就可能导致并发问题】）
*	        
*	        何时选用单例模式？
*	                    1、当需要控制类的实例只能有一个，且客户只能从一个全局访问点访问它
*	                   
*	Date：2025
*	Version：0.1版本
*	Author：Coffee
*	Modify Recoder：
 ***/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingletonPattern
{
    /// <summary>
    /// 【饿汉式】单例模式
    /// </summary>
    internal class AppConfig_HungrySingleton
    {
        //1、开始就定义一个变量来存储创建好的类实例
        private static AppConfig_HungrySingleton instance=new AppConfig_HungrySingleton();

        private string appConfigPathAndName = $"{Directory.GetCurrentDirectory()}\\AppConfig.txt";
        //存放配置文件中参数A的值
        private string parameterA;
        //存放配置文件中参数B的值
        private string parameterB;


        /// <summary>
        /// 2、私有化构造函数
        /// </summary>
        private AppConfig_HungrySingleton()
        {
            CreateConfig();
            ReadConfig();
        }

        //3、定义一个方法来为客户端提供AppConfig_HungrySingleton类的实例
        public static AppConfig_HungrySingleton GetInstance()
        {
            return instance;
        }

        public string AppConfigPathAndName { get => appConfigPathAndName; }
        public string ParameterA { get => parameterA; }
        public string ParameterB { get => parameterB; }


        /// <summary>
        /// 读取配置文件，将配置文件中的内容读取出来设置到属性上
        /// </summary>
        private void ReadConfig()
        {
            List<string> configList = new List<string>();
            using (FileStream fs = new FileStream(appConfigPathAndName, FileMode.Open))
            {
                using (StreamReader sr = new StreamReader(fs))
                {
                    string strLine = sr.ReadLine();
                    while (!string.IsNullOrEmpty(strLine))
                    {
                        configList.Add(strLine);
                        strLine = sr.ReadLine();
                    }
                }
                if (configList != null && configList.Count == 2)
                {
                    parameterA = configList[0];
                    parameterB = configList[1];
                }

            }

        }

        /// <summary>
        /// 创建配置文件
        /// </summary>
        private void CreateConfig()
        {
            if (File.Exists(appConfigPathAndName)) return;

            using (FileStream fs = new FileStream(appConfigPathAndName, FileMode.Create))
            {
                using (StreamWriter sw = new StreamWriter(fs))
                {
                    sw.WriteLine("参数A");
                    sw.WriteLine("参数B");
                    sw.AutoFlush = true;
                }
            }
        }


    }//Class_end
}
