using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrototypePattern.PrototypeeManager
{
    internal class ConcreatePrototype1 : IPrototypeManager
    {
        private string name;

        public IPrototypeManager Clone()
        {
            ConcreatePrototype1 cp=new ConcreatePrototype1();
            cp.SetName(name);
            return cp;
        }

        public string GetName()
        {
            return name;
        }

        public void SetName(string name)
        {
           this.name = name;
        }

        public override string ToString()
        {
            string str = $"这是具体的原型一，名称是【{name}】";
            return str;
        }

    }//Class_end
}
