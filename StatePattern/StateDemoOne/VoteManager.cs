using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatePattern.StateDemoOne
{
    /// <summary>
    /// 投票管理
    /// </summary>
    internal class VoteManager
    {
        //持有状态处理对象
        private IVoteState voteState = null;

        //记录用户投票的结果<用户名称,投票选项>
        private Dictionary<string, string> voteResultDic = new Dictionary<string, string>();
        //记录用户投票次数<用户名称,投票次数>
        private Dictionary<string, int> voteCountDic = new Dictionary<string, int>();

        /// <summary>
        /// 获取记录用户投票的结果容器
        /// </summary>
        /// <returns></returns>
        public Dictionary<string, string> GetVoteResultDic()
        {
            return voteResultDic;
        }

        //投票
        public void Vote(string user,string voteItem)
        {
            int oldVoteCount = 0;
            if (!voteCountDic.ContainsKey(user))
            {
                oldVoteCount += 1;
                voteCountDic.Add(user,oldVoteCount);
            }
            else
            {
                oldVoteCount= voteCountDic[user];
                oldVoteCount += 1;
                voteCountDic[user]= oldVoteCount;
            }

            if (oldVoteCount == 1)
            {
                //voteState = new NormalVoteState();
                voteState = new NormalVoteStateExtand();
            }
            else if (oldVoteCount > 1 && oldVoteCount < 5)
            {
                voteState = new RepeatVoteState();
            }
            else if (oldVoteCount >= 5 && oldVoteCount < 8)
            {
                voteState = new SpiteVoteState();
            }
            //else if (oldVoteCount >= 8)
            //{
            //    voteState = new BlackVoteState();
            //}
            else if (oldVoteCount >= 8 && oldVoteCount < 10)
            {
                voteState = new BlackWarnVoteState();
            }
            else if (oldVoteCount >= 10)
            {
                voteState = new BlackVoteState();
            }

            //然后调用状态对象进行相应的操作
            voteState.Vote(user,voteItem,this);
        }

    }//Class_end
}
