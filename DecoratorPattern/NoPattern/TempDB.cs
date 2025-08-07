using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecoratorPattern.NoPattern
{
    /// <summary>
    /// 在内存中模拟数据库，准备好测试数据，用于计算奖金
    /// </summary>
    internal class TempDB
    {
        //记录每个人的月度销售额
        public static Dictionary<string,double> monthSaleMoneyDic= new Dictionary<string,double>();

        /// <summary>
        /// 填充数据
        /// </summary>
        public static void FillDatas()
        {
            AddInfoToDic(ref monthSaleMoneyDic,"张三",10000.00);
            AddInfoToDic(ref monthSaleMoneyDic,"李四",20000.00);
            AddInfoToDic(ref monthSaleMoneyDic,"王五",30000.00);
        }

        /// <summary>
        /// 添加数据到字典中
        /// </summary>
        /// <typeparam name="T1">数据类型1</typeparam>
        /// <typeparam name="T2">数据类型2</typeparam>
        /// <param name="dic">字典容器</param>
        /// <param name="key">键</param>
        /// <param name="value">值</param>
        private static void AddInfoToDic<T1,T2>(ref Dictionary<T1,T2> dic,T1 key,T2 value)
        {
            if (dic == null || key==null ||"".Equals(key)) return;

            if (dic.ContainsKey(key))
            {
                dic[key] = value;
            }
            else
            {
                dic.Add(key, value);
            }
        }

    }//Class_end
}
