using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlyweightPattern.FlyweightDemoTwo
{
    /// <summary>
    /// 安全管理【实现为单例】
    /// </summary>
    internal class SecurityMgr
    {
        //本类示例
        private static readonly Lazy<SecurityMgr> lazy= new Lazy<SecurityMgr>(() => new SecurityMgr());
        //本类单例
        public static SecurityMgr Instance { get { return lazy.Value; } }
        //禁止该类被外部new
        private SecurityMgr()
        { 

        }

        //获取数据库人员信息
        TestDB testDB = new TestDB();
        //运行期间，用来存放登录人员对应的权限【在Web应用中，这些数据通常存放在session中】
        private Dictionary<string, List<IFlyweight>> personInfoDic = new Dictionary<string, List<IFlyweight>>();


        //模拟登录
        public void Login(string user)
        {
            //登录时就把该用户所拥有的权限从数据库中提取出来
            List<IFlyweight> col=QueryByUser(user);
            //将从数据库中提取的该用户权限内容都放到缓存中去
            AddInfoToDic(user, col);
        }

        //判断某用户对某个安全实体是否拥有某种权限
        public bool HasPermit(string user,string securityEntity,string permit)
        {
            if (string.IsNullOrEmpty(user) || string.IsNullOrEmpty(securityEntity) ||
                string.IsNullOrEmpty(permit))
            {
                return false;
            }

            List<IFlyweight> col = personInfoDic[user];
            if (col == null && col?.Count == 0)
            {
                Console.WriteLine($"【{user}】没有登录或是没有被分配任何权限");
                return false;
            }

            foreach (var item in col)
            {
                //输出当前的实例，看看是否为同一个实例对象
                Console.WriteLine($"查询到【{item}】 该内容对应的唯一编号是【{item.GetHashCode()}】容器数量是【{personInfoDic?.Count}】");
                if (item.Math(securityEntity, permit))
                {
                    return true;
                }
            }

            return false;


        }

        //从数据库中获取某人所拥有的权限
        private List<IFlyweight> QueryByUser(string user)
        {
            List<IFlyweight> col = new List<IFlyweight>();

            if (!string.IsNullOrEmpty(user))
            {
                foreach (var item in testDB.colDB)
                {
                    string[] strArray = item.Split(',');
                    if (strArray[0].Equals(user))
                    {
                        IFlyweight fw = null;

                        //表示权限的组合（不共享的享元）
                        if (strArray[3].Equals("2"))
                        {
                            fw = new UnsharedConcreteFlyweight();
                            //获取需要组合的数据
                            string combinationName = strArray[1];
                            string[] strCombination = testDB.dicDB[combinationName];
                            foreach (string combination in strCombination)
                            {
                                IFlyweight fwtmp = FlyweightFactory.Instance.GetIFlyweight(combination);
                                //把这个对象加入到组合对象中
                                fw.Add(fwtmp);
                            }
                        }
                        else
                        {
                            //表示单个享元
                            string state = $"{strArray[1]},{strArray[2]}";
                            fw = FlyweightFactory.Instance.GetIFlyweight(state);
                        }
                        col.Add(fw);
                    }
                }
            }
            return col;
        }

        //添加信息到字典中
        private void AddInfoToDic(string user, List<IFlyweight> authorizationList)
        {
            if (string.IsNullOrEmpty(user) || authorizationList == null || authorizationList.Count <= 0)
            {
                return;
            }

            if (personInfoDic != null && personInfoDic.ContainsKey(user))
            {
                personInfoDic[user] = authorizationList;
            }
            else
            {
                personInfoDic.Add(user, authorizationList);
            }
        }


    }//Class_end
}
