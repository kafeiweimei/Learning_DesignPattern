using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediatorPattern.CommonMediator
{
    /// <summary>
    /// 部门与人员的中介者对象
    /// </summary>
    internal class DepmentUserMediator
    {
        //实例化一个部门与人员的中介者对象
        private static DepmentUserMediator depmentUserMediator = new DepmentUserMediator();

        //部门与人员关系对象模型列表
        private List<DepmentUserModel> depmentUserModels = new List<DepmentUserModel>();

        /// <summary>
        /// 本类实例【只能通过单例获取该实例】
        /// </summary>
        /// <returns></returns>
        public static DepmentUserMediator GetInstance()
        {
            return depmentUserMediator;
        }

        //禁止私有化实例
        private DepmentUserMediator()
        {
            InitTestDatas();
        }

        /// <summary>
        /// 初始化一些数据用于测试
        /// </summary>
        private void InitTestDatas()
        {
            DepmentUserModel depmentUserModel= new DepmentUserModel();
            depmentUserModel.DepmentUserId = "DU01";
            depmentUserModel.DepmentId = "D01";
            depmentUserModel.UserId = "U01";
            depmentUserModels.Add(depmentUserModel);

            DepmentUserModel depmentUserModel2 = new DepmentUserModel();
            depmentUserModel2.DepmentUserId = "DU02";
            depmentUserModel2.DepmentId = "D01";
            depmentUserModel2.UserId = "U02";
            depmentUserModels.Add(depmentUserModel2);

            DepmentUserModel depmentUserModel3 = new DepmentUserModel();
            depmentUserModel3.DepmentUserId = "DU03";
            depmentUserModel3.DepmentId = "D02";
            depmentUserModel3.UserId = "U03";
            depmentUserModels.Add(depmentUserModel3);

            DepmentUserModel depmentUserModel4 = new DepmentUserModel();
            depmentUserModel4.DepmentUserId = "DU04";
            depmentUserModel4.DepmentId = "D02";
            depmentUserModel4.UserId = "U04";
            depmentUserModels.Add(depmentUserModel4);

            DepmentUserModel depmentUserModel5 = new DepmentUserModel();
            depmentUserModel5.DepmentUserId = "DU05";
            depmentUserModel5.DepmentId = "D02";
            depmentUserModel5.UserId = "U01";
            depmentUserModels.Add(depmentUserModel5);
        }

        /// <summary>
        /// 因撤销部门引起的人员被清除交互
        /// </summary>
        /// <param name="depmentId">撤销部门的编号</param>
        /// <returns></returns>
        public bool DeleteDepment(string depmentId)
        {
            /*请注意，这里为了演示简单，部门撤销后原部门的人员怎么处理的后续业务就不体现了*/
            //1、到记录部门和人员的关系集合里，寻找部门的相关人员

            //创建一个临时集合，记录部门与人员的关系对象
            List<DepmentUserModel> tmpDepmentUserList= new List<DepmentUserModel>();
            foreach (var item in depmentUserModels)
            {
                if (depmentId.Equals(item.DepmentId))
                {
                    //获取到所有与该部门对应的人员关系对象
                    tmpDepmentUserList.Add(item);
                }

            }

            //从获取到的所有与该部门对应的人员关系对象中删除这些关系
            foreach (var item in tmpDepmentUserList)
            {
                depmentUserModels.Remove(item);
            }

            return true;
        }

        /// <summary>
        /// 因人员离职引起的与部门删除该人员交互
        /// </summary>
        /// <param name="userId">离职用户的编号</param>
        /// <returns></returns>
        public bool DeleteUser(string userId)
        {
            //1、到记录部门和人员关系的集合里，寻找人员的相关部门

            //设置一个临时集合，记录需要清除的关系对象
            List<DepmentUserModel> depmentUserModelList = new List<DepmentUserModel>();

            foreach (var item in depmentUserModels)
            {
                if (userId.Equals(item.UserId))
                {
                    //记录需要清除的人员对应部门对象
                    depmentUserModelList.Add(item);
                }
            }

            //从部门与人员关系对象集合里面删除这些关系
            foreach (var item in depmentUserModelList)
            {
                depmentUserModels.Remove(item);
            }

            return true;
        }

        /// <summary>
        /// 显示所有的部门与人员
        /// </summary>
        public void ShowDepmentsUsers()
        {
            foreach (var item in depmentUserModels)
            {
                Console.WriteLine(item);
            }
        }

        /// <summary>
        /// 显示指定部门下的所有人员
        /// </summary>
        /// <param name="depment"></param>
        public void ShowDepmentUsers(Depment depment)
        {
            foreach (var item in depmentUserModels)
            {
                if (depment.DepmentId.Equals(item.DepmentId))
                {
                    string str = $"部门编号是【{item.DepmentId}】下的所有人员编号是【{item.UserId}】";
                    Console.WriteLine(str);
                }
            }
        }

        /// <summary>
        /// 显示指定人员的所属部门
        /// </summary>
        /// <param name="depment"></param>
        public void ShowUserDepments(User user)
        {
            foreach (var item in depmentUserModels)
            {
                if (user.UserId.Equals(item.UserId))
                {
                    string str = $"人员编号是【{item.UserId}】所属的部门编号有【{item.DepmentId}】";
                    Console.WriteLine(str);
                }
            }
        }

        //因人员调换部门引起的与部门交互
        public bool ChangeDepment(string userId,string oldDepmentId,string newDepmentId)
        {
            //本示例不实现了
            return false;
        }

        //因部门合并操作引起的人员交互
        public bool JoinDep(List<string> depmentIdList,Depment newDepment)
        {
            //本示例不实现了
            return false;
        }

    }//Class_end
}
