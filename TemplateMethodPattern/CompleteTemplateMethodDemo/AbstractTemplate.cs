using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemplateMethodPattern.CompleteTemplateMethodDemo
{
    /// <summary>
    /// 一个较为完整的模板定义示例
    /// 注意：
    /// 《1》如果允许所有的类都可以访问这些方法，则可以将它们都定义为public
    /// 《2》如果只是子类需要访问这些方法，那就使用protected
    /// </summary>
    internal abstract class AbstractTemplate
    {
        //模板方法，定义算法骨架
        public void templateMethod()
        {
            //第一步操作
            this.OperationOne();
            //第二步操作
            this.OperationTwo();
            //第三步操作
            this.DoPrimitiveOperationOne();
            //第四步操作
            this.DoPrimitiveOperationTwo();
            //第五步操作
            this.HookOperationOne();
        }

        /// <summary>
        /// 具体操作1【算法中必要的实现步骤，是固定的，且子类不需要访问】
        /// </summary>
        private void OperationOne()
        {
            //具体的实现内容
        }

        /// <summary>
        /// 具体操作2【算法中必要的实现步骤，是固定的，且子类不需要访问】
        /// </summary>
        private void OperationTwo()
        {
            //具体的实现内容
        }

        /// <summary>
        /// 具体的AbstractClass，子类的公共功能，但通常不是具体的算法步骤
        /// </summary>
        protected virtual void CommonOperation()
        { 
            //在这里具体实现
        }

        /// <summary>
        /// 原语操作1，算法中的必要步骤，父类无法确定如何真正实现，需要子类实现
        /// </summary>
        protected abstract void DoPrimitiveOperationOne();

        /// <summary>
        /// 原语操作2，算法中的必要步骤，父类无法确定如何真正实现，需要子类实现
        /// </summary>
        protected abstract void DoPrimitiveOperationTwo();

        /// <summary>
        /// 钩子操作，算法中的步骤，不一定需要，提供默认实现，由子类选择并具体实现
        /// </summary>
        protected virtual void HookOperationOne()
        {
            //这里提供默认实现
        }

        /// <summary>
        /// 工厂方法,创建某个对象，这里用object代替，在算法实现中可能需要
        /// </summary>
        /// <returns></returns>
        protected abstract Object CreateOneObject();

    }//Class_end
}
