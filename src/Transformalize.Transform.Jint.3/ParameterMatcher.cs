using Esprima;
using Esprima.Ast;
using System.Collections.Generic;
using System.Linq;
using Transformalize.Configuration;

namespace Transformalize.Transforms.Jint {

   public class ParameterMatcher : IParameterMatcher {

      public IEnumerable<string> Match(string script, IEnumerable<Field> available) {

         var parser = new JavaScriptParser(script, new ParserOptions() { Tokens = true });

         return parser.ParseProgram()
            .DescendantNodesAndSelf()
            .Where(n => n.Type == Nodes.Identifier)
            .Select(n => n.As<Identifier>())
            .Select(i=>i.Name)
            .Intersect(available.Select(f => f.Alias))
            .Distinct()
            .ToArray();
      }
   }
}
