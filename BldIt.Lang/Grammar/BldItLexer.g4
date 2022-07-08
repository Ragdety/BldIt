lexer grammar BldItLexer;

//INDENT and DEDENT from library: https://github.com/yshavit/antlr-denter: 
tokens { INDENT, DEDENT }

@lexer::header {
using BldIt.Lang.External.AntlrDenter;
}

@lexer::members {
  private DenterHelper denter;
    
  public override IToken NextToken()
  {
      if (denter == null)
      {
          denter = DenterHelper.Builder()
              .Nl(NL)
              .Indent(BldItParser.INDENT)
              .Dedent(BldItParser.DEDENT)
              .PullToken(base.NextToken);
      }

      return denter.NextToken();
  }
}

NL: ('\r'? '\n' '\t'*); //For spaces just switch out '\t'* with ' '*

/* 
  * This is a newline followed by an indentation:
  * Example:
  * BEFORE:
  *   AFTER_INDENTNEWLINE
 */

//Might support until in the future
WHILE: 'while'; // | until;

//Operators
ADD_OP: '+';
SUB_OP: '-';
MULT_OP: '*';
DIV_OP: '/';
MOD_OP: '%';
BOOL_OP: 'and' | 'or';
GREATER_THAN_OP: '>';
LESS_THAN_OP: '<';
GREATER_THAN_EQUAL_OP: '>=';
LESS_THAN_EQUAL_OP: '<=';

//SYMBOLS
OPEN_PAREN: '(';
CLOSE_PAREN: ')';
COMMA: ',';
SEMICOLON: ';';
COLON: ':';
DOT: '.';
ASSIGN_OP: '=';

//Keywords
IF: 'if';
ELSE: 'else';

//Might allow 'eq' and 'neq' in the future
EQUALITY: '==' | '!=' ; //| 'eq' | 'neq' ;
NOT: 'not ' | '!' ;

//Data Types
INTEGER: [0-9]+;
FLOAT: [0-9]+ '.' [0-9]+;
STRING: ('"' ~'"'* '"') | ('\'' ~'\''* '\'');
BOOL: 'true' | 'false';
NULL: 'null';

//End of line can be a new line OR semicolon (adding optional semicolons)
ENDLINE: SEMICOLON;

//Skip whitespace
WS: [ \r\n]+ -> skip;

/*
 * Must start with a letter (upper or lowercase) and 
 * allow any number of letters, numbers, and underscores after
 */
IDENTIFIER: [a-zA-Z_][a-zA-Z0-9_]*;