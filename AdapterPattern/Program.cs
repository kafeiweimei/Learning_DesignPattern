using AdapterPattern.LogManagerV1;
using AdapterPattern.LogManagerV2;

namespace AdapterPattern
{
    internal class Program
    {
        //客户端：用来测试
        static void Main(string[] args)
        {
            TestLogOpc();

            TestLogAdapterOpc();

            TestTwoDirectAdapterOpc();


            Console.ReadLine();
        }

        /// <summary>
        /// 测试日志文件操作
        /// </summary>
        private static void TestLogOpc()
        {
            Console.WriteLine("-----测试日志文件操作------");
            //准备一个日志内容对象
            LogModel logModel=new LogModel();
            logModel.LogId = Guid.NewGuid().ToString();
            logModel.OperateUser = "test";
            logModel.OperateTime= DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            logModel.LogContent = $"这是一个测试内容{new Random(Guid.NewGuid().GetHashCode()).Next(0,99)}_写入文件";

            List<LogModel> logModels=new List<LogModel>();
            logModels.Add(logModel);

            //创建日志文件操作对象
            //string logFilePathAndName = @"H:\Log\Adapter.log";
            //ILogFileOpereate logFileOpereate = new LogFileOperate(logFilePathAndName);

            ILogFileOpereate logFileOpereate = new LogFileOperate();
            //写入日志文件内容到本地文件中
            logFileOpereate.WriteLogFile(logModels);

            //读取本地日志文件内容
            List<LogModel> readLogModels= new List<LogModel>();
            readLogModels = logFileOpereate.ReadLogFile();

            //将读取的日志文件内容展示到界面上
            foreach (var item in readLogModels)
            {
                string str = $"读取的日志文件内容为：{item.toStringShow()}";
                Console.WriteLine(str);
            }

        }

        /// <summary>
        /// 测试日志单向适配器操作
        /// </summary>
        private static void TestLogAdapterOpc()
        {
            Console.WriteLine("\n-----测试日志单向适配器操作------");
            //准备一个日志内容对象
            LogModel logModel = new LogModel();
            logModel.LogId = Guid.NewGuid().ToString();
            logModel.OperateUser = "adapter";
            logModel.OperateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            logModel.LogContent = $"这是一个测试内容{new Random(Guid.NewGuid().GetHashCode()).Next(0, 99)}_单向适配器";

            List<LogModel> logModels = new List<LogModel>();
            logModels.Add(logModel);

            //创建日志文件操作对象
            //string logFilePathAndName = @"H:\Log\Adapter.log";
            //ILogFileOpereate logFileOpereate = new LogFileOperate(logFilePathAndName);

            ILogFileOpereate logFileOpereate = new LogFileOperate();

            //创建新版操作日志的单向适配器接口对象
            ILogDBOperate logDBOperate = new LogFileAdapter(logFileOpereate);

            //写入日志文件内容到本地文件中
            logDBOperate.CreateLog(logModel);

            //读取本地日志文件内容
            List<LogModel> readLogModels = new List<LogModel>();
            readLogModels = logDBOperate.QueryAllLog();

            //将读取的日志文件内容展示到界面上
            foreach (var item in readLogModels)
            {
                string str = $"读取的日志文件内容为：{item.toStringShow()}";
                Console.WriteLine(str);
            }

        }

        /// <summary>
        /// 测试双向日志适配器操作
        /// </summary>
        private static void TestTwoDirectAdapterOpc()
        {
            Console.WriteLine("\n-----测试双向日志适配器操作------");
            //准备一个日志内容对象
            LogModel logModel = new LogModel();
            logModel.LogId = Guid.NewGuid().ToString();
            logModel.OperateUser = "TwoDirectAdapter";
            logModel.OperateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            logModel.LogContent = $"这是一个测试内容{new Random(Guid.NewGuid().GetHashCode()).Next(0, 99)}_双向适配器";

            List<LogModel> logModels = new List<LogModel>();
            logModels.Add(logModel);

            //创建日志文件操作对象
            //string logFilePathAndName = @"H:\Log\Adapter.log";
            //ILogFileOpereate logFileOpereate = new LogFileOperate(logFilePathAndName);

            ILogFileOpereate logFileOpereate = new LogFileOperate();
            //创建数据库日志操作对象
            ILogDBOperate logDBOperate = new LogDBOperate();

            //创建经过双向适配器后操作日志的对象
            ILogFileOpereate logFileOpereateTwoDirectAdapter = new TwoDirectAdapter(logFileOpereate,logDBOperate);
            ILogDBOperate logDBOperateTwoDirectAdapter= new TwoDirectAdapter(logFileOpereate, logDBOperate);

            /*测试从文件日志操作适配数据库日志*/
            Console.WriteLine("\n\n使用数据库日志接口方法保存日志到本地日志文件中");
            logDBOperateTwoDirectAdapter.CreateLog(logModel);
            List<LogModel> allLog= logDBOperateTwoDirectAdapter.QueryAllLog();
            foreach (var item in allLog)
            {
                Console.WriteLine($"使用数据库日志接口方法获取到本地日志文件的所有信息：{item.toStringShow()}");
            }


            /*测试*/
            Console.WriteLine("\n\n使用日志文件接口方法保存日志到数据库中");
            logFileOpereateTwoDirectAdapter.WriteLogFile(logModels);
            Console.WriteLine("\n使用日志文件接口方法读取到数据库所有日志");
            logFileOpereateTwoDirectAdapter.ReadLogFile();
        }

    }//Class_end
}
