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
    internal class Composite : Component
    {
        //用来存储组合对象中包含的子组件对象
        protected List<Component> componentList=new List<Component>();
        //组合对象的名称
        protected string name=string.Empty;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="name">组合对象的名称</param>
        public Composite(string name)
        {
            this.name = name;
        }

        public string GetName
        {
            get { return name; }
        }

        public override void Accept(IVisitor visitor)
        {
            //回调访问者对象的对应方法
            visitor.VisitComposite(this);
            //循环子元素，让子元素也接受访问
            foreach (var item in componentList)
            {
                //调用子对象接受访问，变相实现递归
                item.Accept(visitor);
            }
        }

        public override void AddChild(Component child)
        {
           componentList?.Add(child);
        }

        public override void RemoveChild(Component child)
        {
            componentList?.Remove(child);
        }

        public override Component GetChildren(int index)
        {
            return componentList[index];
        }

    }//Class_end
}
