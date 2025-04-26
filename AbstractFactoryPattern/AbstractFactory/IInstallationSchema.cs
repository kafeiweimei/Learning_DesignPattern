/***
*	Title："设计模式" 项目
*		主题：典型抽象工厂
*	Description：
*	    功能：抽象工厂模式的本质是【选择产品簇(系列)的实现】
*	        抽象工厂模式定义：提供一个创建一系列相关或相互依赖对象的接口，而无需指定它们具体的类
*	        
*	        抽象工厂的功能：抽象工厂的功能是为一系列相关对象或相互依赖对象创建一个接口【抽象工厂其实是一个产品系列】
*	                【特别注意：这个接口内的方法不是任意堆砌的，而是一系列相关或相互依赖的方法】
*	        抽象工厂通常实现为接口；
*	        切换产品系列：由于抽象工厂定义的一系列对象通常是相关或相互依赖的，这些产品构成来了一个系列或产品簇；
*	                    这就带来了很大的灵活性，即切换一个产品簇的时候，只要提供不同的抽象工厂实现就可以
*	                    
*	    
*Date：2025
*	Version：0.1版本
*	Author：Coffee
*	Modify Recoder：
 ***/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactoryPattern.AbstractFactory
{
    /// <summary>
    /// 抽象工厂接口，声明创建抽象产品对象的操作
    /// </summary>
    internal interface IInstallationSchema
    {
        //创建CPU对象
        ICPU CreateCPU();

        //创建主板对象
        IMainboard CreateMainboard();

    }//Interface_end
}
