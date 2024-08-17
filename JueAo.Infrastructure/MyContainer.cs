using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JueAo.Infrastructure
{
    /// <summary>
    /// 控制台程序容器
    /// </summary>
    public sealed class MyContainer
    {
        public static MyContainer Instance { get; private set; } = new MyContainer();

        public ContainerBuilder Builder { get; private set; }

        /// <summary>
        /// 容器
        /// </summary>
        public IContainer Container { get; private set; }

        

        private MyContainer()
        {
            Builder = new ContainerBuilder();
        }



        /// <summary>
        /// 初始化容器
        /// </summary>
        /// <returns></returns>
        public void Init()
        {

            Container = this.Builder.Build();
        }


    }
}
