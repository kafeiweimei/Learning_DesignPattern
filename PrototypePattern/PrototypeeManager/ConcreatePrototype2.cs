using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrototypePattern.PrototypeeManager
{
    internal class ConcreatePrototype2 : IPrototypeManager
    {
        private string name;

        public IPrototypeManager Clone()
        {
            ConcreatePrototype2 cp=new ConcreatePrototype2();
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
            string str = $"这是具体的原型二，名称是【{name}】";
            return str;
        }

    }//Class_end
}
