using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatePattern
{
    /// <summary>
    /// 投票管理
    /// </summary>
    internal class VoteManager
    {
        //记录用户投票的结果<用户名称,投票选项>
        private Dictionary<string,string>voteResultDic= new Dictionary<string,string>();
        //记录用户投票次数<用户名称,投票次数>
        private Dictionary<string,int>voteCountDic= new Dictionary<string,int>();
        //用户投票次数
        int oldVoteCount = 0;

        /// <summary>
        /// 投票方法
        /// </summary>
        /// <param name="user">投票用户</param>
        /// <param name="voteItem">投票选项</param>
        public void Vote(string user,string voteItem)
        {
            //1-若投票次数容器不包含该用户则新增否则从容器获取后再操作
            if (!voteCountDic.ContainsKey(user))
            {
                if (oldVoteCount == 0)
                {
                    oldVoteCount += 1;
                    voteCountDic.Add(user, oldVoteCount);
                }
            }
            else
            {
                oldVoteCount= voteCountDic[user];
                if (oldVoteCount>=1)
                {
                    oldVoteCount += 1;
                    voteCountDic[user] = oldVoteCount;
                }
            }

            //判断用户投票的类型（判断是正常投票、重复投票还是恶意投票）
            if (oldVoteCount == 1)
            {
                //正常投票，则记录到投票记录
                voteResultDic.Add(user, voteItem);
                Console.WriteLine($"恭喜你【{user}】投给【{voteItem}】【{voteCountDic[user]}】票成功");
            }
            else if (oldVoteCount > 1 && oldVoteCount < 5)
            {
                //重复投票，暂不处理
                Console.WriteLine($"请不要重复投票，【{user}】已经投给【{voteItem}】票【{oldVoteCount}】次");
            } 
            else if (oldVoteCount>=5 && oldVoteCount<8)
            {
                //恶意投票，取消用户投票资格，并取消投票记录
                string voteResult = voteResultDic[user];
                if (!string.IsNullOrEmpty(voteResult))
                {
                    voteResultDic[user]="";
                }
                Console.WriteLine($"你有恶意刷票行为，取消投票资格并清空投票记录；【{user}】已投给【{voteItem}】票【{voteCountDic[user]}】次");
            }
            else if (oldVoteCount>=8)
            {
                //记入黑名单，禁止登录系统
                Console.WriteLine($"进入黑名单，禁止登录和使用本系统；【{user}】已投给【{voteItem}】票【{voteCountDic[user]}】次");
            }
            
        }


    }//Class_end
}
