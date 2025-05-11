using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediatorPattern
{
    /// <summary>
    /// 同事类的抽象父类【没有定义抽象方法，主要是用来约束所有同事类的类型】
    /// </summary>
    internal abstract class Colleague
    {
        //持有中介者对象(让每个同事类都知道中介者)
        private IMediator mediator;

        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="mediator">中介者对象</param>
        public Colleague(IMediator mediator)
        {
            this.mediator = mediator;
        }

        /// <summary>
        /// 获取当前同事类对象持有的中介者
        /// </summary>
        /// <returns></returns>
        public IMediator GetMediator()
        {
            return mediator;
        }

    }//Class_end
}
