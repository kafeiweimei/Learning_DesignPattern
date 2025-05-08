using PrototypePattern.PrototypeeManager;
using System.Net.Sockets;

namespace PrototypePattern
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //OrderBussinessTest();

            //OrderBussinessPrototypeTest();

            //TestPrototypeInstaceAndCloneInstace();

            //TestPrototypeInstaceAndCloneInstace2();

            //OrderBussinessTestDeepClone();

            //OrderBussinessTestDeepClone2();

            PrototypeManagerTest();

            Console.ReadLine();
        }

        /// <summary>
        /// 处理订单的业务对象测试
        /// </summary>
        private static void OrderBussinessTest()
        {
            Console.WriteLine("---处理订单的业务对象测试---");

            /*个人订单*/
            Console.WriteLine("\n\n个人订单\n");
            //创建订单对象并设置内容(为了演示简单直接new)
            PersonalOrder po = new PersonalOrder();
            po.CustomerName = "张三";
            po.ProductId = $"CK{new Random(Guid.NewGuid().GetHashCode()).Next(100,999)}";
            po.SetOrderProductNumber(2966);

            //获取订单业务对象(为了演示简单直接new)
            OrderBussiness ob=new OrderBussiness();
            //保存订单业务
            ob.SaveOrder(po);

            /*企业订单*/
            Console.WriteLine("\n\n企业订单\n");
            EnterpriseOrder eo=new EnterpriseOrder();
            eo.EnterpriseName = "牛奶咖啡科技有限公司";
            eo.ProductId= $"CK{new Random(Guid.NewGuid().GetHashCode()).Next(100, 999)}";
            eo.SetOrderProductNumber(3001);

            OrderBussiness ob2 = new OrderBussiness();
            ob2.SaveOrder(eo);
        }

        /// <summary>
        /// 处理订单业务原型模式测试
        /// </summary>
        private static void OrderBussinessPrototypeTest()
        {
            Console.WriteLine("---处理订单业务原型模式测试---");

            /*个人订单*/
            Console.WriteLine("\n\n个人订单\n");
            //创建订单对象并设置内容(为了演示简单直接new)
            Prototype.PersonalOrder po = new Prototype.PersonalOrder();
            po.CustomerName = "张三";
            po.ProductId = $"CK{new Random(Guid.NewGuid().GetHashCode()).Next(100, 999)}";
            po.SetOrderProductNumber(2966);

            //获取订单业务对象(为了演示简单直接new)
            Prototype.OrderBussiness ob = new Prototype.OrderBussiness();
            //保存订单业务
            ob.SaveOrder(po);

            /*企业订单*/
            Console.WriteLine("\n\n企业订单\n");
            Prototype.EnterpriseOrder eo = new Prototype.EnterpriseOrder();
            eo.EnterpriseName = "牛奶咖啡科技有限公司";
            eo.ProductId = $"CK{new Random(Guid.NewGuid().GetHashCode()).Next(100, 999)}";
            eo.SetOrderProductNumber(3001);

            Prototype.OrderBussiness ob2 = new Prototype.OrderBussiness();
            ob2.SaveOrder(eo);
        }

        /// <summary>
        /// 【浅度克隆】原型实例与克隆出来的实例，本质上是不同的实例（克隆完成后，它们之间是没有关联，互不影响的）
        /// </summary>
        private static void TestPrototypeInstaceAndCloneInstace()
        {
            //先创建原型实例
            Prototype.PersonalOrder order = new Prototype.PersonalOrder();
            //设置原型实例的订单数量
            order.SetOrderProductNumber(666);
            //为了演示简单，就只输出数量
            Console.WriteLine($"第一次获取个人订单对象实例的数量【{order.GetOrderProductNumber()}】");


            //通过克隆来获取实例
            Prototype.PersonalOrder order2 = (Prototype.PersonalOrder)order.Clone();
            //修改克隆实例的数量
            order2.SetOrderProductNumber(33);
            //输出数量
            Console.WriteLine($"克隆实例的数量【{order2.GetOrderProductNumber()}】");

            //输出原型实例的数量
            Console.WriteLine($"克隆实例修改数量后原型实例的数量是【{order.GetOrderProductNumber()}】");


        }

        /// <summary>
        /// 【浅度克隆】原型实例与克隆出来的实例，本质上是不同的实例（克隆完成后，它们之间是没有关联，互不影响的）
        /// </summary>
        private static void TestPrototypeInstaceAndCloneInstace2()
        {
            //先创建原型实例
            CSharpClone.PersonalOrder2 order = new CSharpClone.PersonalOrder2();
            //设置原型实例的订单数量
            order.SetOrderProductNumber(666);
            //为了演示简单，就只输出数量
            Console.WriteLine($"第一次获取个人订单对象实例的数量【{order.GetOrderProductNumber()}】");


            //通过克隆来获取实例
            CSharpClone.PersonalOrder2 order2 = (CSharpClone.PersonalOrder2)order.Clone();
            //修改克隆实例的数量
            order2.SetOrderProductNumber(33);
            //输出数量
            Console.WriteLine($"克隆实例的数量【{order2.GetOrderProductNumber()}】");

            //输出原型实例的数量
            Console.WriteLine($"克隆实例修改数量后原型实例的数量是【{order.GetOrderProductNumber()}】");


        }

        /// <summary>
        /// 【深度克隆】处理订单的业务对象测试
        /// </summary>
        private static void OrderBussinessTestDeepClone()
        {
            Console.WriteLine("---处理订单的业务对象测试【深度克隆】---");

            /*个人订单*/
            Console.WriteLine("\n\n个人订单\n");
            //创建订单对象并设置内容(为了演示简单直接new)
            Prototype.PersonalOrder4 po = new Prototype.PersonalOrder4();
            po.CustomerName = "张三";
            po.ProductId = $"CK{new Random(Guid.NewGuid().GetHashCode()).Next(100, 999)}";
            po.SetOrderProductNumber(2966);
            //实例化产品类且指定所有属性的值
            CSharpClone.Product product = new CSharpClone.Product();
            product.ProductName = "产品1";
            product.ProductId = "XCKX006";
            //个人订单对象的产品赋值
            po.Product = product;
            Console.WriteLine($"这是第一次获取的个人订单对象实例【{po}】");


            //通过克隆来获取新实例
            Prototype.PersonalOrder4 po2 = (Prototype.PersonalOrder4)po.Clone();
            //修改克隆实例的值
            po2.CustomerName = "李四";
            po2.ProductId = $"2CK{new Random(Guid.NewGuid().GetHashCode()).Next(100, 999)}";
            po2.SetOrderProductNumber(3666);
            po2.Product.ProductName = "产品2";
            po2.Product.ProductId = "YYCKYY009";
            //输出克隆实例的
            Console.WriteLine($"输出克隆出来的个人订单对象实例【{po2}】");

            //再次输出原型的实例
            Console.WriteLine($"这是第二次获取的个人订单对象实例【{po}】");


        }


        /// <summary>
        /// 【深度克隆】处理订单的业务对象测试
        /// </summary>
        private static void OrderBussinessTestDeepClone2()
        {
            Console.WriteLine("---处理订单的业务对象测试【深度克隆】---");

            /*个人订单*/
            Console.WriteLine("\n\n个人订单\n");
            //创建订单对象并设置内容(为了演示简单直接new)
            CSharpClone.PersonalOrder5 po = new CSharpClone.PersonalOrder5();
            po.CustomerName = "张三";
            po.ProductId = $"CK{new Random(Guid.NewGuid().GetHashCode()).Next(100, 999)}";
            po.SetOrderProductNumber(2966);
            //实例化产品类且指定所有属性的值
            CSharpClone.Product2 product2 = new CSharpClone.Product2();
            product2.ProductName = "产品1";
            product2.ProductId = "XCKX006";
            //个人订单对象的产品赋值
            po.Product2 = product2;
            Console.WriteLine($"这是第一次获取的个人订单对象实例【{po}】");


            //通过克隆来获取新实例
            CSharpClone.PersonalOrder5 po2 = (CSharpClone.PersonalOrder5)po.Clone();
            //修改克隆实例的值
            po2.CustomerName = "李四";
            po2.ProductId = $"2CK{new Random(Guid.NewGuid().GetHashCode()).Next(100, 999)}";
            po2.SetOrderProductNumber(3666);
            po2.Product2.ProductName = "产品2";
            po2.Product2.ProductId = "YYCKYY009";
            //输出克隆实例的
            Console.WriteLine($"输出克隆出来的个人订单对象实例【{po2}】");

            //再次输出原型的实例
            Console.WriteLine($"这是第二次获取的个人订单对象实例【{po}】");


        }

        /// <summary>
        /// 原型管理器测试
        /// </summary>
        private static void PrototypeManagerTest()
        {
            Console.WriteLine("---原型管理器测试---");

            //初始化原型管理器
            string prototypeId = "原型一";
            IPrototypeManager pm = new ConcreatePrototype1();
            PrototypeManager.AddPrototype(prototypeId,pm);

            //1、获取原型来创建对象
            IPrototypeManager pm1 = PrototypeManager.GetPrototype(prototypeId).Clone();
            pm1.SetName("张三");
            Console.WriteLine($"第一个实例是【{pm1}】");

            //2、有人动态的切换
            string prototypeId2 = "原型二";
            IPrototypeManager pm2 = new ConcreatePrototype2();
            PrototypeManager.AddPrototype(prototypeId2,pm2);

            //3、重新获取原型创建对象
            IPrototypeManager pm3 = PrototypeManager.GetPrototype(prototypeId2).Clone();
            pm3.SetName("李四");
            Console.WriteLine($"第二个实例是【{pm3}】");

            //4、有人注销了原型
            PrototypeManager.DelPrototype(prototypeId);

            //5、再次获取原型一来创建对象
            IPrototypeManager pm4 = PrototypeManager.GetPrototype(prototypeId).Clone();
            pm4.SetName("王五");
            Console.WriteLine($"第三个实例是【{pm4}】");

        }

    }//Class_end
}
