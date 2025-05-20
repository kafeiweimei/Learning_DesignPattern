/***
*	Title："设计模式" 项目
*		主题：代理模式
*	Description：代理模式的本质【控制对象访问】
*	        定义：为其他对象提供一种代理以控制对这个对象的访问
*	        功能：代理模式是通过创建一个代理对象，用这个代理对象去代表真实的对象；客户端得到这个代理对象后，对客户端没有什么影响，
*	              就跟得到了真实对象一样来使用【当客户端操作整个代理对象的时候，实际上功能最终还是会由真实的对象来完成，只不过是由
*	              通过代理操作的，也就是客户端操作代理，代理操作真正的对象】正是因为有代理对象夹在客户端和被代理的真实对象中间，相当于
*	              一个中转，那么在中转的时候就有很多花招可以使用了（如：判断权限，若没有足够权限就不给你中转等等）
*	              
*	        代理的分类：  
*	                1、虚代理：根据需要来创建开销很大的对象，该对象只有在需要的时候才会被真正创建。
*	                2、远程代理：用来在不同的地址空间上代表同一个对象，这个不同的地址空间可以是在本机，也可以在其他机器上；
*	                3、Copy-on-Write代理：在客户端操作的时候，只有对象改变了，才会真的拷贝（或克隆）一个目标对象，算是虚代理的一个分支；
*	                4、保护代理：控制对原始对象的访问，如果有需要，可以给不同的用户提供不同的访问权限，以控制他们对原始对象的访问；
*	                5、Cache代理：为那些昂贵操作的结果提供临时的存储空间，以便多个客户端可以共享这些结果；
*	                6、防火墙代理：保护对象不被恶意用户访问和操作；
*	                7、同步代理：使多个用户能够同时访问目标对象而没有冲突；
*	                8、智能指引：在访问对象时执行一些附加操作（如：对指向对象的引用计数、第一次引用一个持久对象时，将它装入内存等）
* 
*           何时选用代理模式？
*                   1、需要为一个对象在不同的地址空间提供局部代表的时候，可以使用远程代理；
*                   2、需要按照需要创建开销很大的对象的时候，可以使用虚代理。
*                   3、需要控制对原始对象的访问的时候，可以使用保护代理；
*                   4、需要在访问对象执行一些附加操作的时候，可以使用智能指引代理；
* 
* 
*	Date：2025
*	Version：0.1版本
*	Author：Coffee
*	Modify Recoder：
 ***/


using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace ProxyPattern.Proxy
{
    internal class Proxy : IUserModel
    {
        //持有被代理的具体目标对象
        private UserModel userModel;
        //是否已经重新装载过数据标识
        private bool loaded = false;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="userModel">被代理的具体目标对象</param>
        public Proxy(UserModel userModel)
        {
            this.userModel = userModel;
        }

        public string? Id { get=>this.userModel.Id ; set =>this.userModel.Id=value; }
        public string? UserId { get => this.userModel.UserId; set => this.userModel.UserId=value; }
        public string? UserName { get => this.userModel.UserName; set => this.userModel.UserName=value; }
        public string? UserSex { get => this.userModel.UserSex; set => this.userModel.UserSex=value; }
        public string? UserAge { get => this.userModel.UserAge; set => this.userModel.UserAge=value; }
        public string? UserTelnumber { get => this.userModel.UserTelnumber; set => this.userModel.UserTelnumber=value; }
        public string? UserHeight { get => this.userModel.UserHeight; set => this.userModel.UserHeight=value; }
        public string? UserWeight { get => this.userModel.UserWeight; set => this.userModel.UserWeight=value; }
        public string? UserAddress { get => this.userModel.UserAddress; set => this.userModel.UserAddress=value; }
        public string? DepmentId 
      {
            get 
            {
                if (!this.loaded)
                {
                    //从数据库重写加载数据
                    Reload();
                    //重新设置加载标识为true
                    this.loaded = true;
                }
                return this.userModel.DepmentId;
            }
            set 
            {
               this.userModel.DepmentId = value;
            }     
      }


        private void Reload()
        {
            Console.WriteLine($"重新查询数据库获取完整的用户数据,UserId={userModel.UserId}");

            string conStr = $"server=.;database=Test;uid=test;pwd=123456";
            SqlServerHelper sqlServerHelper = new SqlServerHelper(conStr);
            string sql = "select ID,UserAge,UserSex,UserTelnumber,UserHeight,UserWeight,UserAddress,DepmentId from UserInfo where UserID=@userId";
            //使用参数内容时周围不能有特殊修符号如单引号等
            SqlParameter[] sqlParameters ={
                new SqlParameter("@userId",SqlDbType.VarChar){Value=userModel.UserId}
            }
            ;
            DataTable dt = sqlServerHelper.ExecuteDataTable(sql, System.Data.CommandType.Text, sqlParameters);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    userModel.Id = dr["ID"].ToString();
                    userModel.UserSex = dr["UserSex"].ToString();
                    userModel.UserAge = dr["UserAge"].ToString();
                    userModel.UserTelnumber = dr["UserTelnumber"].ToString();
                    userModel.UserHeight = dr["UserHeight"].ToString();
                    userModel.UserWeight = dr["UserWeight"].ToString();
                    userModel.UserAddress = dr["UserAddress"].ToString();
                    userModel.DepmentId = dr["DepmentId"].ToString();
                }
            }

        }

        public override string ToString()
        {
            string str = $"完整用户信息——用户的身份证编号【{UserId}】姓名【{UserName}】性别【{UserSex}】年龄【{UserAge}】" +
                $"联系电话【{UserTelnumber}】身高【{UserHeight}】体重【{UserWeight}】地址【{UserAddress}】所属部门编号【{DepmentId}】";
            return str;
        }

    }//Class_end
}
