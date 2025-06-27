using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemplateMethodPattern.TemplateMethodSort
{
    internal class ListSort
    {

        //排序
        public void SortTest()
        {
            List<UserModel> userModelList = GetUserModelList();
            Console.WriteLine("------排序前------");
            Print(userModelList);

            Console.WriteLine("------排序后------");
            userModelList.Sort(Compare);
            Print(userModelList);
        }


        //获取用户列表
        private List<UserModel> GetUserModelList()
        {
            UserModel userModel1 = new UserModel("张三", 23);
            UserModel userModel2 = new UserModel("李四", 21);
            UserModel userModel3 = new UserModel("王五", 26);
            UserModel userModel4 = new UserModel("赵六", 20);
            UserModel userModel5 = new UserModel("钱七", 28);
            return new List<UserModel> {  userModel1, userModel2, userModel3, userModel4, userModel5 };
        }

        //实现比较器
        int Compare(UserModel obj1, UserModel obj2)
        {
            if (obj1.Age>obj2.Age)
            {
                return 1;
            }
            if (obj1.Age == obj2.Age)
            {
                return 0;
            }
            if (obj1.Age < obj2.Age)
            {
                return -1;
            }
            return 0;
        }

        private void Print(List<UserModel> userModels)
        {
            if (userModels == null || userModels.Count < 1) return;

            foreach (var userModel in userModels)
            {
                Console.WriteLine(userModel);
            }
           
        }

    }//Class_end
}
