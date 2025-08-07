using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecoratorPattern.DecoratorDemoTwo
{
    /// <summary>
    /// 需要和被装饰的对象实现同样的接口（装饰器接口）
    /// </summary>
    abstract internal class Decorator1 : IGoodsSaleEbi
    {
        //被装饰的对象
        protected IGoodsSaleEbi ebi;

        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="ebi">被装饰的对象</param>
        public Decorator1(IGoodsSaleEbi ebi)
        {
            this.ebi = ebi;
        }

        public virtual bool Sale(string user, string customer, SaleModel saleModel)
        {
            return ebi.Sale(user, customer, saleModel);
        }
    }//Class_end
}
