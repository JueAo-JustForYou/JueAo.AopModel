using PostSharp.Aspects;
using PostSharp.Serialization;
using System.Diagnostics;

namespace JueAo.Infrastructure.Attributes
{
    [PSerializable]
    [AttributeUsage(AttributeTargets.Method , AllowMultiple = true, Inherited = true)]
    public class PostLogAttribute : OnMethodBoundaryAspect
    {
        public PostLogAttribute()
        {
        }

        public override void OnEntry(MethodExecutionArgs args)
        {
            var parameters = args.Method.GetParameters();

            var printInfo = $"方法：{args.Method.Name}，开始执行，时间：{DateTime.Now}";

            Trace.TraceInformation(printInfo);
        }

        public override void OnExit(MethodExecutionArgs args)
        {
            var printInfo = $"方法：{args.Method.Name}，结束执行，时间：{DateTime.Now}";

            Trace.TraceInformation(printInfo);
        }
    }
}
