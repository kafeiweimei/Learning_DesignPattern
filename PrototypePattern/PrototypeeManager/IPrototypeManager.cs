using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrototypePattern.PrototypeeManager
{
    /// <summary>
    /// 原型管理器接口
    /// </summary>
    internal interface IPrototypeManager
    {
        IPrototypeManager Clone();

        string GetName();
        void SetName(string name);

    }//Interface_end
}
