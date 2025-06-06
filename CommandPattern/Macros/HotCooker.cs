using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandPattern.Macros
{
    /// <summary>
    /// 做热菜的厨师对象
    /// </summary>
    internal class HotCooker : ICooker
    {
        //厨师姓名
        private string cookerName;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="name">厨师姓名</param>
        public HotCooker(string cookerName)
        {
            this.cookerName = cookerName;
        }

        public void Cook(string name,int tableNum)
        {
            //每次做菜的时间都是不一定的，用随机数来模拟
            Random random = new Random(Guid.NewGuid().GetHashCode());

            int cookTime = random.Next(5,20);

            Console.WriteLine($"热菜厨师【{this.cookerName}】正在给【{tableNum}】桌做【{name}】");
            try
            {
                //让线程休息一下，表示正在做菜
                Thread.Sleep(cookTime);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                Console.WriteLine($"热菜厨师【{cookerName}】为【{tableNum}】桌做好了【{name}】,共花费【{cookTime}】分钟");
            }
        }

        public void Run()
        {
            //new Thread(new ThreadStart(()=>
            //{
            //    while (true)
            //    {
            //        Thread.Sleep(1000);

            //        //从命令队列里面获取命令对象
            //        ICommand command = CommondQueue.GetOneCommand();
            //        if (command!=null)
            //        {
            //            //说明去到命令对象了，这个命令对象还没有设置接收者（因为前面还不知道
            //            //到底哪一个厨师来真正执行这个命令;现在知道了，就是当前的厨师实例，设置命令到命令对象中）
            //            command.SetCooker(this);
            //            command.Execute();
            //        }
            //    }
            //})).Start();

            Task task = new Task(() =>
            {
                while (true)
                {
                    Thread.Sleep(1000);

                    //从命令队列里面获取命令对象
                    ICommand command = CommondQueue.GetOneCommand();
                    if (command != null)
                    {
                        //说明去到命令对象了，这个命令对象还没有设置接收者（因为前面还不知道
                        //到底哪一个厨师来真正执行这个命令;现在知道了，就是当前的厨师实例，设置命令到命令对象中）
                        command.SetCooker(this);
                        command.Execute();
                    }
                }
            });

            task.Start();
            
        }

    }//Class_end
}
