using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecoratorPattern.NoPattern
{
    /// <summary>
    /// 奖金规则
    /// </summary>
    internal class PrizeRule
    {
        public PrizeRule()
        {
            //先填充数据
            TempDB.FillDatas();
        }


        /// <summary>
        /// 计算某人在某段时间内的奖金（有些参数在这里的演示中不会使用，但是在实际业务中会用到；
        /// 为表示这个具体的业务方法，因此这些参数被保留了）
        /// </summary>
        /// <param name="user">人员名称</param>
        /// <param name="start">开始时间</param>
        /// <param name="end">结束时间</param>
        /// <returns>返回某人在某段时间内的奖金</returns>
        public double CaculatePrize(string user,DateTime start,DateTime end)
        {
            double prize = 0.00;
            if (string.IsNullOrEmpty(user) || start>end)
            {
                return prize;
            }

            //计算当月业务奖金（所有人）
            prize = MonthPrize(user,start,end);

            //计算累计奖金
            prize += SumPrize(user,start,end);

            //需要判断该人员是普通人员还是业务经理（团队奖金只有业务经理才有）
            if (IsManager(user))
            {
                prize += GroupPrize(user,start,end);
            }

            return prize;
        }

        //计算某人的当月业务奖金
        private double MonthPrize(string user,DateTime start,DateTime end)
        {
            double prize = 0.00;

            //根据人员获取当月的业务额度，然后乘以3%
            prize = TempDB.monthSaleMoneyDic[user]*0.03;
            Console.WriteLine($"【{user}】当月的业务奖金是【{prize}】");

            return prize;
        }

        //计算某人的累计奖金
        private double SumPrize(string user, DateTime start, DateTime end)
        {
            //计算累计奖金（正常来说我们应该安装人员获取累计业务额度，然后再乘以0.1%）
            //我们这里只做演示（就都假定每个人员的业务额度都是一百万1000000）
            double prize = 0.00;
            prize = 1000000 * 0.001;
            Console.WriteLine($"【{user}】的累计奖金是【{prize}】");
            return prize;
        }

        //判断人员是普通人员还是业务经理
        private bool IsManager(string user)
        {
            //实际业务应该从数据库中获取人员对应的职务进行判定
            //我们这里为了掩饰方便，就直接指定王五为经理，其余都是普通员工
            if ("王五".Equals(user))
            {
                return true;
            }
            return false;
        }

        //计算当月团队业务将
        private double GroupPrize(string user,DateTime start,DateTime end)
        {
            //计算当月团队的业务奖金（先算出团队业务总额，然后在乘以1%）
            double groupPize = 0.00;
            foreach (var item in TempDB.monthSaleMoneyDic.Values)
            {
                groupPize += item;
            }
            groupPize = groupPize * 0.01;
            Console.WriteLine($"【{user}】所属团队当月的业务奖金是【{groupPize}】");
            return groupPize;
        }

    }//Class_end
}
