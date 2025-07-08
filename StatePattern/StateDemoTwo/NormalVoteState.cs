using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatePattern.StateDemoTwo
{
    internal class NormalVoteState : IVoteState
    {
        public void Vote(string user, string voteItem, VoteManager voteManager)
        {
            //正常投票，则记录到投票记录
            if (!voteManager.GetVoteResultDic().ContainsKey(user))
            {
                voteManager.GetVoteResultDic().Add(user, voteItem);
            }
            Console.WriteLine($"恭喜你【{user}】投给【{voteItem}】票成功");

            //正常投票完成，维护下一个状态，同一个人在投票就重复了
            if (!voteManager.GetVoteStateDic().ContainsKey(user))
            {
                voteManager.GetVoteStateDic().Add(user, new RepeatVoteState());
            }
            else
            {
                voteManager.GetVoteStateDic()[user] = new RepeatVoteState();
            }
        }
    }//Class_end
}
