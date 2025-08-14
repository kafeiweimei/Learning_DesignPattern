using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainOfResposibilityPattern.ChainOfResposibilityDemoThree
{
    /// <summary>
    /// 通用的请求对象
    /// </summary>
    internal class RequestModel
    {
        //具体的业务类型
        private string type=string.Empty;

        /// <summary>
        /// 构造方法吧具体的业务类型传递进来
        /// </summary>
        /// <param name="type">业务类型</param>
        public RequestModel(string type)
        {
            this.type = type;
        }

        /// <summary>
        /// 获取到当前类型
        /// </summary>
        /// <returns></returns>
        public string GetCurType
        {
            get { return this.type; }
        }


    }//Class_end
}
