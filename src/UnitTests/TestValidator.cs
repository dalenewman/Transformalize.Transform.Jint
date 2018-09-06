#region license
// Transformalize
// Configurable Extract, Transform, and Load
// Copyright 2013-2017 Dale Newman
//  
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//   
//       http://www.apache.org/licenses/LICENSE-2.0
//   
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
#endregion

using System.Linq;
using Autofac;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Transformalize.Configuration;
using Transformalize.Containers.Autofac;
using Transformalize.Contracts;
using Transformalize.Providers.Console;
using Transformalize.Transforms.Jint.Autofac;

namespace UnitTests {

    [TestClass]
    public class TestValidator {

        [TestMethod]
        public void BasicTests()
        {
            const string xml = @"
<add name='TestProcess' read-only='false'>
    <entities>
        <add name='TestData'>
            <rows>
                <add number1='1' number2='1.0' />
                <add number1='2' number2='2.0' />
            </rows>
            <fields>
                <add name='number1' type='int' primary-key='true' v='js(number1 > 1)' help='javascript validation failed' />
                <add name='number2' type='double' v='js(if(number2 > 1.0){ true; } else { number2Message = ""special message""; false; })' />
            </fields>
        </add>
    </entities>

</add>";
            using (var outer = new ConfigurationContainer(new JintModule()).CreateScope(xml)) {
                using (var inner = new TestContainer(new JintModule()).CreateScope(outer, new ConsoleLogger(LogLevel.Debug))) {

                    var process = inner.Resolve<Process>();
                  
                    var controller = inner.Resolve<IProcessController>();
                    controller.Execute();
                    var rows = process.Entities.First().Rows;

                    Assert.AreEqual(false, rows[0]["number1Valid"]);
                    Assert.AreEqual("javascript validation failed|", rows[0]["number1Message"]);

                    Assert.AreEqual(true, rows[1]["number1Valid"]);
                    Assert.AreEqual("", rows[1]["number1Message"]);

                    Assert.AreEqual(false, rows[0]["number2Valid"]);
                    Assert.AreEqual("special message|", rows[0]["number2Message"]);

                    Assert.AreEqual(true, rows[1]["number2Valid"]);
                    Assert.AreEqual("", rows[1]["number2Message"]);



                }
            }
        }
    }
}
