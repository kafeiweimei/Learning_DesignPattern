using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrototypePattern
{
    /// <summary>
    /// 企业订单对象
    /// </summary>
    internal class EnterpriseOrder : IOrder
    {
        //企业名称
        public string? EnterpriseName;
        //产品编号
        public string? ProductId;

        //产品的订单数量
        private int productOrderNumber=0;

        public int GetOrderProductNumber()
        {
            return productOrderNumber;
        }

        public void SetOrderProductNumber(int productNumber)
        {
            productOrderNumber = productNumber;
        }

        public override string ToString()
        {
            string str = $"企业订单的订购企业是【{EnterpriseName},订购的产品是【{ProductId}】,订购数量是【{productOrderNumber}】】";
            return str;
        }


    }//Class_end
}
