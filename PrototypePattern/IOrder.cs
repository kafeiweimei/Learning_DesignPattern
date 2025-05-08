using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrototypePattern
{
    /// <summary>
    /// 订单接口
    /// </summary>
    internal interface IOrder
    {
        //获取订单产品数量
        int GetOrderProductNumber();

        //设置订单产品数量
        void SetOrderProductNumber(int productNumber);


    }//Interface_end
}
