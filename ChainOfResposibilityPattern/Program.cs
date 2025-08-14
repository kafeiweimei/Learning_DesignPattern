namespace ChainOfResposibilityPattern
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //NoPatternTest();
            //ChainOfResposibilityDemoOneTest();
            //ChainOfResposibilityDemoTwoTest();
            //ChainOfResposibilityDemoThreeTest();
            //ChainOfResposibilityDemoThreeExtandTest();
            ChainOfResposibilityDemoFourTest();

            Console.ReadLine();
        }

        /// <summary>
        /// 不用模式测试
        /// </summary>
        private static void NoPatternTest()
        {
            Console.WriteLine("---不用模式测试---");

            NoPattern.FeeRequest feeRequest = new NoPattern.FeeRequest();

            string res1 = feeRequest.RequestToProjectManager("张三",300);
            Console.WriteLine(res1);
            string res2 = feeRequest.RequestToProjectManager("李四",300);
            Console.WriteLine(res2);
            Console.WriteLine();

            string res3 = feeRequest.RequestToProjectManager("张三", 900);
            Console.WriteLine(res3);
            string res4 = feeRequest.RequestToProjectManager("李四", 900);
            Console.WriteLine(res4);
            Console.WriteLine();

            string res5 = feeRequest.RequestToProjectManager("张三", 1005);
            Console.WriteLine(res5);
            string res6 = feeRequest.RequestToProjectManager("李四", 1005);
            Console.WriteLine(res6);
            Console.WriteLine();
        }

        /// <summary>
        /// 责任链示例1测试
        /// </summary>
        private static void ChainOfResposibilityDemoOneTest()
        {
            Console.WriteLine("------责任链示例1测试------");
            //组装职责链
            ChainOfResposibilityDemoOne.Handler handler1 = new ChainOfResposibilityDemoOne.ProjectManager();
            ChainOfResposibilityDemoOne.Handler handler2 = new ChainOfResposibilityDemoOne.DepmentManager();
            ChainOfResposibilityDemoOne.Handler handler3 = new ChainOfResposibilityDemoOne.GeneralManager();

            //指定项目经理的下一个对象是部门经理
            handler1.Successor = handler2;
            //指定部门经理的下一个对象是总经理
            handler2.Successor = handler3;

            //测试
            string res1 = handler1.HandleRequest("张三",300);
            Console.WriteLine(res1);
            string res2 = handler1.HandleRequest("李四",300);
            Console.WriteLine(res2);
            Console.WriteLine();

            string res3 = handler1.HandleRequest("张三", 900);
            Console.WriteLine(res3);
            string res4 = handler1.HandleRequest("李四", 900);
            Console.WriteLine(res4);
            Console.WriteLine();

            string res5 = handler1.HandleRequest("张三", 1005);
            Console.WriteLine(res5);
            string res6 = handler1.HandleRequest("李四", 1005);
            Console.WriteLine(res6);
            Console.WriteLine();

        }

        /// <summary>
        /// 责任链示例2测试
        /// </summary>
        private static void ChainOfResposibilityDemoTwoTest()
        {
            Console.WriteLine("------责任链示例2测试------");

            //先组装责任链
            ChainOfResposibilityDemoTwo.Handler handler1 = new ChainOfResposibilityDemoTwo.ProjectManager();
            ChainOfResposibilityDemoTwo.Handler handler2 = new ChainOfResposibilityDemoTwo.DepmentManager();
            ChainOfResposibilityDemoTwo.Handler handler3 = new ChainOfResposibilityDemoTwo.GeneralManager();
          
            //指定项目经理的下一个对象是部门经理
            handler1.Successor = handler2;
            //指定部门经理的下一个对象是总经理
            handler2.Successor = handler3;

            //开始测试申请费用
            string res1 = handler1.HandleFeeRequest("张三",300);
            Console.WriteLine(res1);
            string res2 = handler1.HandleFeeRequest("张三", 900);
            Console.WriteLine(res2);
            string res3 = handler1.HandleFeeRequest("张三", 1005);
            Console.WriteLine(res3);
            Console.WriteLine();


            //开始测试预支费用
            handler1.HandlePreFeeRequest("张三",4500);
            handler1.HandlePreFeeRequest("张三",9999);
            handler1.HandlePreFeeRequest("张三",16000);
        }

        /// <summary>
        /// 责任链示例3测试
        /// </summary>
        private static void ChainOfResposibilityDemoThreeTest()
        {
            Console.WriteLine("------责任链示例3测试------");

            //组装责任链
            ChainOfResposibilityDemoThree.Handler handler1 = new ChainOfResposibilityDemoThree.ProjectManager();
            ChainOfResposibilityDemoThree.Handler handler2 = new ChainOfResposibilityDemoThree.DepmentManager();
            ChainOfResposibilityDemoThree.Handler handler3 = new ChainOfResposibilityDemoThree.GeneralManager();
            
            //指定项目经理的下一个对象是部门经理
            handler1.Successor = handler2;
            //指定部门经理的下一个对象是总经理
            handler2.Successor= handler3;

            //开始测试费用申请
            ChainOfResposibilityDemoThree.FeeRequestModel feeRequestModel = new ChainOfResposibilityDemoThree.FeeRequestModel();
            feeRequestModel.User = "张三";
            feeRequestModel.Fee = 300;
            //调用处理请求
            string res1 = (string)handler1.HandleRequest(feeRequestModel);
            Console.WriteLine(res1);
            Console.WriteLine();

            //重设金额在调用处理
            feeRequestModel.Fee = 900;
            string res2=(string)handler1.HandleRequest(feeRequestModel);
            Console.WriteLine(res2);
            Console.WriteLine();

            //重设金额在调用处理
            feeRequestModel.Fee = 1005;
            string res3 = (string)handler1.HandleRequest(feeRequestModel);
            Console.WriteLine(res3);
            Console.WriteLine();

        }

        /// <summary>
        /// 责任链示例3拓展测试
        /// </summary>
        private static void ChainOfResposibilityDemoThreeExtandTest()
        {
            Console.WriteLine("------责任链示例3拓展测试------");

            //组装责任链
            ChainOfResposibilityDemoThree.Handler handler1 = new ChainOfResposibilityDemoThree.ProjectManagerExtand();
            ChainOfResposibilityDemoThree.Handler handler2 = new ChainOfResposibilityDemoThree.DepmentManagerExtand();
            ChainOfResposibilityDemoThree.Handler handler3 = new ChainOfResposibilityDemoThree.GeneralManagerExtand();

            //指定项目经理的下一个对象是部门经理
            handler1.Successor = handler2;
            //指定部门经理的下一个对象是总经理
            handler2.Successor = handler3;

            //开始测试费用申请
            ChainOfResposibilityDemoThree.FeeRequestModel feeRequestModel = new ChainOfResposibilityDemoThree.FeeRequestModel();
            feeRequestModel.User = "张三";
            feeRequestModel.Fee = 300;
            //调用处理请求
            string res1 = (string)handler1.HandleRequest(feeRequestModel);
            Console.WriteLine(res1);
            Console.WriteLine();

            //重设金额在调用处理
            feeRequestModel.Fee = 900;
            string res2 = (string)handler1.HandleRequest(feeRequestModel);
            Console.WriteLine(res2);
            Console.WriteLine();

            //重设金额在调用处理
            feeRequestModel.Fee = 1005;
            string res3 = (string)handler1.HandleRequest(feeRequestModel);
            Console.WriteLine(res3);
            Console.WriteLine();


            //开始测试预支费用
            ChainOfResposibilityDemoThree.PreFeeRequestModel preFeeRequestModel = new ChainOfResposibilityDemoThree.PreFeeRequestModel();
            preFeeRequestModel.User = "张三";
            preFeeRequestModel.Fee = 4500;
            //调用处理请求
            handler1.HandleRequest(preFeeRequestModel);

            //重新设置预支费用
            preFeeRequestModel.Fee = 9999;
            handler1.HandleRequest(preFeeRequestModel);

            //重新设置预支费用
            preFeeRequestModel.Fee = 10001;
            handler1.HandleRequest(preFeeRequestModel);
        }

        /// <summary>
        /// 责任链示例4测试
        /// </summary>
        private static void ChainOfResposibilityDemoFourTest()
        {
            Console.WriteLine("------责任链示例4测试------");
            //创建业务对象
            ChainOfResposibilityDemoFour.GoodsSaleHandle goodsSaleHandle = new ChainOfResposibilityDemoFour.GoodsSaleHandle();
            //准备测试数据
            ChainOfResposibilityDemoFour.SaleModel saleModel = new ChainOfResposibilityDemoFour.SaleModel();
            saleModel.GoodsName = "周杰伦-七里香";
            saleModel.SaleNumber = 16;

            //调用业务功能
            goodsSaleHandle.Sale("张三","周茜",saleModel);
            goodsSaleHandle.Sale("李四","李倩",saleModel);
        }

    }//Class_end
}
