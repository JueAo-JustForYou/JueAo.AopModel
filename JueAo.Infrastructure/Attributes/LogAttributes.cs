using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JueAo.Infrastructure.Attributes
{

    [AttributeUsage(AttributeTargets.Method, Inherited = true)]
    public class LogAttributes : Attribute
    {
        public bool IsIngore { get; set; }

        public string Info { get; set; } = string.Empty;
    }
}
