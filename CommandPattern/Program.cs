
namespace CommandPattern
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //OpenButtonPressedTest();

            //ParameterButtonPressedTest();

            //UndoAndRedoOfAddSubTest();

            //CustomerOrderDishTest();

            //ListQueue();

            TestQueue();

            Console.ReadLine();
        }

        /// <summary>
        /// 测试客户按下机箱的开机按钮启动系统
        /// </summary>
        private static void OpenButtonPressedTest()
        {
            Console.WriteLine("------客户按下机箱的开机按钮启动系统------");

            /*1-把命令和真正的实现组合起来，相当于组装机器*/
            IMainBoard mainBoard = new GigaMainBoard();
            OpenCommand openCommand = new OpenCommand(mainBoard);

            /*2-为机箱上的开机按钮设置对应的命令，让按钮知道该做什么*/
            Box box = new Box();
            box.SetOpenCommand(openCommand);

            /*3-模拟用户按下机箱上的按钮*/
            box.OpenButtonPressed();

        }

        /// <summary>
        /// 测试客户按下机箱的参数化配置按钮启动系统
        /// </summary>
        private static void ParameterButtonPressedTest()
        {
            Console.WriteLine("------测试客户按下机箱的参数化配置按钮启动系统------");

            /*1-把命令和真正的实现组合起来，相当于组装机器*/
            IMainBoard mainBoard = new GigaMainBoard();
            OpenCommand openCommand = new OpenCommand(mainBoard);
            RebootCommand rebootCommand = new RebootCommand(mainBoard);

            /*2-为机箱上的开机按钮设置对应的命令，让按钮知道该做什么*/
            Box box = new Box();
            //这里先正确配置开机按钮对应开机命令，重启按钮对应重启命令
            box.SetOpenCommand(openCommand);
            box.SetRebootCommand(rebootCommand);

            /*3-模拟用户按下机箱上的按钮*/
            Console.WriteLine("------正确按钮命令配置------");
            Console.WriteLine(">>>按下开机按钮>>>");
            box.OpenButtonPressed();
            Console.WriteLine(">>>按下重启按钮>>>");
            box.RebootButtonPressed();

            Console.WriteLine("\n");
            //这里错误配置参数命令
            box.SetOpenCommand(rebootCommand);
            box.SetRebootCommand(openCommand);
            Console.WriteLine("------错误按钮命令配置------");
            Console.WriteLine(">>>按下开机按钮>>>");
            box.OpenButtonPressed();
            Console.WriteLine(">>>按下重启按钮>>>");
            box.RebootButtonPressed();


        }

        /// <summary>
        /// 测试加减法的撤销和恢复功能
        /// </summary>
        private static void UndoAndRedoOfAddSubTest()
        {
            Console.WriteLine("------测试加减法的撤销和恢复功能------");

            /*1-组装命令和接收者*/
            //创建接收者
            UndoOPC.IOperation operation = new UndoOPC.Opreation();
            //创建命令对象，并组装命令和接收者
            UndoOPC.AddCommand addCommand = new UndoOPC.AddCommand(operation,6);
            UndoOPC.SubCommand subCommand = new UndoOPC.SubCommand(operation, 2);

            /*2-把命令设置到持有者【计算器里面】*/
            UndoOPC.Calculator calculator = new UndoOPC.Calculator();
            calculator.SetAddCommand(addCommand);
            calculator.SetSubCommand(subCommand);

            /*3-模拟按下按钮*/
            calculator.AddPressed();
            Console.WriteLine($"一次加法运算后的结果是【{operation.GetResult()}】");
            calculator.SubPressed();
            Console.WriteLine($"一次减法运算后的结果是【{operation.GetResult()}】");

            /*4-测试撤销*/
            calculator.UndoPressed();
            Console.WriteLine($"撤销一次后的结果是【{operation.GetResult()}】");
            calculator.UndoPressed();
            Console.WriteLine($"再撤销一次后的结果是【{operation.GetResult()}】");

            /*4-测试恢复*/
            calculator.RedoPressed();
            Console.WriteLine($"恢复一次后的结果是【{operation.GetResult()}】");
            calculator.RedoPressed();
            Console.WriteLine($"再恢复一次后的结果是【{operation.GetResult()}】");


        }

        ///// <summary>
        ///// 测试客户点菜
        ///// </summary>
        //private static void CustomerOrderDishTest()
        //{
        //    //1-创建服务员
        //    Macros.Waiter waiter=new Macros.Waiter();

        //    //2-创命令对象【即需要点的菜品】
        //    Macros.ICommand carrotRribs = new Macros.CarrotRribsCommand();
        //    Macros.ICommand pekingDuck = new Macros.PekingDuckCommand();
        //    Macros.ICommand GarlicMeat = new Macros.GarlicMeatCommand();

        //    //3-点菜
        //    waiter.OrderDish(carrotRribs);
        //    waiter.OrderDish(pekingDuck);
        //    waiter.OrderDish(GarlicMeat);

        //    //4-点菜完毕
        //    waiter.OrderOver();

        //}


        /// <summary>
        /// 测试队列
        /// </summary>
        public static void TestQueue()
        {
            Console.WriteLine("测试队列");

            //1-先启动后台，让整个程序运行起来
            Macros.CookerManager.RunCookerManager();

            //2-为了简单，直接使用循环模拟桌号点菜过程
            for (int i = 0; i <3; i++)
            {
                //创建服务员
                Macros.Waiter waiter = new Macros.Waiter();

                //创建命令对象(即需要点的菜品)
                Macros.ICommand carrotRribs = new Macros.CarrotRribsCommand(i);
                Macros.ICommand pekingDuck = new Macros.PekingDuckCommand(i);

                //点菜（就是服务员把这些菜让服务员记录下来）
                waiter.OrderDish(carrotRribs);
                waiter.OrderDish(pekingDuck);

                //点菜完毕
                waiter.OrderOver();

            }

        }

        private static void ListQueue()
        {
            List<string> strings=new List<string>();
            for (int i = 0; i < 5; i++)
            {
                strings.Add(i.ToString());
                Console.WriteLine(i);
            }

            Console.WriteLine();

            int count = strings.Count;
            for (int i = 0; i < count; i++)
            {
                string str = strings.First();
                Console.WriteLine($"当前读取的值是【{str}】");
                string str2 = strings[0];
                Console.WriteLine($"当前需要移除的值是【{str2}】");
                strings.RemoveAt(0);
            }

        }

    }//Class_end
}
