using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisitorPattern.VisitorDemoTwo
{
    /// <summary>
    /// 组合对象，可以包含其他组合对象或叶子对象
    /// 相当于访问者模式的具体Element实现对象
    /// </summary>
    internal class CompositeExtand : Composite
    {
        public CompositeExtand(string name) : base(name)
        {
        }

        public override void Accept(IVisitor visitor)
        {
            //在这里只用回调访问方法即可，不用遍历所有子元素
           visitor.VisitComposite(this);
        }

        /// <summary>
        /// 新增方法【获取其包含的子组件】
        /// </summary>
        /// <returns></returns>
        public List<Component> GetChildComponent()
        {
            return base.componentList;
        }

    }//Class_end
}
