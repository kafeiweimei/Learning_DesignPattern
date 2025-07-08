using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatePattern.StateDemoOne
{
    internal class BlackWarnVoteState : IVoteState
    {
        public void Vote(string user, string voteItem, VoteManager voteManager)
        {
            //待进入黑名单警告状态
            Console.WriteLine("禁止登录和使用系统3天");
        }
    }//Class_end
}
