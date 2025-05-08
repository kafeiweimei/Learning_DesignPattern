using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrototypePattern.CSharpClone
{
    /// <summary>
    /// 产品对象
    /// </summary>
    internal class Product2 : ICloneable
    {
        //产品编号
        public string? ProductId;
        //产品名称
        public string? ProductName;

        public object Clone()
        {
            //直接使用C#的克隆方法，不用自己手动给属性逐一赋值
            object obj = base.MemberwiseClone();
            return obj;
        }

        public override string ToString()
        {
            string str = $"产品编号【{ProductId}】产品名称【{ProductName}】";
            return str;
        }

    }//Class_end
}
