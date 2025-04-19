using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdapterPattern.LogManagerV1
{
    /// <summary>
    /// 继承接口并实现接口内容（对日志文件的操作）
    /// </summary>
    internal class LogFileOperate : ILogFileOpereate
    {
        private readonly static string _BaseDir=AppDomain.CurrentDomain.BaseDirectory;
        private string _logFilePathAndName=Path.Combine(_BaseDir,@"LogFile\AdapterLog.log");

        public LogFileOperate()
        {

        }

        public LogFileOperate(string logFilePathAndName)
        {
            //先判断是否传入了新的日志文件路径和名称，若有则替换否则使用默认路径
            if (!string.IsNullOrEmpty(logFilePathAndName))
            {
                this._logFilePathAndName = logFilePathAndName;
            }
        }

        public string LogFilePathAndName 
        { 
            get
            {
                string? logPath = Path.GetDirectoryName(_logFilePathAndName);
                if (!Directory.Exists(logPath))
                {
                    Directory.CreateDirectory(logPath);
                }

                if (!File.Exists(_logFilePathAndName))
                {
                    File.Create(_logFilePathAndName).Close();
                }
                return _logFilePathAndName;
            }
        }

        public List<LogModel> ReadLogFile()
        {
            List<LogModel> logModels=new List<LogModel>();

            using (FileStream fs=new FileStream(LogFilePathAndName,FileMode.Open))
            {
                using (StreamReader sr = new StreamReader(fs))
                {
                    string strLine = sr.ReadLine();
                    while (!string.IsNullOrEmpty(strLine))
                    {
                        string[] strLineArray=strLine.Split(',');
                        LogModel logModel = new LogModel();
                        logModel.LogId = strLineArray[0];
                        logModel.OperateUser = strLineArray[1];
                        logModel.OperateTime = strLineArray[2];
                        logModel.LogContent = strLineArray[3];
                        logModels.Add(logModel);

                        strLine= sr.ReadLine();
                    }
                }
            }

            return logModels;
        }

        public void WriteLogFile(List<LogModel> list)
        {
            using (FileStream fs=new FileStream(LogFilePathAndName,FileMode.Append,FileAccess.Write,FileShare.Write))
            {
                using (StreamWriter sw=new StreamWriter(fs))
                {
                    foreach (LogModel logModel in list) 
                    { 
                        sw.WriteLine(logModel.toStringWrite());
                    }
                }
            }
        }

    }//Class_end
}
