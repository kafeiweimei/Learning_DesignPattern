/***
*	Title："设计模式" 项目
*		主题：代理模式
*	Description：
*	        需求：现在有一个订单系统，要求是：一旦订单被创建，只有订单的创建人才可以修改订单中的数据，其他人则不能去修改；
* 
*	Date：2025
*	Version：0.1版本
*	Author：Coffee
*	Modify Recoder：
 ***/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProxyPattern.ProtectProxy
{
    /// <summary>
    /// 订单代理对象
    /// </summary>
    internal class OrderProxy : IOrder
    {
        //持有被代理的具体目标对象
        private Order order = null;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="realSubject">被代理的具体目标对象</param>
        public OrderProxy(Order realSubject)
        {
             this.order = realSubject;   
        }

        public int GetOrderNumber()
        {
            return this.order.GetOrderNumber();
        }

        public string GetOrderUser()
        {
            return this.order.GetOrderUser();
        }

        public string GetProductName()
        {
            return this.order.GetProductName();
        }

        public void SetOrderNumber(int orderNumber, string user)
        {
            //控制访问权限，只有创建订单的人员才能够修改
            if (!string.IsNullOrEmpty(user) && user.Equals(this.GetOrderUser()))
            {
                order.SetOrderNumber(orderNumber, user);
            }
            else
            {
                Console.WriteLine($"抱歉【{user}】，您无权修改订单中的产品数量");
            }
        }

        public void SetOrderUser(string orderUser, string user)
        {
            //控制访问权限，只有创建订单的人员才能够修改
            if (!string.IsNullOrEmpty(user) && user.Equals(this.GetOrderUser()))
            {
                order.SetOrderUser(orderUser, user);
            }
            else
            {
                Console.WriteLine($"抱歉【{user}】，您无权修改订单中的创建人员");
            }
        }

        public void SetProductName(string productName, string user)
        {
            //控制访问权限，只有创建订单的人员才能够修改
            if (!string.IsNullOrEmpty(user) && user.Equals(this.GetOrderUser()))
            {
                order.SetProductName(productName, user);
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
