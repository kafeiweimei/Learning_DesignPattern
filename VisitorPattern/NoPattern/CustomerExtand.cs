using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisitorPattern.NoPattern
{
    /// <summary>
    /// 客户的父类扩展
    /// </summary>
    abstract internal class CustomerExtand:Customer
    {
        /// <summary>
        /// 新增客户对公司产品的偏好分析
        /// </summary>
        public abstract void PredilectionAnalyze();

        /// <summary>
        /// 客户价值分析
        /// </summary>
        public abstract void WorthAnalyze();


    }//Class_end
}
