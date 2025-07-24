using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlyweightPattern.FlyweightDemoOne
{
    /// <summary>
    /// 安全管理【实现为单例】
    /// </summary>
    internal class SecurityMgr
    {
        //本类实例
        private static readonly Lazy<SecurityMgr> lazy= new Lazy<SecurityMgr>(() => new SecurityMgr());
        //本类单例
        public static SecurityMgr Instance { get { return lazy.Value; } }
        //禁止该类被外部new
        private SecurityMgr()
        {
            
        }

        //获取数据库人员信息
        TestDB testDB= new TestDB();

        //在运行期间用来存放登录人员对应的权限【web应用中，这些人员对应的权限数据通常会存放到session中】
        private Dictionary<string, List<IFlyweight>> personInfoDic = new Dictionary<string, List<IFlyweight>>();


        //模拟登录
        public void Login(string user)
        {
            //登录时就把该用户所拥有的权限内容从数据库中提取出来
            List<IFlyweight> col = QueryByUser(user);
            //将从数据库提取的数据存放到缓存中
            AddInfoToDic(user,col);
        }

        //判断某个用户对某个安全实体是否拥有某种权限
        public bool HasPermit(string user,string securityEntity,string permit)
        {
            if (string.IsNullOrEmpty(user) || string.IsNullOrEmpty(securityEntity)||
                string.IsNullOrEmpty(permit))
            {
                return false;
            }

            List<IFlyweight> col = personInfoDic[user];
            if (col==null && col?.Count==0)
            {
                Console.WriteLine($"【{user}】没有登录或是没有被分配任务权限");
                return false;
            }

            foreach (var item in col)
            {
                //输出当前的实力，看看是否为同一个实例对象
                Console.WriteLine($"查询到【{item}】 该内容对应的唯一编号是【{item.GetHashCode()}】");
                if (item.Math(securityEntity,permit))
                {
                    return true;
                }
            }

            return false;
        }

        //从数据库中获取某人所拥有的权限
        private List<IFlyweight> QueryByUser(string user)
        {
            List<IFlyweight> col=new List<IFlyweight>();

            if (!string.IsNullOrEmpty(user))
            {
                foreach (var item in testDB.colDB)
                {
                    string[] strArray = item.Split(',');
                    if (strArray[0].Equals(user))
                    {
                        string state = $"{strArray[1]},{strArray[2]}";
                        IFlyweight fw = FlyweightFactory.Instance.GetIFlyweight(state);
                        col.Add(fw);
                    }
                }
            }
            return col;
        }

        //添加信息到字典中
        private void AddInfoToDic(string user, List<IFlyweight> authorizationList)
        {
            if (string.IsNullOrEmpty(user) || authorizationList == null || authorizationList.Count<=0)
            {
                return;
            }

            if (personInfoDic != null && personInfoDic.ContainsKey(user))
            {
                personInfoDic[user] = authorizationList;
            }
            else
            {
                personInfoDic.Add(user,authorizationList);
            }
        }

    }//Class_end
}
