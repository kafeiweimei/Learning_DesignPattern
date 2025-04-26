using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactoryPattern.DAO
{
    /// <summary>
    /// XML主订单记录的具体实现
    /// </summary>
    internal class XMLOrderMainDAOImpl : IOrderMainDAO
    {
        public void SaveOrderMain()
        {
            Console.WriteLine($"现在是XML实现主订单记录保存");
        }

    }//Class_end
}
