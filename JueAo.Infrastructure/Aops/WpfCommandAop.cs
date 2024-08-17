using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace JueAo.Infrastructure.Aops
{
    /// <summary>
    /// WPF 命令拦截器
    /// </summary>
    public class WpfCommandAop : IInterceptor
    {
        public void Intercept(IInvocation invocation)
        {
            MethodInfo methodInfo = invocation.MethodInvocationTarget?? invocation.Method;
        }
    }
}
