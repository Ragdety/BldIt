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
		FLOAT=33, STRING=34, BOOL=35, NULL=36, ENDLINE=37, IDENTIFIER=38, PARAM_TYPE=39, 
		NEWLINE=40, SKIP_=41;
	public static final int
		RULE_bldItFile = 0, RULE_statements = 1, RULE_statement = 2, RULE_simpleStatement = 3, 
		RULE_compoundStatement = 4, RULE_ifStatement = 5, RULE_singleIfBlock = 6, 
		RULE_elseIfBlock = 7, RULE_elseBlock = 8, RULE_whileStatement = 9, RULE_functionDefinition = 10, 
		RULE_parameters = 11, RULE_block = 12, RULE_functionBlock = 13, RULE_returnStatement = 14, 
		RULE_assignment = 15, RULE_functionCall = 16, RULE_expression = 17, RULE_parenthExpression = 18, 
		RULE_notExpression = 19, RULE_multOp = 20, RULE_addOp = 21, RULE_compareOp = 22, 
		RULE_boolOp = 23, RULE_constant = 24, RULE_pipeline = 25, RULE_globalEnvStatement = 26, 
		RULE_parameterStatement = 27, RULE_stagesStatement = 28, RULE_globalEnvBlock = 29, 
		RULE_parameterBlock = 30, RULE_stagesBlock = 31, RULE_stageStatements = 32, 
		RULE_stageStatement = 33, RULE_stageBlock = 34, RULE_envAssignments = 35, 
		RULE_envAssignment = 36, RULE_paramAssignments = 37, RULE_paramAssignment = 38, 
		RULE_paramValue = 39, RULE_pipelineExpression = 40;
	private static String[] makeRuleNames() {
		return new String[] {
			"bldItFile", "statements", "statement", "simpleStatement", "compoundStatement", 
			"ifStatement", "singleIfBlock", "elseIfBlock", "elseBlock", "whileStatement", 
			"functionDefinition", "parameters", "block", "functionBlock", "returnStatement", 
			"assignment", "functionCall", "expression", "parenthExpression", "notExpression", 
			"multOp", "addOp", "compareOp", "boolOp", "constant", "pipeline", "globalEnvStatement", 
			"parameterStatement", "stagesStatement", "globalEnvBlock", "parameterBlock", 
			"stagesBlock", "stageStatements", "stageStatement", "stageBlock", "envAssignments", 
			"envAssignment", "paramAssignments", "paramAssignment", "paramValue", 
			"pipelineExpression"
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
			"FLOAT", "STRING", "BOOL", "NULL", "ENDLINE", "IDENTIFIER", "PARAM_TYPE", 
			"NEWLINE", "SKIP_"
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
			setState(86);
			_errHandler.sync(this);
			_la = _input.LA(1);
			while ((((_la) & ~0x3f) == 0 && ((1L << _la) & ((1L << WHILE) | (1L << FUNCTION) | (1L << RETURN) | (1L << IF) | (1L << IDENTIFIER) | (1L << NEWLINE))) != 0)) {
				{
				setState(84);
				_errHandler.sync(this);
				switch (_input.LA(1)) {
				case NEWLINE:
					{
					setState(82);
					match(NEWLINE);
					}
					break;
				case WHILE:
				case FUNCTION:
				case RETURN:
				case IF:
				case IDENTIFIER:
					{
					setState(83);
					statement();
					}
					break;
				default:
					throw new NoViableAltException(this);
				}
				}
				setState(88);
				_errHandler.sync(this);
				_la = _input.LA(1);
			}
			setState(89);
			pipeline();
			setState(90);
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
			setState(93); 
			_errHandler.sync(this);
			_la = _input.LA(1);
			do {
				{
				{
				setState(92);
				statement();
				}
				}
				setState(95); 
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
			setState(99);
			_errHandler.sync(this);
			switch (_input.LA(1)) {
			case RETURN:
			case IDENTIFIER:
				enterOuterAlt(_localctx, 1);
				{
				setState(97);
				simpleStatement();
				}
				break;
			case WHILE:
			case FUNCTION:
			case IF:
				enterOuterAlt(_localctx, 2);
				{
				setState(98);
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
			setState(104);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,4,_ctx) ) {
			case 1:
				{
				setState(101);
				assignment();
				}
				break;
			case 2:
				{
				setState(102);
				functionCall();
				}
				break;
			case 3:
				{
				setState(103);
				returnStatement();
				}
				break;
			}
			setState(107);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if (_la==SEMICOLON) {
				{
				setState(106);
				match(SEMICOLON);
				}
			}

			setState(109);
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
			setState(114);
			_errHandler.sync(this);
			switch (_input.LA(1)) {
			case IF:
				{
				setState(111);
				ifStatement();
				}
				break;
			case WHILE:
				{
				setState(112);
				whileStatement();
				}
				break;
			case FUNCTION:
				{
				setState(113);
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
			setState(116);
			singleIfBlock();
			setState(120);
			_errHandler.sync(this);
			_alt = getInterpreter().adaptivePredict(_input,7,_ctx);
			while ( _alt!=2 && _alt!=org.antlr.v4.runtime.atn.ATN.INVALID_ALT_NUMBER ) {
				if ( _alt==1 ) {
					{
					{
					setState(117);
					elseIfBlock();
					}
					} 
				}
				setState(122);
				_errHandler.sync(this);
				_alt = getInterpreter().adaptivePredict(_input,7,_ctx);
			}
			setState(124);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if (_la==ELSE) {
				{
				setState(123);
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
			setState(126);
			match(IF);
			setState(127);
			expression(0);
			setState(128);
			match(COLON);
			setState(129);
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
			setState(131);
			match(ELSE);
			setState(132);
			match(IF);
			setState(133);
			expression(0);
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
			setState(137);
			match(ELSE);
			setState(138);
			match(COLON);
			setState(139);
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
			setState(141);
			match(WHILE);
			setState(142);
			expression(0);
			setState(143);
			match(COLON);
			setState(144);
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
			setState(146);
			match(FUNCTION);
			setState(147);
			match(IDENTIFIER);
			setState(148);
			match(OPEN_PAREN);
			setState(150);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if (_la==IDENTIFIER) {
				{
				setState(149);
				parameters();
				}
			}

			setState(152);
			match(CLOSE_PAREN);
			setState(153);
			match(COLON);
			setState(154);
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
			setState(156);
			match(IDENTIFIER);
			setState(161);
			_errHandler.sync(this);
			_la = _input.LA(1);
			while (_la==COMMA) {
				{
				{
				setState(157);
				match(COMMA);
				setState(158);
				match(IDENTIFIER);
				}
				}
				setState(163);
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
			setState(170);
			_errHandler.sync(this);
			switch (_input.LA(1)) {
			case RETURN:
			case IDENTIFIER:
				enterOuterAlt(_localctx, 1);
				{
				setState(164);
				simpleStatement();
				}
				break;
			case NEWLINE:
				enterOuterAlt(_localctx, 2);
				{
				setState(165);
				match(NEWLINE);
				setState(166);
				match(INDENT);
				setState(167);
				statements();
				setState(168);
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
			setState(179);
			_errHandler.sync(this);
			switch (_input.LA(1)) {
			case RETURN:
			case IDENTIFIER:
				enterOuterAlt(_localctx, 1);
				{
				setState(172);
				simpleStatement();
				}
				break;
			case NEWLINE:
				enterOuterAlt(_localctx, 2);
				{
				setState(173);
				match(NEWLINE);
				setState(174);
				match(INDENT);
				setState(176);
				_errHandler.sync(this);
				_la = _input.LA(1);
				if ((((_la) & ~0x3f) == 0 && ((1L << _la) & ((1L << WHILE) | (1L << FUNCTION) | (1L << RETURN) | (1L << IF) | (1L << IDENTIFIER))) != 0)) {
					{
					setState(175);
					statements();
					}
				}

				setState(178);
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
			setState(181);
			match(RETURN);
			setState(183);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if ((((_la) & ~0x3f) == 0 && ((1L << _la) & ((1L << OPEN_PAREN) | (1L << NOT) | (1L << INTEGER) | (1L << FLOAT) | (1L << STRING) | (1L << BOOL) | (1L << NULL) | (1L << IDENTIFIER))) != 0)) {
				{
				setState(182);
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
			setState(185);
			match(IDENTIFIER);
			setState(186);
			match(ASSIGN_OP);
			setState(187);
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
			setState(189);
			match(IDENTIFIER);
			setState(190);
			match(OPEN_PAREN);
			setState(199);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if ((((_la) & ~0x3f) == 0 && ((1L << _la) & ((1L << OPEN_PAREN) | (1L << NOT) | (1L << INTEGER) | (1L << FLOAT) | (1L << STRING) | (1L << BOOL) | (1L << NULL) | (1L << IDENTIFIER))) != 0)) {
				{
				setState(191);
				expression(0);
				setState(196);
				_errHandler.sync(this);
				_la = _input.LA(1);
				while (_la==COMMA) {
					{
					{
					setState(192);
					match(COMMA);
					setState(193);
					expression(0);
					}
					}
					setState(198);
					_errHandler.sync(this);
					_la = _input.LA(1);
				}
				}
			}

			setState(201);
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
			setState(209);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,17,_ctx) ) {
			case 1:
				{
				_localctx = new ConstantExprContext(_localctx);
				_ctx = _localctx;
				_prevctx = _localctx;

				setState(204);
				constant();
				}
				break;
			case 2:
				{
				_localctx = new IdentifierExprContext(_localctx);
				_ctx = _localctx;
				_prevctx = _localctx;
				setState(205);
				match(IDENTIFIER);
				}
				break;
			case 3:
				{
				_localctx = new FunctionCallExprContext(_localctx);
				_ctx = _localctx;
				_prevctx = _localctx;
				setState(206);
				functionCall();
				}
				break;
			case 4:
				{
				_localctx = new ParenthesizedExprContext(_localctx);
				_ctx = _localctx;
				_prevctx = _localctx;
				setState(207);
				parenthExpression();
				}
				break;
			case 5:
				{
				_localctx = new NotExprContext(_localctx);
				_ctx = _localctx;
				_prevctx = _localctx;
				setState(208);
				notExpression();
				}
				break;
			}
			_ctx.stop = _input.LT(-1);
			setState(229);
			_errHandler.sync(this);
			_alt = getInterpreter().adaptivePredict(_input,19,_ctx);
			while ( _alt!=2 && _alt!=org.antlr.v4.runtime.atn.ATN.INVALID_ALT_NUMBER ) {
				if ( _alt==1 ) {
					if ( _parseListeners!=null ) triggerExitRuleEvent();
					_prevctx = _localctx;
					{
					setState(227);
					_errHandler.sync(this);
					switch ( getInterpreter().adaptivePredict(_input,18,_ctx) ) {
					case 1:
						{
						_localctx = new MultiplicativeExprContext(new ExpressionContext(_parentctx, _parentState));
						pushNewRecursionContext(_localctx, _startState, RULE_expression);
						setState(211);
						if (!(precpred(_ctx, 4))) throw new FailedPredicateException(this, "precpred(_ctx, 4)");
						setState(212);
						multOp();
						setState(213);
						expression(5);
						}
						break;
					case 2:
						{
						_localctx = new AdditiveExprContext(new ExpressionContext(_parentctx, _parentState));
						pushNewRecursionContext(_localctx, _startState, RULE_expression);
						setState(215);
						if (!(precpred(_ctx, 3))) throw new FailedPredicateException(this, "precpred(_ctx, 3)");
						setState(216);
						addOp();
						setState(217);
						expression(4);
						}
						break;
					case 3:
						{
						_localctx = new ComparisonExprContext(new ExpressionContext(_parentctx, _parentState));
						pushNewRecursionContext(_localctx, _startState, RULE_expression);
						setState(219);
						if (!(precpred(_ctx, 2))) throw new FailedPredicateException(this, "precpred(_ctx, 2)");
						setState(220);
						compareOp();
						setState(221);
						expression(3);
						}
						break;
					case 4:
						{
						_localctx = new BooleanExprContext(new ExpressionContext(_parentctx, _parentState));
						pushNewRecursionContext(_localctx, _startState, RULE_expression);
						setState(223);
						if (!(precpred(_ctx, 1))) throw new FailedPredicateException(this, "precpred(_ctx, 1)");
						setState(224);
						boolOp();
						setState(225);
						expression(2);
						}
						break;
					}
					} 
				}
				setState(231);
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
			setState(232);
			match(OPEN_PAREN);
			setState(233);
			expression(0);
			setState(234);
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
			setState(236);
			match(NOT);
			setState(237);
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
			setState(239);
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
			setState(241);
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
			setState(243);
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
			setState(245);
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
			setState(247);
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
		public StagesStatementContext stagesStatement() {
			return getRuleContext(StagesStatementContext.class,0);
		}
		public TerminalNode DEDENT() { return getToken(BldItParser.DEDENT, 0); }
		public GlobalEnvStatementContext globalEnvStatement() {
			return getRuleContext(GlobalEnvStatementContext.class,0);
		}
		public ParameterStatementContext parameterStatement() {
			return getRuleContext(ParameterStatementContext.class,0);
		}
		public PipelineContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_pipeline; }
	}

	public final PipelineContext pipeline() throws RecognitionException {
		PipelineContext _localctx = new PipelineContext(_ctx, getState());
		enterRule(_localctx, 50, RULE_pipeline);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(249);
			match(PIPELINE);
			setState(250);
			match(COLON);
			setState(251);
			match(NEWLINE);
			setState(252);
			match(INDENT);
			setState(254);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if (_la==GLOBALENV) {
				{
				setState(253);
				globalEnvStatement();
				}
			}

			setState(257);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if (_la==PARAMETERS) {
				{
				setState(256);
				parameterStatement();
				}
			}

			setState(259);
			stagesStatement();
			setState(260);
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
		enterRule(_localctx, 52, RULE_globalEnvStatement);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(262);
			match(GLOBALENV);
			setState(263);
			match(COLON);
			setState(264);
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
		enterRule(_localctx, 54, RULE_parameterStatement);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(266);
			match(PARAMETERS);
			setState(267);
			match(COLON);
			setState(268);
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
		enterRule(_localctx, 56, RULE_stagesStatement);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(270);
			match(STAGES);
			setState(271);
			match(COLON);
			setState(272);
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
		enterRule(_localctx, 58, RULE_globalEnvBlock);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(274);
			match(NEWLINE);
			setState(275);
			match(INDENT);
			setState(276);
			envAssignments();
			setState(277);
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
		public TerminalNode INDENT() { return getToken(BldItParser.INDENT, 0); }
		public ParamAssignmentsContext paramAssignments() {
			return getRuleContext(ParamAssignmentsContext.class,0);
		}
		public TerminalNode DEDENT() { return getToken(BldItParser.DEDENT, 0); }
		public ParameterBlockContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_parameterBlock; }
	}

	public final ParameterBlockContext parameterBlock() throws RecognitionException {
		ParameterBlockContext _localctx = new ParameterBlockContext(_ctx, getState());
		enterRule(_localctx, 60, RULE_parameterBlock);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(279);
			match(NEWLINE);
			setState(280);
			match(INDENT);
			setState(281);
			paramAssignments();
			setState(282);
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
		enterRule(_localctx, 62, RULE_stagesBlock);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(284);
			match(NEWLINE);
			setState(285);
			match(INDENT);
			setState(286);
			stageStatements();
			setState(287);
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
		enterRule(_localctx, 64, RULE_stageStatements);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(290); 
			_errHandler.sync(this);
			_la = _input.LA(1);
			do {
				{
				{
				setState(289);
				stageStatement();
				}
				}
				setState(292); 
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
		enterRule(_localctx, 66, RULE_stageStatement);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(294);
			match(STAGE);
			setState(295);
			match(COLON);
			setState(296);
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
		enterRule(_localctx, 68, RULE_stageBlock);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(298);
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
		enterRule(_localctx, 70, RULE_envAssignments);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(306); 
			_errHandler.sync(this);
			_la = _input.LA(1);
			do {
				{
				{
				{
				setState(300);
				envAssignment();
				}
				setState(302);
				_errHandler.sync(this);
				_la = _input.LA(1);
				if (_la==SEMICOLON) {
					{
					setState(301);
					match(SEMICOLON);
					}
				}

				setState(304);
				match(NEWLINE);
				}
				}
				setState(308); 
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
		enterRule(_localctx, 72, RULE_envAssignment);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(310);
			match(IDENTIFIER);
			setState(311);
			match(ASSIGN_OP);
			setState(312);
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

	public static class ParamAssignmentsContext extends ParserRuleContext {
		public List<TerminalNode> NEWLINE() { return getTokens(BldItParser.NEWLINE); }
		public TerminalNode NEWLINE(int i) {
			return getToken(BldItParser.NEWLINE, i);
		}
		public List<ParamAssignmentContext> paramAssignment() {
			return getRuleContexts(ParamAssignmentContext.class);
		}
		public ParamAssignmentContext paramAssignment(int i) {
			return getRuleContext(ParamAssignmentContext.class,i);
		}
		public List<TerminalNode> SEMICOLON() { return getTokens(BldItParser.SEMICOLON); }
		public TerminalNode SEMICOLON(int i) {
			return getToken(BldItParser.SEMICOLON, i);
		}
		public ParamAssignmentsContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_paramAssignments; }
	}

	public final ParamAssignmentsContext paramAssignments() throws RecognitionException {
		ParamAssignmentsContext _localctx = new ParamAssignmentsContext(_ctx, getState());
		enterRule(_localctx, 74, RULE_paramAssignments);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(320); 
			_errHandler.sync(this);
			_la = _input.LA(1);
			do {
				{
				{
				{
				setState(314);
				paramAssignment();
				}
				setState(316);
				_errHandler.sync(this);
				_la = _input.LA(1);
				if (_la==SEMICOLON) {
					{
					setState(315);
					match(SEMICOLON);
					}
				}

				setState(318);
				match(NEWLINE);
				}
				}
				setState(322); 
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

	public static class ParamAssignmentContext extends ParserRuleContext {
		public TerminalNode IDENTIFIER() { return getToken(BldItParser.IDENTIFIER, 0); }
		public TerminalNode COLON() { return getToken(BldItParser.COLON, 0); }
		public TerminalNode PARAM_TYPE() { return getToken(BldItParser.PARAM_TYPE, 0); }
		public TerminalNode ASSIGN_OP() { return getToken(BldItParser.ASSIGN_OP, 0); }
		public ParamValueContext paramValue() {
			return getRuleContext(ParamValueContext.class,0);
		}
		public ParamAssignmentContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_paramAssignment; }
	}

	public final ParamAssignmentContext paramAssignment() throws RecognitionException {
		ParamAssignmentContext _localctx = new ParamAssignmentContext(_ctx, getState());
		enterRule(_localctx, 76, RULE_paramAssignment);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(324);
			match(IDENTIFIER);
			setState(325);
			match(COLON);
			setState(326);
			match(PARAM_TYPE);
			setState(329);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if (_la==ASSIGN_OP) {
				{
				setState(327);
				match(ASSIGN_OP);
				setState(328);
				paramValue();
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

	public static class ParamValueContext extends ParserRuleContext {
		public TerminalNode STRING() { return getToken(BldItParser.STRING, 0); }
		public TerminalNode BOOL() { return getToken(BldItParser.BOOL, 0); }
		public ParamValueContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_paramValue; }
	}

	public final ParamValueContext paramValue() throws RecognitionException {
		ParamValueContext _localctx = new ParamValueContext(_ctx, getState());
		enterRule(_localctx, 78, RULE_paramValue);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(331);
			_la = _input.LA(1);
			if ( !(_la==STRING || _la==BOOL) ) {
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
		enterRule(_localctx, 80, RULE_pipelineExpression);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(333);
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
		"\3\u608b\ua72a\u8133\ub9ed\u417c\u3be7\u7786\u5964\3+\u0152\4\2\t\2\4"+
		"\3\t\3\4\4\t\4\4\5\t\5\4\6\t\6\4\7\t\7\4\b\t\b\4\t\t\t\4\n\t\n\4\13\t"+
		"\13\4\f\t\f\4\r\t\r\4\16\t\16\4\17\t\17\4\20\t\20\4\21\t\21\4\22\t\22"+
		"\4\23\t\23\4\24\t\24\4\25\t\25\4\26\t\26\4\27\t\27\4\30\t\30\4\31\t\31"+
		"\4\32\t\32\4\33\t\33\4\34\t\34\4\35\t\35\4\36\t\36\4\37\t\37\4 \t \4!"+
		"\t!\4\"\t\"\4#\t#\4$\t$\4%\t%\4&\t&\4\'\t\'\4(\t(\4)\t)\4*\t*\3\2\3\2"+
		"\7\2W\n\2\f\2\16\2Z\13\2\3\2\3\2\3\2\3\3\6\3`\n\3\r\3\16\3a\3\4\3\4\5"+
		"\4f\n\4\3\5\3\5\3\5\5\5k\n\5\3\5\5\5n\n\5\3\5\3\5\3\6\3\6\3\6\5\6u\n\6"+
		"\3\7\3\7\7\7y\n\7\f\7\16\7|\13\7\3\7\5\7\177\n\7\3\b\3\b\3\b\3\b\3\b\3"+
		"\t\3\t\3\t\3\t\3\t\3\t\3\n\3\n\3\n\3\n\3\13\3\13\3\13\3\13\3\13\3\f\3"+
		"\f\3\f\3\f\5\f\u0099\n\f\3\f\3\f\3\f\3\f\3\r\3\r\3\r\7\r\u00a2\n\r\f\r"+
		"\16\r\u00a5\13\r\3\16\3\16\3\16\3\16\3\16\3\16\5\16\u00ad\n\16\3\17\3"+
		"\17\3\17\3\17\5\17\u00b3\n\17\3\17\5\17\u00b6\n\17\3\20\3\20\5\20\u00ba"+
		"\n\20\3\21\3\21\3\21\3\21\3\22\3\22\3\22\3\22\3\22\7\22\u00c5\n\22\f\22"+
		"\16\22\u00c8\13\22\5\22\u00ca\n\22\3\22\3\22\3\23\3\23\3\23\3\23\3\23"+
		"\3\23\5\23\u00d4\n\23\3\23\3\23\3\23\3\23\3\23\3\23\3\23\3\23\3\23\3\23"+
		"\3\23\3\23\3\23\3\23\3\23\3\23\7\23\u00e6\n\23\f\23\16\23\u00e9\13\23"+
		"\3\24\3\24\3\24\3\24\3\25\3\25\3\25\3\26\3\26\3\27\3\27\3\30\3\30\3\31"+
		"\3\31\3\32\3\32\3\33\3\33\3\33\3\33\3\33\5\33\u0101\n\33\3\33\5\33\u0104"+
		"\n\33\3\33\3\33\3\33\3\34\3\34\3\34\3\34\3\35\3\35\3\35\3\35\3\36\3\36"+
		"\3\36\3\36\3\37\3\37\3\37\3\37\3\37\3 \3 \3 \3 \3 \3!\3!\3!\3!\3!\3\""+
		"\6\"\u0125\n\"\r\"\16\"\u0126\3#\3#\3#\3#\3$\3$\3%\3%\5%\u0131\n%\3%\3"+
		"%\6%\u0135\n%\r%\16%\u0136\3&\3&\3&\3&\3\'\3\'\5\'\u013f\n\'\3\'\3\'\6"+
		"\'\u0143\n\'\r\'\16\'\u0144\3(\3(\3(\3(\3(\5(\u014c\n(\3)\3)\3*\3*\3*"+
		"\2\3$+\2\4\6\b\n\f\16\20\22\24\26\30\32\34\36 \"$&(*,.\60\62\64\668:<"+
		">@BDFHJLNPR\2\7\3\2\17\21\3\2\r\16\4\2\23\26  \3\2\"&\3\2$%\2\u014b\2"+
		"X\3\2\2\2\4_\3\2\2\2\6e\3\2\2\2\bj\3\2\2\2\nt\3\2\2\2\fv\3\2\2\2\16\u0080"+
		"\3\2\2\2\20\u0085\3\2\2\2\22\u008b\3\2\2\2\24\u008f\3\2\2\2\26\u0094\3"+
		"\2\2\2\30\u009e\3\2\2\2\32\u00ac\3\2\2\2\34\u00b5\3\2\2\2\36\u00b7\3\2"+
		"\2\2 \u00bb\3\2\2\2\"\u00bf\3\2\2\2$\u00d3\3\2\2\2&\u00ea\3\2\2\2(\u00ee"+
		"\3\2\2\2*\u00f1\3\2\2\2,\u00f3\3\2\2\2.\u00f5\3\2\2\2\60\u00f7\3\2\2\2"+
		"\62\u00f9\3\2\2\2\64\u00fb\3\2\2\2\66\u0108\3\2\2\28\u010c\3\2\2\2:\u0110"+
		"\3\2\2\2<\u0114\3\2\2\2>\u0119\3\2\2\2@\u011e\3\2\2\2B\u0124\3\2\2\2D"+
		"\u0128\3\2\2\2F\u012c\3\2\2\2H\u0134\3\2\2\2J\u0138\3\2\2\2L\u0142\3\2"+
		"\2\2N\u0146\3\2\2\2P\u014d\3\2\2\2R\u014f\3\2\2\2TW\7*\2\2UW\5\6\4\2V"+
		"T\3\2\2\2VU\3\2\2\2WZ\3\2\2\2XV\3\2\2\2XY\3\2\2\2Y[\3\2\2\2ZX\3\2\2\2"+
		"[\\\5\64\33\2\\]\7\2\2\3]\3\3\2\2\2^`\5\6\4\2_^\3\2\2\2`a\3\2\2\2a_\3"+
		"\2\2\2ab\3\2\2\2b\5\3\2\2\2cf\5\b\5\2df\5\n\6\2ec\3\2\2\2ed\3\2\2\2f\7"+
		"\3\2\2\2gk\5 \21\2hk\5\"\22\2ik\5\36\20\2jg\3\2\2\2jh\3\2\2\2ji\3\2\2"+
		"\2km\3\2\2\2ln\7\32\2\2ml\3\2\2\2mn\3\2\2\2no\3\2\2\2op\7*\2\2p\t\3\2"+
		"\2\2qu\5\f\7\2ru\5\24\13\2su\5\26\f\2tq\3\2\2\2tr\3\2\2\2ts\3\2\2\2u\13"+
		"\3\2\2\2vz\5\16\b\2wy\5\20\t\2xw\3\2\2\2y|\3\2\2\2zx\3\2\2\2z{\3\2\2\2"+
		"{~\3\2\2\2|z\3\2\2\2}\177\5\22\n\2~}\3\2\2\2~\177\3\2\2\2\177\r\3\2\2"+
		"\2\u0080\u0081\7\36\2\2\u0081\u0082\5$\23\2\u0082\u0083\7\33\2\2\u0083"+
		"\u0084\5\32\16\2\u0084\17\3\2\2\2\u0085\u0086\7\37\2\2\u0086\u0087\7\36"+
		"\2\2\u0087\u0088\5$\23\2\u0088\u0089\7\33\2\2\u0089\u008a\5\32\16\2\u008a"+
		"\21\3\2\2\2\u008b\u008c\7\37\2\2\u008c\u008d\7\33\2\2\u008d\u008e\5\32"+
		"\16\2\u008e\23\3\2\2\2\u008f\u0090\7\n\2\2\u0090\u0091\5$\23\2\u0091\u0092"+
		"\7\33\2\2\u0092\u0093\5\32\16\2\u0093\25\3\2\2\2\u0094\u0095\7\13\2\2"+
		"\u0095\u0096\7(\2\2\u0096\u0098\7\27\2\2\u0097\u0099\5\30\r\2\u0098\u0097"+
		"\3\2\2\2\u0098\u0099\3\2\2\2\u0099\u009a\3\2\2\2\u009a\u009b\7\30\2\2"+
		"\u009b\u009c\7\33\2\2\u009c\u009d\5\34\17\2\u009d\27\3\2\2\2\u009e\u00a3"+
		"\7(\2\2\u009f\u00a0\7\31\2\2\u00a0\u00a2\7(\2\2\u00a1\u009f\3\2\2\2\u00a2"+
		"\u00a5\3\2\2\2\u00a3\u00a1\3\2\2\2\u00a3\u00a4\3\2\2\2\u00a4\31\3\2\2"+
		"\2\u00a5\u00a3\3\2\2\2\u00a6\u00ad\5\b\5\2\u00a7\u00a8\7*\2\2\u00a8\u00a9"+
		"\7\3\2\2\u00a9\u00aa\5\4\3\2\u00aa\u00ab\7\4\2\2\u00ab\u00ad\3\2\2\2\u00ac"+
		"\u00a6\3\2\2\2\u00ac\u00a7\3\2\2\2\u00ad\33\3\2\2\2\u00ae\u00b6\5\b\5"+
		"\2\u00af\u00b0\7*\2\2\u00b0\u00b2\7\3\2\2\u00b1\u00b3\5\4\3\2\u00b2\u00b1"+
		"\3\2\2\2\u00b2\u00b3\3\2\2\2\u00b3\u00b4\3\2\2\2\u00b4\u00b6\7\4\2\2\u00b5"+
		"\u00ae\3\2\2\2\u00b5\u00af\3\2\2\2\u00b6\35\3\2\2\2\u00b7\u00b9\7\f\2"+
		"\2\u00b8\u00ba\5$\23\2\u00b9\u00b8\3\2\2\2\u00b9\u00ba\3\2\2\2\u00ba\37"+
		"\3\2\2\2\u00bb\u00bc\7(\2\2\u00bc\u00bd\7\35\2\2\u00bd\u00be\5$\23\2\u00be"+
		"!\3\2\2\2\u00bf\u00c0\7(\2\2\u00c0\u00c9\7\27\2\2\u00c1\u00c6\5$\23\2"+
		"\u00c2\u00c3\7\31\2\2\u00c3\u00c5\5$\23\2\u00c4\u00c2\3\2\2\2\u00c5\u00c8"+
		"\3\2\2\2\u00c6\u00c4\3\2\2\2\u00c6\u00c7\3\2\2\2\u00c7\u00ca\3\2\2\2\u00c8"+
		"\u00c6\3\2\2\2\u00c9\u00c1\3\2\2\2\u00c9\u00ca\3\2\2\2\u00ca\u00cb\3\2"+
		"\2\2\u00cb\u00cc\7\30\2\2\u00cc#\3\2\2\2\u00cd\u00ce\b\23\1\2\u00ce\u00d4"+
		"\5\62\32\2\u00cf\u00d4\7(\2\2\u00d0\u00d4\5\"\22\2\u00d1\u00d4\5&\24\2"+
		"\u00d2\u00d4\5(\25\2\u00d3\u00cd\3\2\2\2\u00d3\u00cf\3\2\2\2\u00d3\u00d0"+
		"\3\2\2\2\u00d3\u00d1\3\2\2\2\u00d3\u00d2\3\2\2\2\u00d4\u00e7\3\2\2\2\u00d5"+
		"\u00d6\f\6\2\2\u00d6\u00d7\5*\26\2\u00d7\u00d8\5$\23\7\u00d8\u00e6\3\2"+
		"\2\2\u00d9\u00da\f\5\2\2\u00da\u00db\5,\27\2\u00db\u00dc\5$\23\6\u00dc"+
		"\u00e6\3\2\2\2\u00dd\u00de\f\4\2\2\u00de\u00df\5.\30\2\u00df\u00e0\5$"+
		"\23\5\u00e0\u00e6\3\2\2\2\u00e1\u00e2\f\3\2\2\u00e2\u00e3\5\60\31\2\u00e3"+
		"\u00e4\5$\23\4\u00e4\u00e6\3\2\2\2\u00e5\u00d5\3\2\2\2\u00e5\u00d9\3\2"+
		"\2\2\u00e5\u00dd\3\2\2\2\u00e5\u00e1\3\2\2\2\u00e6\u00e9\3\2\2\2\u00e7"+
		"\u00e5\3\2\2\2\u00e7\u00e8\3\2\2\2\u00e8%\3\2\2\2\u00e9\u00e7\3\2\2\2"+
		"\u00ea\u00eb\7\27\2\2\u00eb\u00ec\5$\23\2\u00ec\u00ed\7\30\2\2\u00ed\'"+
		"\3\2\2\2\u00ee\u00ef\7!\2\2\u00ef\u00f0\5$\23\2\u00f0)\3\2\2\2\u00f1\u00f2"+
		"\t\2\2\2\u00f2+\3\2\2\2\u00f3\u00f4\t\3\2\2\u00f4-\3\2\2\2\u00f5\u00f6"+
		"\t\4\2\2\u00f6/\3\2\2\2\u00f7\u00f8\7\22\2\2\u00f8\61\3\2\2\2\u00f9\u00fa"+
		"\t\5\2\2\u00fa\63\3\2\2\2\u00fb\u00fc\7\5\2\2\u00fc\u00fd\7\33\2\2\u00fd"+
		"\u00fe\7*\2\2\u00fe\u0100\7\3\2\2\u00ff\u0101\5\66\34\2\u0100\u00ff\3"+
		"\2\2\2\u0100\u0101\3\2\2\2\u0101\u0103\3\2\2\2\u0102\u0104\58\35\2\u0103"+
		"\u0102\3\2\2\2\u0103\u0104\3\2\2\2\u0104\u0105\3\2\2\2\u0105\u0106\5:"+
		"\36\2\u0106\u0107\7\4\2\2\u0107\65\3\2\2\2\u0108\u0109\7\6\2\2\u0109\u010a"+
		"\7\33\2\2\u010a\u010b\5<\37\2\u010b\67\3\2\2\2\u010c\u010d\7\7\2\2\u010d"+
		"\u010e\7\33\2\2\u010e\u010f\5> \2\u010f9\3\2\2\2\u0110\u0111\7\b\2\2\u0111"+
		"\u0112\7\33\2\2\u0112\u0113\5@!\2\u0113;\3\2\2\2\u0114\u0115\7*\2\2\u0115"+
		"\u0116\7\3\2\2\u0116\u0117\5H%\2\u0117\u0118\7\4\2\2\u0118=\3\2\2\2\u0119"+
		"\u011a\7*\2\2\u011a\u011b\7\3\2\2\u011b\u011c\5L\'\2\u011c\u011d\7\4\2"+
		"\2\u011d?\3\2\2\2\u011e\u011f\7*\2\2\u011f\u0120\7\3\2\2\u0120\u0121\5"+
		"B\"\2\u0121\u0122\7\4\2\2\u0122A\3\2\2\2\u0123\u0125\5D#\2\u0124\u0123"+
		"\3\2\2\2\u0125\u0126\3\2\2\2\u0126\u0124\3\2\2\2\u0126\u0127\3\2\2\2\u0127"+
		"C\3\2\2\2\u0128\u0129\7\t\2\2\u0129\u012a\7\33\2\2\u012a\u012b\5F$\2\u012b"+
		"E\3\2\2\2\u012c\u012d\5\32\16\2\u012dG\3\2\2\2\u012e\u0130\5J&\2\u012f"+
		"\u0131\7\32\2\2\u0130\u012f\3\2\2\2\u0130\u0131\3\2\2\2\u0131\u0132\3"+
		"\2\2\2\u0132\u0133\7*\2\2\u0133\u0135\3\2\2\2\u0134\u012e\3\2\2\2\u0135"+
		"\u0136\3\2\2\2\u0136\u0134\3\2\2\2\u0136\u0137\3\2\2\2\u0137I\3\2\2\2"+
		"\u0138\u0139\7(\2\2\u0139\u013a\7\35\2\2\u013a\u013b\5R*\2\u013bK\3\2"+
		"\2\2\u013c\u013e\5N(\2\u013d\u013f\7\32\2\2\u013e\u013d\3\2\2\2\u013e"+
		"\u013f\3\2\2\2\u013f\u0140\3\2\2\2\u0140\u0141\7*\2\2\u0141\u0143\3\2"+
		"\2\2\u0142\u013c\3\2\2\2\u0143\u0144\3\2\2\2\u0144\u0142\3\2\2\2\u0144"+
		"\u0145\3\2\2\2\u0145M\3\2\2\2\u0146\u0147\7(\2\2\u0147\u0148\7\33\2\2"+
		"\u0148\u014b\7)\2\2\u0149\u014a\7\35\2\2\u014a\u014c\5P)\2\u014b\u0149"+
		"\3\2\2\2\u014b\u014c\3\2\2\2\u014cO\3\2\2\2\u014d\u014e\t\6\2\2\u014e"+
		"Q\3\2\2\2\u014f\u0150\5$\23\2\u0150S\3\2\2\2\36VXaejmtz~\u0098\u00a3\u00ac"+
		"\u00b2\u00b5\u00b9\u00c6\u00c9\u00d3\u00e5\u00e7\u0100\u0103\u0126\u0130"+
		"\u0136\u013e\u0144\u014b";
	public static final ATN _ATN =
		new ATNDeserializer().deserialize(_serializedATN.toCharArray());
	static {
		_decisionToDFA = new DFA[_ATN.getNumberOfDecisions()];
		for (int i = 0; i < _ATN.getNumberOfDecisions(); i++) {
			_decisionToDFA[i] = new DFA(_ATN.getDecisionState(i), i);
		}
	}
}