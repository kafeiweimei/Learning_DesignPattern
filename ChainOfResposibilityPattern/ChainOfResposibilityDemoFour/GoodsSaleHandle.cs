using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainOfResposibilityPattern.ChainOfResposibilityDemoFour
{
    /// <summary>
    /// 商品销售管理模块处理
    /// </summary>
    internal class GoodsSaleHandle
    {
        //保存销售信息（本来销售数据应该是多条的，我们这里主要是演示职责链内容简化了）
        public bool Sale(string user,string customer,SaleModel saleModel)
        {
            /*若全部功能在这里处理，基本顺序如下*/
            //1-权限检查
            //2-通用数据检查
            //3-数据逻辑校验
            //4-真正的业务处理

            /*但现在这些功能是通过功能链来实现，这里就只用构建功能链即可*/
            SaleSecurityCheck ssc= new SaleSecurityCheck();
            SaleDataCheck sdc= new SaleDataCheck();
            SaleLogicCheck slc= new SaleLogicCheck();
            SaleMgr sm= new SaleMgr();

            ssc.Successor = sdc;
            sdc.Successor = slc;
            slc.Successor = sm;

            //向链上的第一个对象发出处理请求
           return ssc.Sale(user,customer,saleModel);
        }

    }//Class_end
}
