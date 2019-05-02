using Jint.Parser;
using System.Collections.Generic;
using System.Linq;
using Transformalize.Configuration;

namespace Transformalize.Jint {

   public class ParameterMatcher {

      private readonly JavaScriptParser _parser;
      public ParameterMatcher(JavaScriptParser parser) {
         _parser = parser;
      }

      public IEnumerable<string> Match(string script, IEnumerable<Field> available) {

         var parsed = _parser.Parse(script, new ParserOptions { Tokens = true });

         return parsed.Tokens
             .Where(o => o.Type == Tokens.Identifier)
             .Select(o => o.Value.ToString())
             .Intersect(available.Select(f => f.Alias))
             .Distinct()
             .ToArray();
      }
   }
}
