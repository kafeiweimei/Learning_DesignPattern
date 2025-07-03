
namespace StrategyPattern
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //PriceStrategyDemoTest();
            //SlarayPayStrategyTest();
            //LogRecordStrategyTest();
            LogRecordStrategyTest2();
            Console.ReadLine();
        }


        /// <summary>
        /// 价格策略示例测试
        /// </summary>
        private static void PriceStrategyDemoTest()
        {
            Console.WriteLine("------价格策略示例测试------");
            //商品价格原价
            double goodsPrice = 1000;
            Console.WriteLine($"商品的原价是【{goodsPrice}】\n");

            ////1-选择并创建需要使用的策略对象【普通用户或新客户策略】
            //StrategyDemo.IStrategy strategy = new StrategyDemo.NormalCustomerStrategy();
            ////2-创建上下文
            //StrategyDemo.Price price = new StrategyDemo.Price(strategy);
            ////3-计算报价
            //double caculatePrice = price.Quote(goodsPrice);
            //Console.WriteLine($"报价是【{caculatePrice}】");

            ////老客户策略
            //strategy = new StrategyDemo.OldCustomerStrategy();
            //price = new StrategyDemo.Price(strategy);
            //caculatePrice = price.Quote(goodsPrice);
            //Console.WriteLine($"报价是【{caculatePrice}】");

            ////大客户策略
            //strategy = new StrategyDemo.LargeCustomerStrategy();
            //price = new StrategyDemo.Price(strategy);
            //caculatePrice = price.Quote(goodsPrice);
            //Console.WriteLine($"报价是【{caculatePrice}】");

            //普通用户报价
            CaculatePrice(goodsPrice,new StrategyDemo.NormalCustomerStrategy());

            //老客户报价
            CaculatePrice(goodsPrice,new StrategyDemo.OldCustomerStrategy());

            //大客户策略
            CaculatePrice(goodsPrice,new StrategyDemo.LargeCustomerStrategy());

            //新增的战略合作客户策略
            CaculatePrice(goodsPrice, new StrategyDemo.CooperateCustomerStragegy());

        }

        private static void CaculatePrice(double goodsPrice,StrategyDemo.IStrategy strategy)
        {
            //1-获取到具体的策略
            if (strategy == null) return;
            //2-创建上下文
            StrategyDemo.Price price = new StrategyDemo.Price(strategy);
            //3-计算报价
            double caculatePrice = price.Quote(goodsPrice);
            Console.WriteLine($"报价是【{caculatePrice}】");
        }

        /// <summary>
        /// 工资支付策略测试
        /// </summary>
        private static void SlarayPayStrategyTest()
        {
            Console.WriteLine("------工资支付策略测试------");

            //1-创建相应的支付策略
            StrategyDemoTwo.IPayStrategy payStrategy_RMB = new StrategyDemoTwo.RMBCashPay();
            StrategyDemoTwo.IPayStrategy payStrategy_Dollar=new StrategyDemoTwo.DollarCashPay();

            //2-准备小李的支付工资上下文
            StrategyDemoTwo.PayContext payContext1 = new StrategyDemoTwo.PayContext("张三",8000,payStrategy_RMB);

            //3-向小李支付工资
            payContext1.PayNow();

            //切换一个人支付工资
            StrategyDemoTwo.PayContext payContext2 = new StrategyDemoTwo.PayContext("Jack",6000,payStrategy_Dollar);
            payContext2.PayNow();

            //测试新添加的银行卡支付1
            StrategyDemoTwo.IPayStrategy payStrategy_Card = new StrategyDemoTwo.CardPay();
            StrategyDemoTwo.PayContext payContext3 = new StrategyDemoTwo.PayContextExtand("李四", 12000, "010998877656", payStrategy_Card);
            payContext3.PayNow();

            //测试新添加的银行卡支付2
            StrategyDemoTwo.IPayStrategy payStrategy_Card2 = new StrategyDemoTwo.CardPay2("010998877656");
            StrategyDemoTwo.PayContext payContext4 = new StrategyDemoTwo.PayContext("王五", 9500, payStrategy_Card2);
            payContext4.PayNow();

        }

        /// <summary>
        /// 日志记录策略测试
        /// </summary>
        private static void LogRecordStrategyTest()
        {
            Console.WriteLine($"------日志记录策略测试------");
            StrategyDemoThree.LogContext logContext= new StrategyDemoThree.LogContext();
            logContext.Log("记录日志");
            logContext.Log("再次记录日志");

        }

        /// <summary>
        /// 日志记录策略测试2
        /// </summary>
        private static void LogRecordStrategyTest2()
        {
            Console.WriteLine($"------日志记录策略测试------");
            StrategyDemoFour.LogContext logContext = new StrategyDemoFour.LogContext();
            logContext.Log("记录日志");
            logContext.Log("再次记录日志");

        }

    }//Class_end
}
