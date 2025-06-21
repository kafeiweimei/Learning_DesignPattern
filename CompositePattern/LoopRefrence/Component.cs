using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompositePattern.LoopRefrence
{
    /// <summary>
    /// 抽象的组件对象
    /// </summary>
    internal abstract class Component
    {
        //记录每个组件的路径
        private string componentPath = string.Empty;

        //获取组件的路径
        public virtual string GetComponentPath { get { return componentPath; } }

        //设置组件的路径
        public virtual void SetComponentPath(string componentPath)
        {
            this.componentPath = componentPath;
        }

        //获取组件名称
        public abstract string GetName();

        //记录父组件对象
        private Component parent = null;

        //获取组件的父组件对象
        public Component GetParent() { return parent; }

        //设置组件的父组件对象
        public void SetParent(Component parent) 
        { 
            this.parent = parent; 
        }

        //获取某个组件的所有子组件对象
        public abstract List<Component> GetAllChildren();

        //输出组件自己的名称
        public abstract void PrintStruct(string preStr);

        //向组合对象中加入组件对象
        public abstract void Add(Component child);

        //从组合对象中移除某个组件对象
        public abstract void Remove(Component child);

        //返回某个索引对应的组件对象
        public abstract Component GetChild(int index);

    }//Class_end
}
