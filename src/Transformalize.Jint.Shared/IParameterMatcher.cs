using System.Collections.Generic;
using Transformalize.Configuration;

namespace Transformalize.Jint {
   public interface IParameterMatcher {

      IEnumerable<string> Match(string script, IEnumerable<Field> available);

   }
}
