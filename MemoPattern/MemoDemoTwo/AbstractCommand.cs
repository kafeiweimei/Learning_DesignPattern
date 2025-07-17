using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoPattern.MemoDemoTwo
{
    /// <summary>
    /// 命令对象的公共对象，实现各个命令对象的公共方法
    /// </summary>
    abstract internal class AbstractCommand : ICommand
    {
        //持有真正的命令实现对象
        protected IOperation operation = null;

        public void SetOperation(IOperation operation)
        {
            this.operation=operation;
        }


        public IMemo CreateMemo()
        {
            return this.operation.CreateMemo();
        }

        public virtual void Execute()
        {
            //具体的功能实现,抽象类这里就不提供默认实现，让具体类自己实现
            throw new NotImplementedException();
        }

        public void Redo(IMemo memo)
        {
            this.operation.SetMemo(memo);
        }

        public void Undo(IMemo memo)
        {
            this.operation.SetMemo(memo);
        }
    }//Class_end
}
