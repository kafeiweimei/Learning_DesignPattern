using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactoryPattern
{
    /// <summary>
    /// 创建主板的简单工厂
    /// </summary>
    internal class MainboardFactory
    {
        /// <summary>
        /// 创建主板对象方法
        /// </summary>
        /// <param name="type">主板类型（1表示技嘉主板；2表示微星主板）</param>
        /// <returns></returns>
        public static IMainboard CreateMainboard(int type) 
        {
            IMainboard mainboard = null;
            switch (type)
            {
                case 1:
                    mainboard = new GAMainboard();
                    break;
                case 2:
                    mainboard = new MSIMainboard();
                    break;
                default:
                    break;
            }

            return mainboard;
        } 


    }//Class_end
}
