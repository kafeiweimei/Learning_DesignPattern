using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecoratorPattern.DecoratorDemoTwo
{
    /// <summary>
    /// 商品销售管理的业务接口
    /// </summary>
    internal interface IGoodsSaleEbi
    {
        /// <summary>
        /// 保存销售信息（这里为了演示就简化了【本来销售数据是多条的】）
        /// </summary>
        /// <param name="user">操作人员</param>
        /// <param name="customer">客户</param>
        /// <param name="saleModel">销售数据</param>
        /// <returns>是否成功 true表示成功</returns>
        bool Sale(string user,string customer,SaleModel saleModel);

    }//Interface_end
}
