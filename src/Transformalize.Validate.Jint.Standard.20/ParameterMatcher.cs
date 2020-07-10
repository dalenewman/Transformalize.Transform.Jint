using Jint.Parser;
using System.Collections.Generic;
using System.Linq;
using Transformalize.Configuration;

namespace Transformalize.Validators.Jint {

   public class ParameterMatcher : IParameterMatcher {

      public IEnumerable<string> Match(string script, IEnumerable<Field> available) {

         var parsed = new JavaScriptParser().Parse(script, new ParserOptions { Tokens = true });

         return parsed.Tokens
             .Where(o => o.Type == Tokens.Identifier)
             .Select(o => o.Value.ToString())
             .Intersect(available.Select(f => f.Alias))
             .Distinct()
             .ToArray();
      }
   }
}
