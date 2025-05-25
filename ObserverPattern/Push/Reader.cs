using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverPattern.Push
{
    /// <summary>
    /// 读者对象
    /// </summary>
    internal class Reader : IObserver
    {
        //读者姓名
        private string name;

        public string Name { get => name; set => name = value; }

        public Reader()
        {
            
        }

        public Reader(string name)
        {
            this.name = name;
        }

        public void Push(string info)
        {
            //被动接收推送来的消息
            string str = $"【{name}】你好，你订阅的报纸有新内容了，内容是【{info}】";
            Console.WriteLine(str);
        }


    }//Class_end
}
