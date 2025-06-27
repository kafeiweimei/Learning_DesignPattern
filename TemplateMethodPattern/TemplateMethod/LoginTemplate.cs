/***
*	Title："设计模式" 项目
*		主题：模板方法模式
*	Description：
*	    基础概念：模板方法模式的本质是【固定算法骨架】
*	    模板方法模式的定义：定义一个操作中的算法的骨架，而将一些步骤延迟到子类中。模板方法使得子类可以不改变
*	        一个算法的结构即可重定义该算法的某些特定步骤
*	    
*	    认识模板方法模式：
*	        1、模板方法模式的功能：在于固定算法骨架，而让具体算法可以实现扩展（这在实际应用中非常广泛，尤其是在设计框架级功能的时候非常有用；框架定义好
*	            了算法的步骤，在合适的点让开发人员进行扩展，实现具体的算法（比如：DAO实现设计通用的增删改查功能））。
*	            模板方法模式还额外提供了一个好处，就是可以控制子类的扩展（因为在父类中定义好了算法步骤，只是在某几个固定的点才会调用到被子类
*	                实现的方法，因此也就只允许在这几个点来扩展功能【这些可以被子类覆盖以扩展功能的方法通常被称为钩子方法】）
*	        2、为何不是接口【为什么模板方法的模板不使用接口而使用抽象方法】？
*	            《1》接口是一个特殊的抽象类，所有接口中的属性自动是常量【即：public final static】而所有接口中的方法必须是抽象的。
*	            《2》抽象类简单的说是用abstract修饰的类【抽象类不一定包含抽象方法；但有抽象方法的类一定是抽象类】；
*	            《3》接口和抽象类相比较，最大的特点是【接口中所有的方法都没有具体的实现】【而抽象类中是可以有具体的实现方法的】。
*	            通常在【既要约束子类的行为，又要为子类提供公共功能的时候使用抽象类】（此处的模板方法模式需要固定定义算法的骨架，
*	                该骨架应该只有一份，算是公共行为；但是其中具体的步骤实现又可能是各不相同的，这恰好符合抽象类的原则）
*	        3、变与不变：程序设计的一个很重要思考点就是“变与不变”也就是分析程序中哪些功能是可变的，哪些是不可变的，然后把不可变的部分抽象出来，进行公共实现
*	            把变化的部分分离出去，用接口来封装隔离，或是用抽象类来约束子类行为
*	    
*	        4、好莱坞法则：简单的说就是【不要找我们，我们会联系你】
*	            模板方法模式很好的体现了这一点，作为父类的模板会在需要的时候，调用子类相应的方法，也就是由父类来找子类实现，而不是让子类找父类来实现；
*	            这也是一种反向控制结构（按照通常的思路，是子类找父类才对，也就是应该子类调用父类方法，父类根本不知道子类，而子类知道父类。
*	            但是在模板方法模式里面，则是父类找子类，所以是一种反向控制结构）
*	            
*	        5、扩展登录控制：在使用模板方法模式实现后，如果想要扩展新功能，有如下两种情况：
*	            《1》只需提供新的子类实现就可以了（如：想要切换不同的加密算法，只需要新创建一个类并覆写父类的加密方法即可，已有的实现不需要任何改动）
*	            《2》既要加入新的功能，也需要新的数据（如：现在对于普通用户登录要实现一个加强版，要求登录人员除了编号和密码外，还需要提供注册时留下的验证
*	                问题和验证答案，验证问题和验证答案记录在数据库中，而不是验证码，一般web开发中登录使用的验证码会存放到session中）
*	        
*	        6、模板的写法：在实现模板的时候，到底哪些方法实现在模板上？模板能不能全部实现了？
*	            《1》模板的方法：定义算法骨架的方法
*	            《2》具体的操作：在模板中直接实现某些步骤的方法。通常这些步骤的实现算法是固定的，而且是不怎么变化的，因此可以将其当做公共功能实现在模板中。
*	                如果不需要为子类提供访问这些方法的话，还是可以private的。这样一来，子类的实现就相对简单些。
*	                如果是子类需要访问的，可以把这些方法定义为sealed的，因为通常情况下，这些实现不能被子类覆盖和改变了。
*	            《3》具体的AbstractClass操作：在模板中实现某些公共功能，可以提提供给子类使用，一般不是具体的算法步骤实现，而是一些辅助的公共功能
*	            《4》原语操作：就是在模板中定义的抽象操作，通常是模板方法需要调用的操作，且是必须的操作，而且在父类中还没有办法确定下来如何实现，需要子类来真正实现的方法。
*	            《5》钩子操作：在模板中定义，并提供默认实现的操作，这些方法通常被视为可扩展的点，但不是必须的，子类可以有选择地覆写这些方法，以提供新的实现来扩展功能。
*	            《6》Factory Method：在模板方法中，如果需要得到某些对象实例，可以考虑通过工厂方法来获取，把具体的构建对象实现延迟到子类中去。    
*	   
*	    何时选用模板方法模式：
*	        1、需要固定定义算法骨架，实现一个算法的不变的部分，并把可变的行为留给子类来实现；
*	        2、各个子类中具有公共行为，应该抽取出来，集中在一个公共类中去实现，从而避免代码重复；
*	        3、需要控制子类扩展的情况，模板方法模式会在特定的点来调用子类的方法，这样只允许在这些点进行扩展。
*	        
*	Date：2025
*	Version：0.1版本
*	Author：Coffee
*	Modify Recoder：
 ***/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace TemplateMethodPattern.TemplateMethod
{
    /// <summary>
    /// 登录控制逻辑模板
    /// </summary>
    internal abstract class LoginTemplate
    {
        /// <summary>
        /// 登录控制逻辑
        /// </summary>
        /// <param name="loginModel">用户输入的登录数据对象</param>
        /// <returns></returns>
        public bool Login(LoginModel loginModel)
        {
            LoginModel lm = GetLoginUserInfo(loginModel.LoginId);
            if (lm != null)
            {
                //对密码进行加密
                string encryptPwd=EncryptPassword(loginModel.Password);
                loginModel.Password = encryptPwd;
                //比较是否匹配
                return IsMatch(loginModel,lm);
            }
            return false;
        }

        /// <summary>
        /// 根据登录编号获取数据库中对应编号用户的数据
        /// </summary>
        /// <param name="loginId">用户编号</param>
        /// <returns></returns>
        protected abstract LoginModel GetLoginUserInfo(string loginId);

        /// <summary>
        /// 对密码数据进行加密【这里默认不加密】
        /// </summary>
        /// <param name="password">用户输入的密码</param>
        /// <returns>返回加密后的密码</returns>
        protected virtual string EncryptPassword(string password)
        {
            return password;
        }

        /// <summary>
        /// 判断用户填写的数据与数据库中的数据是否匹配
        /// </summary>
        /// <param name="loginModel">登录对象</param>
        /// <param name="lm">数据库中的用户数据对象</param>
        /// <returns></returns>
        private bool IsMatch(LoginModel loginModel,LoginModel lm)
        {
            if (loginModel!=null && lm!=null)
            {
                if (loginModel.LoginId.Equals(lm.LoginId)&&
                    loginModel.Password.Equals(lm.Password))
                {
                    return true;
                }
            }
            return false;
        }

    }//Class_end
}
