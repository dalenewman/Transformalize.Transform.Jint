using Autofac;
using Transformalize.Contracts;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using Transformalize.Containers.Autofac;
using Transformalize.Logging;
using Transformalize.Providers.Bogus.Autofac;
using Transformalize.Transforms.Jint.Autofac;

namespace Benchmark {

    
    [LegacyJitX64Job]
    public class Benchmarks {

        [Benchmark(Baseline = true, Description = "5000 rows")]
        public void TestRows() {
            using (var outer = new ConfigurationContainer(new JintModule()).CreateScope(@"files\bogus.xml?Size=5000")) {
                using (var inner = new TestContainer(new JintModule(),new BogusModule()).CreateScope(outer, new NullLogger())) {
                    var controller = inner.Resolve<IProcessController>();
                    controller.Execute();
                }
            }
        }

        [Benchmark(Baseline = false, Description = "5000 rows 1 jint")]
        public void JintRows() {
            using (var outer = new ConfigurationContainer(new JintModule()).CreateScope(@"files\bogus-with-transform.xml?Size=5000")) {
                using (var inner = new TestContainer(new JintModule(), new BogusModule()).CreateScope(outer, new NullLogger())) {
                    var controller = inner.Resolve<IProcessController>();
                    controller.Execute();
                }
            }
        }

        [Benchmark(Baseline = false, Description = "5000 rows 1 jint with dates")]
        public void JintDateRows() {
            using (var outer = new ConfigurationContainer(new JintModule()).CreateScope(@"files\bogus-with-transform-dates.xml?Size=5000")) {
                using (var inner = new TestContainer(new JintModule(), new BogusModule()).CreateScope(outer, new NullLogger())) {
                    var controller = inner.Resolve<IProcessController>();
                    controller.Execute();
                }
            }
        }
    }

    public class Program {
        private static void Main(string[] args) {
            BenchmarkRunner.Run<Benchmarks>();
        }
    }
}
