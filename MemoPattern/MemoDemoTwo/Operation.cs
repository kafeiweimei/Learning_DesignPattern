using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoPattern.MemoDemoTwo
{
    /// <summary>
    /// 具体的运算类，真正实现加减法运算
    /// </summary>
    internal class Operation : IOperation
    {
        //记录运算结果
        private int result = 0;

        public void Add(int num)
        {
            result += num;
        }

        public IMemo CreateMemo()
        {
            MemoImpl memoImpl = new MemoImpl(result);
            return memoImpl;
        }

        public int GetResult()
        {
            return result;
        }

        public void SetMemo(IMemo memo)
        {
            MemoImpl memoImpl = (MemoImpl)memo;
            this.result = memoImpl.GetResult();
        }

        public void Substract(int num)
        {
            result -= num;
        }

        #region 备忘录对象实现
        private class MemoImpl : IMemo
        {
            private int result = 0;

            public MemoImpl(int result)
            {
                this.result = result;
            }

            public int GetResult()
            {
                return result;
            }
        }

        #endregion




    }//Class_end
}
