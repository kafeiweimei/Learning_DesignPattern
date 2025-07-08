using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatePattern.StateDemoTwo
{
    /// <summary>
    /// 投票管理
    /// </summary>
    internal class VoteManager
    {
        //持有状态处理对象
        private IVoteState voteState = null;

        //记录当前每个用户对应的状态处理对象，每个用户当前的状态是不同的<用户名称,当前对应的状态处理对象>
        private Dictionary<string,IVoteState> voteStateDic = new Dictionary<string,IVoteState>();

        //记录用户投票的结果<用户名称,投票的选项>
        private Dictionary<string ,string> voteResultDic= new Dictionary<string ,string>();

        //记录用户投票的次数
        private Dictionary<string,int>voteCountDic= new Dictionary<string ,int>();



        //获取用户状态的容器
        public Dictionary<string, IVoteState> GetVoteStateDic()
        {
            return voteStateDic;
        }

        //获取用户投票的结果容器
        public Dictionary<string, string> GetVoteResultDic()
        {
            return voteResultDic;
        }

        //获取用户投票的次数容器
        public Dictionary<string, int> GetVoteCountDic()
        {
            return voteCountDic;
        }

        //投票
        public void Vote(string user,string voteItem)
        {
            int oldVoteCount = 0;
            //1-先为该用户增加投票次数
            if (!voteCountDic.ContainsKey(user))
            {
                oldVoteCount += 1;
                voteCountDic.Add(user, oldVoteCount);
            }
            else
            {
                oldVoteCount = voteCountDic[user];
                oldVoteCount += 1;
                voteCountDic[user] = oldVoteCount;
            }
            //2-获取该用户的投票状态
            voteState = new NormalVoteState();
            //如果没有投票状态，说明还没有投过票，那就初始化一个正常的投票状态
            if (!voteStateDic.ContainsKey(user))
            {
                voteStateDic.Add(user, voteState);
            }
            else
            {
                voteState=voteStateDic[user];
            }

            //调用投票方法进行操作
            voteState.Vote(user,voteItem,this);
        }


    }//Class_end
}
