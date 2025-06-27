using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemplateMethodPattern.TemplateMethodSort
{
    /// <summary>
    /// 用户模型
    /// </summary>
    internal class UserModel
    {
        public string? Id { get; set; } = Guid.NewGuid().ToString("N");
        public string? Name { get; set; }
        public int Age { get; set; }

        public UserModel(string name,int age)
        {
            this.Name= name;
            this.Age= age;
        }

        public override string ToString()
        {
            string str = $"编号【{this.Id}】姓名【{this.Name}】年龄【{this.Age}】";
            return str ;
        }

    }//Class_end
}
