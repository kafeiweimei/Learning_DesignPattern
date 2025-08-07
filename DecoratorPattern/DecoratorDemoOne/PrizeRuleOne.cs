using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecoratorPattern.DecoratorDemoOne
{
    /// <summary>
    /// 具体实现奖金的类（也是被装饰器装饰的对象）
    /// </summary>
    internal class PrizeRuleOne : PrizeRule
    {
        public override double CaculatePrize(string user, DateTime start, DateTime end)
        {
            //默认实现（没有任何奖金）
            return 0.00;
        }

    }//Class_end
}
