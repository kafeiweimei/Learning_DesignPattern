
using System.Numerics;

namespace CompositePattern
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //CompositeTest();
            //CompositeDemoTest();
            //RecursiveTestDemo();

            //ComponentRefDemoTest();

            LoopRefrenceTest();

            Console.ReadLine();
        }

        /// <summary>
        /// 测试组合
        /// </summary>
        private static void CompositeTest()
        {
            Console.WriteLine("---测试组合---");
            //定义所有的组合对象
            Composite root = new Composite("服装");
            Composite c1 = new Composite("男装");
            Composite c2 = new Composite("女装");

            //定义所有叶子对象
            Leaf leaf1 = new Leaf("衬衣");
            Leaf leaf2 = new Leaf("夹克");
            Leaf leaf3 = new Leaf("裙子");
            Leaf leaf4 = new Leaf("卫衣");
            Leaf leaf5 = new Leaf("牛仔裤");

            //按照树结构来组合对象和叶子对象
            root.AddComposite(c1);
            root.AddComposite(c2);
            c1.AddLeaf(leaf1);
            c1.AddLeaf(leaf2);
            c1.AddLeaf(leaf3);
            c2.AddLeaf(leaf4);
            c2.AddLeaf(leaf5);

            //调用根对象输出结构
            root.PrintStruct("");
        }

        /// <summary>
        /// 测试组合示例
        /// </summary>
        private static void CompositeDemoTest()
        {
            CompositeDemo.Component root = new CompositeDemo.Composite("服装");
            CompositeDemo.Component c1 = new CompositeDemo.Composite("男装");
            CompositeDemo.Component c2 = new CompositeDemo.Composite("女装");

            CompositeDemo.Leaf leaf1 = new CompositeDemo.Leaf("衬衣");
            CompositeDemo.Leaf leaf2 = new CompositeDemo.Leaf("夹克");
            CompositeDemo.Leaf leaf3 = new CompositeDemo.Leaf("裙子");
            CompositeDemo.Leaf leaf4 = new CompositeDemo.Leaf("卫衣");
            CompositeDemo.Leaf leaf5 = new CompositeDemo.Leaf("牛仔裤");

            root.Add(c1);
            root.Add(c2);
            c1.Add(leaf1);
            c1.Add(leaf2);
            c1.Add(leaf3);
            c2.Add(leaf4);
            c2.Add(leaf5);

            root.PrintStruct("");

        }

        /// <summary>
        /// 阶乘测试
        /// </summary>
        private static void RecursiveTestDemo()
        {
            CompositeDemo.RecursiveTest recursiveTest= new CompositeDemo.RecursiveTest();
            int number = 100;
            BigInteger res = recursiveTest.Recursive(number);
            Console.WriteLine($"【{number}】的阶乘是【{res}】");
        }

        /// <summary>
        /// 组件引用测试
        /// </summary>
        private static void ComponentRefDemoTest()
        {
            //定义所有的组合对象
            ComponentDemo.Component root = new ComponentDemo.Composite("服装");
            ComponentDemo.Component c1 = new ComponentDemo.Composite("男装");
            ComponentDemo.Component c2 = new ComponentDemo.Composite("女装");

            //定义所有的叶子对象
            ComponentDemo.Leaf leaf1 = new ComponentDemo.Leaf("衬衣");
            ComponentDemo.Leaf leaf2 = new ComponentDemo.Leaf("夹克");
            ComponentDemo.Leaf leaf3 = new ComponentDemo.Leaf("裙子");
            ComponentDemo.Leaf leaf4 = new ComponentDemo.Leaf("卫衣");
            ComponentDemo.Leaf leaf5 = new ComponentDemo.Leaf("牛仔裤");

            //按照树结构组合对象的叶子对象
            root.Add(c1);
            root.Add(c2);
            c1.Add(leaf1);
            c1.Add(leaf2);
            c1.Add(leaf3);
            c2.Add(leaf4);
            c2.Add(leaf5);

            //输出整棵树
            root.PrintStruct("");
            Console.WriteLine("----------------");

            //删除一个节点
            root.Remove(c1);

            root.PrintStruct("");
        }

        /// <summary>
        /// 循环引用测试
        /// </summary>
        private static void LoopRefrenceTest()
        {
            //定义所有组合对象
            LoopRefrence.Component root = new LoopRefrence.Composite("服装");
            LoopRefrence.Component c1 = new LoopRefrence.Composite("男装");
            LoopRefrence.Component c2 = new LoopRefrence.Composite("女装");
            LoopRefrence.Component c3 = new LoopRefrence.Composite("男装");

            //设置一个环状引用
            root.Add(c1);
            c1.Add(c2);
            c2.Add(c3);

            root.PrintStruct("");

        }

    }//Class_end
}
