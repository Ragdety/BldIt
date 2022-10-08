lexer grammar BldItLexer;

//INDENT and DEDENT from library: https://github.com/yshavit/antlr-denter: 
tokens { INDENT, DEDENT }

options {
    superClass=BldIt.Lang.External.Python3LexerIndent.PythonLexerBase;
}

//Bldit Pipeline keywords:
PIPELINE: ('pipeline' | 'pipe');
GLOBALENV: 'globalEnv';
PARAMETERS: 'parameters';
STAGES: 'stages';
STAGE: 'stage';
HANDLE_ERROR: 'handleError';
//PIPELINE_IDENTIFIER: [a-zA-Z_][a-zA-Z0-9_]*;


//Might support until in the future
WHILE: 'while'; // | until;

FUNCTION: 'fun' | 'def' | 'function';
RETURN: 'return' | 'ret';

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

/*
 * Pipeline
 */
PARAM_TYPE: 'stringParam' | 'boolParam' | 'choiceParam';
SCRIPT: 'script';


//Old skipping:
//Combination of these 2 (WS/NL) causes the program to work BUT with <missing NL> instead of \r\n
//WS: [ \r\n]+ -> skip;
//For spaces just switch out '\t'* with ' '*
//For tabs just switch out '  '* with '\t'*
//NL: ('\r'? '\n' '\t'*);
//COMMENT: '//' .*? '\r'?'\n' -> skip;

//Combination of these 2 removes the <missing NL> but program does not continue after...
//WS: [ \t]+ -> skip;
//NL: ('\r'? '\n' '\t'*);

//Other tokens:
NEWLINE
 : ( {this.atStartOfInput()}?   SPACES
   | ( '\r'? '\n' | '\r' | '\f' ) SPACES?
   )
   {this.onNewLine();}
 ;
 
//Python skipping
SKIP_: ( SPACES | COMMENT | LINE_JOINING ) -> skip;
fragment SPACES: [ \t]+;
fragment COMMENT: ('//' | '#') ~[\r\n\f]*;
fragment LINE_JOINING: '\\' SPACES? ( '\r'? '\n' | '\r' | '\f');

//Data Types
INTEGER: [0-9]+;
FLOAT: [0-9]+ '.' [0-9]+;
STRING: ('"' ~'"'* '"') | ('\'' ~'\''* '\'');
BOOL: 'true' | 'false';
NULL: 'null';

//End of line can be a new line OR semicolon (adding optional semicolons)
ENDLINE: SEMICOLON;
//ENDBLOCK: 'end';

/*
 * Must start with a letter (upper or lowercase) and 
 * allow any number of letters, numbers, and underscores after
 */
IDENTIFIER: [a-zA-Z_][a-zA-Z0-9_]*;