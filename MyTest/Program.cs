using Autofac;
using Autofac.Extras.DynamicProxy;
using Castle.Core.Logging;
using Castle.DynamicProxy;

namespace MyTest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ContainerBuilder builder = new ContainerBuilder();

            //注册拦截器
            //builder.Register(c => new CallLogger(Console.Out));
            builder.Register(c => new CallTester());

            //动态注入拦截器

            //这里定义了两个拦截器，注意它们的顺序。
            //builder.RegisterType<Student>().As<IStudent>().InterceptedBy(typeof(CallLogger), typeof(CallTester)).EnableInterfaceInterceptors();

            //这里定义了一个拦截器
            builder.RegisterType<AnimalWagging>().InterceptedBy(typeof(CallTester))
                .EnableClassInterceptors();
            builder.RegisterType<Dog>().As<IAnimalBark>();

            IContainer container = builder.Build();
            //IStudent student = container.Resolve<IStudent>();
            //student.Add("1003", "Kobe");

            //AnimalWagging animal = new AnimalWagging(new Dog()); //container.Resolve<AnimalWagging>();
            AnimalWagging animal = container.Resolve<AnimalWagging>();
            animal.Wagging();

            Task<string> task = animal.WaggingAsync("哈士奇");
            Console.WriteLine($"{task.Result}");

            Console.ReadKey();
        }
    }

    public class CallTester : IInterceptor
    {
        public void Intercept(IInvocation invocation)
        {
            Console.WriteLine("啥也不干");
            invocation.Proceed();
            Console.WriteLine("也不干啥");
        }
    }

    /// <summary>
    /// 动物吠声接口类
    /// </summary>
    public interface IAnimalBark
    {
        /// <summary>
        /// 吠叫
        /// </summary>
        void Bark();
    }

    /// <summary>
    /// 狗类
    /// </summary>
    public class Dog : IAnimalBark//, IAnimalSleep
    {
        /// <summary>
        /// 吠叫
        /// </summary>
        public void Bark()
        {
            Console.WriteLine("汪汪汪");
        }

        /// <summary>
        /// 睡眠
        /// </summary>
        public void Sleep()
        {
            Console.WriteLine("小狗狗睡着了zZ");
        }
    }

    /// <summary>
    /// 动物摇尾巴
    /// </summary>
    public class AnimalWagging
    {
        /// <summary>
        /// IAnimalBark属性
        /// </summary>
        IAnimalBark animalBark;

        /// <summary>
        /// 有参构造函数
        /// </summary>
        /// <param name="bark">IAnimalBark变量</param>
        public AnimalWagging(IAnimalBark bark)
        {
            animalBark = bark;
        }

        /// <summary>
        /// 摇尾巴
        /// </summary>
        public virtual void Wagging()
        {
            animalBark.Bark();
            Console.WriteLine("摇尾巴");
        }

        /// <summary>
        /// 计数
        /// </summary>
        /// <returns></returns>
        public static int Count()
        {
            return 6;
        }

        /// <summary>
        /// 任务
        /// </summary>
        /// <param name="name">动物名称</param>
        /// <returns></returns>
        public virtual async Task<string> WaggingAsync(string name)
        {
            var result = await Task.Run(() => Count());
            return $"{name}摇了{result}下尾巴";
        }
    }
}
