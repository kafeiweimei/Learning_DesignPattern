using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandPattern.Macros
{
    /// <summary>
    /// 北京烤鸭对象
    /// </summary>
    internal class PekingDuckCommand : ICommand
    {
        //持有真正做菜的厨师对象
        private ICooker cooker = null;

        /// <summary>
        /// 设置具体做菜的厨师
        /// </summary>
        /// <param name="cooker">做菜的厨师</param>
        public void SetCooker(ICooker cooker)
        {
            this.cooker = cooker;   
        }
        public void Execute()
        {
            this.cooker.Cook("北京烤鸭",tableNum);
        }

        //点菜的桌号
        private int tableNum = 0;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="tableNum">点菜的桌号</param>
        public PekingDuckCommand(int tableNum)
        {
            this.tableNum = tableNum;
        }

        /// <summary>
        /// 获取点菜的桌号
        /// </summary>
        /// <returns></returns>
        public int GetTableNumber()
        {
            return this.tableNum;
        }

    }//Class_end
}
