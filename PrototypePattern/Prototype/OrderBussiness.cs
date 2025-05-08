/***
*	Title："设计模式" 项目
*		主题：原型模式
*	Description：
*	   功能：原型模式的本质是【克隆生成对象】
*	        1、通过克隆来创建新的对象实例；
*	        2、为克隆出来的新对象实例复制原型实例属性值
*	        
*	    定义：用原型实例指定创建对象的种类，并通过拷贝这些原型创建新的对象    
*	        
*	    克隆：无论是自己实现克隆方法，还是采用C#提供的克隆方法，都存在一个浅度克隆和深度克隆的问题
*	        1、浅度克隆：只负责克隆按值传递的数据（比如基本数据类型、String类型）
*	        2、深度克隆：除了浅度克隆要克隆的值外，还负责克隆引用类型的数据，基本上就是被克隆实例所有的属性数据都会被克隆出来
*	    
*	    原型模式的优点：
*	                    1、对客户端隐藏具体的实现类型（即：原型模式的客户端只知道原型接口类型，并不知道具体的实现类型，
*	                        从而减少了客户端对具体实现类型的依赖）
*	                    2、在运行时动态改变具体的实现类型（即：原型模式可以在运行期间，
*	                        由客户来注册符合原型接口的实现类型，也可以动态改变具体的实现类型，看起来接口没有任何变化，
*	                        但其实运行的已经是另外一个类实例了【因为克隆一个原型就类似于实例化一个类】）
*	    
*	    原型模式的缺点：
*	                    1、每个原型的子类都必须实现克隆操作，尤其在包含引用类型的对象时，克隆方法会比较麻烦，必须要能够
*	                        递归地让所有相关对象都要正确地实现克隆
*	    
*	    何时选用原型模式：
*	                    1、如果一个系统想要独立于它想要使用的对象时【让系统只面向接口编程，在系统需要新对象时可以通过克隆原型获取】；
*	                    2、如果需要实例化的类是在运行时动态指定的，可通过克隆原型类得到想要的实例。
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

namespace PrototypePattern.Prototype
{
    /// <summary>
    /// 处理订单的业务对象
    /// </summary>
    internal class OrderBussiness
    {
        private const int fixedNumber = 1000;

        public void SaveOrder(IOrder order)
        {
            /*根据业务要求，当预订产品的数量大于1000时，就需要把订单拆分为两份*/

            //1、判断订单是否大于1000（若大于1000则拆分订单）
            while (order.GetOrderProductNumber()>1000)
            {
                //2、创建一份新的订单，除了订单的数量不一样，其他内容都一致
                IOrder newOrder = order.Clone();

                //3、然后进行赋值
                newOrder.SetOrderProductNumber(fixedNumber);

                //4、创建新订单后原订单需要将使用的数量减去
                order.SetOrderProductNumber(order.GetOrderProductNumber()-fixedNumber);

                //5、处理业务功能
                Console.WriteLine($"拆分生成的订单是【{newOrder}】");

            }
            //订单数量不超过1000的直接执行业务处理
            Console.WriteLine($"拆分生成的订单是【{order}】");
        }


    }//Class_end
}
