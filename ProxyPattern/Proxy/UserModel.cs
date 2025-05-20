using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace ProxyPattern.Proxy
{
    /// <summary>
    /// 用户对象
    /// </summary>
    internal class UserModel
    {
        //用户编号
        public string? Id { get; set; }
        //用户身份证编号
        public string? UserId { get; set; }
        //用户名称
        public string? UserName { get; set; }
        //用户性别
        public string? UserSex { get; set; }
        //用户年龄
        public string? UserAge { get; set; }
        //联系电话
        public string? UserTelnumber { get; set; }
        //用户身高
        public string? UserHeight { get; set; }
        //用户体重
        public string? UserWeight { get; set; }
        //用户地址
        public string? UserAddress { get; set; }
        //用户所属部门编号
        public string? DepmentId { get; set; }

        //public override string ToString()
        //{
        //    string str = $"用户的身份证编号【{UserId}】姓名【{UserName}】性别【{UserSex}】年龄【{UserAge}】" +
        //        $"联系电话【{UserTelnumber}】身高【{UserHeight}】体重【{UserWeight}】地址【{UserAddress}】所属部门编号【{DepmentId}】";
        //    return str;
        //}

    }//Class_end
}
