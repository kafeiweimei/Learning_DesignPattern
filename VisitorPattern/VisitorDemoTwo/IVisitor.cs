using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisitorPattern.VisitorDemoTwo
{
    /// <summary>
    /// 访问组合对象结构的访问者接口
    /// </summary>
    internal interface IVisitor
    {
        /// <summary>
        /// 访问组合对象，相当于给组合对象添加访问者的功能
        /// </summary>
        /// <param name="composite">组合对象</param>
        void VisitComposite<T>(T composite);

        /// <summary>
        /// 访问叶子对象，相当于给叶子对象添加访问者的功能
        /// </summary>
        /// <param name="leaf">叶子对象</param>
        void VisitLeaf<T>(T leaf);

    }//Interface_end
}
