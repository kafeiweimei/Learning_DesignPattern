
using PrototypePattern.CSharpClone;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrototypePattern.Prototype
{
    /// <summary>
    /// 个人订单对象
    /// </summary>
    internal class PersonalOrder4 : IOrder
    {
        //订购人员名称
        public string? CustomerName;
        //产品编号
        public string? ProductId;

        //产品对象【新增的产品对象引用类型】
        public CSharpClone.Product? Product;

        //订单产品数量
        private int productOrderNumber=0;
       
        

        public IOrder Clone()
        {
            //创建一个新订单对象，然后把该实例的数据赋值给新对象【浅度克隆】
            PersonalOrder4 po = new PersonalOrder4();
            po.CustomerName = this.CustomerName;
            po.ProductId = this.ProductId;
            po.SetOrderProductNumber(this.productOrderNumber);

            /*自己实现深度克隆也不是很复杂，但是比较麻烦，如果产品类中又有属性是引用类型，
             * 在产品类实现克隆方法的时候，则需要调用那个引用类型的克隆方法了。这样一层层的调用下去，
             * 如果中途有任何一个对象没有正确实现深度克隆，那将会引起错误
             */
            //对于对象类型的数据，深度克隆的时候需要继续调用整个对象的克隆方法【体现深度克隆】
            po.Product = (CSharpClone.Product)this.Product.CloneProduct();

            return po;
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
            string str = $"个人订单的订购人是【{CustomerName},订购的产品是【{ProductId}】,订购数量是【{productOrderNumber}】】，产品对象是【{Product}】】";
            return str;
        }

    }//Class_end
}
