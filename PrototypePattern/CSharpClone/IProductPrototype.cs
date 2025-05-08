using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrototypePattern.CSharpClone
{
    /// <summary>
    /// 定义一个克隆产品自身的接口
    /// </summary>
    internal interface IProductPrototype
    {
        //克隆产品自身的方法
        IProductPrototype CloneProduct();

    }//Interface_end
}
