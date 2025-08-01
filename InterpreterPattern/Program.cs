
namespace InterpreterPattern
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //TestReadAppXml();
            //TestInterpreterDemoOne();
            //TestInterpreterDemoOne2();
            //TestInterpreterDemoTwo();
            TestInterpreterDemoThree();

            Console.ReadLine();
        }

        /// <summary>
        /// 不使用模式示例
        /// </summary>
        private static void TestReadAppXml()
        {
            Console.WriteLine("------不使用模式示例------");
            string xmlFile = $"{AppContext.BaseDirectory}\\NoPattern\\XMLFile1.xml";
            NoPattern.ReadAppXml readAppXml = new NoPattern.ReadAppXml();
            readAppXml.Read(xmlFile,"root");
        }

        /// <summary>
        /// 测试解释器模式示例一
        /// </summary>
        private static void TestInterpreterDemoOne()
        {
            Console.WriteLine("------测试解释器模式示例一------");
            string xmlFile = $"{AppContext.BaseDirectory}\\InterpreterDemoOne\\XMLFile1.xml";
            //准备上下文
            InterpreterDemoOne.Context context = new InterpreterDemoOne.Context(xmlFile);

            /*想要获取上下文元素的值（也就是表达式的值"root/a/b/c"）*/
            //1-构建解释器的抽象语法树
            InterpreterDemoOne.ElementExpression root = new InterpreterDemoOne.ElementExpression("root");
            InterpreterDemoOne.ElementExpression aElement = new InterpreterDemoOne.ElementExpression("a");
            InterpreterDemoOne.ElementExpression bElement = new InterpreterDemoOne.ElementExpression("b");
            InterpreterDemoOne.ElementTerminalExpression cElement = new InterpreterDemoOne.ElementTerminalExpression("c");

            //2-组合抽象语法树
            root.AddElement(aElement);
            aElement.AddElement(bElement);
            bElement.AddElement(cElement);

            //3-调用解释器解析
            string[] ss = root.Interpret(context);
            Console.WriteLine($"最后这个结束元素c的值是【{ss[0]}】");
        }

        /// <summary>
        /// 测试解释器模式示例一2
        /// </summary>
        private static void TestInterpreterDemoOne2()
        {
            Console.WriteLine("------测试解释器模式示例一2------");
            string xmlFile = $"{AppContext.BaseDirectory}\\InterpreterDemoOne\\XMLFile1.xml";
            //准备上下文
            InterpreterDemoOne.Context context = new InterpreterDemoOne.Context(xmlFile);

            /*想要获取上下文元素的c值（也就是表达式的值"root/a/b/c,name"）*/
            //1-构建解释器的抽象语法树
           InterpreterDemoOne.ElementExpression root = new InterpreterDemoOne.ElementExpression("root");
           InterpreterDemoOne.ElementExpression aElement = new InterpreterDemoOne.ElementExpression("a");
           InterpreterDemoOne.ElementExpression bElement = new InterpreterDemoOne.ElementExpression("b");
           InterpreterDemoOne.ElementExpression cElement = new InterpreterDemoOne.ElementExpression("c");
           InterpreterDemoOne.PropertyTerminalExpression cProperty = new InterpreterDemoOne.PropertyTerminalExpression("name");

            //2-组合抽象语法树
            root.AddElement(aElement);
            aElement.AddElement(bElement);
            bElement.AddElement(cElement);
            cElement.AddElement(cProperty);

            //3-调用解释器解析
            string[] ss = root.Interpret(context);
            Console.WriteLine($"最后这个结束元素c的name属性值是【{ss[0]}】");

            //若要继续使用同一个上下文，连续解析则需要初始化上下文对象（如：要连续的再重新获取一次属性Name值
            //你可以重新组合对象重新解析，只要是在使用同一个上下文，就需要重新初始化上下文对象）
            context.ReInit();

            /*获取d元素的属性*/
            //1-清除c的属性终结符解释器和c元素
            cElement.RemoveElement(cProperty);
            bElement.RemoveElement(cElement);

            //2-获取d元素和属性作为终结符
            InterpreterDemoOne.ElementTerminalExpression cElementValue = new InterpreterDemoOne.ElementTerminalExpression("c");

            //3-组合对象
            bElement.AddElement(cElementValue);
            ss = root.Interpret(context);
            Console.WriteLine($"最后这个结束元素d的值是【{ss[0]}】");

        }

        /// <summary>
        /// 测试解释器模式示例二
        /// </summary>
        private static void TestInterpreterDemoTwo()
        {
            Console.WriteLine("------测试解释器模式示例二------");
            string xmlFile = $"{AppContext.BaseDirectory}\\InterpreterDemoTwo\\XMLFile1.xml";
            //准备上下文
            InterpreterDemoTwo.Context context = new InterpreterDemoTwo.Context(xmlFile);

            /*想要获取多个d元素的值（如“root/a/b/d$”）*/
            //首先需要构建解释器的抽象语法树
           InterpreterDemoTwo.ElementExpression root= new InterpreterDemoTwo.ElementExpression("root");
           InterpreterDemoTwo.ElementExpression aElement= new InterpreterDemoTwo.ElementExpression("a");
           InterpreterDemoTwo.ElementExpression bElement=new InterpreterDemoTwo.ElementExpression("b");
           InterpreterDemoTwo.MutiElementTerminalExpression dElement=new InterpreterDemoTwo.MutiElementTerminalExpression("d");

            //组合语法树
            root.AddElement(aElement);
            aElement.AddElement(bElement);
            bElement.AddElement(dElement);

            //调用解析
            string[] ss=root.Interpret(context);
            foreach (var item in ss)
            {
                Console.WriteLine($"d的值是【{item}】");
            }

            context.ReInit();
            bElement.RemoveElement(dElement);
            InterpreterDemoTwo.MutiElementExpression dElement2 = new InterpreterDemoTwo.MutiElementExpression("d");
            InterpreterDemoTwo.MutiPropertyTerminalExpression dProperty = new InterpreterDemoTwo.MutiPropertyTerminalExpression("id");
            bElement.AddElement(dElement2);
            dElement2.AddElement(dProperty);

            string[] ss2= root.Interpret(context);
            foreach (var item in ss2)
            {
                Console.WriteLine($"d的属性值是【{item}】");
            }


        }


        /// <summary>
        /// 测试解释器模式示例三
        /// </summary>
        private static void TestInterpreterDemoThree()
        {
            Console.WriteLine("------测试解释器模式示例三------");
            string xmlFile = $"{AppContext.BaseDirectory}\\InterpreterDemoThree\\XMLFile1.xml";
            InterpreterDemoThree.Context context = new InterpreterDemoThree.Context(xmlFile);

            //通过解析器来获取抽象语法树
            //root/a/b/c.name
            InterpreterDemoThree.ReadXmlExpression readXmlExpression = InterpreterDemoThree.Parser.Parse("root/a/b/d$.id$");

            //请求解析，获取返回值
            string[] ss=readXmlExpression.Interpret(context);

            foreach (var item in ss)
            {
                Console.WriteLine($"d的属性id的值是【{item}】");
            }

            //如果要使用同一个上下文，连续解析，则需要重新初始化上下文对象
            context.ReInit();
            //请求解析，获取返回值
            //root/a/b/c
            InterpreterDemoThree.ReadXmlExpression readXmlExpression2 = InterpreterDemoThree.Parser.Parse("root/a/b/d$");
            string[] ss2= readXmlExpression2.Interpret(context);
            foreach (var item in ss2)
            {
                Console.WriteLine($"d的值是【{item}】");
            }


        }

    }//Class_end
}
