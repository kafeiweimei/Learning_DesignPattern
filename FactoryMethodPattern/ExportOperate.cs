﻿/***
*	Title："设计模式" 项目
*		主题：工厂方法模式
*	Description：
*	    基础概念：工厂方法模式的本质是【延迟到子类来选择实现】
*	    工厂方法模式定义：定义一个用于创建对象的接口，让子类决定实例化哪一个类，FactoryMethod使一个类的实例化延迟到其子类
*	                   
*	    工厂方法模式的功能：是让父类在不知道具体实现的情况下，完成自身的功能调用；而具体的实现延迟到子类来实现；
*	            1、通常父类会是一个抽象类，里面包含创建所需对象的抽象方法，这些抽象方法就是工厂方法
*	                （注意：子类在实现这些抽象方法的时候，通常并不是真正地由子类来实现具体的功能，
*	                而是在子类的方法里面做选择，选择具体的产品实现对象）
*	            2、实现成具体的类（通常情况下需要具体的子类来决定要如何创建父类所需要的对象；
*	                通过工厂方法，可以让子类对象来覆盖父类的实现，从而提供更好的灵活性）
*	            3、工厂方法的参数和返回（工厂方法的实现中，可能需要参数，以便决定到底选用哪一种具体的实现；
*	                一般工厂方法返回的是被创建对象的接口对象，当然也可以是抽象类或者一个具体类的实例）
*	            4、谁来使用工厂方法创建对象（应该是Creator中的其他方法在使用工厂方法创建对象；客户端在使用Creator对象）    
*	    
*	    如何理解IOC/DI?【IOC---InversionofControl 控制反转】【DI---Dependency Injection 依赖注入】
*	            1、参与者都有谁？（一般有三方参与者：一个是某个对象（任意的普通对象）；另一个是IOC/DI的容器
*	            （指用来实现IOC/DI功能的一个框架程序）；最后一个是某个对象的外部资源）
*	            2、谁依赖于谁：当然是某个对象依赖于IOC/DI的容器
*	            3、为什么需要依赖：对象需要IOC/DI的容器来提供对象需要的外部资源
*	            4、谁注入于谁：IOC/DI的容器注入控制对象；
*	            5、到底注入什么：注入某个对象所需要的外部资源
*	            6、谁控制谁：当然是IOC/DI的容器来控制对象了
*	            7、控制什么：主要是控制对象实例的创建
*	            8、为何叫反转：反转是相对于正向而言的，那什么算是正向的呢？（常规情况下的应用程序：
*	                    如果A里面要使用C，你会怎么做？当然是直接创建C的对象【这种情况就被称为正向的】
*	                    【那什么是反向呢？就是A类中不再主动获取C，而是被动的等待，等待IOC/DI的容器获取一个C的实例，
*	                    然后反向地注入到A类中】）
*	            9、依赖注入和控制反转是同一概念吗？（依赖注入和控制反转是对同一件事情的不同描述；
*	                【依赖注入】是从应用程序的角度描述，即【应用程序依赖容器创建并注入它所需要的外部资源】
*	                【控制反转】是从容器的角度描述，即【容器控制应用程序，由容器反向地向应用程序注入其所需的外部资源】）
*	            10、工厂方法与IOC/DI的关系【工厂方法与IOC/DI的思想是相似的，都是主动变被动，进行了主从换位，从而获得了更灵活的程序结构】
*	     
*	     参数化工厂方法：指通过给工厂方法传递参数，让工厂方法根据参数的不同来创建不同的产品对象
*	     
*	     工厂方法模式的优点：
*	            1、可以在不知具体实现的情况下编程（若需要某个产品对象，只需要使用接口即可，无需关心具体实现，具体实现延迟到子类完成）
*	            2、更容易扩展对象的新版本（工厂方法给子类提供了一个挂钩（钩子方法hook），使得扩展新对象版本变得非常容易） 
*	            3、连接平行的类层次（工厂方法除了可以创造产品对象外，在连接平行的类层次上也容易） 
*	            
*	     工厂方法的缺点：
*	            1、具体产品对象与工厂方法的耦合性（在工厂方法模式中，工厂方法是需要创建具体产品对象的实例，因此具体产品对象与工厂方法耦合）
*	             
*	     何时选用工厂方法模式：
*	            1、如果一个类需要创建某个接口对象，但是又不知道具体的实现，可选择工厂方法模式，把创建对象工作延迟到子类实现；
*	            2、如果一个类本身就希望由它的子类来创建所需对象的时候，就使用工厂方法
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

namespace FactoryMethodPattern
{
    /// <summary>
    /// 实现导出数据的业务功能对象
    /// </summary>
    abstract class ExportOperate
    {
        //工厂方法，创建导出的接口对象
        protected abstract IExportFile FactoryMethod();

        //导出文件
        public bool Export(string data)
        {
            //使用工厂方法
            IExportFile exportFile = FactoryMethod();
            return exportFile.Export(data);
        }

    }//Class_end
}
