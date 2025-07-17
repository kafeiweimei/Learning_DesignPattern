using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoPattern.MemoDemoTwo
{
    /// <summary>
    /// 计算器对象（计算器上的加法、减法、撤销、恢复按钮）【相当于备忘录对象的管理者】
    /// </summary>
    internal class Calculator
    {
        //命令操作的历史记录（在撤销时使用）
        private List<ICommand> undoCmdList=new List<ICommand>();
        //命令被撤销的历史记录（在恢复时使用）
        private List<ICommand> redoCmdList=new List<ICommand>();


        //命令操作对应的备忘录对象的历史记录，在撤销时使用
        //（数组有两个元素，第一个是命令执前的状态；第二个是命令执行后的状态）
        private List<IMemo[]>undoMemoList=new List<IMemo[]>();

        //被撤销命令对应的备忘录对象的历史记录，在恢复时使用
        //（数组有两个元素，第一个是命令执行前的状态，第二个是命令执行后的状态）
        private List<IMemo[]>redoMemoList=new List<IMemo[]>();

        //加法命令
        private ICommand addCmd = null;
        //减法命令
        private ICommand subCmd = null;

        /// <summary>
        /// 设置操作为加法
        /// </summary>
        /// <param name="command"></param>
        public void SetAddCmd(ICommand command)
        {
            this.addCmd = command;
        }

        /// <summary>
        /// 设置操作为减法
        /// </summary>
        /// <param name="command"></param>
        public void SetSubCmd(ICommand command)
        {
            this.subCmd = command;
        }

        /// <summary>
        /// 加法按钮逻辑
        /// </summary>
        public void AddPressed()
        {
            //获取对应的备忘录对象，并保存在相应的历史记录中
            IMemo memo1 = this.addCmd.CreateMemo();

            //执行命令
            this.addCmd.Execute();
            //将操作记录到历史记录中
            this.undoCmdList.Add(this.addCmd);

            //获取执行命令后的备忘录对象
            IMemo memo2 = this.addCmd.CreateMemo();
            //设置到撤销历史记录中
            this.undoMemoList.Add(new IMemo[] { memo1,memo2});

        }


        /// <summary>
        /// 减法按钮逻辑
        /// </summary>
        public void SubPressed()
        {
            //获取对应的备忘录对象，并保存到相应的历史记录中
            IMemo memo1=this.subCmd.CreateMemo();

            //执行命令
            this.subCmd.Execute();
            //把操作记录到历史记录中
            undoCmdList.Add(this.subCmd);

            //获取执行命令后的备忘录对象
            IMemo memo2=this.subCmd.CreateMemo();
            //设置到撤销的历史记录中
            this.undoMemoList.Add(new IMemo[] {memo1,memo2 });
        }

        /// <summary>
        /// 撤销按钮
        /// </summary>
        public void UndoPressed()
        {
            if (undoCmdList.Count > 0)
            {
                //取出最后一个命令来撤销
                ICommand cmd = undoCmdList[undoCmdList.Count - 1];
                //获取对应的备忘录对象
                IMemo[] memos = undoMemoList[undoCmdList.Count - 1];

                //撤销
                cmd.Undo(memos[0]);

                //如果还有恢复功能，那就把这个命令记录到恢复的历史记录中
                redoCmdList.Add(cmd);
                //把相应的备忘录对象也添加到恢复备忘录列表中
                redoMemoList.Add(memos);

                //将最后的命令删除
                undoCmdList.Remove(cmd);
                //将相应的备忘录对象也删除
                undoMemoList.Remove(memos);
            }
            else
            {
                Console.WriteLine("很抱歉，已经没有可撤销的命令了");
            }
        }

        /// <summary>
        /// 恢复按钮
        /// </summary>
        public void RedoPressed()
        {
            if (redoCmdList.Count > 0)
            {
                //取出最后一个命令来重做
                ICommand cmd = redoCmdList[redoCmdList.Count - 1];
                //获取相应的备忘录对象
                IMemo[] memos = redoMemoList[redoCmdList.Count - 1];

                //重做
                cmd.Redo(memos[1]);

                //将这个命令记录到可撤销的历史记录中
                undoCmdList.Add(cmd);
                //把相应的备忘录对象也添加到撤销列表中
                undoMemoList.Add(memos);

                //将最后一个命令删除
                redoCmdList.Remove(cmd);
                //将对应的备忘录对象也删除
                redoMemoList.Remove(memos);

            }
            else
            {
                Console.WriteLine("很抱歉，已经没有可恢复的命令了");
            }
        }

    }//Class_end
}
