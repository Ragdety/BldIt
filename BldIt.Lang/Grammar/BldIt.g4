grammar BldIt;

//Main starting point of the program
program: line* EOF;

//Just an indentation/tab
INDENT: '\t';

/* 
  * This is a newline followed by an indentation:
  * Example:
  * BEFORE:
  *   AFTER_INDENTNEWLINE
 */
INDENTNEWLINE: '\r\n\t';
DEDENT: '\r\n';

/* 
  * This is a block of code, instead of brackets, we use indentation like python 
  * Example:
  * BLOCK:
  *   SOME_CODE
  *   SOME_OTHER_CODE
  * ENDBLOCK
 */
//block: INDENTNEWLINE line* INDENTNEWLINE* DEDENT;

line: statement | ifBlock | whileBlock;

statement: (assignment | functionCall) ENDLINE;

/* 
 * This is an if block.
 *
 * Example:
 * if expression:
 *   do_something
 *
 * After that, it's optional to have an 'else: elseIfBlock' expression.
 * Example:
 * if expression:
 *   do_something
 * else if expression:
 *   do_something_else
 * else: 
 *   do_finish_ifBlock
 */
ifBlock: 'if' expression block ('else' elseIfBlock)?;

/*
 * This allows else if blocks
 * It can have a single else or multiple 'else if'
 * If it has a single else, a single block would terminate the ifBlock
 */
elseIfBlock: block | ifBlock;

//While/Unless block
whileBlock: WHILE expression block;

//We're supporting both while and unless
WHILE: 'while' | 'unless';

/*
 * Block expression.
 *
 * Example: 
 * 'some_expression block' would evaluate to:
 * 'some_expression:\r\n\t line1 \r\n\t line2 \r\n\t \r\n' which would evaluate to:
 * 'some_expression:
 *    line1
 *    line2
 * '
 */
block: ':' INDENTNEWLINE (line INDENTNEWLINE)* DEDENT;

assignment: IDENTIFIER '=' expression;

/*
 * Arguments are optional, hence the '?'
 * Examples:
 * some_identifier() OR
 * some_identifier(arg1, arg2)
 */
functionCall: IDENTIFIER '(' (expression (',' expression)*)? ')';

/*
 * Must have mutliplication expression first
 */
expression
  : constant                #constantExpression
  | IDENTIFIER              #identifierExpression
  | functionCall            #functionCallExpression
  | parenthExpression       #parenthesizedExpression
  | notExpression           #notExpression
  | multExpression          #multiplicativeExpression
  | addExpression           #additiveExpression
  | compareExpression       #comparisonExpression
  | boolExpression          #booleanExpression
  ;

//Expression types:
parenthExpression: '(' expression ')';
notExpression: NOT expression;
multExpression: expression multOp expression;
addExpression: expression addOp expression;
compareExpression: expression compareOp expression;
boolExpression: expression boolOp expression;

//Operators
multOp: '*' | '/' | '%' ;
addOp: '+' | '-' ;
compareOp: EQUALITY | '<' | '>' | '<=' | '>=' ;
boolOp: BOOL_OPERATOR;

BOOL_OPERATOR: 'and' | 'or' ;
NOT: 'not' | '!' ;

//Might allow 'eq' and 'neq' in the future
EQUALITY: '==' | '!=' ; //| 'eq' | 'neq' ;

constant: INTEGER | FLOAT | STRING | BOOL | NULL;

INTEGER: [0-9]+;
FLOAT: [0-9]+ '.' [0-9]+;
STRING: ('"' ~'"'* '"') | ('\'' ~'\''* '\'');
BOOL: 'true' | 'false';
NULL: 'null';

//End of line can be a new line OR semicolon (adding optional semicolons)
ENDLINE: [\r\n | ';']+;

//Skip whitespace
WS: [ \t\r\n]+ -> skip;

/*
 * Must start with a letter (upper or lowercase) and 
 * allow any number of letters, numbers, and underscores after
 */
IDENTIFIER: [a-zA-Z_][a-zA-Z0-9_]*;


