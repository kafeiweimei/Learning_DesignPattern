using ProxyPattern.ProtectProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProxyPattern.ModifyProxy
{
    /// <summary>
    /// 订单对象
    /// </summary>
    internal class Order : IOrder
    {
        //订单订购的产品名称
        private string productName=string.Empty;
        //订单的订购数量
        private int orderNumber=0;
        //创建订单的人员
        private string orderUser=string.Empty;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="productName">订单订购的产品名称</param>
        /// <param name="orderNumber">订单数量</param>
        /// <param name="orderUserName">创建订单的人员</param>
        public Order(string productName,int orderNumber,string orderUser)
        {
            this.productName = productName;
            this.orderNumber = orderNumber;
            this.orderUser=orderUser;
            
        }

        public int GetOrderNumber()
        {
            return orderNumber;
        }

        public string GetOrderUser()
        {
            return orderUser;
        }

        public string GetProductName()
        {
            return productName;
        }

        public virtual void SetOrderNumber(int orderNumber, string user)
        {
            this.orderNumber=orderNumber;
        }

        public virtual void SetOrderUser(string orderUser, string user)
        {
            this.orderUser=orderUser;
        }

        public virtual void SetProductName(string productName, string user)
        {
            this.productName=productName;
        }


    }//Class_end
}
