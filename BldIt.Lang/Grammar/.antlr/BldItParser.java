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
		INDENT=1, DEDENT=2, NL=3, WHILE=4, ADD_OP=5, SUB_OP=6, MULT_OP=7, DIV_OP=8, 
		MOD_OP=9, BOOL_OP=10, GREATER_THAN_OP=11, LESS_THAN_OP=12, GREATER_THAN_EQUAL_OP=13, 
		LESS_THAN_EQUAL_OP=14, OPEN_PAREN=15, CLOSE_PAREN=16, COMMA=17, SEMICOLON=18, 
		COLON=19, DOT=20, ASSIGN_OP=21, IF=22, ELSE=23, EQUALITY=24, NOT=25, INTEGER=26, 
		FLOAT=27, STRING=28, BOOL=29, NULL=30, ENDLINE=31, WS=32, IDENTIFIER=33;
	public static final int
		RULE_program = 0, RULE_line = 1, RULE_statement = 2, RULE_ifBlock = 3, 
		RULE_elseIfBlock = 4, RULE_whileBlock = 5, RULE_block = 6, RULE_assignment = 7, 
		RULE_functionCall = 8, RULE_expression = 9, RULE_parenthExpression = 10, 
		RULE_notExpression = 11, RULE_multOp = 12, RULE_addOp = 13, RULE_compareOp = 14, 
		RULE_boolOp = 15, RULE_constant = 16;
	private static String[] makeRuleNames() {
		return new String[] {
			"program", "line", "statement", "ifBlock", "elseIfBlock", "whileBlock", 
			"block", "assignment", "functionCall", "expression", "parenthExpression", 
			"notExpression", "multOp", "addOp", "compareOp", "boolOp", "constant"
		};
	}
	public static final String[] ruleNames = makeRuleNames();

	private static String[] makeLiteralNames() {
		return new String[] {
			null, null, null, null, "'while'", "'+'", "'-'", "'*'", "'/'", "'%'", 
			null, "'>'", "'<'", "'>='", "'<='", "'('", "')'", "','", "';'", "':'", 
			"'.'", "'='", "'if'", "'else'", null, null, null, null, null, null, "'null'"
		};
	}
	private static final String[] _LITERAL_NAMES = makeLiteralNames();
	private static String[] makeSymbolicNames() {
		return new String[] {
			null, "INDENT", "DEDENT", "NL", "WHILE", "ADD_OP", "SUB_OP", "MULT_OP", 
			"DIV_OP", "MOD_OP", "BOOL_OP", "GREATER_THAN_OP", "LESS_THAN_OP", "GREATER_THAN_EQUAL_OP", 
			"LESS_THAN_EQUAL_OP", "OPEN_PAREN", "CLOSE_PAREN", "COMMA", "SEMICOLON", 
			"COLON", "DOT", "ASSIGN_OP", "IF", "ELSE", "EQUALITY", "NOT", "INTEGER", 
			"FLOAT", "STRING", "BOOL", "NULL", "ENDLINE", "WS", "IDENTIFIER"
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

	public static class ProgramContext extends ParserRuleContext {
		public TerminalNode EOF() { return getToken(BldItParser.EOF, 0); }
		public List<LineContext> line() {
			return getRuleContexts(LineContext.class);
		}
		public LineContext line(int i) {
			return getRuleContext(LineContext.class,i);
		}
		public ProgramContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_program; }
	}

	public final ProgramContext program() throws RecognitionException {
		ProgramContext _localctx = new ProgramContext(_ctx, getState());
		enterRule(_localctx, 0, RULE_program);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(37);
			_errHandler.sync(this);
			_la = _input.LA(1);
			while ((((_la) & ~0x3f) == 0 && ((1L << _la) & ((1L << WHILE) | (1L << IF) | (1L << IDENTIFIER))) != 0)) {
				{
				{
				setState(34);
				line();
				}
				}
				setState(39);
				_errHandler.sync(this);
				_la = _input.LA(1);
			}
			setState(40);
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

	public static class LineContext extends ParserRuleContext {
		public StatementContext statement() {
			return getRuleContext(StatementContext.class,0);
		}
		public IfBlockContext ifBlock() {
			return getRuleContext(IfBlockContext.class,0);
		}
		public WhileBlockContext whileBlock() {
			return getRuleContext(WhileBlockContext.class,0);
		}
		public LineContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_line; }
	}

	public final LineContext line() throws RecognitionException {
		LineContext _localctx = new LineContext(_ctx, getState());
		enterRule(_localctx, 2, RULE_line);
		try {
			setState(45);
			_errHandler.sync(this);
			switch (_input.LA(1)) {
			case IDENTIFIER:
				enterOuterAlt(_localctx, 1);
				{
				setState(42);
				statement();
				}
				break;
			case IF:
				enterOuterAlt(_localctx, 2);
				{
				setState(43);
				ifBlock();
				}
				break;
			case WHILE:
				enterOuterAlt(_localctx, 3);
				{
				setState(44);
				whileBlock();
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

	public static class StatementContext extends ParserRuleContext {
		public TerminalNode NL() { return getToken(BldItParser.NL, 0); }
		public AssignmentContext assignment() {
			return getRuleContext(AssignmentContext.class,0);
		}
		public FunctionCallContext functionCall() {
			return getRuleContext(FunctionCallContext.class,0);
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
			enterOuterAlt(_localctx, 1);
			{
			setState(49);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,2,_ctx) ) {
			case 1:
				{
				setState(47);
				assignment();
				}
				break;
			case 2:
				{
				setState(48);
				functionCall();
				}
				break;
			}
			setState(51);
			match(NL);
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

	public static class IfBlockContext extends ParserRuleContext {
		public TerminalNode IF() { return getToken(BldItParser.IF, 0); }
		public ExpressionContext expression() {
			return getRuleContext(ExpressionContext.class,0);
		}
		public BlockContext block() {
			return getRuleContext(BlockContext.class,0);
		}
		public TerminalNode ELSE() { return getToken(BldItParser.ELSE, 0); }
		public ElseIfBlockContext elseIfBlock() {
			return getRuleContext(ElseIfBlockContext.class,0);
		}
		public IfBlockContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_ifBlock; }
	}

	public final IfBlockContext ifBlock() throws RecognitionException {
		IfBlockContext _localctx = new IfBlockContext(_ctx, getState());
		enterRule(_localctx, 6, RULE_ifBlock);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(53);
			match(IF);
			setState(54);
			expression(0);
			setState(55);
			block();
			setState(58);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if (_la==ELSE) {
				{
				setState(56);
				match(ELSE);
				setState(57);
				elseIfBlock();
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

	public static class ElseIfBlockContext extends ParserRuleContext {
		public BlockContext block() {
			return getRuleContext(BlockContext.class,0);
		}
		public IfBlockContext ifBlock() {
			return getRuleContext(IfBlockContext.class,0);
		}
		public ElseIfBlockContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_elseIfBlock; }
	}

	public final ElseIfBlockContext elseIfBlock() throws RecognitionException {
		ElseIfBlockContext _localctx = new ElseIfBlockContext(_ctx, getState());
		enterRule(_localctx, 8, RULE_elseIfBlock);
		try {
			setState(62);
			_errHandler.sync(this);
			switch (_input.LA(1)) {
			case COLON:
				enterOuterAlt(_localctx, 1);
				{
				setState(60);
				block();
				}
				break;
			case IF:
				enterOuterAlt(_localctx, 2);
				{
				setState(61);
				ifBlock();
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

	public static class WhileBlockContext extends ParserRuleContext {
		public TerminalNode WHILE() { return getToken(BldItParser.WHILE, 0); }
		public ExpressionContext expression() {
			return getRuleContext(ExpressionContext.class,0);
		}
		public BlockContext block() {
			return getRuleContext(BlockContext.class,0);
		}
		public WhileBlockContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_whileBlock; }
	}

	public final WhileBlockContext whileBlock() throws RecognitionException {
		WhileBlockContext _localctx = new WhileBlockContext(_ctx, getState());
		enterRule(_localctx, 10, RULE_whileBlock);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(64);
			match(WHILE);
			setState(65);
			expression(0);
			setState(66);
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
		public TerminalNode COLON() { return getToken(BldItParser.COLON, 0); }
		public TerminalNode INDENT() { return getToken(BldItParser.INDENT, 0); }
		public TerminalNode DEDENT() { return getToken(BldItParser.DEDENT, 0); }
		public List<StatementContext> statement() {
			return getRuleContexts(StatementContext.class);
		}
		public StatementContext statement(int i) {
			return getRuleContext(StatementContext.class,i);
		}
		public BlockContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_block; }
	}

	public final BlockContext block() throws RecognitionException {
		BlockContext _localctx = new BlockContext(_ctx, getState());
		enterRule(_localctx, 12, RULE_block);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(68);
			match(COLON);
			setState(69);
			match(INDENT);
			setState(71); 
			_errHandler.sync(this);
			_la = _input.LA(1);
			do {
				{
				{
				setState(70);
				statement();
				}
				}
				setState(73); 
				_errHandler.sync(this);
				_la = _input.LA(1);
			} while ( _la==IDENTIFIER );
			setState(75);
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
		enterRule(_localctx, 14, RULE_assignment);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(77);
			match(IDENTIFIER);
			setState(78);
			match(ASSIGN_OP);
			setState(79);
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
		enterRule(_localctx, 16, RULE_functionCall);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(81);
			match(IDENTIFIER);
			setState(82);
			match(OPEN_PAREN);
			setState(91);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if ((((_la) & ~0x3f) == 0 && ((1L << _la) & ((1L << OPEN_PAREN) | (1L << NOT) | (1L << INTEGER) | (1L << FLOAT) | (1L << STRING) | (1L << BOOL) | (1L << NULL) | (1L << IDENTIFIER))) != 0)) {
				{
				setState(83);
				expression(0);
				setState(88);
				_errHandler.sync(this);
				_la = _input.LA(1);
				while (_la==COMMA) {
					{
					{
					setState(84);
					match(COMMA);
					setState(85);
					expression(0);
					}
					}
					setState(90);
					_errHandler.sync(this);
					_la = _input.LA(1);
				}
				}
			}

			setState(93);
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
		int _startState = 18;
		enterRecursionRule(_localctx, 18, RULE_expression, _p);
		try {
			int _alt;
			enterOuterAlt(_localctx, 1);
			{
			setState(101);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,8,_ctx) ) {
			case 1:
				{
				_localctx = new ConstantExprContext(_localctx);
				_ctx = _localctx;
				_prevctx = _localctx;

				setState(96);
				constant();
				}
				break;
			case 2:
				{
				_localctx = new IdentifierExprContext(_localctx);
				_ctx = _localctx;
				_prevctx = _localctx;
				setState(97);
				match(IDENTIFIER);
				}
				break;
			case 3:
				{
				_localctx = new FunctionCallExprContext(_localctx);
				_ctx = _localctx;
				_prevctx = _localctx;
				setState(98);
				functionCall();
				}
				break;
			case 4:
				{
				_localctx = new ParenthesizedExprContext(_localctx);
				_ctx = _localctx;
				_prevctx = _localctx;
				setState(99);
				parenthExpression();
				}
				break;
			case 5:
				{
				_localctx = new NotExprContext(_localctx);
				_ctx = _localctx;
				_prevctx = _localctx;
				setState(100);
				notExpression();
				}
				break;
			}
			_ctx.stop = _input.LT(-1);
			setState(121);
			_errHandler.sync(this);
			_alt = getInterpreter().adaptivePredict(_input,10,_ctx);
			while ( _alt!=2 && _alt!=org.antlr.v4.runtime.atn.ATN.INVALID_ALT_NUMBER ) {
				if ( _alt==1 ) {
					if ( _parseListeners!=null ) triggerExitRuleEvent();
					_prevctx = _localctx;
					{
					setState(119);
					_errHandler.sync(this);
					switch ( getInterpreter().adaptivePredict(_input,9,_ctx) ) {
					case 1:
						{
						_localctx = new MultiplicativeExprContext(new ExpressionContext(_parentctx, _parentState));
						pushNewRecursionContext(_localctx, _startState, RULE_expression);
						setState(103);
						if (!(precpred(_ctx, 4))) throw new FailedPredicateException(this, "precpred(_ctx, 4)");
						setState(104);
						multOp();
						setState(105);
						expression(5);
						}
						break;
					case 2:
						{
						_localctx = new AdditiveExprContext(new ExpressionContext(_parentctx, _parentState));
						pushNewRecursionContext(_localctx, _startState, RULE_expression);
						setState(107);
						if (!(precpred(_ctx, 3))) throw new FailedPredicateException(this, "precpred(_ctx, 3)");
						setState(108);
						addOp();
						setState(109);
						expression(4);
						}
						break;
					case 3:
						{
						_localctx = new ComparisonExprContext(new ExpressionContext(_parentctx, _parentState));
						pushNewRecursionContext(_localctx, _startState, RULE_expression);
						setState(111);
						if (!(precpred(_ctx, 2))) throw new FailedPredicateException(this, "precpred(_ctx, 2)");
						setState(112);
						compareOp();
						setState(113);
						expression(3);
						}
						break;
					case 4:
						{
						_localctx = new BooleanExprContext(new ExpressionContext(_parentctx, _parentState));
						pushNewRecursionContext(_localctx, _startState, RULE_expression);
						setState(115);
						if (!(precpred(_ctx, 1))) throw new FailedPredicateException(this, "precpred(_ctx, 1)");
						setState(116);
						boolOp();
						setState(117);
						expression(2);
						}
						break;
					}
					} 
				}
				setState(123);
				_errHandler.sync(this);
				_alt = getInterpreter().adaptivePredict(_input,10,_ctx);
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
		enterRule(_localctx, 20, RULE_parenthExpression);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(124);
			match(OPEN_PAREN);
			setState(125);
			expression(0);
			setState(126);
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
		enterRule(_localctx, 22, RULE_notExpression);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(128);
			match(NOT);
			setState(129);
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
		enterRule(_localctx, 24, RULE_multOp);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(131);
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
		enterRule(_localctx, 26, RULE_addOp);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(133);
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
		enterRule(_localctx, 28, RULE_compareOp);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(135);
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
		enterRule(_localctx, 30, RULE_boolOp);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(137);
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
		enterRule(_localctx, 32, RULE_constant);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(139);
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

	public boolean sempred(RuleContext _localctx, int ruleIndex, int predIndex) {
		switch (ruleIndex) {
		case 9:
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
		"\3\u608b\ua72a\u8133\ub9ed\u417c\u3be7\u7786\u5964\3#\u0090\4\2\t\2\4"+
		"\3\t\3\4\4\t\4\4\5\t\5\4\6\t\6\4\7\t\7\4\b\t\b\4\t\t\t\4\n\t\n\4\13\t"+
		"\13\4\f\t\f\4\r\t\r\4\16\t\16\4\17\t\17\4\20\t\20\4\21\t\21\4\22\t\22"+
		"\3\2\7\2&\n\2\f\2\16\2)\13\2\3\2\3\2\3\3\3\3\3\3\5\3\60\n\3\3\4\3\4\5"+
		"\4\64\n\4\3\4\3\4\3\5\3\5\3\5\3\5\3\5\5\5=\n\5\3\6\3\6\5\6A\n\6\3\7\3"+
		"\7\3\7\3\7\3\b\3\b\3\b\6\bJ\n\b\r\b\16\bK\3\b\3\b\3\t\3\t\3\t\3\t\3\n"+
		"\3\n\3\n\3\n\3\n\7\nY\n\n\f\n\16\n\\\13\n\5\n^\n\n\3\n\3\n\3\13\3\13\3"+
		"\13\3\13\3\13\3\13\5\13h\n\13\3\13\3\13\3\13\3\13\3\13\3\13\3\13\3\13"+
		"\3\13\3\13\3\13\3\13\3\13\3\13\3\13\3\13\7\13z\n\13\f\13\16\13}\13\13"+
		"\3\f\3\f\3\f\3\f\3\r\3\r\3\r\3\16\3\16\3\17\3\17\3\20\3\20\3\21\3\21\3"+
		"\22\3\22\3\22\2\3\24\23\2\4\6\b\n\f\16\20\22\24\26\30\32\34\36 \"\2\6"+
		"\3\2\t\13\3\2\7\b\4\2\r\20\32\32\3\2\34 \2\u008f\2\'\3\2\2\2\4/\3\2\2"+
		"\2\6\63\3\2\2\2\b\67\3\2\2\2\n@\3\2\2\2\fB\3\2\2\2\16F\3\2\2\2\20O\3\2"+
		"\2\2\22S\3\2\2\2\24g\3\2\2\2\26~\3\2\2\2\30\u0082\3\2\2\2\32\u0085\3\2"+
		"\2\2\34\u0087\3\2\2\2\36\u0089\3\2\2\2 \u008b\3\2\2\2\"\u008d\3\2\2\2"+
		"$&\5\4\3\2%$\3\2\2\2&)\3\2\2\2\'%\3\2\2\2\'(\3\2\2\2(*\3\2\2\2)\'\3\2"+
		"\2\2*+\7\2\2\3+\3\3\2\2\2,\60\5\6\4\2-\60\5\b\5\2.\60\5\f\7\2/,\3\2\2"+
		"\2/-\3\2\2\2/.\3\2\2\2\60\5\3\2\2\2\61\64\5\20\t\2\62\64\5\22\n\2\63\61"+
		"\3\2\2\2\63\62\3\2\2\2\64\65\3\2\2\2\65\66\7\5\2\2\66\7\3\2\2\2\678\7"+
		"\30\2\289\5\24\13\29<\5\16\b\2:;\7\31\2\2;=\5\n\6\2<:\3\2\2\2<=\3\2\2"+
		"\2=\t\3\2\2\2>A\5\16\b\2?A\5\b\5\2@>\3\2\2\2@?\3\2\2\2A\13\3\2\2\2BC\7"+
		"\6\2\2CD\5\24\13\2DE\5\16\b\2E\r\3\2\2\2FG\7\25\2\2GI\7\3\2\2HJ\5\6\4"+
		"\2IH\3\2\2\2JK\3\2\2\2KI\3\2\2\2KL\3\2\2\2LM\3\2\2\2MN\7\4\2\2N\17\3\2"+
		"\2\2OP\7#\2\2PQ\7\27\2\2QR\5\24\13\2R\21\3\2\2\2ST\7#\2\2T]\7\21\2\2U"+
		"Z\5\24\13\2VW\7\23\2\2WY\5\24\13\2XV\3\2\2\2Y\\\3\2\2\2ZX\3\2\2\2Z[\3"+
		"\2\2\2[^\3\2\2\2\\Z\3\2\2\2]U\3\2\2\2]^\3\2\2\2^_\3\2\2\2_`\7\22\2\2`"+
		"\23\3\2\2\2ab\b\13\1\2bh\5\"\22\2ch\7#\2\2dh\5\22\n\2eh\5\26\f\2fh\5\30"+
		"\r\2ga\3\2\2\2gc\3\2\2\2gd\3\2\2\2ge\3\2\2\2gf\3\2\2\2h{\3\2\2\2ij\f\6"+
		"\2\2jk\5\32\16\2kl\5\24\13\7lz\3\2\2\2mn\f\5\2\2no\5\34\17\2op\5\24\13"+
		"\6pz\3\2\2\2qr\f\4\2\2rs\5\36\20\2st\5\24\13\5tz\3\2\2\2uv\f\3\2\2vw\5"+
		" \21\2wx\5\24\13\4xz\3\2\2\2yi\3\2\2\2ym\3\2\2\2yq\3\2\2\2yu\3\2\2\2z"+
		"}\3\2\2\2{y\3\2\2\2{|\3\2\2\2|\25\3\2\2\2}{\3\2\2\2~\177\7\21\2\2\177"+
		"\u0080\5\24\13\2\u0080\u0081\7\22\2\2\u0081\27\3\2\2\2\u0082\u0083\7\33"+
		"\2\2\u0083\u0084\5\24\13\2\u0084\31\3\2\2\2\u0085\u0086\t\2\2\2\u0086"+
		"\33\3\2\2\2\u0087\u0088\t\3\2\2\u0088\35\3\2\2\2\u0089\u008a\t\4\2\2\u008a"+
		"\37\3\2\2\2\u008b\u008c\7\f\2\2\u008c!\3\2\2\2\u008d\u008e\t\5\2\2\u008e"+
		"#\3\2\2\2\r\'/\63<@KZ]gy{";
	public static final ATN _ATN =
		new ATNDeserializer().deserialize(_serializedATN.toCharArray());
	static {
		_decisionToDFA = new DFA[_ATN.getNumberOfDecisions()];
		for (int i = 0; i < _ATN.getNumberOfDecisions(); i++) {
			_decisionToDFA[i] = new DFA(_ATN.getDecisionState(i), i);
		}
	}
}