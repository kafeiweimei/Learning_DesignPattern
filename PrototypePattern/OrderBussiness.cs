using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrototypePattern
{
    /// <summary>
    /// 处理订单的业务对象
    /// </summary>
    internal class OrderBussiness
    {
        //固定的数量
        private const int fixedNumber = 1000;

        /// <summary>
        /// 保存订单
        /// </summary>
        /// <param name="order">订单</param>
        public void SaveOrder(IOrder order)
        {
            /*根据业务要求，当预订产品的数量大于1000时，就需要把订单拆分为两份*/

            //1、判断订单是否大于1000（若大于1000则拆分订单）
            while (order.GetOrderProductNumber()>1000)
            {
                //2.创建一份新订单，这份订单传入的订单除了数量不一样，其他都相同
                IOrder newOrder = null;
                if (order is PersonalOrder)
                {
                    //创建相应的新订单对象
                    PersonalOrder newPO = new PersonalOrder();
                    //将传入订单的数据赋值给新订单对象
                    PersonalOrder po = (PersonalOrder)order;
                    newPO.CustomerName = po.CustomerName;
                    newPO.ProductId = po.ProductId;
                    newPO.SetOrderProductNumber(fixedNumber);
                    //将个人订单对象内容赋值给新订单
                    newOrder = newPO;
                }
                else if (order is EnterpriseOrder)
                { 
                    EnterpriseOrder newEO = new EnterpriseOrder();
                    EnterpriseOrder eo = (EnterpriseOrder)order;
                    newEO.EnterpriseName = eo.EnterpriseName;
                    newEO.ProductId = eo.ProductId;
                    newEO.SetOrderProductNumber(fixedNumber);
                    newOrder=newEO;
                }

                //3、设置拆分后的订单数量
                order.SetOrderProductNumber(order.GetOrderProductNumber() - fixedNumber);

                //4、处理业务功能
                Console.WriteLine($"拆分生成的订单是【{newOrder}】");

            }
            //订单数量不超过1000的直接执行业务处理
            Console.WriteLine($"拆分生成的订单是【{order}】");

        }


    }//Class_end
}
