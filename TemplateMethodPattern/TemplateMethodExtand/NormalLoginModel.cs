using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemplateMethodPattern.TemplateMethodExtand
{
    internal class NormalLoginModel : LoginModel
    {
        //密保问题和答案
        public string? Question { get; set; }

        public string? Answer { get; set; }

    }//Class_end
}
