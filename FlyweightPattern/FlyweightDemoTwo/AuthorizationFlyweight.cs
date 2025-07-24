using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlyweightPattern.FlyweightDemoTwo
{
    /// <summary>
    /// 封装授权数据库中重复出现的享元对象
    /// </summary>
    internal class AuthorizationFlyweight : IFlyweight
    {
        //内部安全实体
        private string securityEntity = string.Empty;
        //内部权限
        private string permit = string.Empty;

        /// <summary>
        /// 安全实体可供外部访问，但不让外部修改
        /// </summary>
        public string SecurityEntity { get => securityEntity; }

        /// <summary>
        /// 权限可供外部访问，但不让外部修改
        /// </summary>
        public string Permit { get => permit; }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="state">状态数据【包含安全实体和权限用逗号分隔】</param>
        public AuthorizationFlyweight(string state)
        {
            if (!string.IsNullOrEmpty(state))
            {
                if (state.Contains(','))
                {
                    string[] strArray = state.Split(',');
                    securityEntity = strArray[0];
                    permit = strArray[1];
                }
            }
        }

        /// <summary>
        /// 匹配实体和权限
        /// </summary>
        /// <param name="securityEntity"></param>
        /// <param name="permit"></param>
        /// <returns></returns>
        public bool Math(string securityEntity, string permit)
        {
            if (string.IsNullOrEmpty(securityEntity) || string.IsNullOrEmpty(permit))
            {
                return false;
            }

            if (this.securityEntity.Equals(securityEntity) && this.permit.Equals(permit))
            {
                return true;
            }

            return false;
        }

        public override string ToString()
        {
            string str = $"【{SecurityEntity}】拥有【{Permit}】权限";
            return str;
        }

        public void Add(IFlyweight fw)
        {
            throw new Exception("对象不支持这个功能");
        }
    }//Class_end
}
