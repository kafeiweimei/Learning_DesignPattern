using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrototypePattern.CSharpClone
{
    /// <summary>
    /// 产品对象
    /// </summary>
    internal class Product : IProductPrototype
    {
        //产品编号
        public string? ProductId;
        //产品名称
        public string? ProductName;

        public IProductPrototype CloneProduct()
        {
            //创建一个新订单，然后把本实例的数据复制过去
            Product product = new Product();
            product.ProductId = ProductId;
            product.ProductName = ProductName;
            return product;
        }

        public override string ToString()
        {
            string str = $"产品编号【{ProductId}】产品名称【{ProductName}】";
            return str;
        }

    }//Class_end
}
