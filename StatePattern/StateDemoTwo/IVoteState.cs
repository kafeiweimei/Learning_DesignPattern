using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatePattern.StateDemoTwo
{
    /// <summary>
    /// 投票状态接口（规范投票状态对外的相关行为）
    /// </summary>
    internal interface IVoteState
    {
        //处理状态对象的行为
        void Vote(string user,string voteItem,VoteManager voteManager);

    }//Interface_end
}
