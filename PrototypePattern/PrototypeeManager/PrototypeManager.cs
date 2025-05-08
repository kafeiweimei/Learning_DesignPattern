using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace PrototypePattern.PrototypeeManager
{
    internal class PrototypeManager
    {
        //定义一个字典来记录原型编号与原型实例的对应关系
        private static Dictionary<string,IPrototypeManager> dicPrototype=new Dictionary<string,IPrototypeManager>();

        //私有化构造方法，避免外部私自创建实例
        private PrototypeManager()
        {
                
        }

        /// <summary>
        /// 添加原型
        /// </summary>
        /// <param name="prototypeId">原型编号</param>
        /// <param name="prototype">原型实例</param>
        public static void AddPrototype(string prototypeId,IPrototypeManager prototype)
        {
            if (string.IsNullOrEmpty(prototypeId) || prototype == null)
            {
                string str = $"原型编号或者原型不能为空，请检查后重试！";
                Console.WriteLine(str);

                return;
            }

            if (!dicPrototype.ContainsKey(prototypeId))
            {
                dicPrototype.Add(prototypeId, prototype);
            }
            else
            {
                string str = $"当前已经存在编号为【{prototypeId}】的原型【{prototype}】,不用重复添加！！！";
                Console.WriteLine(str);
            }
        }

        /// <summary>
        /// 删除原型
        /// </summary>
        /// <param name="prototypeId">原型编号</param>
        public static void DelPrototype(string prototypeId)
        {
            if (string.IsNullOrEmpty(prototypeId))
            {
                string str = $"原型编号不能为空，请检查后重试！";
                Console.WriteLine(str);
                return;
            }

            dicPrototype.Remove(prototypeId);
            
        }

        /// <summary>
        /// 获取原型
        /// </summary>
        /// <param name="prototypeId">原型编号</param>
        /// <returns></returns>
        public static IPrototypeManager GetPrototype(string prototypeId)
        {
            IPrototypeManager prototype = null;
            if (string.IsNullOrEmpty(prototypeId))
            {
                string str = $"原型编号不能为空，请检查后重试！";
                Console.WriteLine(str);
                return prototype;
            }

            if (dicPrototype.ContainsKey(prototypeId))
            {
                prototype = dicPrototype[prototypeId];
                return prototype;
            }
            else
            {
                Console.WriteLine($"你希望获取的原型还没注册或已被销毁！！！");
                return prototype;
            }
        }

        /// <summary>
        /// 修改原型
        /// </summary>
        /// <param name="prototypeId">原型编号</param>
        /// <param name="prototype">原型实例</param>
        public static void ModifyPrototype(string prototypeId, IPrototypeManager prototype)
        {
            if (string.IsNullOrEmpty(prototypeId) || prototype == null)
            {
                string str = $"原型编号或者原型不能为空，请检查后重试！";
                Console.WriteLine(str);

                return;
            }

            if (dicPrototype.ContainsKey(prototypeId))
            {
                dicPrototype[prototypeId] = prototype; ;
            }
            else
            {
                string str = $"当前不存在编号为【{prototypeId}】的原型，无法修改！！！";
                Console.WriteLine(str);
            }
        }

    }//Class_end
}
