using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecoratorPattern.DecoratorDemoOne
{
    /// <summary>
    /// 计算当月团队业务奖金（装饰器对象）
    /// </summary>
    internal class GroupPrizeDecorator : Decorator
    {
        public GroupPrizeDecorator(PrizeRule prizeRule) : base(prizeRule)
        {
        }

        public override double CaculatePrize(string user, DateTime start, DateTime end)
        {
            //1-先获取前面运算出来的奖金
            double money = base.CaculatePrize(user, start, end);

            //2-计算当月团队业务奖金，先计算出团队总的业务额度，然后再乘以1%
            //假设都是一个团队的
            double group = 0.00;
            foreach (var item in TempDB.monthSaleMoneyDic.Values)
            {
                group += item;
            }

            group = group * 0.01;
            Console.WriteLine($"【{user}】所在团队当月业务奖金是【{group}】");
            return money+group;
        }

    }//Class_end
}
