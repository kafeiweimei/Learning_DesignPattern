using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactoryPattern.DAO
{
    internal class RdbDAOFactory : DAOFactory
    {
        public override IOrderMainDAO CreateOrderMainDAO()
        {
            return new RdbOrderMainDAOImpl();
        }

        public override IOrderDetailDAO CreateOrderDetailDAO()
        {
            return new RdbDetailDAOImpl();
        }


    }//Class_end
}
