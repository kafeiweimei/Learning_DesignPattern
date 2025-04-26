using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactoryPattern.DAO
{
    /// <summary>
    /// 关系数据库主订单DAO的具体实现
    /// </summary>
    internal class RdbOrderMainDAOImpl : IOrderMainDAO
    {
        public void SaveOrderMain()
        {
            Console.WriteLine($"现在是关系数据库保存主订单记录");
        }
    }//Class_end
}
