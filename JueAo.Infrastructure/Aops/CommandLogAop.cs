
using Castle.DynamicProxy;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JueAo.Infrastructure.Aops
{
    public class CommandLogAop : IInterceptor
    {
        private readonly ILogger m_logger;

        public CommandLogAop(/*ILogger logger*/)
        {
            //m_logger = logger;
        }

        public void Intercept(IInvocation invocation)
        {
            try
            {
                System.Diagnostics.Trace.WriteLine($"Command {invocation.Method.Name} executed");

                invocation.Proceed();
                //m_logger.LogInformation($"Command {invocation.Method.Name} executed");
            }
            catch (Exception ex)
            {
                //m_logger.LogError($"Command {invocation.Method.Name} failed: {ex.Message}");
                
            }
        }
    }
}
