using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrototypePattern
{
    /// <summary>
    /// 个人订单对象
    /// </summary>
    internal class PersonalOrder : IOrder
    {
        //消费者名称
        public string? CustomerName;
        //产品编号
        public string? ProductId;

        //产品订单数量
        private int productOrderNumber = 0;


        public int GetOrderProductNumber()
        {
            return productOrderNumber;
        }

        public void SetOrderProductNumber(int productNumber)
        {
            //做各种逻辑校验内容，此处省略
            this.productOrderNumber = productNumber;
        }

        public override string ToString()
        {
            string str=$"个人订单的订购人是【{CustomerName},订购的产品是【{ProductId}】,订购数量是【{productOrderNumber}】】";
            return str;
        }

    }//Class_end
}
