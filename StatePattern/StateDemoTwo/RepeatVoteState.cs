using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatePattern.StateDemoTwo
{
    internal class RepeatVoteState : IVoteState
    {
        public void Vote(string user, string voteItem, VoteManager voteManager)
        {
            //重复投票，不做处理
            Console.WriteLine($"请不要重复投票，【{user}】已经投给【{voteItem}】票");

            //重复投票完成，维护下一个状态，重复投票到5次，就算恶意投票了；注意这里是判断大于等于4，因为在这里设置的是下一个状态
            if (voteManager.GetVoteCountDic()[user]>=4)
            {
                if (!voteManager.GetVoteStateDic().ContainsKey(user))
                {
                    voteManager.GetVoteStateDic().Add(user, new SpiteVoteState());
                }
                else
                {
                    voteManager.GetVoteStateDic()[user]=new SpiteVoteState();
                }
            }
        }
    }//Class_end
}
