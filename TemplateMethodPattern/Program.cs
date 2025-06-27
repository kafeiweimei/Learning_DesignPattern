
namespace TemplateMethodPattern
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //LoginTest();
            //LoginTemplateTest();
            //LoginTemplateExtandTest();
            //LoginTemplateInvokeTest();
            ListSortTest();

            Console.ReadLine();
        }


        /// <summary>
        /// 测试
        /// </summary>
        private static void LoginTest()
        {
            Console.WriteLine("---未使用模板方法模式登录展示---");
            LoginModel loginModel = new LoginModel();
            loginModel.UserId = "test";
            loginModel.Password = "123456789";

            NormalLogin normalLogin = new NormalLogin();
            bool res_normalLogin=normalLogin.Login(loginModel);
            Console.WriteLine($"普通用户登录前台结果【{res_normalLogin}】");

            WorkerLogin workerLogin = new WorkerLogin();
            bool res_workerLogin=workerLogin.Login(loginModel);
            Console.WriteLine($"工作人员登录后台结果【{res_workerLogin}】");

            Console.WriteLine("\n修改密码后展示");
            loginModel.Password = "123456";
            res_normalLogin = normalLogin.Login(loginModel);
            Console.WriteLine($"普通用户登录前台结果【{res_normalLogin}】");
            res_workerLogin = workerLogin.Login(loginModel);
            Console.WriteLine($"工作人员登录后台结果【{res_workerLogin}】");

        }

        /// <summary>
        /// 登录模板测试
        /// </summary>
        private static void LoginTemplateTest()
        {
            Console.WriteLine("\n------使用模板方法模式登录展示------");
            TemplateMethod.LoginModel loginModel = new TemplateMethod.LoginModel();
            loginModel.LoginId = "Test";
            loginModel.Password = "123456789";

            TemplateMethod.LoginTemplate normalLogin = new TemplateMethod.NormalLogin();
            TemplateMethod.LoginTemplate workerLogin = new TemplateMethod.WorkerLogin();

            bool res_normalLogin = normalLogin.Login(loginModel);
            Console.WriteLine($"普通用户登录前台结果【{res_normalLogin}】");

            bool res_workerLogin = workerLogin.Login(loginModel);
            Console.WriteLine($"工作人员登录后台结果【{res_workerLogin}】");

            Console.WriteLine("\n修改密码后展示");
            loginModel.Password = "123456";
            res_normalLogin = normalLogin.Login(loginModel);
            Console.WriteLine($"普通用户登录前台结果【{res_normalLogin}】");
            res_workerLogin = workerLogin.Login(loginModel);
            Console.WriteLine($"工作人员登录后台结果【{res_workerLogin}】");

        }

        /// <summary>
        /// 登录模板拓展测试
        /// </summary>
        private static void LoginTemplateExtandTest()
        {
            Console.WriteLine("\n-----登录模板拓展测试-----");
            TemplateMethodExtand.NormalLoginModel normalLoginModel = new TemplateMethodExtand.NormalLoginModel();
            normalLoginModel.LoginId="Test";
            normalLoginModel.Password= "123456";
            normalLoginModel.Question = "你读过的一所学校名称是？";
            normalLoginModel.Answer = "xxx大学";

            TemplateMethodExtand.LoginTemplate normalLoginExtand= new TemplateMethodExtand.NormalLoginExtand();

            bool res_normalLoginExtand=normalLoginExtand.Login(normalLoginModel);
            Console.WriteLine($"普通人员的拓展登录结果【{res_normalLoginExtand}】");

            //修改问题答案与数据库不一致后
            normalLoginModel.Answer = "xxx高中";
            bool res_normalLoginExtand2 = normalLoginExtand.Login(normalLoginModel);
            Console.WriteLine($"修改后普通人员的拓展登录结果【{res_normalLoginExtand2}】");

        }

        /// <summary>
        /// 登录模板回调测试
        /// </summary>
        private static void LoginTemplateInvokeTest()
        {
            Console.WriteLine("\n------登录模板回调测试------");
            TemplateMethodInvoke.LoginModel loginModel=new TemplateMethodInvoke.LoginModel();
            loginModel.LoginId="Test";
            loginModel.Password = "123456";

            TemplateMethodInvoke.LoginTemplate loginTemplate=new TemplateMethodInvoke.LoginTemplate();

            bool res_normalLogin = loginTemplate.Login(loginModel, new TemplateMethodInvoke.NormalLogin());
            Console.WriteLine($"进行普通用户登录结果【{res_normalLogin}】");

            bool res_workerLogin = loginTemplate.Login(loginModel, new TemplateMethodInvoke.WorkerLogin());
            Console.WriteLine($"工作人员登录结果【{res_workerLogin}】");

            Console.WriteLine("\n修改密码后展示");
            loginModel.Password = "123456789";
            res_normalLogin = loginTemplate.Login(loginModel, new TemplateMethodInvoke.NormalLogin());
            Console.WriteLine($"进行普通用户登录结果【{res_normalLogin}】");

            res_workerLogin = loginTemplate.Login(loginModel, new TemplateMethodInvoke.WorkerLogin());
            Console.WriteLine($"工作人员登录结果【{res_workerLogin}】");

        }

        /// <summary>
        /// 列表排序测试
        /// </summary>
        private static void ListSortTest()
        {
            Console.WriteLine("------列表排序测试------");
            TemplateMethodSort.ListSort listSort= new TemplateMethodSort.ListSort();
            listSort.SortTest();
        }

    }//Class_end
}
