using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisitorPattern.VisitorDemoTwo
{
    /// <summary>
    /// 对象结构，通常这里对元素对象进行遍历，让访问者能访问到所有元素
    /// </summary>
    internal class ObjectStructure
    {
        //表示对象结构，可以是一个组合结构
        private Component root = null;

        /// <summary>
        /// 提供客户端操作的高层接口
        /// </summary>
        /// <param name="visitor">客户端需要使用的访问者</param>
        public void HandleRequest(IVisitor visitor)
        {
            //让组合对象结构中的根元素，接受访问，在组合对象结构中已经实现元素遍历
            if (root != null)
            {
                root.Accept(visitor);
            }
        }

        /// <summary>
        /// 传入组合对象结构
        /// </summary>
        /// <param name="component">组合对象结构</param>
        public void SetRoot(Component component)
        {
            this.root = component;
        }

    }//Class_end
}
