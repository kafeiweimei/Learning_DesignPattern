using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompositePattern.CompositeDemo
{
    /// <summary>
    /// 组合对象【包含其他组合对象、叶子对象】
    /// </summary>
    internal class Composite:Component
    {
        //组合对象名称
        private string name = string.Empty;

        //用来存储组合对象中包含的子组件对象
        private List<Component> componentList = null;

        public Composite(string name)
        {
            this.name = name;
        }

        public override void Add(Component child)
        {
            if (componentList==null)
            {
                componentList=new List<Component>();
            }
            componentList.Add(child);
        }

        public override Component GetComponent(int index)
        {
            throw new NotImplementedException();
        }

        public override void PrintStruct(string preStr)
        {
            Console.WriteLine($"{preStr}+{name}");
            if (componentList!=null && componentList.Count>0)
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
            
        }
    }//Class_end
}
