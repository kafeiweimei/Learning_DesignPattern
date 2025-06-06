using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandPattern.Macros
{
    /// <summary>
    /// 厨师接口
    /// </summary>
    internal interface ICooker
    {
        /// <summary>
        //示意做菜的方法
        /// </summary>
        /// <param name="name">菜品名称</param>
        /// <param name="tableNum">点菜的桌号</param>
        void Cook(string name,int tableNum);


    }//Interface_end
}
