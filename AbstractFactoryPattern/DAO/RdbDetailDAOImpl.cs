using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactoryPattern.DAO
{
    /// <summary>
    /// 关系数据库子订单记录的具体实现
    /// </summary>
    internal class RdbDetailDAOImpl : IOrderDetailDAO
    {
        public void SaveOrderDetail()
        {
            Console.WriteLine($"现在是关系数据库保存子订单记录");
        }

    }//Class_end
}
