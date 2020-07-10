using Jint.Parser;
using System.Linq;
using Transformalize.Contracts;

namespace Transformalize.Validators.Jint {

   public class ScriptTester {

      private readonly IContext _context;
      private readonly JavaScriptParser _parser = new JavaScriptParser();
      private readonly ParserOptions _parserOptions = new ParserOptions { Tolerant = true };

      public ScriptTester(IContext context) {
         _context = context;
      }

      public bool Passes(string script) {
         try {
            var program = _parser.Parse(script, _parserOptions);
            if (program?.Errors == null || !program.Errors.Any()) {
               return true;
            }

            if (program.Errors.Any()) {
               foreach (var e in program.Errors) {
                  _context.Error(e.Message);
               }
               Utility.CodeToError(_context, script);
               return false;
            }

         } catch (ParserException ex) {
            _context.Error(ex.Message);
            Utility.CodeToError(_context, script);
            return false;
         }

         return false;
      }


   }
}
