using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatePattern.StateDemoTwo
{
    internal class BlackWarnVoteState : IVoteState
    {
        public void Vote(string user, string voteItem, VoteManager voteManager)
        {
            //待进入黑名单警告状态
            Console.WriteLine("禁止登录和使用系统3天");
            
            //待进入黑名单警告处理完成，维护下一个状态，投票到10次，就进入黑名单，这里的判断是大于等于9
            if (voteManager.GetVoteCountDic()[user]>=9)
            {
                if (!voteManager.GetVoteStateDic().ContainsKey(user))
                {
                    voteManager.GetVoteStateDic().Add(user, new BlackVoteState());
                }
                else
                {
                    voteManager.GetVoteStateDic()[user] = new BlackVoteState();
                }
            }
        }

    }//Class_end
}
