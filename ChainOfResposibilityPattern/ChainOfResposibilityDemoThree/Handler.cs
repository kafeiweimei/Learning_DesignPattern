using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainOfResposibilityPattern.ChainOfResposibilityDemoThree
{
    /// <summary>
    /// 通用职责对象
    /// </summary>
    abstract internal class Handler
    {
        /// <summary>
        /// 持有下一个处理请求的对象
        /// </summary>
        public Handler Successor { get; set; }

        /// <summary>
        /// 通用处理请求的方法
        /// </summary>
        /// <param name="rm">请求对象</param>
        /// <returns></returns>
        public virtual object HandleRequest(RequestModel rm)
        {
            if (Successor != null)
            {
                //这是默认实现（若子类不处理这个请求）那就传递到下一个职责对象去处理
                return this.Successor.HandleRequest(rm);
            }
            else
            {
                Console.WriteLine("没有后续处理或暂时不支持这样的功能处理");
                return false;
            }
        }


    }//Class_end
}
