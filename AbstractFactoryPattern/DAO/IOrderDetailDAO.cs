using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactoryPattern.DAO
{
    /// <summary>
    /// 子订单对应的DAO操作记录
    /// </summary>
    internal interface IOrderDetailDAO
    {
        //保存子订单记录
        void SaveOrderDetail();

    }//Interface_end
}
