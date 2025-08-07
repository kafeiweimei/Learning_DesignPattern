
namespace DecoratorPattern
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //NoPattern();
            //TestDecoratorDemoOne();
            //TestObjectCompositon();
            TestDecoratorDemoTwo();

            Console.ReadLine();
        }

        /// <summary>
        /// 不使用模式的测试
        /// </summary>
        private static void NoPattern()
        {
            Console.WriteLine("------不使用模式的测试------");

            //创建奖金规则对象
            NoPattern.PrizeRule prizeRule = new NoPattern.PrizeRule();

            DateTime start = Convert.ToDateTime("2025-07-01");
            DateTime end = Convert.ToDateTime("2025-07-31");

            double prize_zs = prizeRule.CaculatePrize("张三",start,end);
            Console.WriteLine($"======张三应得的奖金是【{prize_zs}】\n");
            double prize_ls = prizeRule.CaculatePrize("李四",start,end);
            Console.WriteLine($"======李四应得的奖金是【{prize_ls}】\n");
            double prize_ww = prizeRule.CaculatePrize("王五",start,end);
            Console.WriteLine($"======王五经理应得的奖金是【{prize_ww}】\n");
        }

        /// <summary>
        /// 装饰器模式示例1测试
        /// </summary>
        private static void TestDecoratorDemoOne()
        {
            Console.WriteLine("------装饰器模式示例1测试------");
            //先获取数据库内容
            DecoratorDemoOne.TempDB.FillDatas();

            //1-创建计算基本奖金的类（这也是被装饰的对象）
            DecoratorDemoOne.PrizeRuleOne prizeRuleOne=new DecoratorDemoOne.PrizeRuleOne();

            //2-计算基本奖金装饰（这里需要组合各个装饰：各个装饰者之间最好是不要有先后顺序的限制）

            //组合普通业务人员的奖金计算
            DecoratorDemoOne.Decorator d1 = new DecoratorDemoOne.MonthPrizeDecorator(prizeRuleOne);
            DecoratorDemoOne.Decorator d2=new DecoratorDemoOne.SumPrizeDecorator(d1);

            //注意：这里只需使用最后组合好的对象调用业务方法即可，会依次调用回去
            DateTime start = Convert.ToDateTime("2025-08-01");
            DateTime end = Convert.ToDateTime("2025-08-31");

            double prize_zs = d2.CaculatePrize("张三",start,end);
            Console.WriteLine($"======张三应得奖金【{prize_zs}】\n");
            double prize_ls = d2.CaculatePrize("李四",start,end);
            Console.WriteLine($"======李四应得奖金【{prize_ls}】\n");

            //若是业务经理，还需要计算团队奖金
            DecoratorDemoOne.Decorator d3 =new DecoratorDemoOne.GroupPrizeDecorator(d2);
            double prize_ww = d3.CaculatePrize("王五",start,end);
            Console.WriteLine($"======王五经理应得奖金【{prize_ww}】\n");
        }

        /// <summary>
        /// 组合对象测试
        /// </summary>
        private static void TestObjectCompositon()
        {
            ObjectCompositon.B11 b11= new ObjectCompositon.B11();

            b11.SetD(new ObjectCompositon.D());
            b11.B3();

            b11.B2();

            b11.B1();
            
        }

        /// <summary>
        /// 装饰器模式示例2测试
        /// </summary>
        private static void TestDecoratorDemoTwo()
        {
            Console.WriteLine("------装饰器模式示例2测试------");

            //得到业务接口，组合装饰器
            DecoratorDemoTwo.IGoodsSaleEbi ebi = new DecoratorDemoTwo.CheckDecorator(
                new DecoratorDemoTwo.LogDecorator(new DecoratorDemoTwo.GoodsSaleEbo()));

            //准备测试
            DecoratorDemoTwo.SaleModel saleModel= new DecoratorDemoTwo.SaleModel();
            saleModel.Goods = "华为P80Pro";
            saleModel.SaleNumber = 6;

            //调用业务功能
            ebi.Sale("张三","周茜",saleModel);
            ebi.Sale("李四","李思",saleModel);

        }

    }//Class_end
}
