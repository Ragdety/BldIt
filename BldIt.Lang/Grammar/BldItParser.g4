parser grammar BldItParser;

options {
  tokenVocab = BldItLexer;
}

//Main starting point of the program
bldItFile: (NEWLINE | statement)* pipeline EOF;

statements: statement+;

statement: simpleStatement | compoundStatement;

simpleStatement: (assignment | functionCall) SEMICOLON? NEWLINE;

compoundStatement: (ifStatement | whileStatement);

/* 
 * This is an if block.
 *
 * Example:
 * if expression:
 *   do_something
 * 
 *
 * After that, it's optional to have an 'elseIfBlock' (0 or more) and 'elseBlock'.
 * Example:
 * if expression:
 *   do_something
 * else if expression:
 *   do_something_else
 * else: 
 *   do_finish_ifBlock
 * 
 */

ifStatement: singleIfBlock elseIfBlock* elseBlock?;

//If BLOCKS
singleIfBlock: IF expression COLON block;
elseIfBlock: ELSE IF expression COLON block;
elseBlock: ELSE COLON block;

//While/Unless block
whileStatement: WHILE expression COLON block;


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
block: simpleStatement | NEWLINE INDENT statements DEDENT;

assignment: IDENTIFIER ASSIGN_OP expression;

/*
 * Arguments are optional, hence the '?'
 * Examples:
 * some_identifier() OR
 * some_identifier(arg1, arg2)
 */
functionCall: IDENTIFIER OPEN_PAREN (expression (COMMA expression)*)? CLOSE_PAREN;

/*
 * Expressions evaluate to a value.
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

//Operators
multOp: MULT_OP | DIV_OP | MOD_OP ;
addOp: ADD_OP | SUB_OP ;
compareOp: EQUALITY | LESS_THAN_OP | GREATER_THAN_OP | LESS_THAN_EQUAL_OP | GREATER_THAN_EQUAL_OP ;
boolOp: BOOL_OP;
constant: INTEGER | FLOAT | STRING | BOOL | NULL;


//BldIt pipeline gramar specification
pipeline: PIPELINE COLON NEWLINE INDENT pipelineSections DEDENT;

//Pipeline sections (must be in this order)
//Note: Only stagesStatement is required
pipelineSections: pipelineSectionOrder;
pipelineSectionOrder: globalEnvStatement? parameterStatement? stagesStatement;

//Pipeline statements
globalEnvStatement: GLOBALENV COLON globalEnvBlock;
parameterStatement: PARAMETERS COLON parameterBlock;
stagesStatement: STAGES COLON stagesBlock;

//Pipeline Blocks
globalEnvBlock: NEWLINE;//NEWLINE INDENT /*envAssignments**/ DEDENT;
parameterBlock: NEWLINE;//NEWLINE INDENT /*paramAssignments**/ DEDENT;
stagesBlock: NEWLINE INDENT stageStatements DEDENT;

//At least one stage is required
stageStatements: stageStatement+;
stageStatement: STAGE /*stageName*/ COLON stageBlock;
//stageName: PIPELINE_IDENTIFIER;
stageBlock: block;

//Pipeline assignments:
//envAssignments: 