using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProxyPattern.Proxy
{
    /// <summary>
    /// 用户管理对象
    /// </summary>
    internal class UserManager
    {
        /// <summary>
        /// 根据部门编号来获取该部门下的所有人员
        /// </summary>
        /// <param name="depmentId">部门编号</param>
        /// <returns>返回该部门下的所有人员</returns>
        public List<IUserModel> GetUserByDepmentId(string depmentId)
        {
            string conStr = $"server=.;database=Test;uid=test;pwd=123456";
            SqlServerHelper sqlServerHelper = new SqlServerHelper(conStr);
            //只需要查询UserId与UserName两个值就可以了
            string sql = $"select uo.UserId,uo.UserName from UserInfo uo left join Depment dt on uo.depmentId=dt.ID where dt.ID like '{depmentId}%'";

            DataTable dt = sqlServerHelper.ExecuteDataTable(sql);

            if (dt.Rows.Count>0)
            {
                List<IUserModel> userModels = new List<IUserModel>();
                foreach (DataRow dr in dt.Rows)
                {
                    //这里是只创建代理对象，而不是直接创建UserModel对象
                    Proxy proxy = new Proxy(new UserModel());
                   
                    proxy.UserId = dr["UserID"].ToString();
                    proxy.UserName = dr["UserName"].ToString();
                    userModels.Add(proxy);
                }
                return userModels;
            }

            return null;
        }


    }//Class_end
}
