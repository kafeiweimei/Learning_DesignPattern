using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactoryPattern.DAO
{
    /// <summary>
    /// XML子订单记录的具体实现
    /// </summary>
    internal class XMLDetailDAOImpl : IOrderDetailDAO
    {
        public void SaveOrderDetail()
        {
            Console.WriteLine($"现在是XML实现子订单记录的保存");
        }

    }//Class_end
}
