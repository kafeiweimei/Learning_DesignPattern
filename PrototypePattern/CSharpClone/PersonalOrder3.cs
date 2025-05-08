using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrototypePattern.CSharpClone
{
    internal class PersonalOrder3 : IOrder2, ICloneable
    {
        //订购人员名称
        public string? CustomerName;
        //产品编号
        public string? ProductId;

        //订单产品数量
        private int productOrderNumber = 0;

        public object Clone()
        {
            //直接调用父类的克隆方法【浅度克隆】
            object obj = base.MemberwiseClone();
            return obj;
        }

        public int GetOrderProductNumber()
        {
            return this.productOrderNumber;
        }

        public void SetOrderProductNumber(int productNumber)
        {
            //做各种逻辑校验内容，此处省略
            this.productOrderNumber = productNumber;
        }
        public override string ToString()
        {
            string str = $"个人订单的订购人是【{CustomerName},订购的产品是【{ProductId}】,订购数量是【{productOrderNumber}】】";
            return str;
        }

    }//Class_end
}
