using ProxyPattern.ProtectProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProxyPattern.ModifyProxy
{
    /// <summary>
    /// 订单代理对象
    /// </summary>
    internal class OrderProxy : Order
    {
        public static OrderProxy instance;//单例

        public OrderProxy(string productName, int orderNumber, string orderUser) : base(productName, orderNumber, orderUser)
        {
            if (instance == null)
            {
                instance = this;
            }
            else
            {
                Console.WriteLine($"{GetType()}/OrderProxy()函数不允许重复实例化！！！");
            }
        }

        public override void SetOrderNumber(int orderNumber, string user)
        {
            //控制访问权限，只有创建订单的人员才能够修改
            if (!string.IsNullOrEmpty(user) && user.Equals(this.GetOrderUser()))
            {
                base.SetOrderNumber(orderNumber, user);
            }
            else
            {
                Console.WriteLine($"抱歉【{user}】，您无权修改订单中的产品数量");
            }
        }

        public override void SetOrderUser(string orderUser, string user)
        {
            //控制访问权限，只有创建订单的人员才能够修改
            if (!string.IsNullOrEmpty(user) && user.Equals(this.GetOrderUser()))
            {
                base.SetOrderUser(orderUser, user);
            }
            else
            {
                Console.WriteLine($"抱歉【{user}】，您无权修改订单中的创建人员");
            }
        }

        public override void SetProductName(string productName, string user)
        {
            //控制访问权限，只有创建订单的人员才能够修改
            if (!string.IsNullOrEmpty(user) && user.Equals(this.GetOrderUser()))
            {
                base.SetProductName(productName, user);
            }
            else
            {
                Console.WriteLine($"抱歉【{user}】，您无权修改订单中的产品名称");
            }
        }


        public override string ToString()
        {
            string str = $"订单订购的产品名称是【{GetProductName()}】数量是【{GetOrderNumber()}】创建订单的人员是【{GetOrderUser()}】";
            return str;
        }

    }//Class_end
}
