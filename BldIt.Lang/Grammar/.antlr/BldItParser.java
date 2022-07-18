// Generated from c:\Users\ragde\OneDrive\Desktop\Programming\BldIt\BldIt.Lang\Grammar\BldItParser.g4 by ANTLR 4.9.2
import org.antlr.v4.runtime.atn.*;
import org.antlr.v4.runtime.dfa.DFA;
import org.antlr.v4.runtime.*;
import org.antlr.v4.runtime.misc.*;
import org.antlr.v4.runtime.tree.*;
import java.util.List;
import java.util.Iterator;
import java.util.ArrayList;

@SuppressWarnings({"all", "warnings", "unchecked", "unused", "cast"})
public class BldItParser extends Parser {
	static { RuntimeMetaData.checkVersion("4.9.2", RuntimeMetaData.VERSION); }

	protected static final DFA[] _decisionToDFA;
	protected static final PredictionContextCache _sharedContextCache =
		new PredictionContextCache();
	public static final int
		INDENT=1, DEDENT=2, PIPELINE=3, GLOBALENV=4, PARAMETERS=5, STAGES=6, STAGE=7, 
		WHILE=8, FUNCTION=9, RETURN=10, ADD_OP=11, SUB_OP=12, MULT_OP=13, DIV_OP=14, 
		MOD_OP=15, BOOL_OP=16, GREATER_THAN_OP=17, LESS_THAN_OP=18, GREATER_THAN_EQUAL_OP=19, 
		LESS_THAN_EQUAL_OP=20, OPEN_PAREN=21, CLOSE_PAREN=22, COMMA=23, SEMICOLON=24, 
		COLON=25, DOT=26, ASSIGN_OP=27, IF=28, ELSE=29, EQUALITY=30, NOT=31, INTEGER=32, 
		FLOAT=33, STRING=34, BOOL=35, NULL=36, ENDLINE=37, IDENTIFIER=38, NEWLINE=39, 
		SKIP_=40;
	public static final int
		RULE_bldItFile = 0, RULE_statements = 1, RULE_statement = 2, RULE_simpleStatement = 3, 
		RULE_compoundStatement = 4, RULE_ifStatement = 5, RULE_singleIfBlock = 6, 
		RULE_elseIfBlock = 7, RULE_elseBlock = 8, RULE_whileStatement = 9, RULE_functionDefinition = 10, 
		RULE_parameters = 11, RULE_block = 12, RULE_functionBlock = 13, RULE_returnStatement = 14, 
		RULE_assignment = 15, RULE_functionCall = 16, RULE_expression = 17, RULE_parenthExpression = 18, 
		RULE_notExpression = 19, RULE_multOp = 20, RULE_addOp = 21, RULE_compareOp = 22, 
		RULE_boolOp = 23, RULE_constant = 24, RULE_pipeline = 25, RULE_pipelineSections = 26, 
		RULE_globalEnvStatement = 27, RULE_parameterStatement = 28, RULE_stagesStatement = 29, 
		RULE_globalEnvBlock = 30, RULE_parameterBlock = 31, RULE_stagesBlock = 32, 
		RULE_stageStatements = 33, RULE_stageStatement = 34, RULE_stageBlock = 35, 
		RULE_envAssignments = 36, RULE_envAssignment = 37, RULE_pipelineExpression = 38;
	private static String[] makeRuleNames() {
		return new String[] {
			"bldItFile", "statements", "statement", "simpleStatement", "compoundStatement", 
			"ifStatement", "singleIfBlock", "elseIfBlock", "elseBlock", "whileStatement", 
			"functionDefinition", "parameters", "block", "functionBlock", "returnStatement", 
			"assignment", "functionCall", "expression", "parenthExpression", "notExpression", 
			"multOp", "addOp", "compareOp", "boolOp", "constant", "pipeline", "pipelineSections", 
			"globalEnvStatement", "parameterStatement", "stagesStatement", "globalEnvBlock", 
			"parameterBlock", "stagesBlock", "stageStatements", "stageStatement", 
			"stageBlock", "envAssignments", "envAssignment", "pipelineExpression"
		};
	}
	public static final String[] ruleNames = makeRuleNames();

	private static String[] makeLiteralNames() {
		return new String[] {
			null, null, null, null, "'globalEnv'", "'parameters'", "'stages'", "'stage'", 
			"'while'", null, null, "'+'", "'-'", "'*'", "'/'", "'%'", null, "'>'", 
			"'<'", "'>='", "'<='", "'('", "')'", "','", "';'", "':'", "'.'", "'='", 
			"'if'", "'else'", null, null, null, null, null, null, "'null'"
		};
	}
	private static final String[] _LITERAL_NAMES = makeLiteralNames();
	private static String[] makeSymbolicNames() {
		return new String[] {
			null, "INDENT", "DEDENT", "PIPELINE", "GLOBALENV", "PARAMETERS", "STAGES", 
			"STAGE", "WHILE", "FUNCTION", "RETURN", "ADD_OP", "SUB_OP", "MULT_OP", 
			"DIV_OP", "MOD_OP", "BOOL_OP", "GREATER_THAN_OP", "LESS_THAN_OP", "GREATER_THAN_EQUAL_OP", 
			"LESS_THAN_EQUAL_OP", "OPEN_PAREN", "CLOSE_PAREN", "COMMA", "SEMICOLON", 
			"COLON", "DOT", "ASSIGN_OP", "IF", "ELSE", "EQUALITY", "NOT", "INTEGER", 
			"FLOAT", "STRING", "BOOL", "NULL", "ENDLINE", "IDENTIFIER", "NEWLINE", 
			"SKIP_"
		};
	}
	private static final String[] _SYMBOLIC_NAMES = makeSymbolicNames();
	public static final Vocabulary VOCABULARY = new VocabularyImpl(_LITERAL_NAMES, _SYMBOLIC_NAMES);

	/**
	 * @deprecated Use {@link #VOCABULARY} instead.
	 */
	@Deprecated
	public static final String[] tokenNames;
	static {
		tokenNames = new String[_SYMBOLIC_NAMES.length];
		for (int i = 0; i < tokenNames.length; i++) {
			tokenNames[i] = VOCABULARY.getLiteralName(i);
			if (tokenNames[i] == null) {
				tokenNames[i] = VOCABULARY.getSymbolicName(i);
			}

			if (tokenNames[i] == null) {
				tokenNames[i] = "<INVALID>";
			}
		}
	}

	@Override
	@Deprecated
	public String[] getTokenNames() {
		return tokenNames;
	}

	@Override

	public Vocabulary getVocabulary() {
		return VOCABULARY;
	}

	@Override
	public String getGrammarFileName() { return "BldItParser.g4"; }

	@Override
	public String[] getRuleNames() { return ruleNames; }

	@Override
	public String getSerializedATN() { return _serializedATN; }

	@Override
	public ATN getATN() { return _ATN; }

	public BldItParser(TokenStream input) {
		super(input);
		_interp = new ParserATNSimulator(this,_ATN,_decisionToDFA,_sharedContextCache);
	}

	public static class BldItFileContext extends ParserRuleContext {
		public PipelineContext pipeline() {
			return getRuleContext(PipelineContext.class,0);
		}
		public TerminalNode EOF() { return getToken(BldItParser.EOF, 0); }
		public List<TerminalNode> NEWLINE() { return getTokens(BldItParser.NEWLINE); }
		public TerminalNode NEWLINE(int i) {
			return getToken(BldItParser.NEWLINE, i);
		}
		public List<StatementContext> statement() {
			return getRuleContexts(StatementContext.class);
		}
		public StatementContext statement(int i) {
			return getRuleContext(StatementContext.class,i);
		}
		public BldItFileContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_bldItFile; }
	}

	public final BldItFileContext bldItFile() throws RecognitionException {
		BldItFileContext _localctx = new BldItFileContext(_ctx, getState());
		enterRule(_localctx, 0, RULE_bldItFile);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(82);
			_errHandler.sync(this);
			_la = _input.LA(1);
			while ((((_la) & ~0x3f) == 0 && ((1L << _la) & ((1L << WHILE) | (1L << FUNCTION) | (1L << RETURN) | (1L << IF) | (1L << IDENTIFIER) | (1L << NEWLINE))) != 0)) {
				{
				setState(80);
				_errHandler.sync(this);
				switch (_input.LA(1)) {
				case NEWLINE:
					{
					setState(78);
					match(NEWLINE);
					}
					break;
				case WHILE:
				case FUNCTION:
				case RETURN:
				case IF:
				case IDENTIFIER:
					{
					setState(79);
					statement();
					}
					break;
				default:
					throw new NoViableAltException(this);
				}
				}
				setState(84);
				_errHandler.sync(this);
				_la = _input.LA(1);
			}
			setState(85);
			pipeline();
			setState(86);
			match(EOF);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class StatementsContext extends ParserRuleContext {
		public List<StatementContext> statement() {
			return getRuleContexts(StatementContext.class);
		}
		public StatementContext statement(int i) {
			return getRuleContext(StatementContext.class,i);
		}
		public StatementsContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_statements; }
	}

	public final StatementsContext statements() throws RecognitionException {
		StatementsContext _localctx = new StatementsContext(_ctx, getState());
		enterRule(_localctx, 2, RULE_statements);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(89); 
			_errHandler.sync(this);
			_la = _input.LA(1);
			do {
				{
				{
				setState(88);
				statement();
				}
				}
				setState(91); 
				_errHandler.sync(this);
				_la = _input.LA(1);
			} while ( (((_la) & ~0x3f) == 0 && ((1L << _la) & ((1L << WHILE) | (1L << FUNCTION) | (1L << RETURN) | (1L << IF) | (1L << IDENTIFIER))) != 0) );
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class StatementContext extends ParserRuleContext {
		public SimpleStatementContext simpleStatement() {
			return getRuleContext(SimpleStatementContext.class,0);
		}
		public CompoundStatementContext compoundStatement() {
			return getRuleContext(CompoundStatementContext.class,0);
		}
		public StatementContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_statement; }
	}

	public final StatementContext statement() throws RecognitionException {
		StatementContext _localctx = new StatementContext(_ctx, getState());
		enterRule(_localctx, 4, RULE_statement);
		try {
			setState(95);
			_errHandler.sync(this);
			switch (_input.LA(1)) {
			case RETURN:
			case IDENTIFIER:
				enterOuterAlt(_localctx, 1);
				{
				setState(93);
				simpleStatement();
				}
				break;
			case WHILE:
			case FUNCTION:
			case IF:
				enterOuterAlt(_localctx, 2);
				{
				setState(94);
				compoundStatement();
				}
				break;
			default:
				throw new NoViableAltException(this);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class SimpleStatementContext extends ParserRuleContext {
		public TerminalNode NEWLINE() { return getToken(BldItParser.NEWLINE, 0); }
		public AssignmentContext assignment() {
			return getRuleContext(AssignmentContext.class,0);
		}
		public FunctionCallContext functionCall() {
			return getRuleContext(FunctionCallContext.class,0);
		}
		public ReturnStatementContext returnStatement() {
			return getRuleContext(ReturnStatementContext.class,0);
		}
		public TerminalNode SEMICOLON() { return getToken(BldItParser.SEMICOLON, 0); }
		public SimpleStatementContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_simpleStatement; }
	}

	public final SimpleStatementContext simpleStatement() throws RecognitionException {
		SimpleStatementContext _localctx = new SimpleStatementContext(_ctx, getState());
		enterRule(_localctx, 6, RULE_simpleStatement);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(100);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,4,_ctx) ) {
			case 1:
				{
				setState(97);
				assignment();
				}
				break;
			case 2:
				{
				setState(98);
				functionCall();
				}
				break;
			case 3:
				{
				setState(99);
				returnStatement();
				}
				break;
			}
			setState(103);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if (_la==SEMICOLON) {
				{
				setState(102);
				match(SEMICOLON);
				}
			}

			setState(105);
			match(NEWLINE);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class CompoundStatementContext extends ParserRuleContext {
		public IfStatementContext ifStatement() {
			return getRuleContext(IfStatementContext.class,0);
		}
		public WhileStatementContext whileStatement() {
			return getRuleContext(WhileStatementContext.class,0);
		}
		public FunctionDefinitionContext functionDefinition() {
			return getRuleContext(FunctionDefinitionContext.class,0);
		}
		public CompoundStatementContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_compoundStatement; }
	}

	public final CompoundStatementContext compoundStatement() throws RecognitionException {
		CompoundStatementContext _localctx = new CompoundStatementContext(_ctx, getState());
		enterRule(_localctx, 8, RULE_compoundStatement);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(110);
			_errHandler.sync(this);
			switch (_input.LA(1)) {
			case IF:
				{
				setState(107);
				ifStatement();
				}
				break;
			case WHILE:
				{
				setState(108);
				whileStatement();
				}
				break;
			case FUNCTION:
				{
				setState(109);
				functionDefinition();
				}
				break;
			default:
				throw new NoViableAltException(this);
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class IfStatementContext extends ParserRuleContext {
		public SingleIfBlockContext singleIfBlock() {
			return getRuleContext(SingleIfBlockContext.class,0);
		}
		public List<ElseIfBlockContext> elseIfBlock() {
			return getRuleContexts(ElseIfBlockContext.class);
		}
		public ElseIfBlockContext elseIfBlock(int i) {
			return getRuleContext(ElseIfBlockContext.class,i);
		}
		public ElseBlockContext elseBlock() {
			return getRuleContext(ElseBlockContext.class,0);
		}
		public IfStatementContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_ifStatement; }
	}

	public final IfStatementContext ifStatement() throws RecognitionException {
		IfStatementContext _localctx = new IfStatementContext(_ctx, getState());
		enterRule(_localctx, 10, RULE_ifStatement);
		int _la;
		try {
			int _alt;
			enterOuterAlt(_localctx, 1);
			{
			setState(112);
			singleIfBlock();
			setState(116);
			_errHandler.sync(this);
			_alt = getInterpreter().adaptivePredict(_input,7,_ctx);
			while ( _alt!=2 && _alt!=org.antlr.v4.runtime.atn.ATN.INVALID_ALT_NUMBER ) {
				if ( _alt==1 ) {
					{
					{
					setState(113);
					elseIfBlock();
					}
					} 
				}
				setState(118);
				_errHandler.sync(this);
				_alt = getInterpreter().adaptivePredict(_input,7,_ctx);
			}
			setState(120);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if (_la==ELSE) {
				{
				setState(119);
				elseBlock();
				}
			}

			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class SingleIfBlockContext extends ParserRuleContext {
		public TerminalNode IF() { return getToken(BldItParser.IF, 0); }
		public ExpressionContext expression() {
			return getRuleContext(ExpressionContext.class,0);
		}
		public TerminalNode COLON() { return getToken(BldItParser.COLON, 0); }
		public BlockContext block() {
			return getRuleContext(BlockContext.class,0);
		}
		public SingleIfBlockContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_singleIfBlock; }
	}

	public final SingleIfBlockContext singleIfBlock() throws RecognitionException {
		SingleIfBlockContext _localctx = new SingleIfBlockContext(_ctx, getState());
		enterRule(_localctx, 12, RULE_singleIfBlock);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(122);
			match(IF);
			setState(123);
			expression(0);
			setState(124);
			match(COLON);
			setState(125);
			block();
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class ElseIfBlockContext extends ParserRuleContext {
		public TerminalNode ELSE() { return getToken(BldItParser.ELSE, 0); }
		public TerminalNode IF() { return getToken(BldItParser.IF, 0); }
		public ExpressionContext expression() {
			return getRuleContext(ExpressionContext.class,0);
		}
		public TerminalNode COLON() { return getToken(BldItParser.COLON, 0); }
		public BlockContext block() {
			return getRuleContext(BlockContext.class,0);
		}
		public ElseIfBlockContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_elseIfBlock; }
	}

	public final ElseIfBlockContext elseIfBlock() throws RecognitionException {
		ElseIfBlockContext _localctx = new ElseIfBlockContext(_ctx, getState());
		enterRule(_localctx, 14, RULE_elseIfBlock);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(127);
			match(ELSE);
			setState(128);
			match(IF);
			setState(129);
			expression(0);
			setState(130);
			match(COLON);
			setState(131);
			block();
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class ElseBlockContext extends ParserRuleContext {
		public TerminalNode ELSE() { return getToken(BldItParser.ELSE, 0); }
		public TerminalNode COLON() { return getToken(BldItParser.COLON, 0); }
		public BlockContext block() {
			return getRuleContext(BlockContext.class,0);
		}
		public ElseBlockContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_elseBlock; }
	}

	public final ElseBlockContext elseBlock() throws RecognitionException {
		ElseBlockContext _localctx = new ElseBlockContext(_ctx, getState());
		enterRule(_localctx, 16, RULE_elseBlock);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(133);
			match(ELSE);
			setState(134);
			match(COLON);
			setState(135);
			block();
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class WhileStatementContext extends ParserRuleContext {
		public TerminalNode WHILE() { return getToken(BldItParser.WHILE, 0); }
		public ExpressionContext expression() {
			return getRuleContext(ExpressionContext.class,0);
		}
		public TerminalNode COLON() { return getToken(BldItParser.COLON, 0); }
		public BlockContext block() {
			return getRuleContext(BlockContext.class,0);
		}
		public WhileStatementContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_whileStatement; }
	}

	public final WhileStatementContext whileStatement() throws RecognitionException {
		WhileStatementContext _localctx = new WhileStatementContext(_ctx, getState());
		enterRule(_localctx, 18, RULE_whileStatement);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(137);
			match(WHILE);
			setState(138);
			expression(0);
			setState(139);
			match(COLON);
			setState(140);
			block();
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class FunctionDefinitionContext extends ParserRuleContext {
		public TerminalNode FUNCTION() { return getToken(BldItParser.FUNCTION, 0); }
		public TerminalNode IDENTIFIER() { return getToken(BldItParser.IDENTIFIER, 0); }
		public TerminalNode OPEN_PAREN() { return getToken(BldItParser.OPEN_PAREN, 0); }
		public TerminalNode CLOSE_PAREN() { return getToken(BldItParser.CLOSE_PAREN, 0); }
		public TerminalNode COLON() { return getToken(BldItParser.COLON, 0); }
		public FunctionBlockContext functionBlock() {
			return getRuleContext(FunctionBlockContext.class,0);
		}
		public ParametersContext parameters() {
			return getRuleContext(ParametersContext.class,0);
		}
		public FunctionDefinitionContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_functionDefinition; }
	}

	public final FunctionDefinitionContext functionDefinition() throws RecognitionException {
		FunctionDefinitionContext _localctx = new FunctionDefinitionContext(_ctx, getState());
		enterRule(_localctx, 20, RULE_functionDefinition);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(142);
			match(FUNCTION);
			setState(143);
			match(IDENTIFIER);
			setState(144);
			match(OPEN_PAREN);
			setState(146);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if (_la==IDENTIFIER) {
				{
				setState(145);
				parameters();
				}
			}

			setState(148);
			match(CLOSE_PAREN);
			setState(149);
			match(COLON);
			setState(150);
			functionBlock();
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class ParametersContext extends ParserRuleContext {
		public List<TerminalNode> IDENTIFIER() { return getTokens(BldItParser.IDENTIFIER); }
		public TerminalNode IDENTIFIER(int i) {
			return getToken(BldItParser.IDENTIFIER, i);
		}
		public List<TerminalNode> COMMA() { return getTokens(BldItParser.COMMA); }
		public TerminalNode COMMA(int i) {
			return getToken(BldItParser.COMMA, i);
		}
		public ParametersContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_parameters; }
	}

	public final ParametersContext parameters() throws RecognitionException {
		ParametersContext _localctx = new ParametersContext(_ctx, getState());
		enterRule(_localctx, 22, RULE_parameters);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			{
			setState(152);
			match(IDENTIFIER);
			setState(157);
			_errHandler.sync(this);
			_la = _input.LA(1);
			while (_la==COMMA) {
				{
				{
				setState(153);
				match(COMMA);
				setState(154);
				match(IDENTIFIER);
				}
				}
				setState(159);
				_errHandler.sync(this);
				_la = _input.LA(1);
			}
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class BlockContext extends ParserRuleContext {
		public SimpleStatementContext simpleStatement() {
			return getRuleContext(SimpleStatementContext.class,0);
		}
		public TerminalNode NEWLINE() { return getToken(BldItParser.NEWLINE, 0); }
		public TerminalNode INDENT() { return getToken(BldItParser.INDENT, 0); }
		public StatementsContext statements() {
			return getRuleContext(StatementsContext.class,0);
		}
		public TerminalNode DEDENT() { return getToken(BldItParser.DEDENT, 0); }
		public BlockContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_block; }
	}

	public final BlockContext block() throws RecognitionException {
		BlockContext _localctx = new BlockContext(_ctx, getState());
		enterRule(_localctx, 24, RULE_block);
		try {
			setState(166);
			_errHandler.sync(this);
			switch (_input.LA(1)) {
			case RETURN:
			case IDENTIFIER:
				enterOuterAlt(_localctx, 1);
				{
				setState(160);
				simpleStatement();
				}
				break;
			case NEWLINE:
				enterOuterAlt(_localctx, 2);
				{
				setState(161);
				match(NEWLINE);
				setState(162);
				match(INDENT);
				setState(163);
				statements();
				setState(164);
				match(DEDENT);
				}
				break;
			default:
				throw new NoViableAltException(this);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class FunctionBlockContext extends ParserRuleContext {
		public SimpleStatementContext simpleStatement() {
			return getRuleContext(SimpleStatementContext.class,0);
		}
		public TerminalNode NEWLINE() { return getToken(BldItParser.NEWLINE, 0); }
		public TerminalNode INDENT() { return getToken(BldItParser.INDENT, 0); }
		public TerminalNode DEDENT() { return getToken(BldItParser.DEDENT, 0); }
		public StatementsContext statements() {
			return getRuleContext(StatementsContext.class,0);
		}
		public FunctionBlockContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_functionBlock; }
	}

	public final FunctionBlockContext functionBlock() throws RecognitionException {
		FunctionBlockContext _localctx = new FunctionBlockContext(_ctx, getState());
		enterRule(_localctx, 26, RULE_functionBlock);
		int _la;
		try {
			setState(175);
			_errHandler.sync(this);
			switch (_input.LA(1)) {
			case RETURN:
			case IDENTIFIER:
				enterOuterAlt(_localctx, 1);
				{
				setState(168);
				simpleStatement();
				}
				break;
			case NEWLINE:
				enterOuterAlt(_localctx, 2);
				{
				setState(169);
				match(NEWLINE);
				setState(170);
				match(INDENT);
				setState(172);
				_errHandler.sync(this);
				_la = _input.LA(1);
				if ((((_la) & ~0x3f) == 0 && ((1L << _la) & ((1L << WHILE) | (1L << FUNCTION) | (1L << RETURN) | (1L << IF) | (1L << IDENTIFIER))) != 0)) {
					{
					setState(171);
					statements();
					}
				}

				setState(174);
				match(DEDENT);
				}
				break;
			default:
				throw new NoViableAltException(this);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class ReturnStatementContext extends ParserRuleContext {
		public TerminalNode RETURN() { return getToken(BldItParser.RETURN, 0); }
		public ExpressionContext expression() {
			return getRuleContext(ExpressionContext.class,0);
		}
		public ReturnStatementContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_returnStatement; }
	}

	public final ReturnStatementContext returnStatement() throws RecognitionException {
		ReturnStatementContext _localctx = new ReturnStatementContext(_ctx, getState());
		enterRule(_localctx, 28, RULE_returnStatement);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(177);
			match(RETURN);
			setState(179);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if ((((_la) & ~0x3f) == 0 && ((1L << _la) & ((1L << OPEN_PAREN) | (1L << NOT) | (1L << INTEGER) | (1L << FLOAT) | (1L << STRING) | (1L << BOOL) | (1L << NULL) | (1L << IDENTIFIER))) != 0)) {
				{
				setState(178);
				expression(0);
				}
			}

			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class AssignmentContext extends ParserRuleContext {
		public TerminalNode IDENTIFIER() { return getToken(BldItParser.IDENTIFIER, 0); }
		public TerminalNode ASSIGN_OP() { return getToken(BldItParser.ASSIGN_OP, 0); }
		public ExpressionContext expression() {
			return getRuleContext(ExpressionContext.class,0);
		}
		public AssignmentContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_assignment; }
	}

	public final AssignmentContext assignment() throws RecognitionException {
		AssignmentContext _localctx = new AssignmentContext(_ctx, getState());
		enterRule(_localctx, 30, RULE_assignment);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(181);
			match(IDENTIFIER);
			setState(182);
			match(ASSIGN_OP);
			setState(183);
			expression(0);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class FunctionCallContext extends ParserRuleContext {
		public TerminalNode IDENTIFIER() { return getToken(BldItParser.IDENTIFIER, 0); }
		public TerminalNode OPEN_PAREN() { return getToken(BldItParser.OPEN_PAREN, 0); }
		public TerminalNode CLOSE_PAREN() { return getToken(BldItParser.CLOSE_PAREN, 0); }
		public List<ExpressionContext> expression() {
			return getRuleContexts(ExpressionContext.class);
		}
		public ExpressionContext expression(int i) {
			return getRuleContext(ExpressionContext.class,i);
		}
		public List<TerminalNode> COMMA() { return getTokens(BldItParser.COMMA); }
		public TerminalNode COMMA(int i) {
			return getToken(BldItParser.COMMA, i);
		}
		public FunctionCallContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_functionCall; }
	}

	public final FunctionCallContext functionCall() throws RecognitionException {
		FunctionCallContext _localctx = new FunctionCallContext(_ctx, getState());
		enterRule(_localctx, 32, RULE_functionCall);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(185);
			match(IDENTIFIER);
			setState(186);
			match(OPEN_PAREN);
			setState(195);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if ((((_la) & ~0x3f) == 0 && ((1L << _la) & ((1L << OPEN_PAREN) | (1L << NOT) | (1L << INTEGER) | (1L << FLOAT) | (1L << STRING) | (1L << BOOL) | (1L << NULL) | (1L << IDENTIFIER))) != 0)) {
				{
				setState(187);
				expression(0);
				setState(192);
				_errHandler.sync(this);
				_la = _input.LA(1);
				while (_la==COMMA) {
					{
					{
					setState(188);
					match(COMMA);
					setState(189);
					expression(0);
					}
					}
					setState(194);
					_errHandler.sync(this);
					_la = _input.LA(1);
				}
				}
			}

			setState(197);
			match(CLOSE_PAREN);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class ExpressionContext extends ParserRuleContext {
		public ExpressionContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_expression; }
	 
		public ExpressionContext() { }
		public void copyFrom(ExpressionContext ctx) {
			super.copyFrom(ctx);
		}
	}
	public static class NotExprContext extends ExpressionContext {
		public NotExpressionContext notExpression() {
			return getRuleContext(NotExpressionContext.class,0);
		}
		public NotExprContext(ExpressionContext ctx) { copyFrom(ctx); }
	}
	public static class ParenthesizedExprContext extends ExpressionContext {
		public ParenthExpressionContext parenthExpression() {
			return getRuleContext(ParenthExpressionContext.class,0);
		}
		public ParenthesizedExprContext(ExpressionContext ctx) { copyFrom(ctx); }
	}
	public static class BooleanExprContext extends ExpressionContext {
		public List<ExpressionContext> expression() {
			return getRuleContexts(ExpressionContext.class);
		}
		public ExpressionContext expression(int i) {
			return getRuleContext(ExpressionContext.class,i);
		}
		public BoolOpContext boolOp() {
			return getRuleContext(BoolOpContext.class,0);
		}
		public BooleanExprContext(ExpressionContext ctx) { copyFrom(ctx); }
	}
	public static class FunctionCallExprContext extends ExpressionContext {
		public FunctionCallContext functionCall() {
			return getRuleContext(FunctionCallContext.class,0);
		}
		public FunctionCallExprContext(ExpressionContext ctx) { copyFrom(ctx); }
	}
	public static class ComparisonExprContext extends ExpressionContext {
		public List<ExpressionContext> expression() {
			return getRuleContexts(ExpressionContext.class);
		}
		public ExpressionContext expression(int i) {
			return getRuleContext(ExpressionContext.class,i);
		}
		public CompareOpContext compareOp() {
			return getRuleContext(CompareOpContext.class,0);
		}
		public ComparisonExprContext(ExpressionContext ctx) { copyFrom(ctx); }
	}
	public static class AdditiveExprContext extends ExpressionContext {
		public List<ExpressionContext> expression() {
			return getRuleContexts(ExpressionContext.class);
		}
		public ExpressionContext expression(int i) {
			return getRuleContext(ExpressionContext.class,i);
		}
		public AddOpContext addOp() {
			return getRuleContext(AddOpContext.class,0);
		}
		public AdditiveExprContext(ExpressionContext ctx) { copyFrom(ctx); }
	}
	public static class MultiplicativeExprContext extends ExpressionContext {
		public List<ExpressionContext> expression() {
			return getRuleContexts(ExpressionContext.class);
		}
		public ExpressionContext expression(int i) {
			return getRuleContext(ExpressionContext.class,i);
		}
		public MultOpContext multOp() {
			return getRuleContext(MultOpContext.class,0);
		}
		public MultiplicativeExprContext(ExpressionContext ctx) { copyFrom(ctx); }
	}
	public static class ConstantExprContext extends ExpressionContext {
		public ConstantContext constant() {
			return getRuleContext(ConstantContext.class,0);
		}
		public ConstantExprContext(ExpressionContext ctx) { copyFrom(ctx); }
	}
	public static class IdentifierExprContext extends ExpressionContext {
		public TerminalNode IDENTIFIER() { return getToken(BldItParser.IDENTIFIER, 0); }
		public IdentifierExprContext(ExpressionContext ctx) { copyFrom(ctx); }
	}

	public final ExpressionContext expression() throws RecognitionException {
		return expression(0);
	}

	private ExpressionContext expression(int _p) throws RecognitionException {
		ParserRuleContext _parentctx = _ctx;
		int _parentState = getState();
		ExpressionContext _localctx = new ExpressionContext(_ctx, _parentState);
		ExpressionContext _prevctx = _localctx;
		int _startState = 34;
		enterRecursionRule(_localctx, 34, RULE_expression, _p);
		try {
			int _alt;
			enterOuterAlt(_localctx, 1);
			{
			setState(205);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,17,_ctx) ) {
			case 1:
				{
				_localctx = new ConstantExprContext(_localctx);
				_ctx = _localctx;
				_prevctx = _localctx;

				setState(200);
				constant();
				}
				break;
			case 2:
				{
				_localctx = new IdentifierExprContext(_localctx);
				_ctx = _localctx;
				_prevctx = _localctx;
				setState(201);
				match(IDENTIFIER);
				}
				break;
			case 3:
				{
				_localctx = new FunctionCallExprContext(_localctx);
				_ctx = _localctx;
				_prevctx = _localctx;
				setState(202);
				functionCall();
				}
				break;
			case 4:
				{
				_localctx = new ParenthesizedExprContext(_localctx);
				_ctx = _localctx;
				_prevctx = _localctx;
				setState(203);
				parenthExpression();
				}
				break;
			case 5:
				{
				_localctx = new NotExprContext(_localctx);
				_ctx = _localctx;
				_prevctx = _localctx;
				setState(204);
				notExpression();
				}
				break;
			}
			_ctx.stop = _input.LT(-1);
			setState(225);
			_errHandler.sync(this);
			_alt = getInterpreter().adaptivePredict(_input,19,_ctx);
			while ( _alt!=2 && _alt!=org.antlr.v4.runtime.atn.ATN.INVALID_ALT_NUMBER ) {
				if ( _alt==1 ) {
					if ( _parseListeners!=null ) triggerExitRuleEvent();
					_prevctx = _localctx;
					{
					setState(223);
					_errHandler.sync(this);
					switch ( getInterpreter().adaptivePredict(_input,18,_ctx) ) {
					case 1:
						{
						_localctx = new MultiplicativeExprContext(new ExpressionContext(_parentctx, _parentState));
						pushNewRecursionContext(_localctx, _startState, RULE_expression);
						setState(207);
						if (!(precpred(_ctx, 4))) throw new FailedPredicateException(this, "precpred(_ctx, 4)");
						setState(208);
						multOp();
						setState(209);
						expression(5);
						}
						break;
					case 2:
						{
						_localctx = new AdditiveExprContext(new ExpressionContext(_parentctx, _parentState));
						pushNewRecursionContext(_localctx, _startState, RULE_expression);
						setState(211);
						if (!(precpred(_ctx, 3))) throw new FailedPredicateException(this, "precpred(_ctx, 3)");
						setState(212);
						addOp();
						setState(213);
						expression(4);
						}
						break;
					case 3:
						{
						_localctx = new ComparisonExprContext(new ExpressionContext(_parentctx, _parentState));
						pushNewRecursionContext(_localctx, _startState, RULE_expression);
						setState(215);
						if (!(precpred(_ctx, 2))) throw new FailedPredicateException(this, "precpred(_ctx, 2)");
						setState(216);
						compareOp();
						setState(217);
						expression(3);
						}
						break;
					case 4:
						{
						_localctx = new BooleanExprContext(new ExpressionContext(_parentctx, _parentState));
						pushNewRecursionContext(_localctx, _startState, RULE_expression);
						setState(219);
						if (!(precpred(_ctx, 1))) throw new FailedPredicateException(this, "precpred(_ctx, 1)");
						setState(220);
						boolOp();
						setState(221);
						expression(2);
						}
						break;
					}
					} 
				}
				setState(227);
				_errHandler.sync(this);
				_alt = getInterpreter().adaptivePredict(_input,19,_ctx);
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			unrollRecursionContexts(_parentctx);
		}
		return _localctx;
	}

	public static class ParenthExpressionContext extends ParserRuleContext {
		public TerminalNode OPEN_PAREN() { return getToken(BldItParser.OPEN_PAREN, 0); }
		public ExpressionContext expression() {
			return getRuleContext(ExpressionContext.class,0);
		}
		public TerminalNode CLOSE_PAREN() { return getToken(BldItParser.CLOSE_PAREN, 0); }
		public ParenthExpressionContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_parenthExpression; }
	}

	public final ParenthExpressionContext parenthExpression() throws RecognitionException {
		ParenthExpressionContext _localctx = new ParenthExpressionContext(_ctx, getState());
		enterRule(_localctx, 36, RULE_parenthExpression);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(228);
			match(OPEN_PAREN);
			setState(229);
			expression(0);
			setState(230);
			match(CLOSE_PAREN);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class NotExpressionContext extends ParserRuleContext {
		public TerminalNode NOT() { return getToken(BldItParser.NOT, 0); }
		public ExpressionContext expression() {
			return getRuleContext(ExpressionContext.class,0);
		}
		public NotExpressionContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_notExpression; }
	}

	public final NotExpressionContext notExpression() throws RecognitionException {
		NotExpressionContext _localctx = new NotExpressionContext(_ctx, getState());
		enterRule(_localctx, 38, RULE_notExpression);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(232);
			match(NOT);
			setState(233);
			expression(0);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class MultOpContext extends ParserRuleContext {
		public TerminalNode MULT_OP() { return getToken(BldItParser.MULT_OP, 0); }
		public TerminalNode DIV_OP() { return getToken(BldItParser.DIV_OP, 0); }
		public TerminalNode MOD_OP() { return getToken(BldItParser.MOD_OP, 0); }
		public MultOpContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_multOp; }
	}

	public final MultOpContext multOp() throws RecognitionException {
		MultOpContext _localctx = new MultOpContext(_ctx, getState());
		enterRule(_localctx, 40, RULE_multOp);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(235);
			_la = _input.LA(1);
			if ( !((((_la) & ~0x3f) == 0 && ((1L << _la) & ((1L << MULT_OP) | (1L << DIV_OP) | (1L << MOD_OP))) != 0)) ) {
			_errHandler.recoverInline(this);
			}
			else {
				if ( _input.LA(1)==Token.EOF ) matchedEOF = true;
				_errHandler.reportMatch(this);
				consume();
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class AddOpContext extends ParserRuleContext {
		public TerminalNode ADD_OP() { return getToken(BldItParser.ADD_OP, 0); }
		public TerminalNode SUB_OP() { return getToken(BldItParser.SUB_OP, 0); }
		public AddOpContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_addOp; }
	}

	public final AddOpContext addOp() throws RecognitionException {
		AddOpContext _localctx = new AddOpContext(_ctx, getState());
		enterRule(_localctx, 42, RULE_addOp);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(237);
			_la = _input.LA(1);
			if ( !(_la==ADD_OP || _la==SUB_OP) ) {
			_errHandler.recoverInline(this);
			}
			else {
				if ( _input.LA(1)==Token.EOF ) matchedEOF = true;
				_errHandler.reportMatch(this);
				consume();
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class CompareOpContext extends ParserRuleContext {
		public TerminalNode EQUALITY() { return getToken(BldItParser.EQUALITY, 0); }
		public TerminalNode LESS_THAN_OP() { return getToken(BldItParser.LESS_THAN_OP, 0); }
		public TerminalNode GREATER_THAN_OP() { return getToken(BldItParser.GREATER_THAN_OP, 0); }
		public TerminalNode LESS_THAN_EQUAL_OP() { return getToken(BldItParser.LESS_THAN_EQUAL_OP, 0); }
		public TerminalNode GREATER_THAN_EQUAL_OP() { return getToken(BldItParser.GREATER_THAN_EQUAL_OP, 0); }
		public CompareOpContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_compareOp; }
	}

	public final CompareOpContext compareOp() throws RecognitionException {
		CompareOpContext _localctx = new CompareOpContext(_ctx, getState());
		enterRule(_localctx, 44, RULE_compareOp);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(239);
			_la = _input.LA(1);
			if ( !((((_la) & ~0x3f) == 0 && ((1L << _la) & ((1L << GREATER_THAN_OP) | (1L << LESS_THAN_OP) | (1L << GREATER_THAN_EQUAL_OP) | (1L << LESS_THAN_EQUAL_OP) | (1L << EQUALITY))) != 0)) ) {
			_errHandler.recoverInline(this);
			}
			else {
				if ( _input.LA(1)==Token.EOF ) matchedEOF = true;
				_errHandler.reportMatch(this);
				consume();
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class BoolOpContext extends ParserRuleContext {
		public TerminalNode BOOL_OP() { return getToken(BldItParser.BOOL_OP, 0); }
		public BoolOpContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_boolOp; }
	}

	public final BoolOpContext boolOp() throws RecognitionException {
		BoolOpContext _localctx = new BoolOpContext(_ctx, getState());
		enterRule(_localctx, 46, RULE_boolOp);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(241);
			match(BOOL_OP);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class ConstantContext extends ParserRuleContext {
		public TerminalNode INTEGER() { return getToken(BldItParser.INTEGER, 0); }
		public TerminalNode FLOAT() { return getToken(BldItParser.FLOAT, 0); }
		public TerminalNode STRING() { return getToken(BldItParser.STRING, 0); }
		public TerminalNode BOOL() { return getToken(BldItParser.BOOL, 0); }
		public TerminalNode NULL() { return getToken(BldItParser.NULL, 0); }
		public ConstantContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_constant; }
	}

	public final ConstantContext constant() throws RecognitionException {
		ConstantContext _localctx = new ConstantContext(_ctx, getState());
		enterRule(_localctx, 48, RULE_constant);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(243);
			_la = _input.LA(1);
			if ( !((((_la) & ~0x3f) == 0 && ((1L << _la) & ((1L << INTEGER) | (1L << FLOAT) | (1L << STRING) | (1L << BOOL) | (1L << NULL))) != 0)) ) {
			_errHandler.recoverInline(this);
			}
			else {
				if ( _input.LA(1)==Token.EOF ) matchedEOF = true;
				_errHandler.reportMatch(this);
				consume();
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class PipelineContext extends ParserRuleContext {
		public TerminalNode PIPELINE() { return getToken(BldItParser.PIPELINE, 0); }
		public TerminalNode COLON() { return getToken(BldItParser.COLON, 0); }
		public TerminalNode NEWLINE() { return getToken(BldItParser.NEWLINE, 0); }
		public TerminalNode INDENT() { return getToken(BldItParser.INDENT, 0); }
		public PipelineSectionsContext pipelineSections() {
			return getRuleContext(PipelineSectionsContext.class,0);
		}
		public TerminalNode DEDENT() { return getToken(BldItParser.DEDENT, 0); }
		public PipelineContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_pipeline; }
	}

	public final PipelineContext pipeline() throws RecognitionException {
		PipelineContext _localctx = new PipelineContext(_ctx, getState());
		enterRule(_localctx, 50, RULE_pipeline);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(245);
			match(PIPELINE);
			setState(246);
			match(COLON);
			setState(247);
			match(NEWLINE);
			setState(248);
			match(INDENT);
			setState(249);
			pipelineSections();
			setState(250);
			match(DEDENT);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class PipelineSectionsContext extends ParserRuleContext {
		public StagesStatementContext stagesStatement() {
			return getRuleContext(StagesStatementContext.class,0);
		}
		public GlobalEnvStatementContext globalEnvStatement() {
			return getRuleContext(GlobalEnvStatementContext.class,0);
		}
		public PipelineSectionsContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_pipelineSections; }
	}

	public final PipelineSectionsContext pipelineSections() throws RecognitionException {
		PipelineSectionsContext _localctx = new PipelineSectionsContext(_ctx, getState());
		enterRule(_localctx, 52, RULE_pipelineSections);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(253);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if (_la==GLOBALENV) {
				{
				setState(252);
				globalEnvStatement();
				}
			}

			setState(255);
			stagesStatement();
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class GlobalEnvStatementContext extends ParserRuleContext {
		public TerminalNode GLOBALENV() { return getToken(BldItParser.GLOBALENV, 0); }
		public TerminalNode COLON() { return getToken(BldItParser.COLON, 0); }
		public GlobalEnvBlockContext globalEnvBlock() {
			return getRuleContext(GlobalEnvBlockContext.class,0);
		}
		public GlobalEnvStatementContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_globalEnvStatement; }
	}

	public final GlobalEnvStatementContext globalEnvStatement() throws RecognitionException {
		GlobalEnvStatementContext _localctx = new GlobalEnvStatementContext(_ctx, getState());
		enterRule(_localctx, 54, RULE_globalEnvStatement);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(257);
			match(GLOBALENV);
			setState(258);
			match(COLON);
			setState(259);
			globalEnvBlock();
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class ParameterStatementContext extends ParserRuleContext {
		public TerminalNode PARAMETERS() { return getToken(BldItParser.PARAMETERS, 0); }
		public TerminalNode COLON() { return getToken(BldItParser.COLON, 0); }
		public ParameterBlockContext parameterBlock() {
			return getRuleContext(ParameterBlockContext.class,0);
		}
		public ParameterStatementContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_parameterStatement; }
	}

	public final ParameterStatementContext parameterStatement() throws RecognitionException {
		ParameterStatementContext _localctx = new ParameterStatementContext(_ctx, getState());
		enterRule(_localctx, 56, RULE_parameterStatement);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(261);
			match(PARAMETERS);
			setState(262);
			match(COLON);
			setState(263);
			parameterBlock();
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class StagesStatementContext extends ParserRuleContext {
		public TerminalNode STAGES() { return getToken(BldItParser.STAGES, 0); }
		public TerminalNode COLON() { return getToken(BldItParser.COLON, 0); }
		public StagesBlockContext stagesBlock() {
			return getRuleContext(StagesBlockContext.class,0);
		}
		public StagesStatementContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_stagesStatement; }
	}

	public final StagesStatementContext stagesStatement() throws RecognitionException {
		StagesStatementContext _localctx = new StagesStatementContext(_ctx, getState());
		enterRule(_localctx, 58, RULE_stagesStatement);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(265);
			match(STAGES);
			setState(266);
			match(COLON);
			setState(267);
			stagesBlock();
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class GlobalEnvBlockContext extends ParserRuleContext {
		public TerminalNode NEWLINE() { return getToken(BldItParser.NEWLINE, 0); }
		public TerminalNode INDENT() { return getToken(BldItParser.INDENT, 0); }
		public EnvAssignmentsContext envAssignments() {
			return getRuleContext(EnvAssignmentsContext.class,0);
		}
		public TerminalNode DEDENT() { return getToken(BldItParser.DEDENT, 0); }
		public GlobalEnvBlockContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_globalEnvBlock; }
	}

	public final GlobalEnvBlockContext globalEnvBlock() throws RecognitionException {
		GlobalEnvBlockContext _localctx = new GlobalEnvBlockContext(_ctx, getState());
		enterRule(_localctx, 60, RULE_globalEnvBlock);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(269);
			match(NEWLINE);
			setState(270);
			match(INDENT);
			setState(271);
			envAssignments();
			setState(272);
			match(DEDENT);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class ParameterBlockContext extends ParserRuleContext {
		public TerminalNode NEWLINE() { return getToken(BldItParser.NEWLINE, 0); }
		public ParameterBlockContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_parameterBlock; }
	}

	public final ParameterBlockContext parameterBlock() throws RecognitionException {
		ParameterBlockContext _localctx = new ParameterBlockContext(_ctx, getState());
		enterRule(_localctx, 62, RULE_parameterBlock);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(274);
			match(NEWLINE);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class StagesBlockContext extends ParserRuleContext {
		public TerminalNode NEWLINE() { return getToken(BldItParser.NEWLINE, 0); }
		public TerminalNode INDENT() { return getToken(BldItParser.INDENT, 0); }
		public StageStatementsContext stageStatements() {
			return getRuleContext(StageStatementsContext.class,0);
		}
		public TerminalNode DEDENT() { return getToken(BldItParser.DEDENT, 0); }
		public StagesBlockContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_stagesBlock; }
	}

	public final StagesBlockContext stagesBlock() throws RecognitionException {
		StagesBlockContext _localctx = new StagesBlockContext(_ctx, getState());
		enterRule(_localctx, 64, RULE_stagesBlock);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(276);
			match(NEWLINE);
			setState(277);
			match(INDENT);
			setState(278);
			stageStatements();
			setState(279);
			match(DEDENT);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class StageStatementsContext extends ParserRuleContext {
		public List<StageStatementContext> stageStatement() {
			return getRuleContexts(StageStatementContext.class);
		}
		public StageStatementContext stageStatement(int i) {
			return getRuleContext(StageStatementContext.class,i);
		}
		public StageStatementsContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_stageStatements; }
	}

	public final StageStatementsContext stageStatements() throws RecognitionException {
		StageStatementsContext _localctx = new StageStatementsContext(_ctx, getState());
		enterRule(_localctx, 66, RULE_stageStatements);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(282); 
			_errHandler.sync(this);
			_la = _input.LA(1);
			do {
				{
				{
				setState(281);
				stageStatement();
				}
				}
				setState(284); 
				_errHandler.sync(this);
				_la = _input.LA(1);
			} while ( _la==STAGE );
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class StageStatementContext extends ParserRuleContext {
		public TerminalNode STAGE() { return getToken(BldItParser.STAGE, 0); }
		public TerminalNode COLON() { return getToken(BldItParser.COLON, 0); }
		public StageBlockContext stageBlock() {
			return getRuleContext(StageBlockContext.class,0);
		}
		public StageStatementContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_stageStatement; }
	}

	public final StageStatementContext stageStatement() throws RecognitionException {
		StageStatementContext _localctx = new StageStatementContext(_ctx, getState());
		enterRule(_localctx, 68, RULE_stageStatement);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(286);
			match(STAGE);
			setState(287);
			match(COLON);
			setState(288);
			stageBlock();
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class StageBlockContext extends ParserRuleContext {
		public BlockContext block() {
			return getRuleContext(BlockContext.class,0);
		}
		public StageBlockContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_stageBlock; }
	}

	public final StageBlockContext stageBlock() throws RecognitionException {
		StageBlockContext _localctx = new StageBlockContext(_ctx, getState());
		enterRule(_localctx, 70, RULE_stageBlock);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(290);
			block();
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class EnvAssignmentsContext extends ParserRuleContext {
		public List<TerminalNode> NEWLINE() { return getTokens(BldItParser.NEWLINE); }
		public TerminalNode NEWLINE(int i) {
			return getToken(BldItParser.NEWLINE, i);
		}
		public List<EnvAssignmentContext> envAssignment() {
			return getRuleContexts(EnvAssignmentContext.class);
		}
		public EnvAssignmentContext envAssignment(int i) {
			return getRuleContext(EnvAssignmentContext.class,i);
		}
		public List<TerminalNode> SEMICOLON() { return getTokens(BldItParser.SEMICOLON); }
		public TerminalNode SEMICOLON(int i) {
			return getToken(BldItParser.SEMICOLON, i);
		}
		public EnvAssignmentsContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_envAssignments; }
	}

	public final EnvAssignmentsContext envAssignments() throws RecognitionException {
		EnvAssignmentsContext _localctx = new EnvAssignmentsContext(_ctx, getState());
		enterRule(_localctx, 72, RULE_envAssignments);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(298); 
			_errHandler.sync(this);
			_la = _input.LA(1);
			do {
				{
				{
				{
				setState(292);
				envAssignment();
				}
				setState(294);
				_errHandler.sync(this);
				_la = _input.LA(1);
				if (_la==SEMICOLON) {
					{
					setState(293);
					match(SEMICOLON);
					}
				}

				setState(296);
				match(NEWLINE);
				}
				}
				setState(300); 
				_errHandler.sync(this);
				_la = _input.LA(1);
			} while ( _la==IDENTIFIER );
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class EnvAssignmentContext extends ParserRuleContext {
		public TerminalNode IDENTIFIER() { return getToken(BldItParser.IDENTIFIER, 0); }
		public TerminalNode ASSIGN_OP() { return getToken(BldItParser.ASSIGN_OP, 0); }
		public PipelineExpressionContext pipelineExpression() {
			return getRuleContext(PipelineExpressionContext.class,0);
		}
		public EnvAssignmentContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_envAssignment; }
	}

	public final EnvAssignmentContext envAssignment() throws RecognitionException {
		EnvAssignmentContext _localctx = new EnvAssignmentContext(_ctx, getState());
		enterRule(_localctx, 74, RULE_envAssignment);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(302);
			match(IDENTIFIER);
			setState(303);
			match(ASSIGN_OP);
			setState(304);
			pipelineExpression();
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class PipelineExpressionContext extends ParserRuleContext {
		public ExpressionContext expression() {
			return getRuleContext(ExpressionContext.class,0);
		}
		public PipelineExpressionContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_pipelineExpression; }
	}

	public final PipelineExpressionContext pipelineExpression() throws RecognitionException {
		PipelineExpressionContext _localctx = new PipelineExpressionContext(_ctx, getState());
		enterRule(_localctx, 76, RULE_pipelineExpression);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(306);
			expression(0);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public boolean sempred(RuleContext _localctx, int ruleIndex, int predIndex) {
		switch (ruleIndex) {
		case 17:
			return expression_sempred((ExpressionContext)_localctx, predIndex);
		}
		return true;
	}
	private boolean expression_sempred(ExpressionContext _localctx, int predIndex) {
		switch (predIndex) {
		case 0:
			return precpred(_ctx, 4);
		case 1:
			return precpred(_ctx, 3);
		case 2:
			return precpred(_ctx, 2);
		case 3:
			return precpred(_ctx, 1);
		}
		return true;
	}

	public static final String _serializedATN =
		"\3\u608b\ua72a\u8133\ub9ed\u417c\u3be7\u7786\u5964\3*\u0137\4\2\t\2\4"+
		"\3\t\3\4\4\t\4\4\5\t\5\4\6\t\6\4\7\t\7\4\b\t\b\4\t\t\t\4\n\t\n\4\13\t"+
		"\13\4\f\t\f\4\r\t\r\4\16\t\16\4\17\t\17\4\20\t\20\4\21\t\21\4\22\t\22"+
		"\4\23\t\23\4\24\t\24\4\25\t\25\4\26\t\26\4\27\t\27\4\30\t\30\4\31\t\31"+
		"\4\32\t\32\4\33\t\33\4\34\t\34\4\35\t\35\4\36\t\36\4\37\t\37\4 \t \4!"+
		"\t!\4\"\t\"\4#\t#\4$\t$\4%\t%\4&\t&\4\'\t\'\4(\t(\3\2\3\2\7\2S\n\2\f\2"+
		"\16\2V\13\2\3\2\3\2\3\2\3\3\6\3\\\n\3\r\3\16\3]\3\4\3\4\5\4b\n\4\3\5\3"+
		"\5\3\5\5\5g\n\5\3\5\5\5j\n\5\3\5\3\5\3\6\3\6\3\6\5\6q\n\6\3\7\3\7\7\7"+
		"u\n\7\f\7\16\7x\13\7\3\7\5\7{\n\7\3\b\3\b\3\b\3\b\3\b\3\t\3\t\3\t\3\t"+
		"\3\t\3\t\3\n\3\n\3\n\3\n\3\13\3\13\3\13\3\13\3\13\3\f\3\f\3\f\3\f\5\f"+
		"\u0095\n\f\3\f\3\f\3\f\3\f\3\r\3\r\3\r\7\r\u009e\n\r\f\r\16\r\u00a1\13"+
		"\r\3\16\3\16\3\16\3\16\3\16\3\16\5\16\u00a9\n\16\3\17\3\17\3\17\3\17\5"+
		"\17\u00af\n\17\3\17\5\17\u00b2\n\17\3\20\3\20\5\20\u00b6\n\20\3\21\3\21"+
		"\3\21\3\21\3\22\3\22\3\22\3\22\3\22\7\22\u00c1\n\22\f\22\16\22\u00c4\13"+
		"\22\5\22\u00c6\n\22\3\22\3\22\3\23\3\23\3\23\3\23\3\23\3\23\5\23\u00d0"+
		"\n\23\3\23\3\23\3\23\3\23\3\23\3\23\3\23\3\23\3\23\3\23\3\23\3\23\3\23"+
		"\3\23\3\23\3\23\7\23\u00e2\n\23\f\23\16\23\u00e5\13\23\3\24\3\24\3\24"+
		"\3\24\3\25\3\25\3\25\3\26\3\26\3\27\3\27\3\30\3\30\3\31\3\31\3\32\3\32"+
		"\3\33\3\33\3\33\3\33\3\33\3\33\3\33\3\34\5\34\u0100\n\34\3\34\3\34\3\35"+
		"\3\35\3\35\3\35\3\36\3\36\3\36\3\36\3\37\3\37\3\37\3\37\3 \3 \3 \3 \3"+
		" \3!\3!\3\"\3\"\3\"\3\"\3\"\3#\6#\u011d\n#\r#\16#\u011e\3$\3$\3$\3$\3"+
		"%\3%\3&\3&\5&\u0129\n&\3&\3&\6&\u012d\n&\r&\16&\u012e\3\'\3\'\3\'\3\'"+
		"\3(\3(\3(\2\3$)\2\4\6\b\n\f\16\20\22\24\26\30\32\34\36 \"$&(*,.\60\62"+
		"\64\668:<>@BDFHJLN\2\6\3\2\17\21\3\2\r\16\4\2\23\26  \3\2\"&\2\u012e\2"+
		"T\3\2\2\2\4[\3\2\2\2\6a\3\2\2\2\bf\3\2\2\2\np\3\2\2\2\fr\3\2\2\2\16|\3"+
		"\2\2\2\20\u0081\3\2\2\2\22\u0087\3\2\2\2\24\u008b\3\2\2\2\26\u0090\3\2"+
		"\2\2\30\u009a\3\2\2\2\32\u00a8\3\2\2\2\34\u00b1\3\2\2\2\36\u00b3\3\2\2"+
		"\2 \u00b7\3\2\2\2\"\u00bb\3\2\2\2$\u00cf\3\2\2\2&\u00e6\3\2\2\2(\u00ea"+
		"\3\2\2\2*\u00ed\3\2\2\2,\u00ef\3\2\2\2.\u00f1\3\2\2\2\60\u00f3\3\2\2\2"+
		"\62\u00f5\3\2\2\2\64\u00f7\3\2\2\2\66\u00ff\3\2\2\28\u0103\3\2\2\2:\u0107"+
		"\3\2\2\2<\u010b\3\2\2\2>\u010f\3\2\2\2@\u0114\3\2\2\2B\u0116\3\2\2\2D"+
		"\u011c\3\2\2\2F\u0120\3\2\2\2H\u0124\3\2\2\2J\u012c\3\2\2\2L\u0130\3\2"+
		"\2\2N\u0134\3\2\2\2PS\7)\2\2QS\5\6\4\2RP\3\2\2\2RQ\3\2\2\2SV\3\2\2\2T"+
		"R\3\2\2\2TU\3\2\2\2UW\3\2\2\2VT\3\2\2\2WX\5\64\33\2XY\7\2\2\3Y\3\3\2\2"+
		"\2Z\\\5\6\4\2[Z\3\2\2\2\\]\3\2\2\2][\3\2\2\2]^\3\2\2\2^\5\3\2\2\2_b\5"+
		"\b\5\2`b\5\n\6\2a_\3\2\2\2a`\3\2\2\2b\7\3\2\2\2cg\5 \21\2dg\5\"\22\2e"+
		"g\5\36\20\2fc\3\2\2\2fd\3\2\2\2fe\3\2\2\2gi\3\2\2\2hj\7\32\2\2ih\3\2\2"+
		"\2ij\3\2\2\2jk\3\2\2\2kl\7)\2\2l\t\3\2\2\2mq\5\f\7\2nq\5\24\13\2oq\5\26"+
		"\f\2pm\3\2\2\2pn\3\2\2\2po\3\2\2\2q\13\3\2\2\2rv\5\16\b\2su\5\20\t\2t"+
		"s\3\2\2\2ux\3\2\2\2vt\3\2\2\2vw\3\2\2\2wz\3\2\2\2xv\3\2\2\2y{\5\22\n\2"+
		"zy\3\2\2\2z{\3\2\2\2{\r\3\2\2\2|}\7\36\2\2}~\5$\23\2~\177\7\33\2\2\177"+
		"\u0080\5\32\16\2\u0080\17\3\2\2\2\u0081\u0082\7\37\2\2\u0082\u0083\7\36"+
		"\2\2\u0083\u0084\5$\23\2\u0084\u0085\7\33\2\2\u0085\u0086\5\32\16\2\u0086"+
		"\21\3\2\2\2\u0087\u0088\7\37\2\2\u0088\u0089\7\33\2\2\u0089\u008a\5\32"+
		"\16\2\u008a\23\3\2\2\2\u008b\u008c\7\n\2\2\u008c\u008d\5$\23\2\u008d\u008e"+
		"\7\33\2\2\u008e\u008f\5\32\16\2\u008f\25\3\2\2\2\u0090\u0091\7\13\2\2"+
		"\u0091\u0092\7(\2\2\u0092\u0094\7\27\2\2\u0093\u0095\5\30\r\2\u0094\u0093"+
		"\3\2\2\2\u0094\u0095\3\2\2\2\u0095\u0096\3\2\2\2\u0096\u0097\7\30\2\2"+
		"\u0097\u0098\7\33\2\2\u0098\u0099\5\34\17\2\u0099\27\3\2\2\2\u009a\u009f"+
		"\7(\2\2\u009b\u009c\7\31\2\2\u009c\u009e\7(\2\2\u009d\u009b\3\2\2\2\u009e"+
		"\u00a1\3\2\2\2\u009f\u009d\3\2\2\2\u009f\u00a0\3\2\2\2\u00a0\31\3\2\2"+
		"\2\u00a1\u009f\3\2\2\2\u00a2\u00a9\5\b\5\2\u00a3\u00a4\7)\2\2\u00a4\u00a5"+
		"\7\3\2\2\u00a5\u00a6\5\4\3\2\u00a6\u00a7\7\4\2\2\u00a7\u00a9\3\2\2\2\u00a8"+
		"\u00a2\3\2\2\2\u00a8\u00a3\3\2\2\2\u00a9\33\3\2\2\2\u00aa\u00b2\5\b\5"+
		"\2\u00ab\u00ac\7)\2\2\u00ac\u00ae\7\3\2\2\u00ad\u00af\5\4\3\2\u00ae\u00ad"+
		"\3\2\2\2\u00ae\u00af\3\2\2\2\u00af\u00b0\3\2\2\2\u00b0\u00b2\7\4\2\2\u00b1"+
		"\u00aa\3\2\2\2\u00b1\u00ab\3\2\2\2\u00b2\35\3\2\2\2\u00b3\u00b5\7\f\2"+
		"\2\u00b4\u00b6\5$\23\2\u00b5\u00b4\3\2\2\2\u00b5\u00b6\3\2\2\2\u00b6\37"+
		"\3\2\2\2\u00b7\u00b8\7(\2\2\u00b8\u00b9\7\35\2\2\u00b9\u00ba\5$\23\2\u00ba"+
		"!\3\2\2\2\u00bb\u00bc\7(\2\2\u00bc\u00c5\7\27\2\2\u00bd\u00c2\5$\23\2"+
		"\u00be\u00bf\7\31\2\2\u00bf\u00c1\5$\23\2\u00c0\u00be\3\2\2\2\u00c1\u00c4"+
		"\3\2\2\2\u00c2\u00c0\3\2\2\2\u00c2\u00c3\3\2\2\2\u00c3\u00c6\3\2\2\2\u00c4"+
		"\u00c2\3\2\2\2\u00c5\u00bd\3\2\2\2\u00c5\u00c6\3\2\2\2\u00c6\u00c7\3\2"+
		"\2\2\u00c7\u00c8\7\30\2\2\u00c8#\3\2\2\2\u00c9\u00ca\b\23\1\2\u00ca\u00d0"+
		"\5\62\32\2\u00cb\u00d0\7(\2\2\u00cc\u00d0\5\"\22\2\u00cd\u00d0\5&\24\2"+
		"\u00ce\u00d0\5(\25\2\u00cf\u00c9\3\2\2\2\u00cf\u00cb\3\2\2\2\u00cf\u00cc"+
		"\3\2\2\2\u00cf\u00cd\3\2\2\2\u00cf\u00ce\3\2\2\2\u00d0\u00e3\3\2\2\2\u00d1"+
		"\u00d2\f\6\2\2\u00d2\u00d3\5*\26\2\u00d3\u00d4\5$\23\7\u00d4\u00e2\3\2"+
		"\2\2\u00d5\u00d6\f\5\2\2\u00d6\u00d7\5,\27\2\u00d7\u00d8\5$\23\6\u00d8"+
		"\u00e2\3\2\2\2\u00d9\u00da\f\4\2\2\u00da\u00db\5.\30\2\u00db\u00dc\5$"+
		"\23\5\u00dc\u00e2\3\2\2\2\u00dd\u00de\f\3\2\2\u00de\u00df\5\60\31\2\u00df"+
		"\u00e0\5$\23\4\u00e0\u00e2\3\2\2\2\u00e1\u00d1\3\2\2\2\u00e1\u00d5\3\2"+
		"\2\2\u00e1\u00d9\3\2\2\2\u00e1\u00dd\3\2\2\2\u00e2\u00e5\3\2\2\2\u00e3"+
		"\u00e1\3\2\2\2\u00e3\u00e4\3\2\2\2\u00e4%\3\2\2\2\u00e5\u00e3\3\2\2\2"+
		"\u00e6\u00e7\7\27\2\2\u00e7\u00e8\5$\23\2\u00e8\u00e9\7\30\2\2\u00e9\'"+
		"\3\2\2\2\u00ea\u00eb\7!\2\2\u00eb\u00ec\5$\23\2\u00ec)\3\2\2\2\u00ed\u00ee"+
		"\t\2\2\2\u00ee+\3\2\2\2\u00ef\u00f0\t\3\2\2\u00f0-\3\2\2\2\u00f1\u00f2"+
		"\t\4\2\2\u00f2/\3\2\2\2\u00f3\u00f4\7\22\2\2\u00f4\61\3\2\2\2\u00f5\u00f6"+
		"\t\5\2\2\u00f6\63\3\2\2\2\u00f7\u00f8\7\5\2\2\u00f8\u00f9\7\33\2\2\u00f9"+
		"\u00fa\7)\2\2\u00fa\u00fb\7\3\2\2\u00fb\u00fc\5\66\34\2\u00fc\u00fd\7"+
		"\4\2\2\u00fd\65\3\2\2\2\u00fe\u0100\58\35\2\u00ff\u00fe\3\2\2\2\u00ff"+
		"\u0100\3\2\2\2\u0100\u0101\3\2\2\2\u0101\u0102\5<\37\2\u0102\67\3\2\2"+
		"\2\u0103\u0104\7\6\2\2\u0104\u0105\7\33\2\2\u0105\u0106\5> \2\u01069\3"+
		"\2\2\2\u0107\u0108\7\7\2\2\u0108\u0109\7\33\2\2\u0109\u010a\5@!\2\u010a"+
		";\3\2\2\2\u010b\u010c\7\b\2\2\u010c\u010d\7\33\2\2\u010d\u010e\5B\"\2"+
		"\u010e=\3\2\2\2\u010f\u0110\7)\2\2\u0110\u0111\7\3\2\2\u0111\u0112\5J"+
		"&\2\u0112\u0113\7\4\2\2\u0113?\3\2\2\2\u0114\u0115\7)\2\2\u0115A\3\2\2"+
		"\2\u0116\u0117\7)\2\2\u0117\u0118\7\3\2\2\u0118\u0119\5D#\2\u0119\u011a"+
		"\7\4\2\2\u011aC\3\2\2\2\u011b\u011d\5F$\2\u011c\u011b\3\2\2\2\u011d\u011e"+
		"\3\2\2\2\u011e\u011c\3\2\2\2\u011e\u011f\3\2\2\2\u011fE\3\2\2\2\u0120"+
		"\u0121\7\t\2\2\u0121\u0122\7\33\2\2\u0122\u0123\5H%\2\u0123G\3\2\2\2\u0124"+
		"\u0125\5\32\16\2\u0125I\3\2\2\2\u0126\u0128\5L\'\2\u0127\u0129\7\32\2"+
		"\2\u0128\u0127\3\2\2\2\u0128\u0129\3\2\2\2\u0129\u012a\3\2\2\2\u012a\u012b"+
		"\7)\2\2\u012b\u012d\3\2\2\2\u012c\u0126\3\2\2\2\u012d\u012e\3\2\2\2\u012e"+
		"\u012c\3\2\2\2\u012e\u012f\3\2\2\2\u012fK\3\2\2\2\u0130\u0131\7(\2\2\u0131"+
		"\u0132\7\35\2\2\u0132\u0133\5N(\2\u0133M\3\2\2\2\u0134\u0135\5$\23\2\u0135"+
		"O\3\2\2\2\32RT]afipvz\u0094\u009f\u00a8\u00ae\u00b1\u00b5\u00c2\u00c5"+
		"\u00cf\u00e1\u00e3\u00ff\u011e\u0128\u012e";
	public static final ATN _ATN =
		new ATNDeserializer().deserialize(_serializedATN.toCharArray());
	static {
		_decisionToDFA = new DFA[_ATN.getNumberOfDecisions()];
		for (int i = 0; i < _ATN.getNumberOfDecisions(); i++) {
			_decisionToDFA[i] = new DFA(_ATN.getDecisionState(i), i);
		}
	}
}