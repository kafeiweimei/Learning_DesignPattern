using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace VisitorPattern.VisitorDemoTwo
{
    /// <summary>
    /// 抽象的组件对象，相当于访问者模式中的元素对象
    /// </summary>
    abstract internal class Component
    {
        /// <summary>
        /// 接受访问者的访问
        /// </summary>
        /// <param name="visitor">访问者对象</param>
        public abstract void Accept(IVisitor visitor);

        /// <summary>
        /// 向组合对象中加入组件对象
        /// </summary>
        /// <param name="child">被加入组合对象中的组件对象</param>
        public virtual void AddChild(Component child)
        {
            //默认实现，抛出例外，叶子对象没有这个功能或子组件没有实现这个功能
            Console.WriteLine("对象不支持该功能！！！"); 
        }

        /// <summary>
        /// 从组合对象中移除组件对象
        /// </summary>
        /// <param name="child">被移除的组件对象</param>
        public virtual void RemoveChild(Component child)
        {
            //默认实现，抛出例外，叶子对象没有这个功能或子组件没有实现这个功能
            Console.WriteLine("对象不支持该功能！！！");
        }

        /// <summary>
        /// 返回某个索引对应的组件对象
        /// </summary>
        /// <param name="index">需要获取的组件对象索引，索引从0开始</param>
        /// <returns>索引对应的组件对象</returns>
        public virtual Component GetChildren(int index)
        {
            Console.WriteLine("对象不支持这个功能");
            return null;
        }

    }//Class_end
}
