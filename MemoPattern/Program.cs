namespace MemoPattern
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //TestFlowAMock();
            //TestMemoDemoOne();
            TestMemoDemoTwo();

            Console.ReadLine();
        }

        /// <summary>
        /// 测试模拟运行流程
        /// </summary>
        private static void TestFlowAMock()
        {
            Console.WriteLine("------测试模拟运行流程------");
            NoPattern.FlowAMock flowAMock = new NoPattern.FlowAMock("TestFlow");

            //运行流程的第一阶段
            flowAMock.RunPhaseOne();
            //获取到运行流程第一阶段后产生的数据，提供给后续使用【可确保后续流程的方案一、方案二使用的基础数据是一样的】
            int tempResult = flowAMock.TempResult;
            string tempState=flowAMock.TempState;

            //按照方案一运行流程后半部分
            flowAMock.SchemaOne();
            //运行完成方案一后将数据重设回去
            flowAMock.TempResult = tempResult;
            flowAMock.TempState = tempState;

            //按照方案二运行流程后半部分
            flowAMock.SchemaTwo();
        }

        /// <summary>
        /// 测试备忘录示例一
        /// </summary>
        private static void TestMemoDemoOne()
        {
            Console.WriteLine("------测试备忘录示例一------");
            //创建模拟运行的流程对象
            MemoDemoOne.FlowAMock flowAMock = new MemoDemoOne.FlowAMock("TestFlow");

            //运行流程的第一个阶段
            flowAMock.RunPhaseOne();

            /*创建需运行对象的管理者维护该对象的数据某个时段的状态*/
            //创建一个流程的管理者
            MemoDemoOne.FlowAMemoManager flowAMemoManager = new MemoDemoOne.FlowAMemoManager();
            //创建【此模拟运行流程对象】的备忘录对象（并保存到管理者对象里面提供给后续使用）
            MemoDemoOne.IFlowAMockMemo flowAMockMemo = flowAMock.CreateMemo();
            flowAMemoManager.SaveMemo(flowAMockMemo);


            //按照方案一运行流程的后半部分
            flowAMock.SchemaOne();

            //从备忘录管理者那里获取备忘录对象，并设置回去（即：实现模拟运行流程对象自己恢复到内部状态）
            flowAMock.SetMemo(flowAMemoManager.RetriveMemo());

            //按照方案二运行流程的后半部分
            flowAMock.SchemaTwo();

        }

        /// <summary>
        /// 测试备忘录示例二
        /// </summary>
        private static void TestMemoDemoTwo()
        {
            Console.WriteLine("------测试备忘录示例二------");

            /*1-组装命令和接收者*/
            //创建操作对象【作为命令的接收者】
            MemoDemoTwo.IOperation operation = new MemoDemoTwo.Operation();

            //创建加法命令
            MemoDemoTwo.AddCommand addCmd = new MemoDemoTwo.AddCommand(5);
            //创建减法命令
            MemoDemoTwo.SubstractCommand subCmd=new MemoDemoTwo.SubstractCommand(3);

            //组装命令和接收者
            addCmd.SetOperation(operation);
            subCmd.SetOperation(operation);

            /*2-把命令设置到持有者【计算器中】*/
            MemoDemoTwo.Calculator calculator=new MemoDemoTwo.Calculator();
            calculator.SetAddCmd(addCmd);
            calculator.SetSubCmd(subCmd);

            /*3-模拟按下指定按钮*/
            calculator.AddPressed();
            Console.WriteLine($"执行【加法】一次运算后的结果是【{operation.GetResult()}】");
            calculator.SubPressed();
            Console.WriteLine($"执行【减法】一次运算后的结果是【{operation.GetResult()}】");
            
            /*4-测试撤销*/
            for ( int i = 1; i <=3 ; i++ )
            {
                calculator.UndoPressed();
                Console.WriteLine($"执行【撤销】【{i}】次后的结果是【{operation.GetResult()}】");
            }

            /*5-测试恢复*/
            for ( int i = 1;i <=3 ; i++ )
            {
                calculator.RedoPressed();
                Console.WriteLine($"执行【恢复】【{i}】次后的结果是【{operation.GetResult()}】");
            }
        }

    }//Class_end
}
