using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlyweightPattern.FlyweightDemoThree
{
    /// <summary>
    /// 在内存中模拟存储在数据库中的值
    /// </summary>
    internal class TestDB
    {
        //用来存放单独授权数据的值
        public List<string> colDB = new List<string>();
        //用来存放组合授权数据的值
        public Dictionary<string, string[]> dicDB = new Dictionary<string, string[]>();

        public TestDB()
        {
            FillDatas();
        }

        public void FillDatas()
        {
            AddInfoToList(ref colDB, "张三,人员列表,查看,1");
            AddInfoToList(ref colDB, "李四,人员列表,查看,1");
            AddInfoToList(ref colDB, "李四,操作薪资数据,,2");
            dicDB.Add("操作薪资数据", new string[] { "薪资数据,查看", "薪资数据,修改" });

            //增加更多的授权
            for (int i = 0; i < 3; i++)
            {
                AddInfoToList(ref colDB, $"张三{i},人员列表,查看,1");
            }

        }

        private void AddInfoToList<T>(ref List<T> list, T needAddInfo)
        {
            if (list == null)
            {
                list = new List<T>();
            }

            if (!list.Contains(needAddInfo) && (needAddInfo != null || !needAddInfo.Equals("")))
            {
                list.Add(needAddInfo);
            }
        }

    }//Class_end
}
