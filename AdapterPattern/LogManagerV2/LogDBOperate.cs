using AdapterPattern.LogManagerV1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdapterPattern.LogManagerV2
{
    /// <summary>
    /// 数据库存储日志类（这里仅作示意就不真正实现与数据库的交互）
    /// </summary>
    internal class LogDBOperate : ILogDBOperate
    {
        public bool CreateLog(LogModel logModel)
        {
            Console.WriteLine($"记录日志到数据库：{logModel.toStringShow()}");
            //省略了连接数据库并保存日志的操作
            return true;
        }

        public bool DeleteLog(LogModel logModel)
        {
            Console.WriteLine($"删除数据库日志：{logModel.toStringShow()}");
            //省略了连接数据库并删除日志的操作
            return true;
        }

        public List<LogModel> QueryAllLog()
        {
            Console.WriteLine($"获取数据库的所有日志");
            //省略了连接数据库并查询日志的操作
            return new List<LogModel>();
        }

        public bool UpdateLog(LogModel logModel)
        {
            Console.WriteLine($"更新数据库日志：{logModel.toStringShow()}");
            //省略了连接数据库并更新日志的操作
            return true;
        }

    }//Class_end
}
