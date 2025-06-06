using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandPattern.Macros
{
    /// <summary>
    /// 萝卜炖排骨命令
    /// </summary>
    internal class CarrotRribsCommand : ICommand
    {
        //持有具体操作的厨师对象
        private ICooker cooker = null;

        /// <summary>
        /// 设置具体做菜的厨师对象
        /// </summary>
        /// <param name="cook">做菜的厨师</param>
        public void SetCooker(ICooker cooker)
        {
            this.cooker = cooker;
        }

        //点菜的桌号
        private int tableNum = 0;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="tableNum">点菜的桌号</param>
        public CarrotRribsCommand(int tableNum)
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

        public void Execute()
        {
            this.cooker.Cook("萝卜炖排骨",tableNum);
        }

    }//Class_end
}
