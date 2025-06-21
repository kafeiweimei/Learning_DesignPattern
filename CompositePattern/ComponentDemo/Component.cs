using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompositePattern.ComponentDemo
{
    /// <summary>
    /// 抽象的组件对象
    /// </summary>
    internal abstract class Component
    {
        //父组件对象
        private Component parent = null;

        /// <summary>
        /// 获取一个组件的父组件对象
        /// </summary>
        /// <returns></returns>
        public Component GetParent()
        {
            return parent;
        }

        /// <summary>
        /// 设置一个组件的父组件对象
        /// </summary>
        /// <param name="parent">父组件对象</param>
        public void SetParent(Component parent)
        {
            this.parent = parent;
        }

        //返回某个组件的子组件对象
        public abstract List<Component> GetChildren();

        //输出组件自己的名称
        public abstract void PrintStruct(string preStr);

        //向组合对象中加入组件对象
        public abstract void Add(Component child);

        //从组合对象中移除某个组件对象
        public abstract void Remove(Component child);

        //返回某个索引对应的组件对象
        public abstract Component GetComponent(int index);

    }//Class_end
}
