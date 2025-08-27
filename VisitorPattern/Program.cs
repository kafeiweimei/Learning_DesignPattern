
namespace VisitorPattern
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //NoPatternTest();
            //VisitorDemoOneTest();
            //VisitorDemoTwoTest();
            VisitorDemoTwoTest2();
            Console.ReadLine();
        }


        /// <summary>
        /// 不使用模式的测试
        /// </summary>
        private static void NoPatternTest()
        {
            Console.WriteLine("------不使用模式的测试------");
            //准备测试数据
            List<NoPattern.CustomerExtand>customerList= PreparedTestDatas();

            foreach (var item in customerList)
            {
                //进行偏好分析
                item.PredilectionAnalyze();
                //进行价值分析
                item.WorthAnalyze();
                Console.WriteLine();
            }
        }

        //准备测试数据
        private static List<NoPattern.CustomerExtand> PreparedTestDatas()
        {
            List<NoPattern.CustomerExtand> customerList=new List<NoPattern.CustomerExtand>(); ;

            //为了测试方便准备的测试数据
            NoPattern.CustomerExtand ce1= new NoPattern.EnterpriseCustomerExtand();
            ce1.CustomerName = "XXX集团";
            customerList.Add(ce1);

            NoPattern.CustomerExtand ce2= new NoPattern.EnterpriseCustomerExtand();
            ce2.CustomerName = "XXX公司";
            customerList.Add(ce2);

            NoPattern.CustomerExtand ce3= new NoPattern.EnterpriseCustomerExtand();
            ce3.CustomerName = "张三";
            customerList.Add(ce3);
            
            return customerList;
        }

        /// <summary>
        /// 访问者模式示例一测试
        /// </summary>
        private static void VisitorDemoOneTest()
        {
            Console.WriteLine("------访问者模式示例一测试------");
            //创建结构对象
            VisitorDemoOne.ObjectStructure oe=new VisitorDemoOne.ObjectStructure();
            //准备测试数据
            VisitorDemoOne.Customer cr1=new VisitorDemoOne.EnterpriseCustomer();
            cr1.CustomerName = "XXX集团";
            oe.AddElement(cr1);   
            
            VisitorDemoOne.Customer cr2=new VisitorDemoOne.EnterpriseCustomer();
            cr2.CustomerName = "XXX公司";
            oe.AddElement(cr2);

            VisitorDemoOne.Customer cr3 = new VisitorDemoOne.PersonalCustomer();
            cr3.CustomerName = "张三";
            oe.AddElement(cr3);

            //客户提出服务请求，传入服务请求的Visitor
            VisitorDemoOne.IVisitor visitor = new VisitorDemoOne.ServiceRequestVisitor();
            oe.HandleRequest(visitor);
            Console.WriteLine();
            
            //要对客户进行偏好分析，传入偏好分析的Visitor
            visitor = new VisitorDemoOne.PredilectionAnalyzeVisitor();
            oe.HandleRequest(visitor);
            Console.WriteLine();

            //新增对客户的价值分析，传入价值分析的Visitor
            visitor = new VisitorDemoOne.WorthAnalyzeVisitor();
            oe.HandleRequest(visitor);
        }

        /// <summary>
        /// 访问者模式示例二测试
        /// </summary>
        private static void VisitorDemoTwoTest()
        {
            Console.WriteLine("------访问者模式示例二测试------");

            //定义所有的组合对象
            VisitorDemoTwo.Component root=new VisitorDemoTwo.Composite("服装");
            VisitorDemoTwo.Component c1 = new VisitorDemoTwo.Composite("男装");
            VisitorDemoTwo.Component c2 = new VisitorDemoTwo.Composite("女装");

            //定义所有的叶子对象
            VisitorDemoTwo.Component l1 = new VisitorDemoTwo.Leaf("衬衣");
            VisitorDemoTwo.Component l2 = new VisitorDemoTwo.Leaf("夹克");
            VisitorDemoTwo.Component l3 = new VisitorDemoTwo.Leaf("裙子");
            VisitorDemoTwo.Component l4 = new VisitorDemoTwo.Leaf("套装");

            //按照树的结构组合对象和叶子对象
            root.AddChild(c1); 
            root.AddChild(c2);

            c1.AddChild(l1);
            c1.AddChild(l2);

            c2.AddChild(l3);
            c2.AddChild(l4);

            //创建ObjectStructure
            VisitorDemoTwo.ObjectStructure oe=new VisitorDemoTwo.ObjectStructure();
            oe.SetRoot(root);

            //调用ObjectStructure来处理请求功能
            VisitorDemoTwo.IVisitor visitor=new VisitorDemoTwo.PrintNameVisitor();
            oe.HandleRequest(visitor);
            Console.WriteLine();

        }

        /// <summary>
        /// 访问者模式示例二测试2
        /// </summary>
        private static void VisitorDemoTwoTest2()
        {
            Console.WriteLine("------访问者模式示例二测试------");

            //定义所有的组合对象
            VisitorDemoTwo.Component root = new VisitorDemoTwo.CompositeExtand("服装");
            VisitorDemoTwo.Component c1 = new VisitorDemoTwo.CompositeExtand("男装");
            VisitorDemoTwo.Component c2 = new VisitorDemoTwo.CompositeExtand("女装");

            //定义所有的叶子对象
            VisitorDemoTwo.Component l1 = new VisitorDemoTwo.Leaf("衬衣");
            VisitorDemoTwo.Component l2 = new VisitorDemoTwo.Leaf("夹克");
            VisitorDemoTwo.Component l3 = new VisitorDemoTwo.Leaf("裙子");
            VisitorDemoTwo.Component l4 = new VisitorDemoTwo.Leaf("套装");

            //按照树的结构组合对象和叶子对象
            root.AddChild(c1);
            root.AddChild(c2);

            c1.AddChild(l1);
            c1.AddChild(l2);

            c2.AddChild(l3);
            c2.AddChild(l4);

            VisitorDemoTwo.PrintStructVisitor visitor = new VisitorDemoTwo.PrintStructVisitor();
            root.Accept(visitor);

        }

    }//Class_end
}
