using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProxyPattern
{
    /// <summary>
    /// 用户管理对象
    /// </summary>
    internal class UserManager
    {

        public static List<UserModel> GetUserByDepmentId(string depmentId)
        {
            string conStr = $"server=.;database=Test;uid=test;pwd=123456";
            SqlServerHelper sqlServerHelper = new SqlServerHelper(conStr);
            string sql = $"select uo.* from UserInfo uo left join Depment dt on uo.depmentId=dt.ID where dt.ID like '{depmentId}%'";

            DataTable dt = sqlServerHelper.ExecuteDataTable(sql);

            ////使用参数内容时周围不能有特殊修符号如单引号等
            //SqlParameter[] sqlParameters ={
            //    new SqlParameter("@dd",SqlDbType.VarChar){Value=depmentId}
            //}
            //;
            //DataTable dt = sqlServerHelper.ExecuteDataTable(sql, System.Data.CommandType.Text, sqlParameters);

            if (dt.Rows.Count>0)
            {
                List<UserModel> userModels = new List<UserModel>(); 
                foreach (DataRow dr in dt.Rows)
                {
                    UserModel userModel = new UserModel();
                    userModel.Id = dr["ID"].ToString();
                    userModel.UserId = dr["UserID"].ToString();
                    userModel.UserName = dr["UserName"].ToString();
                    userModel.UserSex = dr["UserSex"].ToString();
                    userModel.UserAge = dr["UserAge"].ToString();
                    userModel.UserTelnumber = dr["UserTelnumber"].ToString();
                    userModel.UserHeight = dr["UserHeight"].ToString();
                    userModel.UserWeight = dr["UserWeight"].ToString();
                    userModel.UserAddress = dr["UserAddress"].ToString();
                    userModel.DepmentId = dr["DepmentId"].ToString();
                   
                    userModels.Add(userModel);
                }
                return userModels;
            }
            

            return null;
        }


    }//Class_end
}
