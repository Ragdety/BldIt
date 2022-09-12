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
		SCRIPT=40, ECHO=41, NEWLINE=42, SKIP_=43;
	public static final int
		RULE_bldItFile = 0, RULE_statements = 1, RULE_statement = 2, RULE_simpleStatement = 3, 
		RULE_compoundStatement = 4, RULE_ifStatement = 5, RULE_singleIfBlock = 6, 
		RULE_elseIfBlock = 7, RULE_elseBlock = 8, RULE_whileStatement = 9, RULE_functionDefinition = 10, 
		RULE_parameters = 11, RULE_block = 12, RULE_functionBlock = 13, RULE_returnStatement = 14, 
		RULE_assignment = 15, RULE_functionCall = 16, RULE_expression = 17, RULE_parenthExpression = 18, 
		RULE_notExpression = 19, RULE_multOp = 20, RULE_addOp = 21, RULE_compareOp = 22, 
		RULE_boolOp = 23, RULE_constant = 24, RULE_pipeline = 25, RULE_globalEnvStatement = 26, 
		RULE_parameterStatement = 27, RULE_stagesStatement = 28, RULE_globalEnvBlock = 29, 
		RULE_parameterBlock = 30, RULE_stagesBlock = 31, RULE_stageStatement = 32, 
		RULE_stageBlock = 33, RULE_stepStatement = 34, RULE_simpleStepStatement = 35, 
		RULE_compoundStepStatement = 36, RULE_pipelineSimpleStepCall = 37, RULE_echoStep = 38, 
		RULE_runStep = 39, RULE_errorStep = 40, RULE_handleErrorsStep = 41, RULE_scriptStep = 42, 
		RULE_scriptBlock = 43, RULE_stepStatements = 44, RULE_envAssignments = 45, 
		RULE_envAssignment = 46, RULE_paramAssignments = 47, RULE_paramAssignment = 48, 
		RULE_paramValue = 49, RULE_pipelineExpression = 50;
	private static String[] makeRuleNames() {
		return new String[] {
			"bldItFile", "statements", "statement", "simpleStatement", "compoundStatement", 
			"ifStatement", "singleIfBlock", "elseIfBlock", "elseBlock", "whileStatement", 
			"functionDefinition", "parameters", "block", "functionBlock", "returnStatement", 
			"assignment", "functionCall", "expression", "parenthExpression", "notExpression", 
			"multOp", "addOp", "compareOp", "boolOp", "constant", "pipeline", "globalEnvStatement", 
			"parameterStatement", "stagesStatement", "globalEnvBlock", "parameterBlock", 
			"stagesBlock", "stageStatement", "stageBlock", "stepStatement", "simpleStepStatement", 
			"compoundStepStatement", "pipelineSimpleStepCall", "echoStep", "runStep", 
			"errorStep", "handleErrorsStep", "scriptStep", "scriptBlock", "stepStatements", 
			"envAssignments", "envAssignment", "paramAssignments", "paramAssignment", 
			"paramValue", "pipelineExpression"
		};
	}
	public static final String[] ruleNames = makeRuleNames();

	private static String[] makeLiteralNames() {
		return new String[] {
			null, null, null, null, "'globalEnv'", "'parameters'", "'stages'", "'stage'", 
			"'while'", null, null, "'+'", "'-'", "'*'", "'/'", "'%'", null, "'>'", 
			"'<'", "'>='", "'<='", "'('", "')'", "','", "';'", "':'", "'.'", "'='", 
			"'if'", "'else'", null, null, null, null, null, null, "'null'", null, 
			null, null, "'script'", "'echo'"
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
			"SCRIPT", "ECHO", "NEWLINE", "SKIP_"
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
			setState(106);
			_errHandler.sync(this);
			_la = _input.LA(1);
			while ((((_la) & ~0x3f) == 0 && ((1L << _la) & ((1L << WHILE) | (1L << FUNCTION) | (1L << RETURN) | (1L << IF) | (1L << IDENTIFIER) | (1L << NEWLINE))) != 0)) {
				{
				setState(104);
				_errHandler.sync(this);
				switch (_input.LA(1)) {
				case NEWLINE:
					{
					setState(102);
					match(NEWLINE);
					}
					break;
				case WHILE:
				case FUNCTION:
				case RETURN:
				case IF:
				case IDENTIFIER:
					{
					setState(103);
					statement();
					}
					break;
				default:
					throw new NoViableAltException(this);
				}
				}
				setState(108);
				_errHandler.sync(this);
				_la = _input.LA(1);
			}
			setState(109);
			pipeline();
			setState(110);
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
			setState(113); 
			_errHandler.sync(this);
			_la = _input.LA(1);
			do {
				{
				{
				setState(112);
				statement();
				}
				}
				setState(115); 
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
			setState(119);
			_errHandler.sync(this);
			switch (_input.LA(1)) {
			case RETURN:
			case IDENTIFIER:
				enterOuterAlt(_localctx, 1);
				{
				setState(117);
				simpleStatement();
				}
				break;
			case WHILE:
			case FUNCTION:
			case IF:
				enterOuterAlt(_localctx, 2);
				{
				setState(118);
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
			setState(124);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,4,_ctx) ) {
			case 1:
				{
				setState(121);
				assignment();
				}
				break;
			case 2:
				{
				setState(122);
				functionCall();
				}
				break;
			case 3:
				{
				setState(123);
				returnStatement();
				}
				break;
			}
			setState(127);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if (_la==SEMICOLON) {
				{
				setState(126);
				match(SEMICOLON);
				}
			}

			setState(129);
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
			setState(134);
			_errHandler.sync(this);
			switch (_input.LA(1)) {
			case IF:
				{
				setState(131);
				ifStatement();
				}
				break;
			case WHILE:
				{
				setState(132);
				whileStatement();
				}
				break;
			case FUNCTION:
				{
				setState(133);
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
			setState(136);
			singleIfBlock();
			setState(140);
			_errHandler.sync(this);
			_alt = getInterpreter().adaptivePredict(_input,7,_ctx);
			while ( _alt!=2 && _alt!=org.antlr.v4.runtime.atn.ATN.INVALID_ALT_NUMBER ) {
				if ( _alt==1 ) {
					{
					{
					setState(137);
					elseIfBlock();
					}
					} 
				}
				setState(142);
				_errHandler.sync(this);
				_alt = getInterpreter().adaptivePredict(_input,7,_ctx);
			}
			setState(144);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if (_la==ELSE) {
				{
				setState(143);
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
			setState(146);
			match(IF);
			setState(147);
			expression(0);
			setState(148);
			match(COLON);
			setState(149);
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
			setState(151);
			match(ELSE);
			setState(152);
			match(IF);
			setState(153);
			expression(0);
			setState(154);
			match(COLON);
			setState(155);
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
			setState(157);
			match(ELSE);
			setState(158);
			match(COLON);
			setState(159);
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
			setState(161);
			match(WHILE);
			setState(162);
			expression(0);
			setState(163);
			match(COLON);
			setState(164);
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
			setState(166);
			match(FUNCTION);
			setState(167);
			match(IDENTIFIER);
			setState(168);
			match(OPEN_PAREN);
			setState(170);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if (_la==IDENTIFIER) {
				{
				setState(169);
				parameters();
				}
			}

			setState(172);
			match(CLOSE_PAREN);
			setState(173);
			match(COLON);
			setState(174);
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
			setState(176);
			match(IDENTIFIER);
			setState(181);
			_errHandler.sync(this);
			_la = _input.LA(1);
			while (_la==COMMA) {
				{
				{
				setState(177);
				match(COMMA);
				setState(178);
				match(IDENTIFIER);
				}
				}
				setState(183);
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
			setState(190);
			_errHandler.sync(this);
			switch (_input.LA(1)) {
			case RETURN:
			case IDENTIFIER:
				enterOuterAlt(_localctx, 1);
				{
				setState(184);
				simpleStatement();
				}
				break;
			case NEWLINE:
				enterOuterAlt(_localctx, 2);
				{
				setState(185);
				match(NEWLINE);
				setState(186);
				match(INDENT);
				setState(187);
				statements();
				setState(188);
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
			setState(199);
			_errHandler.sync(this);
			switch (_input.LA(1)) {
			case RETURN:
			case IDENTIFIER:
				enterOuterAlt(_localctx, 1);
				{
				setState(192);
				simpleStatement();
				}
				break;
			case NEWLINE:
				enterOuterAlt(_localctx, 2);
				{
				setState(193);
				match(NEWLINE);
				setState(194);
				match(INDENT);
				setState(196);
				_errHandler.sync(this);
				_la = _input.LA(1);
				if ((((_la) & ~0x3f) == 0 && ((1L << _la) & ((1L << WHILE) | (1L << FUNCTION) | (1L << RETURN) | (1L << IF) | (1L << IDENTIFIER))) != 0)) {
					{
					setState(195);
					statements();
					}
				}

				setState(198);
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
			setState(201);
			match(RETURN);
			setState(203);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if ((((_la) & ~0x3f) == 0 && ((1L << _la) & ((1L << OPEN_PAREN) | (1L << NOT) | (1L << INTEGER) | (1L << FLOAT) | (1L << STRING) | (1L << BOOL) | (1L << NULL) | (1L << IDENTIFIER))) != 0)) {
				{
				setState(202);
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
			setState(205);
			match(IDENTIFIER);
			setState(206);
			match(ASSIGN_OP);
			setState(207);
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
			setState(209);
			match(IDENTIFIER);
			setState(210);
			match(OPEN_PAREN);
			setState(219);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if ((((_la) & ~0x3f) == 0 && ((1L << _la) & ((1L << OPEN_PAREN) | (1L << NOT) | (1L << INTEGER) | (1L << FLOAT) | (1L << STRING) | (1L << BOOL) | (1L << NULL) | (1L << IDENTIFIER))) != 0)) {
				{
				setState(211);
				expression(0);
				setState(216);
				_errHandler.sync(this);
				_la = _input.LA(1);
				while (_la==COMMA) {
					{
					{
					setState(212);
					match(COMMA);
					setState(213);
					expression(0);
					}
					}
					setState(218);
					_errHandler.sync(this);
					_la = _input.LA(1);
				}
				}
			}

			setState(221);
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
			setState(229);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,17,_ctx) ) {
			case 1:
				{
				_localctx = new ConstantExprContext(_localctx);
				_ctx = _localctx;
				_prevctx = _localctx;

				setState(224);
				constant();
				}
				break;
			case 2:
				{
				_localctx = new IdentifierExprContext(_localctx);
				_ctx = _localctx;
				_prevctx = _localctx;
				setState(225);
				match(IDENTIFIER);
				}
				break;
			case 3:
				{
				_localctx = new FunctionCallExprContext(_localctx);
				_ctx = _localctx;
				_prevctx = _localctx;
				setState(226);
				functionCall();
				}
				break;
			case 4:
				{
				_localctx = new ParenthesizedExprContext(_localctx);
				_ctx = _localctx;
				_prevctx = _localctx;
				setState(227);
				parenthExpression();
				}
				break;
			case 5:
				{
				_localctx = new NotExprContext(_localctx);
				_ctx = _localctx;
				_prevctx = _localctx;
				setState(228);
				notExpression();
				}
				break;
			}
			_ctx.stop = _input.LT(-1);
			setState(249);
			_errHandler.sync(this);
			_alt = getInterpreter().adaptivePredict(_input,19,_ctx);
			while ( _alt!=2 && _alt!=org.antlr.v4.runtime.atn.ATN.INVALID_ALT_NUMBER ) {
				if ( _alt==1 ) {
					if ( _parseListeners!=null ) triggerExitRuleEvent();
					_prevctx = _localctx;
					{
					setState(247);
					_errHandler.sync(this);
					switch ( getInterpreter().adaptivePredict(_input,18,_ctx) ) {
					case 1:
						{
						_localctx = new MultiplicativeExprContext(new ExpressionContext(_parentctx, _parentState));
						pushNewRecursionContext(_localctx, _startState, RULE_expression);
						setState(231);
						if (!(precpred(_ctx, 4))) throw new FailedPredicateException(this, "precpred(_ctx, 4)");
						setState(232);
						multOp();
						setState(233);
						expression(5);
						}
						break;
					case 2:
						{
						_localctx = new AdditiveExprContext(new ExpressionContext(_parentctx, _parentState));
						pushNewRecursionContext(_localctx, _startState, RULE_expression);
						setState(235);
						if (!(precpred(_ctx, 3))) throw new FailedPredicateException(this, "precpred(_ctx, 3)");
						setState(236);
						addOp();
						setState(237);
						expression(4);
						}
						break;
					case 3:
						{
						_localctx = new ComparisonExprContext(new ExpressionContext(_parentctx, _parentState));
						pushNewRecursionContext(_localctx, _startState, RULE_expression);
						setState(239);
						if (!(precpred(_ctx, 2))) throw new FailedPredicateException(this, "precpred(_ctx, 2)");
						setState(240);
						compareOp();
						setState(241);
						expression(3);
						}
						break;
					case 4:
						{
						_localctx = new BooleanExprContext(new ExpressionContext(_parentctx, _parentState));
						pushNewRecursionContext(_localctx, _startState, RULE_expression);
						setState(243);
						if (!(precpred(_ctx, 1))) throw new FailedPredicateException(this, "precpred(_ctx, 1)");
						setState(244);
						boolOp();
						setState(245);
						expression(2);
						}
						break;
					}
					} 
				}
				setState(251);
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
			setState(252);
			match(OPEN_PAREN);
			setState(253);
			expression(0);
			setState(254);
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
			setState(256);
			match(NOT);
			setState(257);
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
			setState(259);
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
			setState(261);
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
			setState(263);
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
			setState(265);
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
			setState(267);
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
			setState(269);
			match(PIPELINE);
			setState(270);
			match(COLON);
			setState(271);
			match(NEWLINE);
			setState(272);
			match(INDENT);
			setState(274);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if (_la==GLOBALENV) {
				{
				setState(273);
				globalEnvStatement();
				}
			}

			setState(277);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if (_la==PARAMETERS) {
				{
				setState(276);
				parameterStatement();
				}
			}

			setState(279);
			stagesStatement();
			setState(280);
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
			setState(282);
			match(GLOBALENV);
			setState(283);
			match(COLON);
			setState(284);
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
			setState(286);
			match(PARAMETERS);
			setState(287);
			match(COLON);
			setState(288);
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
			setState(290);
			match(STAGES);
			setState(291);
			match(COLON);
			setState(292);
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
			setState(294);
			match(NEWLINE);
			setState(295);
			match(INDENT);
			setState(296);
			envAssignments();
			setState(297);
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
			setState(299);
			match(NEWLINE);
			setState(300);
			match(INDENT);
			setState(301);
			paramAssignments();
			setState(302);
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
		public TerminalNode DEDENT() { return getToken(BldItParser.DEDENT, 0); }
		public List<StageStatementContext> stageStatement() {
			return getRuleContexts(StageStatementContext.class);
		}
		public StageStatementContext stageStatement(int i) {
			return getRuleContext(StageStatementContext.class,i);
		}
		public StagesBlockContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_stagesBlock; }
	}

	public final StagesBlockContext stagesBlock() throws RecognitionException {
		StagesBlockContext _localctx = new StagesBlockContext(_ctx, getState());
		enterRule(_localctx, 62, RULE_stagesBlock);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(304);
			match(NEWLINE);
			setState(305);
			match(INDENT);
			setState(307); 
			_errHandler.sync(this);
			_la = _input.LA(1);
			do {
				{
				{
				setState(306);
				stageStatement();
				}
				}
				setState(309); 
				_errHandler.sync(this);
				_la = _input.LA(1);
			} while ( _la==STAGE );
			setState(311);
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

	public static class StageStatementContext extends ParserRuleContext {
		public TerminalNode STAGE() { return getToken(BldItParser.STAGE, 0); }
		public TerminalNode STRING() { return getToken(BldItParser.STRING, 0); }
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
		enterRule(_localctx, 64, RULE_stageStatement);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(313);
			match(STAGE);
			setState(314);
			match(STRING);
			setState(315);
			match(COLON);
			setState(316);
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
		public SimpleStepStatementContext simpleStepStatement() {
			return getRuleContext(SimpleStepStatementContext.class,0);
		}
		public TerminalNode NEWLINE() { return getToken(BldItParser.NEWLINE, 0); }
		public TerminalNode INDENT() { return getToken(BldItParser.INDENT, 0); }
		public TerminalNode DEDENT() { return getToken(BldItParser.DEDENT, 0); }
		public List<StepStatementContext> stepStatement() {
			return getRuleContexts(StepStatementContext.class);
		}
		public StepStatementContext stepStatement(int i) {
			return getRuleContext(StepStatementContext.class,i);
		}
		public StageBlockContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_stageBlock; }
	}

	public final StageBlockContext stageBlock() throws RecognitionException {
		StageBlockContext _localctx = new StageBlockContext(_ctx, getState());
		enterRule(_localctx, 66, RULE_stageBlock);
		int _la;
		try {
			setState(328);
			_errHandler.sync(this);
			switch (_input.LA(1)) {
			case IDENTIFIER:
				enterOuterAlt(_localctx, 1);
				{
				setState(318);
				simpleStepStatement();
				}
				break;
			case NEWLINE:
				enterOuterAlt(_localctx, 2);
				{
				setState(319);
				match(NEWLINE);
				setState(320);
				match(INDENT);
				setState(322); 
				_errHandler.sync(this);
				_la = _input.LA(1);
				do {
					{
					{
					setState(321);
					stepStatement();
					}
					}
					setState(324); 
					_errHandler.sync(this);
					_la = _input.LA(1);
				} while ( (((_la) & ~0x3f) == 0 && ((1L << _la) & ((1L << STRING) | (1L << IDENTIFIER) | (1L << SCRIPT))) != 0) );
				setState(326);
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

	public static class StepStatementContext extends ParserRuleContext {
		public SimpleStepStatementContext simpleStepStatement() {
			return getRuleContext(SimpleStepStatementContext.class,0);
		}
		public CompoundStepStatementContext compoundStepStatement() {
			return getRuleContext(CompoundStepStatementContext.class,0);
		}
		public StepStatementContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_stepStatement; }
	}

	public final StepStatementContext stepStatement() throws RecognitionException {
		StepStatementContext _localctx = new StepStatementContext(_ctx, getState());
		enterRule(_localctx, 68, RULE_stepStatement);
		try {
			setState(332);
			_errHandler.sync(this);
			switch (_input.LA(1)) {
			case IDENTIFIER:
				enterOuterAlt(_localctx, 1);
				{
				setState(330);
				simpleStepStatement();
				}
				break;
			case STRING:
			case SCRIPT:
				enterOuterAlt(_localctx, 2);
				{
				setState(331);
				compoundStepStatement();
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

	public static class SimpleStepStatementContext extends ParserRuleContext {
		public PipelineSimpleStepCallContext pipelineSimpleStepCall() {
			return getRuleContext(PipelineSimpleStepCallContext.class,0);
		}
		public TerminalNode NEWLINE() { return getToken(BldItParser.NEWLINE, 0); }
		public TerminalNode SEMICOLON() { return getToken(BldItParser.SEMICOLON, 0); }
		public SimpleStepStatementContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_simpleStepStatement; }
	}

	public final SimpleStepStatementContext simpleStepStatement() throws RecognitionException {
		SimpleStepStatementContext _localctx = new SimpleStepStatementContext(_ctx, getState());
		enterRule(_localctx, 70, RULE_simpleStepStatement);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(334);
			pipelineSimpleStepCall();
			setState(336);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if (_la==SEMICOLON) {
				{
				setState(335);
				match(SEMICOLON);
				}
			}

			setState(338);
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

	public static class CompoundStepStatementContext extends ParserRuleContext {
		public ScriptStepContext scriptStep() {
			return getRuleContext(ScriptStepContext.class,0);
		}
		public HandleErrorsStepContext handleErrorsStep() {
			return getRuleContext(HandleErrorsStepContext.class,0);
		}
		public CompoundStepStatementContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_compoundStepStatement; }
	}

	public final CompoundStepStatementContext compoundStepStatement() throws RecognitionException {
		CompoundStepStatementContext _localctx = new CompoundStepStatementContext(_ctx, getState());
		enterRule(_localctx, 72, RULE_compoundStepStatement);
		try {
			setState(342);
			_errHandler.sync(this);
			switch (_input.LA(1)) {
			case SCRIPT:
				enterOuterAlt(_localctx, 1);
				{
				setState(340);
				scriptStep();
				}
				break;
			case STRING:
				enterOuterAlt(_localctx, 2);
				{
				setState(341);
				handleErrorsStep();
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

	public static class PipelineSimpleStepCallContext extends ParserRuleContext {
		public TerminalNode IDENTIFIER() { return getToken(BldItParser.IDENTIFIER, 0); }
		public TerminalNode OPEN_PAREN() { return getToken(BldItParser.OPEN_PAREN, 0); }
		public TerminalNode CLOSE_PAREN() { return getToken(BldItParser.CLOSE_PAREN, 0); }
		public List<PipelineExpressionContext> pipelineExpression() {
			return getRuleContexts(PipelineExpressionContext.class);
		}
		public PipelineExpressionContext pipelineExpression(int i) {
			return getRuleContext(PipelineExpressionContext.class,i);
		}
		public List<TerminalNode> COMMA() { return getTokens(BldItParser.COMMA); }
		public TerminalNode COMMA(int i) {
			return getToken(BldItParser.COMMA, i);
		}
		public PipelineSimpleStepCallContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_pipelineSimpleStepCall; }
	}

	public final PipelineSimpleStepCallContext pipelineSimpleStepCall() throws RecognitionException {
		PipelineSimpleStepCallContext _localctx = new PipelineSimpleStepCallContext(_ctx, getState());
		enterRule(_localctx, 74, RULE_pipelineSimpleStepCall);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(344);
			match(IDENTIFIER);
			setState(345);
			match(OPEN_PAREN);
			setState(354);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if ((((_la) & ~0x3f) == 0 && ((1L << _la) & ((1L << OPEN_PAREN) | (1L << NOT) | (1L << INTEGER) | (1L << FLOAT) | (1L << STRING) | (1L << BOOL) | (1L << NULL) | (1L << IDENTIFIER))) != 0)) {
				{
				setState(346);
				pipelineExpression();
				setState(351);
				_errHandler.sync(this);
				_la = _input.LA(1);
				while (_la==COMMA) {
					{
					{
					setState(347);
					match(COMMA);
					setState(348);
					pipelineExpression();
					}
					}
					setState(353);
					_errHandler.sync(this);
					_la = _input.LA(1);
				}
				}
			}

			setState(356);
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

	public static class EchoStepContext extends ParserRuleContext {
		public TerminalNode ECHO() { return getToken(BldItParser.ECHO, 0); }
		public PipelineExpressionContext pipelineExpression() {
			return getRuleContext(PipelineExpressionContext.class,0);
		}
		public EchoStepContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_echoStep; }
	}

	public final EchoStepContext echoStep() throws RecognitionException {
		EchoStepContext _localctx = new EchoStepContext(_ctx, getState());
		enterRule(_localctx, 76, RULE_echoStep);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(358);
			match(ECHO);
			setState(359);
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

	public static class RunStepContext extends ParserRuleContext {
		public TerminalNode STRING() { return getToken(BldItParser.STRING, 0); }
		public RunStepContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_runStep; }
	}

	public final RunStepContext runStep() throws RecognitionException {
		RunStepContext _localctx = new RunStepContext(_ctx, getState());
		enterRule(_localctx, 78, RULE_runStep);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(361);
			match(STRING);
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

	public static class ErrorStepContext extends ParserRuleContext {
		public TerminalNode STRING() { return getToken(BldItParser.STRING, 0); }
		public ErrorStepContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_errorStep; }
	}

	public final ErrorStepContext errorStep() throws RecognitionException {
		ErrorStepContext _localctx = new ErrorStepContext(_ctx, getState());
		enterRule(_localctx, 80, RULE_errorStep);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(363);
			match(STRING);
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

	public static class HandleErrorsStepContext extends ParserRuleContext {
		public TerminalNode STRING() { return getToken(BldItParser.STRING, 0); }
		public HandleErrorsStepContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_handleErrorsStep; }
	}

	public final HandleErrorsStepContext handleErrorsStep() throws RecognitionException {
		HandleErrorsStepContext _localctx = new HandleErrorsStepContext(_ctx, getState());
		enterRule(_localctx, 82, RULE_handleErrorsStep);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(365);
			match(STRING);
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

	public static class ScriptStepContext extends ParserRuleContext {
		public TerminalNode SCRIPT() { return getToken(BldItParser.SCRIPT, 0); }
		public TerminalNode COLON() { return getToken(BldItParser.COLON, 0); }
		public ScriptBlockContext scriptBlock() {
			return getRuleContext(ScriptBlockContext.class,0);
		}
		public ScriptStepContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_scriptStep; }
	}

	public final ScriptStepContext scriptStep() throws RecognitionException {
		ScriptStepContext _localctx = new ScriptStepContext(_ctx, getState());
		enterRule(_localctx, 84, RULE_scriptStep);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(367);
			match(SCRIPT);
			setState(368);
			match(COLON);
			setState(369);
			scriptBlock();
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

	public static class ScriptBlockContext extends ParserRuleContext {
		public TerminalNode NEWLINE() { return getToken(BldItParser.NEWLINE, 0); }
		public TerminalNode INDENT() { return getToken(BldItParser.INDENT, 0); }
		public TerminalNode DEDENT() { return getToken(BldItParser.DEDENT, 0); }
		public StepStatementsContext stepStatements() {
			return getRuleContext(StepStatementsContext.class,0);
		}
		public StatementsContext statements() {
			return getRuleContext(StatementsContext.class,0);
		}
		public ScriptBlockContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_scriptBlock; }
	}

	public final ScriptBlockContext scriptBlock() throws RecognitionException {
		ScriptBlockContext _localctx = new ScriptBlockContext(_ctx, getState());
		enterRule(_localctx, 86, RULE_scriptBlock);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(371);
			match(NEWLINE);
			setState(372);
			match(INDENT);
			setState(375);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,30,_ctx) ) {
			case 1:
				{
				setState(373);
				stepStatements();
				}
				break;
			case 2:
				{
				setState(374);
				statements();
				}
				break;
			}
			setState(377);
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

	public static class StepStatementsContext extends ParserRuleContext {
		public List<StepStatementContext> stepStatement() {
			return getRuleContexts(StepStatementContext.class);
		}
		public StepStatementContext stepStatement(int i) {
			return getRuleContext(StepStatementContext.class,i);
		}
		public StepStatementsContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_stepStatements; }
	}

	public final StepStatementsContext stepStatements() throws RecognitionException {
		StepStatementsContext _localctx = new StepStatementsContext(_ctx, getState());
		enterRule(_localctx, 88, RULE_stepStatements);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(380); 
			_errHandler.sync(this);
			_la = _input.LA(1);
			do {
				{
				{
				setState(379);
				stepStatement();
				}
				}
				setState(382); 
				_errHandler.sync(this);
				_la = _input.LA(1);
			} while ( (((_la) & ~0x3f) == 0 && ((1L << _la) & ((1L << STRING) | (1L << IDENTIFIER) | (1L << SCRIPT))) != 0) );
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
		enterRule(_localctx, 90, RULE_envAssignments);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(390); 
			_errHandler.sync(this);
			_la = _input.LA(1);
			do {
				{
				{
				{
				setState(384);
				envAssignment();
				}
				setState(386);
				_errHandler.sync(this);
				_la = _input.LA(1);
				if (_la==SEMICOLON) {
					{
					setState(385);
					match(SEMICOLON);
					}
				}

				setState(388);
				match(NEWLINE);
				}
				}
				setState(392); 
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
		enterRule(_localctx, 92, RULE_envAssignment);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(394);
			match(IDENTIFIER);
			setState(395);
			match(ASSIGN_OP);
			setState(396);
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
		enterRule(_localctx, 94, RULE_paramAssignments);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(404); 
			_errHandler.sync(this);
			_la = _input.LA(1);
			do {
				{
				{
				{
				setState(398);
				paramAssignment();
				}
				setState(400);
				_errHandler.sync(this);
				_la = _input.LA(1);
				if (_la==SEMICOLON) {
					{
					setState(399);
					match(SEMICOLON);
					}
				}

				setState(402);
				match(NEWLINE);
				}
				}
				setState(406); 
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
		enterRule(_localctx, 96, RULE_paramAssignment);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(408);
			match(IDENTIFIER);
			setState(409);
			match(COLON);
			setState(410);
			match(PARAM_TYPE);
			setState(413);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if (_la==ASSIGN_OP) {
				{
				setState(411);
				match(ASSIGN_OP);
				setState(412);
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
		enterRule(_localctx, 98, RULE_paramValue);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(415);
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
		enterRule(_localctx, 100, RULE_pipelineExpression);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(417);
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
		"\3\u608b\ua72a\u8133\ub9ed\u417c\u3be7\u7786\u5964\3-\u01a6\4\2\t\2\4"+
		"\3\t\3\4\4\t\4\4\5\t\5\4\6\t\6\4\7\t\7\4\b\t\b\4\t\t\t\4\n\t\n\4\13\t"+
		"\13\4\f\t\f\4\r\t\r\4\16\t\16\4\17\t\17\4\20\t\20\4\21\t\21\4\22\t\22"+
		"\4\23\t\23\4\24\t\24\4\25\t\25\4\26\t\26\4\27\t\27\4\30\t\30\4\31\t\31"+
		"\4\32\t\32\4\33\t\33\4\34\t\34\4\35\t\35\4\36\t\36\4\37\t\37\4 \t \4!"+
		"\t!\4\"\t\"\4#\t#\4$\t$\4%\t%\4&\t&\4\'\t\'\4(\t(\4)\t)\4*\t*\4+\t+\4"+
		",\t,\4-\t-\4.\t.\4/\t/\4\60\t\60\4\61\t\61\4\62\t\62\4\63\t\63\4\64\t"+
		"\64\3\2\3\2\7\2k\n\2\f\2\16\2n\13\2\3\2\3\2\3\2\3\3\6\3t\n\3\r\3\16\3"+
		"u\3\4\3\4\5\4z\n\4\3\5\3\5\3\5\5\5\177\n\5\3\5\5\5\u0082\n\5\3\5\3\5\3"+
		"\6\3\6\3\6\5\6\u0089\n\6\3\7\3\7\7\7\u008d\n\7\f\7\16\7\u0090\13\7\3\7"+
		"\5\7\u0093\n\7\3\b\3\b\3\b\3\b\3\b\3\t\3\t\3\t\3\t\3\t\3\t\3\n\3\n\3\n"+
		"\3\n\3\13\3\13\3\13\3\13\3\13\3\f\3\f\3\f\3\f\5\f\u00ad\n\f\3\f\3\f\3"+
		"\f\3\f\3\r\3\r\3\r\7\r\u00b6\n\r\f\r\16\r\u00b9\13\r\3\16\3\16\3\16\3"+
		"\16\3\16\3\16\5\16\u00c1\n\16\3\17\3\17\3\17\3\17\5\17\u00c7\n\17\3\17"+
		"\5\17\u00ca\n\17\3\20\3\20\5\20\u00ce\n\20\3\21\3\21\3\21\3\21\3\22\3"+
		"\22\3\22\3\22\3\22\7\22\u00d9\n\22\f\22\16\22\u00dc\13\22\5\22\u00de\n"+
		"\22\3\22\3\22\3\23\3\23\3\23\3\23\3\23\3\23\5\23\u00e8\n\23\3\23\3\23"+
		"\3\23\3\23\3\23\3\23\3\23\3\23\3\23\3\23\3\23\3\23\3\23\3\23\3\23\3\23"+
		"\7\23\u00fa\n\23\f\23\16\23\u00fd\13\23\3\24\3\24\3\24\3\24\3\25\3\25"+
		"\3\25\3\26\3\26\3\27\3\27\3\30\3\30\3\31\3\31\3\32\3\32\3\33\3\33\3\33"+
		"\3\33\3\33\5\33\u0115\n\33\3\33\5\33\u0118\n\33\3\33\3\33\3\33\3\34\3"+
		"\34\3\34\3\34\3\35\3\35\3\35\3\35\3\36\3\36\3\36\3\36\3\37\3\37\3\37\3"+
		"\37\3\37\3 \3 \3 \3 \3 \3!\3!\3!\6!\u0136\n!\r!\16!\u0137\3!\3!\3\"\3"+
		"\"\3\"\3\"\3\"\3#\3#\3#\3#\6#\u0145\n#\r#\16#\u0146\3#\3#\5#\u014b\n#"+
		"\3$\3$\5$\u014f\n$\3%\3%\5%\u0153\n%\3%\3%\3&\3&\5&\u0159\n&\3\'\3\'\3"+
		"\'\3\'\3\'\7\'\u0160\n\'\f\'\16\'\u0163\13\'\5\'\u0165\n\'\3\'\3\'\3("+
		"\3(\3(\3)\3)\3*\3*\3+\3+\3,\3,\3,\3,\3-\3-\3-\3-\5-\u017a\n-\3-\3-\3."+
		"\6.\u017f\n.\r.\16.\u0180\3/\3/\5/\u0185\n/\3/\3/\6/\u0189\n/\r/\16/\u018a"+
		"\3\60\3\60\3\60\3\60\3\61\3\61\5\61\u0193\n\61\3\61\3\61\6\61\u0197\n"+
		"\61\r\61\16\61\u0198\3\62\3\62\3\62\3\62\3\62\5\62\u01a0\n\62\3\63\3\63"+
		"\3\64\3\64\3\64\2\3$\65\2\4\6\b\n\f\16\20\22\24\26\30\32\34\36 \"$&(*"+
		",.\60\62\64\668:<>@BDFHJLNPRTVXZ\\^`bdf\2\7\3\2\17\21\3\2\r\16\4\2\23"+
		"\26  \3\2\"&\3\2$%\2\u019e\2l\3\2\2\2\4s\3\2\2\2\6y\3\2\2\2\b~\3\2\2\2"+
		"\n\u0088\3\2\2\2\f\u008a\3\2\2\2\16\u0094\3\2\2\2\20\u0099\3\2\2\2\22"+
		"\u009f\3\2\2\2\24\u00a3\3\2\2\2\26\u00a8\3\2\2\2\30\u00b2\3\2\2\2\32\u00c0"+
		"\3\2\2\2\34\u00c9\3\2\2\2\36\u00cb\3\2\2\2 \u00cf\3\2\2\2\"\u00d3\3\2"+
		"\2\2$\u00e7\3\2\2\2&\u00fe\3\2\2\2(\u0102\3\2\2\2*\u0105\3\2\2\2,\u0107"+
		"\3\2\2\2.\u0109\3\2\2\2\60\u010b\3\2\2\2\62\u010d\3\2\2\2\64\u010f\3\2"+
		"\2\2\66\u011c\3\2\2\28\u0120\3\2\2\2:\u0124\3\2\2\2<\u0128\3\2\2\2>\u012d"+
		"\3\2\2\2@\u0132\3\2\2\2B\u013b\3\2\2\2D\u014a\3\2\2\2F\u014e\3\2\2\2H"+
		"\u0150\3\2\2\2J\u0158\3\2\2\2L\u015a\3\2\2\2N\u0168\3\2\2\2P\u016b\3\2"+
		"\2\2R\u016d\3\2\2\2T\u016f\3\2\2\2V\u0171\3\2\2\2X\u0175\3\2\2\2Z\u017e"+
		"\3\2\2\2\\\u0188\3\2\2\2^\u018c\3\2\2\2`\u0196\3\2\2\2b\u019a\3\2\2\2"+
		"d\u01a1\3\2\2\2f\u01a3\3\2\2\2hk\7,\2\2ik\5\6\4\2jh\3\2\2\2ji\3\2\2\2"+
		"kn\3\2\2\2lj\3\2\2\2lm\3\2\2\2mo\3\2\2\2nl\3\2\2\2op\5\64\33\2pq\7\2\2"+
		"\3q\3\3\2\2\2rt\5\6\4\2sr\3\2\2\2tu\3\2\2\2us\3\2\2\2uv\3\2\2\2v\5\3\2"+
		"\2\2wz\5\b\5\2xz\5\n\6\2yw\3\2\2\2yx\3\2\2\2z\7\3\2\2\2{\177\5 \21\2|"+
		"\177\5\"\22\2}\177\5\36\20\2~{\3\2\2\2~|\3\2\2\2~}\3\2\2\2\177\u0081\3"+
		"\2\2\2\u0080\u0082\7\32\2\2\u0081\u0080\3\2\2\2\u0081\u0082\3\2\2\2\u0082"+
		"\u0083\3\2\2\2\u0083\u0084\7,\2\2\u0084\t\3\2\2\2\u0085\u0089\5\f\7\2"+
		"\u0086\u0089\5\24\13\2\u0087\u0089\5\26\f\2\u0088\u0085\3\2\2\2\u0088"+
		"\u0086\3\2\2\2\u0088\u0087\3\2\2\2\u0089\13\3\2\2\2\u008a\u008e\5\16\b"+
		"\2\u008b\u008d\5\20\t\2\u008c\u008b\3\2\2\2\u008d\u0090\3\2\2\2\u008e"+
		"\u008c\3\2\2\2\u008e\u008f\3\2\2\2\u008f\u0092\3\2\2\2\u0090\u008e\3\2"+
		"\2\2\u0091\u0093\5\22\n\2\u0092\u0091\3\2\2\2\u0092\u0093\3\2\2\2\u0093"+
		"\r\3\2\2\2\u0094\u0095\7\36\2\2\u0095\u0096\5$\23\2\u0096\u0097\7\33\2"+
		"\2\u0097\u0098\5\32\16\2\u0098\17\3\2\2\2\u0099\u009a\7\37\2\2\u009a\u009b"+
		"\7\36\2\2\u009b\u009c\5$\23\2\u009c\u009d\7\33\2\2\u009d\u009e\5\32\16"+
		"\2\u009e\21\3\2\2\2\u009f\u00a0\7\37\2\2\u00a0\u00a1\7\33\2\2\u00a1\u00a2"+
		"\5\32\16\2\u00a2\23\3\2\2\2\u00a3\u00a4\7\n\2\2\u00a4\u00a5\5$\23\2\u00a5"+
		"\u00a6\7\33\2\2\u00a6\u00a7\5\32\16\2\u00a7\25\3\2\2\2\u00a8\u00a9\7\13"+
		"\2\2\u00a9\u00aa\7(\2\2\u00aa\u00ac\7\27\2\2\u00ab\u00ad\5\30\r\2\u00ac"+
		"\u00ab\3\2\2\2\u00ac\u00ad\3\2\2\2\u00ad\u00ae\3\2\2\2\u00ae\u00af\7\30"+
		"\2\2\u00af\u00b0\7\33\2\2\u00b0\u00b1\5\34\17\2\u00b1\27\3\2\2\2\u00b2"+
		"\u00b7\7(\2\2\u00b3\u00b4\7\31\2\2\u00b4\u00b6\7(\2\2\u00b5\u00b3\3\2"+
		"\2\2\u00b6\u00b9\3\2\2\2\u00b7\u00b5\3\2\2\2\u00b7\u00b8\3\2\2\2\u00b8"+
		"\31\3\2\2\2\u00b9\u00b7\3\2\2\2\u00ba\u00c1\5\b\5\2\u00bb\u00bc\7,\2\2"+
		"\u00bc\u00bd\7\3\2\2\u00bd\u00be\5\4\3\2\u00be\u00bf\7\4\2\2\u00bf\u00c1"+
		"\3\2\2\2\u00c0\u00ba\3\2\2\2\u00c0\u00bb\3\2\2\2\u00c1\33\3\2\2\2\u00c2"+
		"\u00ca\5\b\5\2\u00c3\u00c4\7,\2\2\u00c4\u00c6\7\3\2\2\u00c5\u00c7\5\4"+
		"\3\2\u00c6\u00c5\3\2\2\2\u00c6\u00c7\3\2\2\2\u00c7\u00c8\3\2\2\2\u00c8"+
		"\u00ca\7\4\2\2\u00c9\u00c2\3\2\2\2\u00c9\u00c3\3\2\2\2\u00ca\35\3\2\2"+
		"\2\u00cb\u00cd\7\f\2\2\u00cc\u00ce\5$\23\2\u00cd\u00cc\3\2\2\2\u00cd\u00ce"+
		"\3\2\2\2\u00ce\37\3\2\2\2\u00cf\u00d0\7(\2\2\u00d0\u00d1\7\35\2\2\u00d1"+
		"\u00d2\5$\23\2\u00d2!\3\2\2\2\u00d3\u00d4\7(\2\2\u00d4\u00dd\7\27\2\2"+
		"\u00d5\u00da\5$\23\2\u00d6\u00d7\7\31\2\2\u00d7\u00d9\5$\23\2\u00d8\u00d6"+
		"\3\2\2\2\u00d9\u00dc\3\2\2\2\u00da\u00d8\3\2\2\2\u00da\u00db\3\2\2\2\u00db"+
		"\u00de\3\2\2\2\u00dc\u00da\3\2\2\2\u00dd\u00d5\3\2\2\2\u00dd\u00de\3\2"+
		"\2\2\u00de\u00df\3\2\2\2\u00df\u00e0\7\30\2\2\u00e0#\3\2\2\2\u00e1\u00e2"+
		"\b\23\1\2\u00e2\u00e8\5\62\32\2\u00e3\u00e8\7(\2\2\u00e4\u00e8\5\"\22"+
		"\2\u00e5\u00e8\5&\24\2\u00e6\u00e8\5(\25\2\u00e7\u00e1\3\2\2\2\u00e7\u00e3"+
		"\3\2\2\2\u00e7\u00e4\3\2\2\2\u00e7\u00e5\3\2\2\2\u00e7\u00e6\3\2\2\2\u00e8"+
		"\u00fb\3\2\2\2\u00e9\u00ea\f\6\2\2\u00ea\u00eb\5*\26\2\u00eb\u00ec\5$"+
		"\23\7\u00ec\u00fa\3\2\2\2\u00ed\u00ee\f\5\2\2\u00ee\u00ef\5,\27\2\u00ef"+
		"\u00f0\5$\23\6\u00f0\u00fa\3\2\2\2\u00f1\u00f2\f\4\2\2\u00f2\u00f3\5."+
		"\30\2\u00f3\u00f4\5$\23\5\u00f4\u00fa\3\2\2\2\u00f5\u00f6\f\3\2\2\u00f6"+
		"\u00f7\5\60\31\2\u00f7\u00f8\5$\23\4\u00f8\u00fa\3\2\2\2\u00f9\u00e9\3"+
		"\2\2\2\u00f9\u00ed\3\2\2\2\u00f9\u00f1\3\2\2\2\u00f9\u00f5\3\2\2\2\u00fa"+
		"\u00fd\3\2\2\2\u00fb\u00f9\3\2\2\2\u00fb\u00fc\3\2\2\2\u00fc%\3\2\2\2"+
		"\u00fd\u00fb\3\2\2\2\u00fe\u00ff\7\27\2\2\u00ff\u0100\5$\23\2\u0100\u0101"+
		"\7\30\2\2\u0101\'\3\2\2\2\u0102\u0103\7!\2\2\u0103\u0104\5$\23\2\u0104"+
		")\3\2\2\2\u0105\u0106\t\2\2\2\u0106+\3\2\2\2\u0107\u0108\t\3\2\2\u0108"+
		"-\3\2\2\2\u0109\u010a\t\4\2\2\u010a/\3\2\2\2\u010b\u010c\7\22\2\2\u010c"+
		"\61\3\2\2\2\u010d\u010e\t\5\2\2\u010e\63\3\2\2\2\u010f\u0110\7\5\2\2\u0110"+
		"\u0111\7\33\2\2\u0111\u0112\7,\2\2\u0112\u0114\7\3\2\2\u0113\u0115\5\66"+
		"\34\2\u0114\u0113\3\2\2\2\u0114\u0115\3\2\2\2\u0115\u0117\3\2\2\2\u0116"+
		"\u0118\58\35\2\u0117\u0116\3\2\2\2\u0117\u0118\3\2\2\2\u0118\u0119\3\2"+
		"\2\2\u0119\u011a\5:\36\2\u011a\u011b\7\4\2\2\u011b\65\3\2\2\2\u011c\u011d"+
		"\7\6\2\2\u011d\u011e\7\33\2\2\u011e\u011f\5<\37\2\u011f\67\3\2\2\2\u0120"+
		"\u0121\7\7\2\2\u0121\u0122\7\33\2\2\u0122\u0123\5> \2\u01239\3\2\2\2\u0124"+
		"\u0125\7\b\2\2\u0125\u0126\7\33\2\2\u0126\u0127\5@!\2\u0127;\3\2\2\2\u0128"+
		"\u0129\7,\2\2\u0129\u012a\7\3\2\2\u012a\u012b\5\\/\2\u012b\u012c\7\4\2"+
		"\2\u012c=\3\2\2\2\u012d\u012e\7,\2\2\u012e\u012f\7\3\2\2\u012f\u0130\5"+
		"`\61\2\u0130\u0131\7\4\2\2\u0131?\3\2\2\2\u0132\u0133\7,\2\2\u0133\u0135"+
		"\7\3\2\2\u0134\u0136\5B\"\2\u0135\u0134\3\2\2\2\u0136\u0137\3\2\2\2\u0137"+
		"\u0135\3\2\2\2\u0137\u0138\3\2\2\2\u0138\u0139\3\2\2\2\u0139\u013a\7\4"+
		"\2\2\u013aA\3\2\2\2\u013b\u013c\7\t\2\2\u013c\u013d\7$\2\2\u013d\u013e"+
		"\7\33\2\2\u013e\u013f\5D#\2\u013fC\3\2\2\2\u0140\u014b\5H%\2\u0141\u0142"+
		"\7,\2\2\u0142\u0144\7\3\2\2\u0143\u0145\5F$\2\u0144\u0143\3\2\2\2\u0145"+
		"\u0146\3\2\2\2\u0146\u0144\3\2\2\2\u0146\u0147\3\2\2\2\u0147\u0148\3\2"+
		"\2\2\u0148\u0149\7\4\2\2\u0149\u014b\3\2\2\2\u014a\u0140\3\2\2\2\u014a"+
		"\u0141\3\2\2\2\u014bE\3\2\2\2\u014c\u014f\5H%\2\u014d\u014f\5J&\2\u014e"+
		"\u014c\3\2\2\2\u014e\u014d\3\2\2\2\u014fG\3\2\2\2\u0150\u0152\5L\'\2\u0151"+
		"\u0153\7\32\2\2\u0152\u0151\3\2\2\2\u0152\u0153\3\2\2\2\u0153\u0154\3"+
		"\2\2\2\u0154\u0155\7,\2\2\u0155I\3\2\2\2\u0156\u0159\5V,\2\u0157\u0159"+
		"\5T+\2\u0158\u0156\3\2\2\2\u0158\u0157\3\2\2\2\u0159K\3\2\2\2\u015a\u015b"+
		"\7(\2\2\u015b\u0164\7\27\2\2\u015c\u0161\5f\64\2\u015d\u015e\7\31\2\2"+
		"\u015e\u0160\5f\64\2\u015f\u015d\3\2\2\2\u0160\u0163\3\2\2\2\u0161\u015f"+
		"\3\2\2\2\u0161\u0162\3\2\2\2\u0162\u0165\3\2\2\2\u0163\u0161\3\2\2\2\u0164"+
		"\u015c\3\2\2\2\u0164\u0165\3\2\2\2\u0165\u0166\3\2\2\2\u0166\u0167\7\30"+
		"\2\2\u0167M\3\2\2\2\u0168\u0169\7+\2\2\u0169\u016a\5f\64\2\u016aO\3\2"+
		"\2\2\u016b\u016c\7$\2\2\u016cQ\3\2\2\2\u016d\u016e\7$\2\2\u016eS\3\2\2"+
		"\2\u016f\u0170\7$\2\2\u0170U\3\2\2\2\u0171\u0172\7*\2\2\u0172\u0173\7"+
		"\33\2\2\u0173\u0174\5X-\2\u0174W\3\2\2\2\u0175\u0176\7,\2\2\u0176\u0179"+
		"\7\3\2\2\u0177\u017a\5Z.\2\u0178\u017a\5\4\3\2\u0179\u0177\3\2\2\2\u0179"+
		"\u0178\3\2\2\2\u017a\u017b\3\2\2\2\u017b\u017c\7\4\2\2\u017cY\3\2\2\2"+
		"\u017d\u017f\5F$\2\u017e\u017d\3\2\2\2\u017f\u0180\3\2\2\2\u0180\u017e"+
		"\3\2\2\2\u0180\u0181\3\2\2\2\u0181[\3\2\2\2\u0182\u0184\5^\60\2\u0183"+
		"\u0185\7\32\2\2\u0184\u0183\3\2\2\2\u0184\u0185\3\2\2\2\u0185\u0186\3"+
		"\2\2\2\u0186\u0187\7,\2\2\u0187\u0189\3\2\2\2\u0188\u0182\3\2\2\2\u0189"+
		"\u018a\3\2\2\2\u018a\u0188\3\2\2\2\u018a\u018b\3\2\2\2\u018b]\3\2\2\2"+
		"\u018c\u018d\7(\2\2\u018d\u018e\7\35\2\2\u018e\u018f\5f\64\2\u018f_\3"+
		"\2\2\2\u0190\u0192\5b\62\2\u0191\u0193\7\32\2\2\u0192\u0191\3\2\2\2\u0192"+
		"\u0193\3\2\2\2\u0193\u0194\3\2\2\2\u0194\u0195\7,\2\2\u0195\u0197\3\2"+
		"\2\2\u0196\u0190\3\2\2\2\u0197\u0198\3\2\2\2\u0198\u0196\3\2\2\2\u0198"+
		"\u0199\3\2\2\2\u0199a\3\2\2\2\u019a\u019b\7(\2\2\u019b\u019c\7\33\2\2"+
		"\u019c\u019f\7)\2\2\u019d\u019e\7\35\2\2\u019e\u01a0\5d\63\2\u019f\u019d"+
		"\3\2\2\2\u019f\u01a0\3\2\2\2\u01a0c\3\2\2\2\u01a1\u01a2\t\6\2\2\u01a2"+
		"e\3\2\2\2\u01a3\u01a4\5$\23\2\u01a4g\3\2\2\2\'jluy~\u0081\u0088\u008e"+
		"\u0092\u00ac\u00b7\u00c0\u00c6\u00c9\u00cd\u00da\u00dd\u00e7\u00f9\u00fb"+
		"\u0114\u0117\u0137\u0146\u014a\u014e\u0152\u0158\u0161\u0164\u0179\u0180"+
		"\u0184\u018a\u0192\u0198\u019f";
	public static final ATN _ATN =
		new ATNDeserializer().deserialize(_serializedATN.toCharArray());
	static {
		_decisionToDFA = new DFA[_ATN.getNumberOfDecisions()];
		for (int i = 0; i < _ATN.getNumberOfDecisions(); i++) {
			_decisionToDFA[i] = new DFA(_ATN.getDecisionState(i), i);
		}
	}
}