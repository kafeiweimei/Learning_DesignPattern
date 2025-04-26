using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactoryPattern.DAO
{
    internal class XmlDAOFactory : DAOFactory
    {
        public override IOrderMainDAO CreateOrderMainDAO()
        {
            return new XMLOrderMainDAOImpl();
        }

        public override IOrderDetailDAO CreateOrderDetailDAO()
        {
            return new XMLDetailDAOImpl();
        }


    }//Class_end
}
