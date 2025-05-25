using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverPattern.Pull
{
    /// <summary>
    /// 具体的读者对象
    /// </summary>
    internal class Reader : IObserver
    {
        //读者名称
        private string? name;

        public string Name { get => name; set => name = value; }

        public Reader()
        {  
        }

        public Reader(string name)
        {
            this.name = name;
        }

        public void Pull(Subject subject)
        {
            //主动拉去信息，看是否有新的报纸信息
            string newsPaperInfo = ((NewsPaper)subject).GetInfo();

            Console.WriteLine($"【{name}】你好，收到新报纸了，你现在可以点击阅读，内容是【{newsPaperInfo}】");
        }
    }//Class_end
}
