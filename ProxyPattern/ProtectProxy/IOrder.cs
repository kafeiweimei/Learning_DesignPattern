using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProxyPattern.ProtectProxy
{
    /// <summary>
    /// 订单对象接口
    /// </summary>
    internal interface IOrder
    {
        //获取订单订购的产品名称
        string GetProductName();

        //设置订单订购的产品名称与人员
        void SetProductName(string productName,string user);

        //获取订购订单的数量
        int GetOrderNumber();

        //设置订购订单的数量与人员
        void SetOrderNumber(int orderNumber,string user);

        //获取创建订单的人员
        string GetOrderUser();
        //设置创建订单的人员与人员
        void SetOrderUser(string orderUser, string user);

    }//Interface_end
}
