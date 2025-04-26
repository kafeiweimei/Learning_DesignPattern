using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactoryPattern.DAO
{
    /// <summary>
    /// 主订单对应的DAO操作接口
    /// </summary>
    internal interface IOrderMainDAO
    {
        //保存主订单记录
        void SaveOrderMain();

    }//Interface_end
}
