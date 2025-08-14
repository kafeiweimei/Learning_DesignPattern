using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainOfResposibilityPattern.ChainOfResposibilityDemoFour
{
    /// <summary>
    /// 销售职责接口
    /// </summary>
    abstract internal class SaleHandler
    {
        /// <summary>
        /// 持有下一个处理请求的对象
        /// </summary>
        public SaleHandler Successor { get; set; } = null;

        /// <summary>
        /// 处理保存销售信息的请求
        /// </summary>
        /// <param name="user">操作人员</param>
        /// <param name="customer">客户</param>
        /// <param name="saleModel">销售对象</param>
        /// <returns>true:表示成功</returns>
        public abstract bool Sale(string user,string customer,SaleModel saleModel);

    }//Class_end
}
