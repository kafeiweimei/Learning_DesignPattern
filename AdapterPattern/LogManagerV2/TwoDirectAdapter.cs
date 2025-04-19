using AdapterPattern.LogManagerV1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdapterPattern.LogManagerV2
{
    /// <summary>
    /// 双向适配器（同时继承第一版、第二版日志操作接口并实现）
    /// </summary>
    internal class TwoDirectAdapter : ILogFileOpereate, ILogDBOperate
    {
        //持有需要被适配文件存储日志的接口对象
        private ILogFileOpereate logFileOpereate;
        //持有需要被适配数据库存储日志的接口对象
        private ILogDBOperate logDBOperate;

        /// <summary>
        /// 构造方法（传入需要被适配的对象）
        /// </summary>
        /// <param name="logFileOpereate">文件存储日志接口对象</param>
        /// <param name="logDBOperate">数据库存储日志接口对象</param>
        public TwoDirectAdapter(ILogFileOpereate logFileOpereate,ILogDBOperate logDBOperate)
        {
            this.logFileOpereate = logFileOpereate;
            this.logDBOperate = logDBOperate;   
        }

        /*增删改查方法是用文件操作日志适配数据库操作日志实现方式的接口方法*/
        public bool CreateLog(LogModel logModel)
        {
            List<LogModel> logModels = new List<LogModel>();
            logModels.Add(logModel);
            logFileOpereate.WriteLogFile(logModels);
            return true;
        }

        public bool DeleteLog(LogModel logModel)
        {
            //1、读取日志文件内容
            List<LogModel> logModels = logFileOpereate.ReadLogFile();
            //2、移除对应的日志对象
            logModels.Remove(logModel);
            //重新写入日志文件
            logFileOpereate.WriteLogFile(logModels);

            return true;
        }

        public List<LogModel> QueryAllLog()
        {
            return logFileOpereate.ReadLogFile();
        }

        public bool UpdateLog(LogModel logModel)
        {
            //1、先读取文件内容
            List<LogModel> logModels = logFileOpereate.ReadLogFile();
            //2、修改相应地日志对象
            int count = logModels.Count;
            for (int i = 0; i < count; i++)
            {
                if (logModels[i].LogId.Equals(logModel.LogId))
                {
                    logModels[i] = logModel;
                    break;
                }
            }
            //3、重新写入文件
            logFileOpereate.WriteLogFile(logModels);

            return true;
        }

        /*如下两个方法是使用数据库操作日志的方式适配文件操作日志的接口方法*/
        public List<LogModel> ReadLogFile()
        {
            return logDBOperate.QueryAllLog();
        }

        public void WriteLogFile(List<LogModel> list)
        {
            foreach (LogModel logModel in list)
            {
                logDBOperate.CreateLog(logModel);
            }
        }

    }//Class_end
}
