using AdapterPattern.LogManagerV1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdapterPattern.LogManagerV2
{
    /// <summary>
    /// 现在采用数据库来管理日志，定义日志的数据库接口
    /// </summary>
    internal interface ILogDBOperate
    {
        //新增日志
        bool CreateLog(LogModel logModel);

        //删除日志
        bool DeleteLog(LogModel logModel);

        //修改日志
        bool UpdateLog(LogModel logModel);

        //查询所有日志
        List<LogModel> QueryAllLog();

    }//Interface_end
}
