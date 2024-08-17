using Castle.Core.Internal;
using Castle.DynamicProxy;
using JueAo.Infrastructure.Attributes;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace JueAo.Infrastructure.Aops
{
    public class CommandLogAop : IInterceptor
    {
        private readonly ILogger m_logger;

        public string Info { get; set; } = string.Empty;

        public CommandLogAop(/*ILogger logger*/)
        {
            //m_logger = logger;
        }

        public void Intercept(IInvocation invocation)
        {
            try
            {
                var method = invocation.MethodInvocationTarget ?? invocation.Method;
                if (method.GetCustomAttribute<LogAttributes>(true) is LogAttributes logAttributes)
                {
                    if (logAttributes.IsIngore)
                    {
                        return;
                    }

                    System.Diagnostics.Trace.WriteLine($"========={logAttributes.Info}=====>>Command {invocation.Method.Name} executed");

                    invocation.Proceed();

                    System.Diagnostics.Trace.WriteLine($"Command {invocation.Method.Name} executed<<==============");

                }
                else
                {
                    System.Diagnostics.Trace.WriteLine($"----------------Command {invocation.Method.Name} executed");

                    invocation.Proceed();

                    System.Diagnostics.Trace.WriteLine($"Command {invocation.Method.Name} executed----------------");

                    //m_logger.LogInformation($"Command {invocation.Method.Name} executed");
                }


            }
            catch (Exception ex)
            {
                //m_logger.LogError($"Command {invocation.Method.Name} failed: {ex.Message}");
                
            }
        }
    }
}
