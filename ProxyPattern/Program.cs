using ProxyPattern.ProtectProxy;
using ProxyPattern.Proxy;

namespace ProxyPattern
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //GetDepmentUsersTest();

            //GetUserInfoProxyTest();

            //OrderProxyTest();

            OrderProxyTest2();

            Console.ReadLine();
        }

        /// <summary>
        /// 测试获取部门人员
        /// </summary>
        private static void GetDepmentUsersTest()
        {
            Console.WriteLine("---测试获取部门人员---");
            string depmentId = "0101";
            Console.WriteLine($"{depmentId} 部门的所有人员如下");
            List<UserModel> userModels = UserManager.GetUserByDepmentId(depmentId);
            foreach (UserModel userModel in userModels)
            {
                Console.WriteLine(userModel.ToString());
            }

            depmentId = "0102";
            Console.WriteLine($"\n{depmentId} 部门的所有人员如下");
            List<UserModel> userModels2 = UserManager.GetUserByDepmentId(depmentId);
            foreach (UserModel userModel in userModels2)
            {
                Console.WriteLine(userModel.ToString());
            }
        }

        /// <summary>
        /// 测试用户代理客户端
        /// </summary>
        private static void GetUserInfoProxyTest()
        {
            Proxy.UserManager userManager = new Proxy.UserManager();
            List<IUserModel> userModels = userManager.GetUserByDepmentId("0101");

            //若只是显示用户名称，则不需要重新查询数据库
            foreach (var item in userModels)
            {
                string str = $"用户的身份证编号是【{item.UserId}】姓名是【{item.UserName}】";
                Console.WriteLine(str);
                
            }

            Console.WriteLine();
            //若要访问非用户身份证编号和姓名外的属性内容，那就需要重新查询数据库
            foreach (var item in userModels)
            {
                string str = $"用户的身份证编号是【{item.UserId}】姓名是【{item.UserName}】部门是【{item.DepmentId}】";
                Console.WriteLine(str);
                Console.WriteLine(item.ToString());
            }

        }

        /// <summary>
        /// 订单代理测试
        /// </summary>
        private static void OrderProxyTest()
        {
            //张三先登录系统创建一个订单
            IOrder order = new OrderProxy(new Order("设计模式",666,"张三"));
            Console.WriteLine($"初始创建订单的信息是\n{order.ToString()}\n\n");


            //李四想要修改，此时应该有报错提示
            order.SetOrderNumber(999,"李四");
            Console.WriteLine($"李四尝试修改订单数量后，订单信息是\n{order.ToString()}");

            //创建者张三修改订单，可正常修改且不会报错
            order.SetOrderNumber(888,"张三");
            Console.WriteLine($"\n\n张三修改订单数量后，订单信息是\n{order.ToString()}");
        }

        /// <summary>
        /// 订单代理测试【继承方式】
        /// </summary>
        private static void OrderProxyTest2()
        {
            //张三先登录系统创建一个订单
            ModifyProxy.Order order = new ModifyProxy.OrderProxy("设计模式", 666, "张三");
            Console.WriteLine($"初始创建订单的信息是\n{order.ToString()}\n\n");


            //李四想要修改，此时应该有报错提示
            order.SetOrderNumber(999, "李四");
            Console.WriteLine($"李四尝试修改订单数量后，订单信息是\n{order.ToString()}");

            //创建者张三修改订单，可正常修改且不会报错
            order.SetOrderNumber(888, "张三");
            Console.WriteLine($"\n\n张三修改订单数量后，订单信息是\n{order.ToString()}");
        }

    }//Class_end
}
