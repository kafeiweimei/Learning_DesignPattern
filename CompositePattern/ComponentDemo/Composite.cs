using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompositePattern.ComponentDemo
{
    /// <summary>
    /// 组合对象，通常包含其他组合对象或者叶子对象
    /// </summary>
    internal class Composite : Component
    {
        //用来存储组合对象中包含的子组件对象
        private List<Component> componentList = null;

        //组合对象的名称
        private string name = string.Empty;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="name">组合对象的名称</param>
        public Composite(string name)
        {
            this.name = name;
        }

        public override void Add(Component child)
        {
            //延迟初始化
            if (componentList==null)
            {
                componentList = new List<Component>();
            }
            componentList.Add(child);
            //添加对父组件的引用
            child.SetParent(this);
        }

        public override List<Component> GetChildren()
        {
            return componentList;
        }

        public override Component GetComponent(int index)
        {
            if (componentList != null)
            {
                return componentList[index];
            }
            return null;
        }

        /// <summary>
        /// 输出组合对象自身的结构
        /// </summary>
        /// <param name="preStr">前缀（主要是按照层级拼接的空格，实现向后缩进）</param>
        public override void PrintStruct(string preStr)
        {
            //先把自己输出
            Console.WriteLine($"{preStr}+{name}");
            //如果包含子对象就输出
            if (componentList!=null)
            {
                preStr += " ";
                foreach (Component child in componentList)
                {
                    //递归输出每个子对象
                    child.PrintStruct(preStr);
                }
            }

        }

        public override void Remove(Component child)
        {
            if (componentList != null)
            {
                //查找需要删除的组件在集合中的索引位置
                int index=componentList.IndexOf(child);

                if (index!=-1)
                {
                    //先把被删除商品类别对象的父商品类别，设置为被删除的商品类别的子类型的父商品类别
                    foreach (var item in child.GetChildren())
                    {
                        //删除的组件对象是本实例的一个子组件对象
                        item.SetParent(this);
                        //把被删除的商品类别对象的子组件对象添加到当前实例中
                        componentList.Add(item);
                    }

                    //真正移除
                    componentList.RemoveAt(index);
                }

            }
        }
    }//Class_end
}
