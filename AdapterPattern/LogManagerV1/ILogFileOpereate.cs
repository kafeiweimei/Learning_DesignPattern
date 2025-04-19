using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdapterPattern.LogManagerV1
{
    /// <summary>
    /// 日志文件操作接口
    /// </summary>
    internal interface ILogFileOpereate
    {
        /// <summary>
        /// 读取日志文件，从文件里面获取存储的日志列表内容
        /// </summary>
        /// <returns>返回读取的日志内容列表</returns>
        List<LogModel> ReadLogFile();

        /// <summary>
        /// 写日志文件，把日志列表内容写到日志文件中
        /// </summary>
        /// <param name="list">需写入的日志内容列表</param>
        void WriteLogFile(List<LogModel>list);

    }//Interface_end
}
