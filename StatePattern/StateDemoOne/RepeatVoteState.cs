using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatePattern.StateDemoOne
{
    /// <summary>
    /// 重复投票
    /// </summary>
    internal class RepeatVoteState : IVoteState
    {
        public void Vote(string user, string voteItem, VoteManager voteManager)
        {
            //重复投票，不做处理
            Console.WriteLine($"请不要重复投票，【{user}】已经投给【{voteItem}】票");
        }
    }//Class_end
}
