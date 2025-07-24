using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlyweightPattern.NoPattern
{
    /// <summary>
    /// 安全管理【实现为单例】
    /// </summary>
    internal class SecurityMgr
    {
        private static readonly Lazy<SecurityMgr> lazy=new Lazy<SecurityMgr>(() => new SecurityMgr());

        //禁止该类被外部new
        private SecurityMgr()
        {
            
        }

        //本类实例
        public static SecurityMgr Instance 
        { 
            get 
            {
                /*Console.WriteLine($"SecurityMgr单例类的编号是{lazy.Value.GetHashCode()}");*/ 
                return lazy.Value; 
            }     
        }

        //获取数据库人员信息（内存模拟数据）
        TestDB testDB= new TestDB();

        //运行期间用来存放登录人员的对应权限
        private Dictionary<string, List<AuthorizationModel>> personInfoDic = new Dictionary<string, List<AuthorizationModel>>();

        /// <summary>
        /// 模拟登录功能
        /// </summary>
        /// <param name="user">登录的用户</param>
        public void Login(string user)
        {
            //登录时就需要把该用户所拥有的权限从数据库中获取出来
            List<AuthorizationModel> col = QueryByUser(user);
            //然后将从数据库获取的用户数据放到缓存中
            AddInfoToDic(ref personInfoDic,user,col);
        }

        /// <summary>
        /// 判断某个用户对某个安全实体是否拥有某种权限
        /// </summary>
        /// <param name="user">被检测权限的用户</param>
        /// <param name="securityEntity">安全实体</param>
        /// <param name="permit">权限</param>
        /// <returns>true：表示【用户】拥有【安全实体】的【权限】</returns>
        public bool HasPermit(string user,string securityEntity,string permit)
        {
            Console.WriteLine($"现在开始判断【{user}】是否拥有【{securityEntity}】模块的【{permit}】权限 ");
            bool res= false;
            if (string.IsNullOrEmpty(user) || string.IsNullOrEmpty(securityEntity) || 
                string.IsNullOrEmpty(permit))
            {
                return false;
            }

            List<AuthorizationModel> col = personInfoDic[user];
            if (col==null || col.Count<=0)
            {
                Console.WriteLine($"【{user}】没有登录或是被分配任务的权限");
                return false;
            }

            foreach (var item in col)
            {
                Console.WriteLine($"查询到【{item}】该内容对应的唯一编号是【{item.GetHashCode()}】");
                if (item.SecurityEntity.Equals(securityEntity)&&
                    item.Permit.Equals(permit))
                {
                    return true;
                }
            }
            return res;
        }

        //从数据库中获取某人所拥有的权限
        private List<AuthorizationModel> QueryByUser(string user)
        {
            List<AuthorizationModel> col = new List<AuthorizationModel>();
            if (!string.IsNullOrEmpty(user))
            {
                foreach (var item in testDB.colDB)
                {
                    string[] strArray = item.Split(',');
                    if (strArray[0].Equals(user))
                    {
                        AuthorizationModel am = new AuthorizationModel();
                        am.User= strArray[0];
                        am.SecurityEntity = strArray[1];
                        am.Permit= strArray[2];

                        col.Add(am);
                    }
                }
            }
            return col;
        }

        //添加信息到字典中
        private void AddInfoToDic(ref Dictionary<string,List<AuthorizationModel>> personInfoDic, 
            string user,List<AuthorizationModel> authorizations)
        {
            if (string.IsNullOrEmpty(user) || authorizations==null || authorizations.Count<=0)
            {
                return;
            }

            if (personInfoDic.ContainsKey(user))
            {
                personInfoDic[user] = authorizations;
            }
            else
            {
                personInfoDic.Add(user, authorizations);
            }

        }


    }//Class_end
}
