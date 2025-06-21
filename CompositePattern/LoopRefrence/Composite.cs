using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompositePattern.LoopRefrence
{
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
            if (componentList == null)
            {
                componentList = new List<Component>();
            }
            componentList.Add(child);

            //判断组件路径是否为空（若为空则本组件是根组件）
            if (string.IsNullOrEmpty(this.GetComponentPath) || this.GetComponentPath.Trim().Length==0)
            {
                //把本组件的name设置大组件路径中
                this.SetComponentPath(this.name);
            }
            //判断要加入的组件在路径上是否出现过
            if (this.GetComponentPath.StartsWith(child.GetName() + "."))
            {
                //说明是根组件，重复添加了
                throw new Exception($"在本通路【{this.GetComponentPath}】上，组件【{child.GetName()}】已经被添加过了");
            }
            else
            {
                if (this.GetComponentPath.IndexOf("." + child.GetName()) <= 0)
                {
                    //表示没有出现过，可以添加
                    //计算组件的路径
                    string componentPath = $"{this.GetComponentPath}.{child.GetName()}";
                    //设置子组件的路径
                    child.SetComponentPath(componentPath);
                }
                else
                {
                    throw new Exception($"在本通路【{this.GetComponentPath}】上，组件【{child.GetName()}】已经被添加过了");
                }
            }

        }

        public override List<Component> GetAllChildren()
        {
            return componentList;
        }

        public override Component GetChild(int index)
        {
           return componentList[index];
        }

        public override string GetName()
        {
            return this.name;
        }

        public override void PrintStruct(string preStr)
        {
            Console.WriteLine($"{preStr}+{name}");
            if (componentList!=null)
            {
                preStr += " ";
                foreach (Component child in componentList)
                {
                    child.PrintStruct(preStr);
                }
            }
        }

        public override void Remove(Component child)
        {
            if (componentList!=null)
            {
                int index = componentList.IndexOf(child);

                if (index!=-1)
                {
                    //先把被删除的商品类别对象的父商品类别，设置为被删除商品类别的子类别的父商品类别
                    foreach (var item in child.GetAllChildren())
                    {
                        //删除的组件对象是本实例的一个子组件对象
                        item.SetParent(this);
                        componentList.Add(item);
                    }
                    //真正删除
                    componentList.RemoveAt(index);
                }
            }
        }
    }//Class_end
}
