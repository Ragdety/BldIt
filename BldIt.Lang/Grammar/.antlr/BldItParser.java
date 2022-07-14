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
		WHILE=8, ADD_OP=9, SUB_OP=10, MULT_OP=11, DIV_OP=12, MOD_OP=13, BOOL_OP=14, 
		GREATER_THAN_OP=15, LESS_THAN_OP=16, GREATER_THAN_EQUAL_OP=17, LESS_THAN_EQUAL_OP=18, 
		OPEN_PAREN=19, CLOSE_PAREN=20, COMMA=21, SEMICOLON=22, COLON=23, DOT=24, 
		ASSIGN_OP=25, IF=26, ELSE=27, EQUALITY=28, NOT=29, INTEGER=30, FLOAT=31, 
		STRING=32, BOOL=33, NULL=34, ENDLINE=35, IDENTIFIER=36, NEWLINE=37, SKIP_=38;
	public static final int
		RULE_bldItFile = 0, RULE_statements = 1, RULE_statement = 2, RULE_simpleStatement = 3, 
		RULE_compoundStatement = 4, RULE_ifStatement = 5, RULE_singleIfBlock = 6, 
		RULE_elseBlock = 7, RULE_whileStatement = 8, RULE_block = 9, RULE_assignment = 10, 
		RULE_functionCall = 11, RULE_expression = 12, RULE_parenthExpression = 13, 
		RULE_notExpression = 14, RULE_multOp = 15, RULE_addOp = 16, RULE_compareOp = 17, 
		RULE_boolOp = 18, RULE_constant = 19, RULE_pipeline = 20, RULE_pipelineSections = 21, 
		RULE_pipelineSectionOrder = 22, RULE_globalEnvStatement = 23, RULE_parameterStatement = 24, 
		RULE_stagesStatement = 25, RULE_globalEnvBlock = 26, RULE_parameterBlock = 27, 
		RULE_stagesBlock = 28, RULE_stageStatements = 29, RULE_stageStatement = 30, 
		RULE_stageBlock = 31;
	private static String[] makeRuleNames() {
		return new String[] {
			"bldItFile", "statements", "statement", "simpleStatement", "compoundStatement", 
			"ifStatement", "singleIfBlock", "elseBlock", "whileStatement", "block", 
			"assignment", "functionCall", "expression", "parenthExpression", "notExpression", 
			"multOp", "addOp", "compareOp", "boolOp", "constant", "pipeline", "pipelineSections", 
			"pipelineSectionOrder", "globalEnvStatement", "parameterStatement", "stagesStatement", 
			"globalEnvBlock", "parameterBlock", "stagesBlock", "stageStatements", 
			"stageStatement", "stageBlock"
		};
	}
	public static final String[] ruleNames = makeRuleNames();

	private static String[] makeLiteralNames() {
		return new String[] {
			null, null, null, null, "'globalEnv'", "'parameters'", "'stages'", "'stage'", 
			"'while'", "'+'", "'-'", "'*'", "'/'", "'%'", null, "'>'", "'<'", "'>='", 
			"'<='", "'('", "')'", "','", "';'", "':'", "'.'", "'='", "'if'", "'else'", 
			null, null, null, null, null, null, "'null'"
		};
	}
	private static final String[] _LITERAL_NAMES = makeLiteralNames();
	private static String[] makeSymbolicNames() {
		return new String[] {
			null, "INDENT", "DEDENT", "PIPELINE", "GLOBALENV", "PARAMETERS", "STAGES", 
			"STAGE", "WHILE", "ADD_OP", "SUB_OP", "MULT_OP", "DIV_OP", "MOD_OP", 
			"BOOL_OP", "GREATER_THAN_OP", "LESS_THAN_OP", "GREATER_THAN_EQUAL_OP", 
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
			setState(68);
			_errHandler.sync(this);
			_la = _input.LA(1);
			while ((((_la) & ~0x3f) == 0 && ((1L << _la) & ((1L << WHILE) | (1L << IF) | (1L << IDENTIFIER) | (1L << NEWLINE))) != 0)) {
				{
				setState(66);
				_errHandler.sync(this);
				switch (_input.LA(1)) {
				case NEWLINE:
					{
					setState(64);
					match(NEWLINE);
					}
					break;
				case WHILE:
				case IF:
				case IDENTIFIER:
					{
					setState(65);
					statement();
					}
					break;
				default:
					throw new NoViableAltException(this);
				}
				}
				setState(70);
				_errHandler.sync(this);
				_la = _input.LA(1);
			}
			setState(71);
			pipeline();
			setState(72);
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
			setState(75); 
			_errHandler.sync(this);
			_la = _input.LA(1);
			do {
				{
				{
				setState(74);
				statement();
				}
				}
				setState(77); 
				_errHandler.sync(this);
				_la = _input.LA(1);
			} while ( (((_la) & ~0x3f) == 0 && ((1L << _la) & ((1L << WHILE) | (1L << IF) | (1L << IDENTIFIER))) != 0) );
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
			setState(81);
			_errHandler.sync(this);
			switch (_input.LA(1)) {
			case IDENTIFIER:
				enterOuterAlt(_localctx, 1);
				{
				setState(79);
				simpleStatement();
				}
				break;
			case WHILE:
			case IF:
				enterOuterAlt(_localctx, 2);
				{
				setState(80);
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
			setState(85);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,4,_ctx) ) {
			case 1:
				{
				setState(83);
				assignment();
				}
				break;
			case 2:
				{
				setState(84);
				functionCall();
				}
				break;
			}
			setState(88);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if (_la==SEMICOLON) {
				{
				setState(87);
				match(SEMICOLON);
				}
			}

			setState(90);
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
			setState(94);
			_errHandler.sync(this);
			switch (_input.LA(1)) {
			case IF:
				{
				setState(92);
				ifStatement();
				}
				break;
			case WHILE:
				{
				setState(93);
				whileStatement();
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
			enterOuterAlt(_localctx, 1);
			{
			setState(96);
			singleIfBlock();
			setState(98);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if (_la==ELSE) {
				{
				setState(97);
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
			setState(100);
			match(IF);
			setState(101);
			expression(0);
			setState(102);
			match(COLON);
			setState(103);
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
		enterRule(_localctx, 14, RULE_elseBlock);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(105);
			match(ELSE);
			setState(106);
			match(COLON);
			setState(107);
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
		enterRule(_localctx, 16, RULE_whileStatement);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(109);
			match(WHILE);
			setState(110);
			expression(0);
			setState(111);
			match(COLON);
			setState(112);
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
		enterRule(_localctx, 18, RULE_block);
		try {
			setState(120);
			_errHandler.sync(this);
			switch (_input.LA(1)) {
			case IDENTIFIER:
				enterOuterAlt(_localctx, 1);
				{
				setState(114);
				simpleStatement();
				}
				break;
			case NEWLINE:
				enterOuterAlt(_localctx, 2);
				{
				setState(115);
				match(NEWLINE);
				setState(116);
				match(INDENT);
				setState(117);
				statements();
				setState(118);
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
		enterRule(_localctx, 20, RULE_assignment);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(122);
			match(IDENTIFIER);
			setState(123);
			match(ASSIGN_OP);
			setState(124);
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
		enterRule(_localctx, 22, RULE_functionCall);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(126);
			match(IDENTIFIER);
			setState(127);
			match(OPEN_PAREN);
			setState(136);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if ((((_la) & ~0x3f) == 0 && ((1L << _la) & ((1L << OPEN_PAREN) | (1L << NOT) | (1L << INTEGER) | (1L << FLOAT) | (1L << STRING) | (1L << BOOL) | (1L << NULL) | (1L << IDENTIFIER))) != 0)) {
				{
				setState(128);
				expression(0);
				setState(133);
				_errHandler.sync(this);
				_la = _input.LA(1);
				while (_la==COMMA) {
					{
					{
					setState(129);
					match(COMMA);
					setState(130);
					expression(0);
					}
					}
					setState(135);
					_errHandler.sync(this);
					_la = _input.LA(1);
				}
				}
			}

			setState(138);
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
		int _startState = 24;
		enterRecursionRule(_localctx, 24, RULE_expression, _p);
		try {
			int _alt;
			enterOuterAlt(_localctx, 1);
			{
			setState(146);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,11,_ctx) ) {
			case 1:
				{
				_localctx = new ConstantExprContext(_localctx);
				_ctx = _localctx;
				_prevctx = _localctx;

				setState(141);
				constant();
				}
				break;
			case 2:
				{
				_localctx = new IdentifierExprContext(_localctx);
				_ctx = _localctx;
				_prevctx = _localctx;
				setState(142);
				match(IDENTIFIER);
				}
				break;
			case 3:
				{
				_localctx = new FunctionCallExprContext(_localctx);
				_ctx = _localctx;
				_prevctx = _localctx;
				setState(143);
				functionCall();
				}
				break;
			case 4:
				{
				_localctx = new ParenthesizedExprContext(_localctx);
				_ctx = _localctx;
				_prevctx = _localctx;
				setState(144);
				parenthExpression();
				}
				break;
			case 5:
				{
				_localctx = new NotExprContext(_localctx);
				_ctx = _localctx;
				_prevctx = _localctx;
				setState(145);
				notExpression();
				}
				break;
			}
			_ctx.stop = _input.LT(-1);
			setState(166);
			_errHandler.sync(this);
			_alt = getInterpreter().adaptivePredict(_input,13,_ctx);
			while ( _alt!=2 && _alt!=org.antlr.v4.runtime.atn.ATN.INVALID_ALT_NUMBER ) {
				if ( _alt==1 ) {
					if ( _parseListeners!=null ) triggerExitRuleEvent();
					_prevctx = _localctx;
					{
					setState(164);
					_errHandler.sync(this);
					switch ( getInterpreter().adaptivePredict(_input,12,_ctx) ) {
					case 1:
						{
						_localctx = new MultiplicativeExprContext(new ExpressionContext(_parentctx, _parentState));
						pushNewRecursionContext(_localctx, _startState, RULE_expression);
						setState(148);
						if (!(precpred(_ctx, 4))) throw new FailedPredicateException(this, "precpred(_ctx, 4)");
						setState(149);
						multOp();
						setState(150);
						expression(5);
						}
						break;
					case 2:
						{
						_localctx = new AdditiveExprContext(new ExpressionContext(_parentctx, _parentState));
						pushNewRecursionContext(_localctx, _startState, RULE_expression);
						setState(152);
						if (!(precpred(_ctx, 3))) throw new FailedPredicateException(this, "precpred(_ctx, 3)");
						setState(153);
						addOp();
						setState(154);
						expression(4);
						}
						break;
					case 3:
						{
						_localctx = new ComparisonExprContext(new ExpressionContext(_parentctx, _parentState));
						pushNewRecursionContext(_localctx, _startState, RULE_expression);
						setState(156);
						if (!(precpred(_ctx, 2))) throw new FailedPredicateException(this, "precpred(_ctx, 2)");
						setState(157);
						compareOp();
						setState(158);
						expression(3);
						}
						break;
					case 4:
						{
						_localctx = new BooleanExprContext(new ExpressionContext(_parentctx, _parentState));
						pushNewRecursionContext(_localctx, _startState, RULE_expression);
						setState(160);
						if (!(precpred(_ctx, 1))) throw new FailedPredicateException(this, "precpred(_ctx, 1)");
						setState(161);
						boolOp();
						setState(162);
						expression(2);
						}
						break;
					}
					} 
				}
				setState(168);
				_errHandler.sync(this);
				_alt = getInterpreter().adaptivePredict(_input,13,_ctx);
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
		enterRule(_localctx, 26, RULE_parenthExpression);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(169);
			match(OPEN_PAREN);
			setState(170);
			expression(0);
			setState(171);
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
		enterRule(_localctx, 28, RULE_notExpression);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(173);
			match(NOT);
			setState(174);
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
		enterRule(_localctx, 30, RULE_multOp);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(176);
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
		enterRule(_localctx, 32, RULE_addOp);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(178);
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
		enterRule(_localctx, 34, RULE_compareOp);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(180);
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
		enterRule(_localctx, 36, RULE_boolOp);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(182);
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
		enterRule(_localctx, 38, RULE_constant);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(184);
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
		enterRule(_localctx, 40, RULE_pipeline);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(186);
			match(PIPELINE);
			setState(187);
			match(COLON);
			setState(188);
			match(NEWLINE);
			setState(189);
			match(INDENT);
			setState(190);
			pipelineSections();
			setState(191);
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
		public PipelineSectionOrderContext pipelineSectionOrder() {
			return getRuleContext(PipelineSectionOrderContext.class,0);
		}
		public PipelineSectionsContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_pipelineSections; }
	}

	public final PipelineSectionsContext pipelineSections() throws RecognitionException {
		PipelineSectionsContext _localctx = new PipelineSectionsContext(_ctx, getState());
		enterRule(_localctx, 42, RULE_pipelineSections);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(193);
			pipelineSectionOrder();
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

	public static class PipelineSectionOrderContext extends ParserRuleContext {
		public StagesStatementContext stagesStatement() {
			return getRuleContext(StagesStatementContext.class,0);
		}
		public GlobalEnvStatementContext globalEnvStatement() {
			return getRuleContext(GlobalEnvStatementContext.class,0);
		}
		public ParameterStatementContext parameterStatement() {
			return getRuleContext(ParameterStatementContext.class,0);
		}
		public PipelineSectionOrderContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_pipelineSectionOrder; }
	}

	public final PipelineSectionOrderContext pipelineSectionOrder() throws RecognitionException {
		PipelineSectionOrderContext _localctx = new PipelineSectionOrderContext(_ctx, getState());
		enterRule(_localctx, 44, RULE_pipelineSectionOrder);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(196);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if (_la==GLOBALENV) {
				{
				setState(195);
				globalEnvStatement();
				}
			}

			setState(199);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if (_la==PARAMETERS) {
				{
				setState(198);
				parameterStatement();
				}
			}

			setState(201);
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
		enterRule(_localctx, 46, RULE_globalEnvStatement);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(203);
			match(GLOBALENV);
			setState(204);
			match(COLON);
			setState(205);
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
		enterRule(_localctx, 48, RULE_parameterStatement);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(207);
			match(PARAMETERS);
			setState(208);
			match(COLON);
			setState(209);
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
		enterRule(_localctx, 50, RULE_stagesStatement);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(211);
			match(STAGES);
			setState(212);
			match(COLON);
			setState(213);
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
		public GlobalEnvBlockContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_globalEnvBlock; }
	}

	public final GlobalEnvBlockContext globalEnvBlock() throws RecognitionException {
		GlobalEnvBlockContext _localctx = new GlobalEnvBlockContext(_ctx, getState());
		enterRule(_localctx, 52, RULE_globalEnvBlock);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(215);
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

	public static class ParameterBlockContext extends ParserRuleContext {
		public TerminalNode NEWLINE() { return getToken(BldItParser.NEWLINE, 0); }
		public ParameterBlockContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_parameterBlock; }
	}

	public final ParameterBlockContext parameterBlock() throws RecognitionException {
		ParameterBlockContext _localctx = new ParameterBlockContext(_ctx, getState());
		enterRule(_localctx, 54, RULE_parameterBlock);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(217);
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
		enterRule(_localctx, 56, RULE_stagesBlock);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(219);
			match(NEWLINE);
			setState(220);
			match(INDENT);
			setState(221);
			stageStatements();
			setState(222);
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
		enterRule(_localctx, 58, RULE_stageStatements);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(225); 
			_errHandler.sync(this);
			_la = _input.LA(1);
			do {
				{
				{
				setState(224);
				stageStatement();
				}
				}
				setState(227); 
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
		enterRule(_localctx, 60, RULE_stageStatement);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(229);
			match(STAGE);
			setState(230);
			match(COLON);
			setState(231);
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
		enterRule(_localctx, 62, RULE_stageBlock);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(233);
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

	public boolean sempred(RuleContext _localctx, int ruleIndex, int predIndex) {
		switch (ruleIndex) {
		case 12:
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
		"\3\u608b\ua72a\u8133\ub9ed\u417c\u3be7\u7786\u5964\3(\u00ee\4\2\t\2\4"+
		"\3\t\3\4\4\t\4\4\5\t\5\4\6\t\6\4\7\t\7\4\b\t\b\4\t\t\t\4\n\t\n\4\13\t"+
		"\13\4\f\t\f\4\r\t\r\4\16\t\16\4\17\t\17\4\20\t\20\4\21\t\21\4\22\t\22"+
		"\4\23\t\23\4\24\t\24\4\25\t\25\4\26\t\26\4\27\t\27\4\30\t\30\4\31\t\31"+
		"\4\32\t\32\4\33\t\33\4\34\t\34\4\35\t\35\4\36\t\36\4\37\t\37\4 \t \4!"+
		"\t!\3\2\3\2\7\2E\n\2\f\2\16\2H\13\2\3\2\3\2\3\2\3\3\6\3N\n\3\r\3\16\3"+
		"O\3\4\3\4\5\4T\n\4\3\5\3\5\5\5X\n\5\3\5\5\5[\n\5\3\5\3\5\3\6\3\6\5\6a"+
		"\n\6\3\7\3\7\5\7e\n\7\3\b\3\b\3\b\3\b\3\b\3\t\3\t\3\t\3\t\3\n\3\n\3\n"+
		"\3\n\3\n\3\13\3\13\3\13\3\13\3\13\3\13\5\13{\n\13\3\f\3\f\3\f\3\f\3\r"+
		"\3\r\3\r\3\r\3\r\7\r\u0086\n\r\f\r\16\r\u0089\13\r\5\r\u008b\n\r\3\r\3"+
		"\r\3\16\3\16\3\16\3\16\3\16\3\16\5\16\u0095\n\16\3\16\3\16\3\16\3\16\3"+
		"\16\3\16\3\16\3\16\3\16\3\16\3\16\3\16\3\16\3\16\3\16\3\16\7\16\u00a7"+
		"\n\16\f\16\16\16\u00aa\13\16\3\17\3\17\3\17\3\17\3\20\3\20\3\20\3\21\3"+
		"\21\3\22\3\22\3\23\3\23\3\24\3\24\3\25\3\25\3\26\3\26\3\26\3\26\3\26\3"+
		"\26\3\26\3\27\3\27\3\30\5\30\u00c7\n\30\3\30\5\30\u00ca\n\30\3\30\3\30"+
		"\3\31\3\31\3\31\3\31\3\32\3\32\3\32\3\32\3\33\3\33\3\33\3\33\3\34\3\34"+
		"\3\35\3\35\3\36\3\36\3\36\3\36\3\36\3\37\6\37\u00e4\n\37\r\37\16\37\u00e5"+
		"\3 \3 \3 \3 \3!\3!\3!\2\3\32\"\2\4\6\b\n\f\16\20\22\24\26\30\32\34\36"+
		" \"$&(*,.\60\62\64\668:<>@\2\6\3\2\r\17\3\2\13\f\4\2\21\24\36\36\3\2 "+
		"$\2\u00e3\2F\3\2\2\2\4M\3\2\2\2\6S\3\2\2\2\bW\3\2\2\2\n`\3\2\2\2\fb\3"+
		"\2\2\2\16f\3\2\2\2\20k\3\2\2\2\22o\3\2\2\2\24z\3\2\2\2\26|\3\2\2\2\30"+
		"\u0080\3\2\2\2\32\u0094\3\2\2\2\34\u00ab\3\2\2\2\36\u00af\3\2\2\2 \u00b2"+
		"\3\2\2\2\"\u00b4\3\2\2\2$\u00b6\3\2\2\2&\u00b8\3\2\2\2(\u00ba\3\2\2\2"+
		"*\u00bc\3\2\2\2,\u00c3\3\2\2\2.\u00c6\3\2\2\2\60\u00cd\3\2\2\2\62\u00d1"+
		"\3\2\2\2\64\u00d5\3\2\2\2\66\u00d9\3\2\2\28\u00db\3\2\2\2:\u00dd\3\2\2"+
		"\2<\u00e3\3\2\2\2>\u00e7\3\2\2\2@\u00eb\3\2\2\2BE\7\'\2\2CE\5\6\4\2DB"+
		"\3\2\2\2DC\3\2\2\2EH\3\2\2\2FD\3\2\2\2FG\3\2\2\2GI\3\2\2\2HF\3\2\2\2I"+
		"J\5*\26\2JK\7\2\2\3K\3\3\2\2\2LN\5\6\4\2ML\3\2\2\2NO\3\2\2\2OM\3\2\2\2"+
		"OP\3\2\2\2P\5\3\2\2\2QT\5\b\5\2RT\5\n\6\2SQ\3\2\2\2SR\3\2\2\2T\7\3\2\2"+
		"\2UX\5\26\f\2VX\5\30\r\2WU\3\2\2\2WV\3\2\2\2XZ\3\2\2\2Y[\7\30\2\2ZY\3"+
		"\2\2\2Z[\3\2\2\2[\\\3\2\2\2\\]\7\'\2\2]\t\3\2\2\2^a\5\f\7\2_a\5\22\n\2"+
		"`^\3\2\2\2`_\3\2\2\2a\13\3\2\2\2bd\5\16\b\2ce\5\20\t\2dc\3\2\2\2de\3\2"+
		"\2\2e\r\3\2\2\2fg\7\34\2\2gh\5\32\16\2hi\7\31\2\2ij\5\24\13\2j\17\3\2"+
		"\2\2kl\7\35\2\2lm\7\31\2\2mn\5\24\13\2n\21\3\2\2\2op\7\n\2\2pq\5\32\16"+
		"\2qr\7\31\2\2rs\5\24\13\2s\23\3\2\2\2t{\5\b\5\2uv\7\'\2\2vw\7\3\2\2wx"+
		"\5\4\3\2xy\7\4\2\2y{\3\2\2\2zt\3\2\2\2zu\3\2\2\2{\25\3\2\2\2|}\7&\2\2"+
		"}~\7\33\2\2~\177\5\32\16\2\177\27\3\2\2\2\u0080\u0081\7&\2\2\u0081\u008a"+
		"\7\25\2\2\u0082\u0087\5\32\16\2\u0083\u0084\7\27\2\2\u0084\u0086\5\32"+
		"\16\2\u0085\u0083\3\2\2\2\u0086\u0089\3\2\2\2\u0087\u0085\3\2\2\2\u0087"+
		"\u0088\3\2\2\2\u0088\u008b\3\2\2\2\u0089\u0087\3\2\2\2\u008a\u0082\3\2"+
		"\2\2\u008a\u008b\3\2\2\2\u008b\u008c\3\2\2\2\u008c\u008d\7\26\2\2\u008d"+
		"\31\3\2\2\2\u008e\u008f\b\16\1\2\u008f\u0095\5(\25\2\u0090\u0095\7&\2"+
		"\2\u0091\u0095\5\30\r\2\u0092\u0095\5\34\17\2\u0093\u0095\5\36\20\2\u0094"+
		"\u008e\3\2\2\2\u0094\u0090\3\2\2\2\u0094\u0091\3\2\2\2\u0094\u0092\3\2"+
		"\2\2\u0094\u0093\3\2\2\2\u0095\u00a8\3\2\2\2\u0096\u0097\f\6\2\2\u0097"+
		"\u0098\5 \21\2\u0098\u0099\5\32\16\7\u0099\u00a7\3\2\2\2\u009a\u009b\f"+
		"\5\2\2\u009b\u009c\5\"\22\2\u009c\u009d\5\32\16\6\u009d\u00a7\3\2\2\2"+
		"\u009e\u009f\f\4\2\2\u009f\u00a0\5$\23\2\u00a0\u00a1\5\32\16\5\u00a1\u00a7"+
		"\3\2\2\2\u00a2\u00a3\f\3\2\2\u00a3\u00a4\5&\24\2\u00a4\u00a5\5\32\16\4"+
		"\u00a5\u00a7\3\2\2\2\u00a6\u0096\3\2\2\2\u00a6\u009a\3\2\2\2\u00a6\u009e"+
		"\3\2\2\2\u00a6\u00a2\3\2\2\2\u00a7\u00aa\3\2\2\2\u00a8\u00a6\3\2\2\2\u00a8"+
		"\u00a9\3\2\2\2\u00a9\33\3\2\2\2\u00aa\u00a8\3\2\2\2\u00ab\u00ac\7\25\2"+
		"\2\u00ac\u00ad\5\32\16\2\u00ad\u00ae\7\26\2\2\u00ae\35\3\2\2\2\u00af\u00b0"+
		"\7\37\2\2\u00b0\u00b1\5\32\16\2\u00b1\37\3\2\2\2\u00b2\u00b3\t\2\2\2\u00b3"+
		"!\3\2\2\2\u00b4\u00b5\t\3\2\2\u00b5#\3\2\2\2\u00b6\u00b7\t\4\2\2\u00b7"+
		"%\3\2\2\2\u00b8\u00b9\7\20\2\2\u00b9\'\3\2\2\2\u00ba\u00bb\t\5\2\2\u00bb"+
		")\3\2\2\2\u00bc\u00bd\7\5\2\2\u00bd\u00be\7\31\2\2\u00be\u00bf\7\'\2\2"+
		"\u00bf\u00c0\7\3\2\2\u00c0\u00c1\5,\27\2\u00c1\u00c2\7\4\2\2\u00c2+\3"+
		"\2\2\2\u00c3\u00c4\5.\30\2\u00c4-\3\2\2\2\u00c5\u00c7\5\60\31\2\u00c6"+
		"\u00c5\3\2\2\2\u00c6\u00c7\3\2\2\2\u00c7\u00c9\3\2\2\2\u00c8\u00ca\5\62"+
		"\32\2\u00c9\u00c8\3\2\2\2\u00c9\u00ca\3\2\2\2\u00ca\u00cb\3\2\2\2\u00cb"+
		"\u00cc\5\64\33\2\u00cc/\3\2\2\2\u00cd\u00ce\7\6\2\2\u00ce\u00cf\7\31\2"+
		"\2\u00cf\u00d0\5\66\34\2\u00d0\61\3\2\2\2\u00d1\u00d2\7\7\2\2\u00d2\u00d3"+
		"\7\31\2\2\u00d3\u00d4\58\35\2\u00d4\63\3\2\2\2\u00d5\u00d6\7\b\2\2\u00d6"+
		"\u00d7\7\31\2\2\u00d7\u00d8\5:\36\2\u00d8\65\3\2\2\2\u00d9\u00da\7\'\2"+
		"\2\u00da\67\3\2\2\2\u00db\u00dc\7\'\2\2\u00dc9\3\2\2\2\u00dd\u00de\7\'"+
		"\2\2\u00de\u00df\7\3\2\2\u00df\u00e0\5<\37\2\u00e0\u00e1\7\4\2\2\u00e1"+
		";\3\2\2\2\u00e2\u00e4\5> \2\u00e3\u00e2\3\2\2\2\u00e4\u00e5\3\2\2\2\u00e5"+
		"\u00e3\3\2\2\2\u00e5\u00e6\3\2\2\2\u00e6=\3\2\2\2\u00e7\u00e8\7\t\2\2"+
		"\u00e8\u00e9\7\31\2\2\u00e9\u00ea\5@!\2\u00ea?\3\2\2\2\u00eb\u00ec\5\24"+
		"\13\2\u00ecA\3\2\2\2\23DFOSWZ`dz\u0087\u008a\u0094\u00a6\u00a8\u00c6\u00c9"+
		"\u00e5";
	public static final ATN _ATN =
		new ATNDeserializer().deserialize(_serializedATN.toCharArray());
	static {
		_decisionToDFA = new DFA[_ATN.getNumberOfDecisions()];
		for (int i = 0; i < _ATN.getNumberOfDecisions(); i++) {
			_decisionToDFA[i] = new DFA(_ATN.getDecisionState(i), i);
		}
	}
}