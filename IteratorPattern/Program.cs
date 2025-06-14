namespace IteratorPattern
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //GetPaySalaryTest();

            //GetPaySalaryAggregateTest();

            //PageTurningTest();

            RandomPageTurningTest();

            Console.ReadLine();
        }

        /// <summary>
        /// 获取到支付薪水的测试
        /// </summary>
        private static void GetPaySalaryTest()
        {
            Console.WriteLine("---获取到支付薪水的测试---");
            //访问集团的工资列表
            PayManager payManager = new PayManager();
            //先计算在获取
            payManager.CaculatePay();
            List<PayModel> payModelList= payManager.GetPayModels();
            Console.WriteLine("---集团的工资列表信息：");
            foreach (var payModel in payModelList)
            {
                Console.WriteLine(payModel);
            }

            //访问新收购公司的工资列表
            SalaryManager salaryManager = new SalaryManager();
            salaryManager.CaculatePay();
            PayModel[] payModelsArray = salaryManager.GetPayModels();
            Console.WriteLine("---新收购公司的工资信息：");
            foreach (var payModel in payModelsArray)
            {
                Console.WriteLine(payModel);
            }
        }

        /// <summary>
        /// 获取到支付薪水的聚合测试
        /// </summary>
        private static void GetPaySalaryAggregateTest()
        {
            Console.WriteLine("---获取到支付薪水的聚合测试---");
            //访问集团的工资列表
            AggregateOne.PayManager payManager = new AggregateOne.PayManager();
            //先计算再获取
            payManager.CaculatePay();
            Console.WriteLine("---集团的工资列表信息：");
            Print(payManager.CreateIterator());

            //访问新收购公司的工资列表
            AggregateOne.SalaryManager salaryManager = new AggregateOne.SalaryManager();
            salaryManager.CaculatePay();
            Console.WriteLine("---新收购公司的工资信息：");
            Print(salaryManager.CreateIterator());

        }
        private static void Print(AggregateOne.Itetator it)
        {
            //循环输出聚合对象中的值
            //首先设置迭代器到第一个元素
            it.First();
            while (!it.IsDone())
            {
                //取出当前的元素
                object obj = it.CurrentItem();
                Console.WriteLine($"当前对象是【{obj}】");
                //如果没有迭代到最后则继续向下迭代
                it.Next();
            }

        }


        /// <summary>
        /// 测试翻页
        /// </summary>
        private static void PageTurningTest()
        {
            Console.WriteLine("---测试翻页---");
            //访问新收购公司的工资列表
            PageTurning.SalaryManager salaryManager = new PageTurning.SalaryManager();
            salaryManager.CaculatePay();
            //得到翻页迭代器
            PageTurning.IAggregateIterator ir=salaryManager.CreateIterator();

            //获取第一页，每页显示2条
            List<object> list = ir.Next(2);
            Console.WriteLine($"第一页数据：");
            Print2(list);

            //获取第二页，每页显示2条
            List<object> list2 = ir.Next(2);
            Console.WriteLine($"第二页数据：");
            Print2(list2);

            //向前翻一页（即再次获取第二页）
            List<object> list3 = ir.Previous(2);
            Console.WriteLine($"再次获取第二页数据：");
            Print2(list3);
        }
        private static void Print2(List<object> list)
        {
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
        }

        /// <summary>
        /// 测试随机翻页
        /// </summary>
        private static void RandomPageTurningTest()
        {
            Console.WriteLine("---测试随机翻页---");

            //访问新收购公司的工资列表
            RandomPageTurning.SalaryManager salaryManager = new RandomPageTurning.SalaryManager();
            //先计算工资数据
            salaryManager.CaculatePay();
            //得到翻页迭代器
            RandomPageTurning.IAggregationIterator<RandomPageTurning.PayModel> it = (RandomPageTurning.IAggregationIterator<RandomPageTurning.PayModel>)salaryManager.CreateIterator();


            //获取第一页数据，每页显示2条
            RandomPageTurning.PayModel[] payModelArray1 = it.GetPageDatas(1,2);
            Console.WriteLine($"第一页的数据是:");
            Print3(payModelArray1);

            //获取第二页数据，每页显示2条
            RandomPageTurning.PayModel[] payModelArray2 = it.GetPageDatas(2, 2);
            Console.WriteLine($"第二页的数据是:");
            Print3(payModelArray2);

            //获取第一页数据，每页显示2条
            RandomPageTurning.PayModel[] payModelArray3 = it.GetPageDatas(1, 2);
            Console.WriteLine($"第一页的数据是:");
            Print3(payModelArray3);

            //获取第三页数据，每页显示2条
            RandomPageTurning.PayModel[] payModelArray4 = it.GetPageDatas(3, 2);
            Console.WriteLine($"第三页的数据是:");
            Print3(payModelArray4);

        }

        private static void Print3(RandomPageTurning.PayModel[] payModelArray)
        {
            foreach (var item in payModelArray)
            {
                Console.WriteLine(item);
            }
        }


    }//Class_end
}
