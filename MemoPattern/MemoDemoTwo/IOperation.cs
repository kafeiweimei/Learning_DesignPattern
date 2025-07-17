using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoPattern.MemoDemoTwo
{
    /// <summary>
    /// 操作运算的接口
    /// </summary>
    internal interface IOperation
    {
        //获取计算完成后的结果
        int GetResult();

        //执行加法
        void Add(int num);

        //执行减法
        void Substract(int num);

        //创建保存原发器对象状态的备忘录对象
        IMemo CreateMemo();

        //重新设置原发器对象状态，让其回到备忘录对象记录的状态
        void SetMemo(IMemo memo);


    }//Interface_end
}
