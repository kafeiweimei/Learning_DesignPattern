using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlyweightPattern.FlyweightDemoTwo
{
    /// <summary>
    /// 享元接口【通过这个接口可以接受并作用于外部状态】
    /// </summary>
    internal interface IFlyweight
    {
        /// <summary>
        /// 判断传入的安全实体和权限是否与享元对象内部状态匹配
        /// </summary>
        /// <param name="securityEntity">安全实体</param>
        /// <param name="permit">权限</param>
        /// <returns>true：表示匹配</returns>
        bool Math(string securityEntity, string permit);

        /// <summary>
        /// 为享元接口添加子享元对象
        /// </summary>
        /// <param name="fw">被添加的子享元对象</param>
        void Add(IFlyweight fw);

    }//Interface_end
}
