using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisitorPattern.VisitorDemoOne
{
    /// <summary>
    /// 对象结构，通常这里对元素对象进行遍历，让访问者能访问到所有元素
    /// </summary>
    internal class ObjectStructure
    {
        //要操作的客户列表
        private List<Customer> tmpList = new List<Customer>();

        /// <summary>
        /// 提供给客户端操作的高层接口，具体的功能由客户端传入的访问者决定
        /// </summary>
        /// <param name="visitor">客户端需要使用的访问者</param>
        public void HandleRequest(IVisitor visitor)
        {
            foreach (var customer in tmpList)
            {
                customer.Accept(visitor);
            }
            
        }

        /// <summary>
        /// 组件对象结构，向对象结构中添加元素（不同对象结构有不同的构建方式）
        /// </summary>
        /// <param name="customer">需加入的对象</param>
        public void AddElement(Customer customer)
        {
            this.tmpList.Add(customer);
        }


    }//Class_end
}
