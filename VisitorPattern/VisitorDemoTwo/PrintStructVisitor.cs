using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisitorPattern.VisitorDemoTwo
{
    /// <summary>
    /// 具体的访问者，实现：输出组合对象自身的结构
    /// </summary>
    internal class PrintStructVisitor : IVisitor
    {
        //前缀
        private string preStr = "";

        public void VisitComposite<T>(T composite)
        {
            CompositeExtand ce = composite as CompositeExtand;
            if (ce != null)
            {
                //先把自己输出
                Console.WriteLine($"{preStr}{ce.GetName}");
                //若还包含子组件，则输出这些子组件对象
                if (ce.GetChildComponent().Count>0)
                {
                    //然后添加一个空格，表示向后缩进一个空格
                    preStr += " ";
                    //输出当前对象的子对象
                    foreach (var item in ce.GetChildComponent())
                    {
                        item.Accept(this);
                    }

                    //把循环子对象多加入的一个空格去掉
                    preStr=preStr.Substring(0, preStr.Length-1);
                }
            }
        }

        public void VisitLeaf<T>(T leaf)
        {
            Leaf lf = leaf as Leaf;
            if (lf != null)
            {
                Console.WriteLine($"{preStr}-{lf.GetName}");
            }
        }
    }//Class_end
}
