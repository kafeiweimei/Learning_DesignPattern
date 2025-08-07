/***
*	Title："设计模式" 项目
*		主题：组合对象
*	Description：
*	    组合对象的优势
*	        《1》可以有选择的复用功能（即持有其他对象实例的功能可以根据需要使用需要到的，不使用的不调用即可）；
*	        《2》在调用持有的其他对象实例功能前后，可以实现一些功能处理（比如：该类持有A对象实例，该类对于A对象是透明的（即：A对象并不知道它自己的A1方法在被调用前后被追加了什么功能））。
*	        《3》可以组合拥有多个对象的功能（比如：在这个类中除了持有A对象的实例还可以持有C对象的实例，可以分别组合调用A对象实例与B对象实例的方法）
*	    
*	    何时创建被组合对象的实例：
*	        《1》方式一：在属性上直接定义并创建需要组合对象的实例；
*	        《2》方式二：在属性上定义一个变量，来表示持有被组合对象的实例，具体的实例从外部传入，也可以通过IOC/DI容器来注入。
*	        
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

namespace DecoratorPattern.ObjectCompositon
{
    /// <summary>
    /// 【使用对象组合方式】实现对A对象A1方法的扩展（即：直接创建A对象的实例进行操作）
    /// </summary>
    internal class B11
    {
        //持有A对象实例【这就是属于在属性上创建需要组合的对象】
        A a = new A();
        //持有C对象实例【这就是属于在属性上创建需要组合的对象】
        C c = new C();

        //通过外部传入需要组合的对象
        private D d = null;
        public void SetD(D d)
        {
            this.d = d;
        }

        public void B1()
        {
            Console.WriteLine($"我是B11对象");
            //转调A对象的功能
            a.A1();
            Console.WriteLine($"{this.GetType().Name}/B1()");
            Console.WriteLine("\n");
        }

        public void B2()
        {
            Console.WriteLine($"我是B11对象");
            Console.WriteLine($"{this.GetType().Name}/这是扩展的功能B2");
            //转调C对象的功能
            c.C1();
            Console.WriteLine("\n");
        }

        public void B3()
        {
            Console.WriteLine($"我是B11对象");
            //转调D对象的功能
            d.D1();
            Console.WriteLine("\n");
        }

    }//Class_end
}
