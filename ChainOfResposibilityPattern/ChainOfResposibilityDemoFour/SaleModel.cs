using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainOfResposibilityPattern.ChainOfResposibilityDemoFour
{
    /// <summary>
    /// 销售模型
    /// </summary>
    internal class SaleModel
    {
        /// <summary>
        /// 销售商品
        /// </summary>
        public string GoodsName { get; set; }=string.Empty;

        /// <summary>
        /// 销售数量
        /// </summary>
        public int SaleNumber { get; set; } = 0;

        public override string ToString()
        {
            string str = $"商品名称【{GoodsName}】销售数量【{SaleNumber}】";
            return str ;
        }

    }//Class_end
}
