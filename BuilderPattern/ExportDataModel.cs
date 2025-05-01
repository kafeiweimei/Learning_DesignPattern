using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuilderPattern
{
    /// <summary>
    /// 描述输出数据的对象
    /// </summary>
    internal class ExportDataModel
    {
        //产品编号
        private string? productId;
        //销售价格
        private double price;
        //销售数量
        private double amount;

        public string ProductId { get => productId; set => productId = value; }
        public double Price { get => price; set => price = value; }
        public double Amount { get => amount; set => amount = value; }

    }//Class_end
}
