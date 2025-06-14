using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IteratorPattern.PageTurning
{
    /// <summary>
    /// 工资描述模型对象
    /// </summary>
    internal class PayModel
    {
        /// <summary>
        /// 支付工资的人员
        /// </summary>
        public string? UserName { get; set; }

        /// <summary>
        /// 支付的工资数额
        /// </summary>
        public double Pay { get; set; }

        public override string ToString()
        {
            string str = $"用户【{UserName}】的工资是【{Pay}】";
            return str;
        }


    }//Class_end
}
