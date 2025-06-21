using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompositePattern
{
    /// <summary>
    /// 组合对象，可以包含其他组合对象或叶子对象
    /// </summary>
    internal class Composite
    {
        //用来记录包含的其他组合对象
        private List<Composite> compositeList = new List<Composite>();
        //用来记录包含的其他叶子对象
        private List<Leaf> leafList = new List<Leaf>();

        //组合对象的名称
        private string name = string.Empty;

        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="name">组合对象的名称</param>
        public Composite(string name)
        {
            this.name = name;      
        }

        /// <summary>
        /// 向组合对象加入被它包含的其他组合对象
        /// </summary>
        /// <param name="composite">被它包含的其他组合对象</param>
        public void AddComposite(Composite composite)
        {
            compositeList.Add(composite);
        }

        /// <summary>
        /// 向组合对象加入被它包含的叶子对象
        /// </summary>
        /// <param name="leaf">被它包含的叶子对象</param>
        public void AddLeaf(Leaf leaf)
        {
            leafList.Add(leaf);
        }

        /// <summary>
        /// 输出组合对象自身的结构
        /// </summary>
        /// <param name="preStr">前缀【主要是按照层级拼接的空格，实现向后缩进】</param>
        public void PrintStruct(string preStr)
        {
            Console.WriteLine($"{preStr}+{this.name}");

            preStr += " ";
            foreach (Leaf leaf in leafList)
            {
                leaf.PrintStruct(preStr);
            }

            //输出当前对象的子对象
            foreach (var item in compositeList)
            {
                item.PrintStruct(preStr);
            }
        }

    }//Class_end
}
