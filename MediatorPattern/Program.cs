using MediatorPattern.CommonMediator;

namespace MediatorPattern
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //MainBoardMediatorTest();

            DepmentUserMediatorTest();

            Console.ReadLine();
        }

        /// <summary>
        /// 主板中介者测试
        /// </summary>
        private static void MainBoardMediatorTest()
        {
            Console.WriteLine("---主板中介者测试---");

            //1、创建中介者——主板对象
            MainBoard mainBoard= new MainBoard();
            //2、创建同事类
            CdDriver cdDriver = new CdDriver(mainBoard);
            Cpu cpu = new Cpu(mainBoard);
            VideoCard videoCard=new VideoCard(mainBoard);
            SoundCard soundCard=new SoundCard(mainBoard);

            //3、让中介者知道所有同事
            mainBoard.SetCDDriver(cdDriver);
            mainBoard.SetCpu(cpu);
            mainBoard.SetVideoCard(videoCard);
            mainBoard.SetSoundCard(soundCard);

            //4、开始将光盘放入光驱中，光驱读取光盘就可以看电影了
            cdDriver.ReadCD();

        }

        /// <summary>
        /// 部门与人员中介者测试
        /// </summary>
        private static void DepmentUserMediatorTest()
        {
            DepmentUserMediator depmentUserMediator = DepmentUserMediator.GetInstance();

            /*测试撤销部门*/
            //1、准备要撤销的部门【D01,D02】
            Depment depment1 = new Depment();
            depment1.DepmentId = "D01";
            depment1.DepmentName = "技术研发部门";

            Console.WriteLine("\n---撤销部门前的情况---");
            depmentUserMediator.ShowDepmentsUsers();

            //2、删除部门
            depment1.DeleteDepment();
            Console.WriteLine("---撤销部门后的情况---");
            depmentUserMediator.ShowDepmentsUsers();



            /*测试人员离职*/
            Console.WriteLine("\n\n---人员离职前的情况---");
            depmentUserMediator.ShowDepmentsUsers();

            //1、准备离职人员
            User user = new User();
            user.UserId = "U01";
            user.UserName = "张三";
           
            //depmentUserMediator.ShowUserDepments(user);
            //人员离职
            user.Resign();
            Console.WriteLine("---人员离职后的情况---");
            depmentUserMediator.ShowDepmentsUsers();


        }

    }//Class_end
}
