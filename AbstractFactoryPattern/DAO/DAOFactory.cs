using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactoryPattern.DAO
{
    /// <summary>
    /// 抽象工厂，创建主订单、子订单对应的DAO对象
    /// </summary>
    abstract class DAOFactory
    {
        //创建主订单记录对应的DAO对象
        public abstract IOrderMainDAO CreateOrderMainDAO();

        //创建子订单记录对应的DAO对象
        public abstract IOrderDetailDAO CreateOrderDetailDAO();

    }//Class_end
}
