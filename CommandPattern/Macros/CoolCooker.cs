using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandPattern.Macros
{
    /// <summary>
    /// 做凉菜的厨师
    /// </summary>
    internal class CoolCooker : ICooker
    {
        //厨师姓名
        private string cookerName;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="cookerName">厨师姓名</param>
        public CoolCooker(string cookerName)
        {
           this.cookerName = cookerName;
        }

        public void Cook(string name, int tableNum)
        {
            //每次做菜的时间都是不一定的，用随机数来模拟
            Random random = new Random(Guid.NewGuid().GetHashCode());

            int cookTime = random.Next(3,12);

            Console.WriteLine($"凉菜厨师【{this.cookerName}】正在给【{tableNum}】桌做【{name}】");
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
                Console.WriteLine($"凉菜厨师【{cookerName}】为【{tableNum}】桌做好了【{name}】,共花费【{cookTime}】分钟");
            }
        }

        public void Run()
        {
            new Thread(new ThreadStart(() =>
            {
                while (true)
                {
                    //从命令队列里面获取命令对象
                    ICommand command = CommondQueue.GetOneCommand();
                    if (command != null)
                    {
                        //说明去到命令对象了，这个命令对象还没有设置接收者（因为前面还不知道
                        //到底哪一个厨师来真正执行这个命令;现在知道了，就是当前的厨师实例，设置命令到命令对象中）
                        command.SetCooker(this);
                        command.Execute();
                    }
                    try
                    {
                        //休息1秒
                        Thread.Sleep(1000);
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }

                }
            })).Start();
        }

    }//Class_end
}
