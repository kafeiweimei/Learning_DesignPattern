using ObserverPattern.Pull;
using ObserverPattern.WaterCheck;

namespace ObserverPattern
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //NewsPaperObserverPullTest();

            //NewsPaperObserverPushTest();

            WaterWatcherTest();

            Console.ReadLine();
        }

        /// <summary>
        /// 测试报纸的观察者主动拉取模式
        /// </summary>
        private static void NewsPaperObserverPullTest()
        {
            Console.WriteLine("------测试报纸的观察者主动拉取模式------");
            //创建一个报纸类型
            NewsPaper newsPaper= new NewsPaper();

            //创建多个读者
            Reader reader1 = new Reader("张三");
            Reader reader2 = new Reader("李四");
            Reader reader3 = new Reader("王五");

            //读者订阅报纸
            newsPaper.Add(reader1);
            newsPaper.Add(reader2);
            newsPaper.Add(reader3);

            //报社出新报纸内容
            newsPaper.SetInfo("这是我们新出的报纸内容：读者自己主动拉取消息的观察者模式");

        }

        /// <summary>
        /// 测试报纸主动推送的观察者模式
        /// </summary>
        private static void NewsPaperObserverPushTest()
        {
            Console.WriteLine("------测试报纸主动推送的观察者模式------");
            //创建一个报纸类型
            Push.NewsPaper newsPaper = new Push.NewsPaper();

            //创建多个读者
            Push.Reader reader1 = new Push.Reader("张三");
            Push.Reader reader2 = new Push.Reader("李四");
            Push.Reader reader3 = new Push.Reader("王五");

            //读者订阅报纸
            newsPaper.Add(reader1);
            newsPaper.Add(reader2);
            newsPaper.Add(reader3);

            //报社出新报纸内容
            newsPaper.SetInfo("这是我们新出的报纸内容：报纸主动推送消息的观察者模式");

        }

        /// <summary>
        /// 水质检测测试
        /// </summary>
        private static void WaterWatcherTest()
        {
            Console.WriteLine("------水质检测测试------");
            //创建水质监测对象
            WaterQuality waterQuality = new WaterQuality();

            //创建观察者对象（水质监测的各个工作部门人员）
            WaterWatcher waterWatcher1 = new WaterWatcher("检测人员");
            WaterWatcher waterWatcher2 = new WaterWatcher("预警人员");
            WaterWatcher waterWatcher3 = new WaterWatcher("检测部门领导");

            //订阅水质监测事件
            waterQuality.Add(waterWatcher1);
            waterQuality.Add(waterWatcher2);
            waterQuality.Add(waterWatcher3);

            //使用仪器检测水质污染级别后，填写水质污染报告
            Console.WriteLine("\n---水质正常的时候---");
            waterQuality.SetPolluteLevel(0);
            Console.WriteLine("\n---水质轻度污染的时候---");
            waterQuality.SetPolluteLevel(1);
            Console.WriteLine("\n---水质中度污染的时候---");
            waterQuality.SetPolluteLevel(2);

        }

    }//Class_end
}
