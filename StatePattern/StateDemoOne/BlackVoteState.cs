using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatePattern.StateDemoOne
{
    internal class BlackVoteState : IVoteState
    {
        public void Vote(string user, string voteItem, VoteManager voteManager)
        {
            //记入黑名单，禁止登录系统
            Console.WriteLine($"进入黑名单，禁止登录和使用本系统；【{user}】已投给【{voteItem}】票");
        }
    }//Class_end
}
