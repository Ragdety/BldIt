parser grammar BldItParser;

options {
  tokenVocab = BldItLexer;
}

//Main starting point of the program
program: line* EOF;

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

statement: (assignment | functionCall) NL;

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
ifBlock: IF expression block (ELSE elseIfBlock)?;

/*
 * This allows else if blocks
 * It can have a single else or multiple 'else if'
 * If it has a single else, a single block would terminate the ifBlock
 */
elseIfBlock: block | ifBlock;

//While/Unless block
whileBlock: WHILE expression block;


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
block: COLON INDENT statement+ DEDENT;

assignment: IDENTIFIER ASSIGN_OP expression;

/*
 * Arguments are optional, hence the '?'
 * Examples:
 * some_identifier() OR
 * some_identifier(arg1, arg2)
 */
functionCall: IDENTIFIER OPEN_PAREN (expression (COMMA expression)*)? CLOSE_PAREN;

/*
 * Expressions evaluate to a some value.
 * Must have multiplication expression first
 */
expression
  : constant                              #constantExpr
  | IDENTIFIER                            #identifierExpr
  | functionCall                          #functionCallExpr
  | parenthExpression                     #parenthesizedExpr
  | notExpression                         #notExpr
  | expression multOp expression          #multiplicativeExpr
  | expression addOp expression           #additiveExpr
  | expression compareOp expression       #comparisonExpr
  | expression boolOp expression          #booleanExpr
  ;

//Expression types:
parenthExpression: OPEN_PAREN expression CLOSE_PAREN;
notExpression: NOT expression;
// multExpression: expression multOp expression;
// addExpression: expression addOp expression;
// compareExpression: expression compareOp expression;
// boolExpression: expression boolOp expression;

//Operators
multOp: MULT_OP | DIV_OP | MOD_OP ;
addOp: ADD_OP | SUB_OP ;
compareOp: EQUALITY | LESS_THAN_OP | GREATER_THAN_OP | LESS_THAN_EQUAL_OP | GREATER_THAN_EQUAL_OP ;
boolOp: BOOL_OP;


constant: INTEGER | FLOAT | STRING | BOOL | NULL;