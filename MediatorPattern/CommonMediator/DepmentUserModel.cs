using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediatorPattern.CommonMediator
{
    /// <summary>
    /// 部门与人员关系对象模型
    /// </summary>
    internal class DepmentUserModel
    {
        //用于部门和人员关系的编号，作为主键
        private string? depmentUserId;
        //部门编号
        private string? depmentId;
        //人员编号
        private string? userId;

        public string? DepmentUserId { get => depmentUserId; set => depmentUserId = value; }
        public string? DepmentId { get => depmentId; set => depmentId = value; }
        public string? UserId { get => userId; set => userId = value; }

        public override string ToString()
        {
            string str = $"部门与人员关系Id【{depmentUserId}】  部门ID是【{DepmentId}】 人员ID是【{UserId}】";
            return str;
        }

    }//Class_end
}
