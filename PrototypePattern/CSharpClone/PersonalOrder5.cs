using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrototypePattern.CSharpClone
{
    internal class PersonalOrder5 : IOrder2, ICloneable
    {
        //订购人员名称
        public string? CustomerName;
        //产品编号
        public string? ProductId;

        //产品对象【新增的产品对象引用类型】
        public Product2? Product2;

        //订单产品数量
        private int productOrderNumber = 0;

        public object Clone()
        {
            //直接调用C#的克隆方法【浅度克隆】
            PersonalOrder5 obj = (PersonalOrder5)base.MemberwiseClone();
            //必须手工针对每一个引用类型的属性进行克隆
            obj.Product2 = (Product2)this.Product2.Clone();
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
            string str = $"个人订单的订购人是【{CustomerName},订购的产品是【{ProductId}】,订购数量是【{productOrderNumber}】，产品对象是【{Product2}】】";
            return str;
        }
    }//Class_end
}
