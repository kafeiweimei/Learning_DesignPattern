using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatePattern.StateDemoOne
{
    /// <summary>
    /// 正常投票
    /// </summary>
    internal class NormalVoteState : IVoteState
    {
        public void Vote(string user, string voteItem, VoteManager voteManager)
        {
            //正常投票，则记录到投票记录
            if (!voteManager.GetVoteResultDic().ContainsKey(user))
            {
                voteManager.GetVoteResultDic().Add(user,voteItem);
            }
            Console.WriteLine($"恭喜你【{user}】投给【{voteItem}】票成功");
        }
    }//Class_end
}
