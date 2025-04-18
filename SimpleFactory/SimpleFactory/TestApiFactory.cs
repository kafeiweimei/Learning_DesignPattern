/***
*	Title："设计模式" 项目
*		主题：简单工厂
*	Description：
*	    基础概念：
*	        工厂就是用来创造东西的（通常情况下工厂是用来创造接口对象的）
*	            但是也可以用来创造抽象类，甚至是一个具体的类实例
*	            
*	        《静态工厂》：使用简单工厂的时候，通常不用创建简单工厂类的实例（没必要），
*		              因此可以直接把简单工厂类实现为一个工具类(即：使用static修饰方法为静态的)；
*		              而工厂的方法通常都是静态的，所以称其为静态工厂
*		    《万能工厂》：
*		        一个简单工厂可以包含很多构建东西的方法（这些方法可以创建不同的接口、抽象类或类示例）
*		        也就是说理论上一个简单工厂其实可以构建任何东西，因此又叫做万能工厂
*		        注意：虽然理论上简单工厂可以创建任何东西，但是实际使用中不建议简单工厂可创建对象的范围太大，
*		              建议是一个简单工厂控制在一个独立的模块内，这样使用起来才会职责清晰不混乱
*		            
*		    《简单工厂的命名》：
*		        《类名称》：建议是【模块名称+Factory】（如接口名称是：ITestApi,则简单工厂类名称是：TestApiFactory）
*		        《方法名称》：建议是【Get+接口名称】、【Create+接口名称】或【Build+接口名称】
*		        (如接口名称是：ITestApi，则简单工厂内对应的接口名称是：GetTestApi、CreateTestApi或BuildTestApi)
*		    
*		功能：
*		     简单工厂方法的内部主要实现的功能是【选择合适的实现类】来创建实例对象，涉及到选择，
*		     就需要选择的条件或参数（这些选择条件或参数可来源于客户端传入、配置文件传入或程序运行时的某个值传入）
*		     这样要传入参数就会存在一个缺点【就是客户端必须要知道每个参数的含义（同时也需要理解每个参数对应的功能处理）】这样的话
*		     就导致了在一定程度上给客户端暴露了内部的一些实现细节
*		     
*		     《优点》：
*		            1、帮助封装，让外部实现了真正的面向接口编程
*		            2、解耦，通过简单工厂，实现客户端与具体实现类的解耦
*		     《缺点》：
*		            1、可能增加客户端的复杂度（即简单工厂是选择条件或参数来进行合适类对象的创建，对外会暴露细节，增加客户端使用难度）
*		            2、不方便扩展子工厂
*		     
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

namespace SimpleFactory
{
    /// <summary>
    /// ITestApi接口的简单工厂（用于创建接口的实现对象）
    /// （解决：只知到ITestApi接口，而不知道是哪个类实现了它，这样就得不到接口对象，无法使用接口问题）
    /// </summary>
    internal class TestApiFactory
    {
        /// <summary>
        /// 构建ITestApi接口的实现类
        /// </summary>
        /// <param name="implObjNum">实现对象编号</param>
        /// <returns>返回创建好的ITestApi对象</returns>
        public static ITestApi BuildTestApi(int implObjNum)
        {
            ITestApi testApi = new ImplTestApi();

            switch (implObjNum)
            {
                case 0:
                    testApi = new ImplTestApi();
                    break;
                case 1:
                    testApi = new ImplA();
                    break;
                case 2:
                    testApi = new ImplB();
                    break;

                default:
                    break;
            }
            return testApi;
        }

    }//Class_end
}
