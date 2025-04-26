/***
*	Title："设计模式" 项目
*		主题：可拓展的抽象抽象工厂（不太安全）
*	Description：
*	    功能：抽象工厂模式的本质是【选择产品簇(系列)的实现】
*	        抽象工厂本质：是选择单个产品的实现，虽然一个类里面可以有多个工厂方法，但是这些方法之间一般是没有联系的；
*	                      抽象工厂着重的就是为一个产品簇选择实现；抽象工厂方法通常是有联系的，它们都是产品某一部分或是相互依赖的
*	        
*	        抽象工厂模式的优点：
*	                1、分离接口和实现（客户端使用抽象工厂来创建需要的对象，而客户端根本不知道具体的实现是谁，客户端只是面向产品的接口编程而已）
*	                2、使得切换产品系列变得容易（因为一个具体的工厂实现代表一个产品系列【如：Schema1代表装机方案一：Intel的CPU+技嘉的主板;
*	                     Schema2代表装机方案二：AMD的CPU+微星的主板；客户选用不同的模式，就相当于切换不同的产品系列】）
*	        
*	        抽象工厂模式的缺点：
*	                1、不太容易扩展新的产品（典型的抽象工厂方法若需要给整个产品新添加一个产品，那就需要修改抽象工厂，
*	                                        这样会导致修改所有的工厂实现类；可扩展的抽象工厂可以解决新增产品问题，但是又不够安全）
*	                2、容易造成类层次复杂（在使用抽象工厂模式时，若需要选择的层次过多，那么会造成整个类层次变得复杂）
*	       
*	       何时选用抽象工厂模式？
*	                1、如果希望一个系统独立于它的产品创建、组合和表示的时候【即：希望一个系统只知道产品的接口，而不关心实现】
*	                2、如果一个系统要由多个产品系列中的一个来配置的时候【即：可以动态的切换多个产品簇(系列)】
*	                3、如果要强调一系列相关产品的接口，以便联合使用它们的时候
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

namespace AbstractFactoryPattern.ExtandAbstractFactory
{
    /// <summary>
    /// 可拓展的抽象工厂接口
    /// </summary>
    internal interface IExtandAbstractFacoty
    {
        /// <summary>
        /// 一个通用的创建产品对象方法
        /// </summary>
        /// <param name="type">具体创建产品类型标识</param>
        /// <returns>返回被创建出的产品对象</returns>
        object CreateProduct(int type);


    }//Interface_end
}
