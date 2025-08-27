using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisitorPattern.VisitorDemoTwo
{
    /// <summary>
    /// 具体的访问者，实现：输出对象的名称，在组合读写的名称前面添加"节点"，在叶子对象的名称前面添加"叶子"
    /// </summary>
    internal class PrintNameVisitor : IVisitor
    {

        public void VisitComposite<T>(T composite)
        {

            Composite ce= composite as Composite;
            if (ce!=null)
            {
                //访问到组合对象的数据
                Console.WriteLine($"节点【{ce.GetName}】");
            }
           
        }

        public void VisitLeaf<T>(T leaf)
        {
            Leaf lf= leaf as Leaf;
            if (lf!=null)
            {
                Console.WriteLine($"叶子【{lf.GetName}】");
            }
        }
    }//Class_end
}
