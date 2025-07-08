using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatePattern.StateDemoOne
{
    internal class NormalVoteStateExtand:NormalVoteState,IVoteState
    {
        public new void Vote(string user, string voteItem, VoteManager voteManager)
        {
            //先调用已有的功能
            base.Vote(user, voteItem, voteManager);
            //然后在给与积分奖励
            Console.WriteLine("奖励积分10分");
        }

    }//Class_end
}
