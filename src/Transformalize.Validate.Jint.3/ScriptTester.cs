﻿using Esprima;
using Transformalize.Contracts;

namespace Transformalize.Validators.Jint {

   public class ScriptTester {

      private readonly IContext _context;
      private readonly ParserOptions _parserOptions = new ParserOptions { Tolerant = true };

      public ScriptTester(IContext context) {
         _context = context;
      }

      public bool Passes(string script) {
         try {
            var program = new JavaScriptParser(script, _parserOptions).ParseProgram();
         } catch (ParserException ex) {
            _context.Error(ex.Message);
            Utility.CodeToError(_context, script);
            return false;
         }
         return true;
      }
   }
}
