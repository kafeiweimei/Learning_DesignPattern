using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecoratorPattern.DecoratorDemoOne
{
    /// <summary>
    /// 奖金规则
    /// </summary>
    abstract internal class PrizeRule
    {
        /// <summary>
        /// 计算某人在某段时间内的奖金（有些参数在这里的演示中不会使用，但是在实际业务中会用到；
        /// 为表示这个具体的业务方法，因此这些参数被保留了）
        /// </summary>
        /// <param name="user">人员名称</param>
        /// <param name="start">开始时间</param>
        /// <param name="end">结束时间</param>
        /// <returns>返回某人在某段时间内的奖金</returns>
        public abstract double CaculatePrize(string user, DateTime start, DateTime end);

    }//Class_end
}
