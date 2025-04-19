using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdapterPattern.LogManagerV1
{
    /// <summary>
    /// 日志模型
    /// </summary>
    internal class LogModel
    {
        //日志编号
        private string? logId;
        //日志操作人员
        private string? operateUser;
        //日志操作时间(以yyyy-MM-DD HH:mm:ss格式记录)
        private string? operateTime;
        //日志内容
        private string? logContent;

        /// <summary>
        /// 日志编号
        /// </summary>
        public string? LogId { get => logId; set => logId = value; }

        /// <summary>
        /// 日志操作人员
        /// </summary>
        public string? OperateUser { get => operateUser; set => operateUser = value; }

        /// <summary>
        /// 日志操作时间(以yyyy-MM-DD HH:mm:ss格式记录)
        /// </summary>
        public string? OperateTime { get=>operateTime; set=>operateTime=value; }

        /// <summary>
        /// 日志内容
        /// </summary>
        public string? LogContent { get => logContent; set => logContent = value; }

        /// <summary>
        /// 写入配置文件内容
        /// </summary>
        /// <param name="separator">内容分隔符（默认为逗号）</param>
        /// <returns></returns>
        public string toStringWrite(char separator=',')
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendJoin(separator, new[] {logId,OperateUser,OperateTime,logContent });                         
            return stringBuilder.ToString();
        }

        /// <summary>
        /// 界面展示内容
        /// </summary>
        /// <param name="separator">内容分割符(默认为一个空格)</param>
        /// <returns></returns>
        public string toStringShow(char separator = ' ')
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendFormat($"LogId={LogId}{separator}");
            stringBuilder.AppendFormat($"OperateUser={OperateUser}{separator}");
            stringBuilder.AppendFormat($"OperateTime={OperateTime}{separator}");
            stringBuilder.AppendFormat($"LogContent={LogContent}{separator}");
            return stringBuilder.ToString();
        }


    }//Class_end
}
