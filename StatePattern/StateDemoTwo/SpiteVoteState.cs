using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatePattern.StateDemoTwo
{
    internal class SpiteVoteState : IVoteState
    {
        public void Vote(string user, string voteItem, VoteManager voteManager)
        {
            //恶意投票，取消用户投票资格，并取消投票记录
            if (voteManager.GetVoteResultDic().ContainsKey(user))
            {
                voteManager.GetVoteResultDic()[user] = "";
            }
            Console.WriteLine($"你有恶意刷票行为，取消投票资格并清空投票记录；【{user}】已投给【{voteItem}】票");

            //恶意投票完成，维护下一个状态，投票到8次则进入黑名单，这里的判断是大于等于7
            if (voteManager.GetVoteCountDic()[user]>=7)
            {
                if (!voteManager.GetVoteStateDic().ContainsKey(user))
                {
                    //voteManager.GetVoteStateDic().Add(user, new BlackVoteState());
                    voteManager.GetVoteStateDic().Add(user, new BlackWarnVoteState());
                }
                else
                {
                    //voteManager.GetVoteStateDic()[user] = new BlackVoteState();
                    voteManager.GetVoteStateDic()[user] = new BlackWarnVoteState();
                }
            }
        }
    }//Class_end
}
