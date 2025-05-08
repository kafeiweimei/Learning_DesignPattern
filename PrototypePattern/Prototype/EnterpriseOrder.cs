using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrototypePattern.Prototype
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
        private int productOrderNumber = 0;

        public IOrder Clone()
        {
            //创建一个新订单对象，然后把该实例的数据赋值给新对象【浅度克隆】
            EnterpriseOrder eo = new EnterpriseOrder();
            eo.EnterpriseName = this.EnterpriseName;
            eo.ProductId = this.ProductId;
            eo.SetOrderProductNumber(this.productOrderNumber);

            return eo;
        }

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
            string str = $"企业订单的订购企业是【{EnterpriseName},订购的产品是【{ProductId}】,订购数量是【{productOrderNumber}】】";
            return str;
        }

    }//Class_end
}
