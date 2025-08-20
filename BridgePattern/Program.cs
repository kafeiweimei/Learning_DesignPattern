namespace BridgePattern
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //NoPatternTest();
            BridgeDemoOneTest();
            Console.ReadLine();
        }

        /// <summary>
        /// 不使用模式的示例
        /// </summary>
        private static void NoPatternTest()
        {
            Console.WriteLine("------不使用模式的示例------");
            //使用站内消息方式发送【普通】消息
            NoPattern.IMessage message = new NoPattern.CommonMsgSMS();
            message.Send("请你吃饭", "张三");
            //使用站内消息方式发送【加急】消息
            message = new NoPattern.UrgencyMsgSMS();
            message.Send("请你吃饭", "张三");
            Console.WriteLine();

            //使用邮件的方式发送【普通】消息
            message = new NoPattern.CommonMsgEmail();
            message.Send("请你吃饭", "张三");
            //使用邮件的方式发送【加急】消息
            message = new NoPattern.UrgencyMsgEmail();
            message.Send("请你吃饭", "张三");
        }

        /// <summary>
        /// 桥接模式示例1
        /// </summary>
        private static void BridgeDemoOneTest()
        {
            Console.WriteLine("------桥接模式示例1------");
            /*把发送消息实现方式切换为站内信*/
            //创建具体的实现对象
            BridgeDemoOne.IMessage messageStyle = new BridgeDemoOne.MsgSMS();

            //创建一个普通的消息对象
            BridgeDemoOne.AbstractMessage abstarctMessage=new BridgeDemoOne.CommonMsg(messageStyle);
            abstarctMessage.SendMsg("请你吃饭","张三");

            //创建一个紧急消息对象
            abstarctMessage=new BridgeDemoOne.UrgencyMsg(messageStyle);
            abstarctMessage.SendMsg("请你吃饭","张三");

            //创建一个特急消息对象
            abstarctMessage = new BridgeDemoOne.SpecialUrgencyMsg(messageStyle);
            abstarctMessage.SendMsg("请你吃饭", "张三");
            Console.WriteLine();


            /*把发送消息实现方式切换为邮件*/
            //创建具体的实现对象
            messageStyle=new BridgeDemoOne.MsgEmail();

            //创建一个普通的消息对象
            abstarctMessage = new BridgeDemoOne.CommonMsg(messageStyle);
            abstarctMessage.SendMsg("请你吃饭", "张三");

            //创建一个紧急消息对象
            abstarctMessage = new BridgeDemoOne.UrgencyMsg(messageStyle);
            abstarctMessage.SendMsg("请你吃饭", "张三");

            //创建一个特急消息对象
            abstarctMessage = new BridgeDemoOne.SpecialUrgencyMsg(messageStyle);
            abstarctMessage.SendMsg("请你吃饭", "张三");

        }

    }//Class_end
}
