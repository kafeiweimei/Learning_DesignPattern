
using StatePattern.StateDemoThree;

namespace StatePattern
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //VoteManagerTest();
            //VoteManagerByStatePattern();
            //VoteManagerTwoByStatePattern();
            LeaveRequestTest();

            Console.ReadLine();
        }

        /// <summary>
        /// 投票管理测试
        /// </summary>
        private static void VoteManagerTest()
        {
            Console.WriteLine("---投票管理测试---");
            VoteManager voteManager = new VoteManager();
            for (int i = 0; i < 10; i++)
            {
                voteManager.Vote("张三","A");
            }
        }

        /// <summary>
        /// 使用状态模式进行投票管理测试
        /// </summary>
        private static void VoteManagerByStatePattern()
        {
            Console.WriteLine("---使用状态模式进行投票管理测试---");
            StateDemoOne.VoteManager voteManager = new StateDemoOne.VoteManager();
            for (int i = 0; i < 10; i++)
            {
                voteManager.Vote("张三", "A");
            }
        }

        /// <summary>
        /// 使用状态模式进行投票管理测试2
        /// </summary>
        private static void VoteManagerTwoByStatePattern()
        {
            Console.WriteLine("---使用状态模式进行投票管理测试2---");
            StateDemoTwo.VoteManager voteManager = new StateDemoTwo.VoteManager();
            for (int i = 0; i < 10; i++)
            {
                voteManager.Vote("张三", "A");
            }
        }

        /// <summary>
        /// 请假流程审批
        /// </summary>
        private static void LeaveRequestTest()
        {
            //创建业务对象并设置业务数据
            StateDemoThree.LeaveRequestModel requestModel = new StateDemoThree.LeaveRequestModel();
            requestModel.User = "张三";
            requestModel.BeginDate = DateTime.Now.ToString("F");
            requestModel.LeaveDays = 5;

            //创建上下文对象
            StateDemoThree.LeaveRequestContext requestContext= new StateDemoThree.LeaveRequestContext();
            //为上下文设置业务对象模型
            requestContext.BusinessModel = requestModel;
            //配置上下文状态
            requestContext.State = new ProjectManagerState2();
            //开始运行
            requestContext.Dowork();

        }

    }//Class_end 
}
