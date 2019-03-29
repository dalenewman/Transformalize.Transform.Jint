using Autofac;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using Transformalize.Configuration;
using Transformalize.Containers.Autofac;
using Transformalize.Contracts;
using Transformalize.Providers.Bogus.Autofac;
using Transformalize.Transforms.Jint.Autofac;
using NullLogger = Transformalize.Logging.NullLogger;

namespace Benchmark {


   [LegacyJitX64Job]
   public class Benchmarks {

      private readonly IPipelineLogger _logger = new NullLogger();

      [Benchmark(Baseline = true, Description = "5000 rows")]
      public void TestRows() {
         using (var outer = new ConfigurationContainer(new JintModule()).CreateScope(@"files\bogus.xml?Size=5000", _logger)) {
            var process = outer.Resolve<Process>();
            using (var inner = new TestContainer(new JintModule(), new BogusModule()).CreateScope(process, _logger)) {
               var controller = inner.Resolve<IProcessController>();
               controller.Execute();
            }
         }
      }

      [Benchmark(Baseline = false, Description = "5000 rows 1 jint")]
      public void JintRows() {
         using (var outer = new ConfigurationContainer(new JintModule()).CreateScope(@"files\bogus-with-transform.xml?Size=5000", _logger)) {
            var process = outer.Resolve<Process>();
            using (var inner = new TestContainer(new JintModule(), new BogusModule()).CreateScope(process, _logger)) {
               var controller = inner.Resolve<IProcessController>();
               controller.Execute();
            }
         }
      }

      [Benchmark(Baseline = false, Description = "5000 rows 1 jint with dates")]
      public void JintDateRows() {
         using (var outer = new ConfigurationContainer(new JintModule()).CreateScope(@"files\bogus-with-transform-dates.xml?Size=5000", _logger)) {
            var process = outer.Resolve<Process>();
            using (var inner = new TestContainer(new JintModule(), new BogusModule()).CreateScope(process, _logger)) {
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
