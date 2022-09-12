// Generated from c:\Users\ragde\OneDrive\Desktop\Programming\BldIt\BldIt.Lang\Grammar\BldItLexer.g4 by ANTLR 4.9.2
import org.antlr.v4.runtime.Lexer;
import org.antlr.v4.runtime.CharStream;
import org.antlr.v4.runtime.Token;
import org.antlr.v4.runtime.TokenStream;
import org.antlr.v4.runtime.*;
import org.antlr.v4.runtime.atn.*;
import org.antlr.v4.runtime.dfa.DFA;
import org.antlr.v4.runtime.misc.*;

@SuppressWarnings({"all", "warnings", "unchecked", "unused", "cast"})
public class BldItLexer extends BldIt.Lang.External.Python3LexerIndent.PythonLexerBase {
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
	public static String[] channelNames = {
		"DEFAULT_TOKEN_CHANNEL", "HIDDEN"
	};

	public static String[] modeNames = {
		"DEFAULT_MODE"
	};

	private static String[] makeRuleNames() {
		return new String[] {
			"PIPELINE", "GLOBALENV", "PARAMETERS", "STAGES", "STAGE", "WHILE", "FUNCTION", 
			"RETURN", "ADD_OP", "SUB_OP", "MULT_OP", "DIV_OP", "MOD_OP", "BOOL_OP", 
			"GREATER_THAN_OP", "LESS_THAN_OP", "GREATER_THAN_EQUAL_OP", "LESS_THAN_EQUAL_OP", 
			"OPEN_PAREN", "CLOSE_PAREN", "COMMA", "SEMICOLON", "COLON", "DOT", "ASSIGN_OP", 
			"IF", "ELSE", "EQUALITY", "NOT", "INTEGER", "FLOAT", "STRING", "BOOL", 
			"NULL", "ENDLINE", "IDENTIFIER", "PARAM_TYPE", "SCRIPT", "ECHO", "NEWLINE", 
			"SKIP_", "SPACES", "COMMENT", "LINE_JOINING"
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


	public BldItLexer(CharStream input) {
		super(input);
		_interp = new LexerATNSimulator(this,_ATN,_decisionToDFA,_sharedContextCache);
	}

	@Override
	public String getGrammarFileName() { return "BldItLexer.g4"; }

	@Override
	public String[] getRuleNames() { return ruleNames; }

	@Override
	public String getSerializedATN() { return _serializedATN; }

	@Override
	public String[] getChannelNames() { return channelNames; }

	@Override
	public String[] getModeNames() { return modeNames; }

	@Override
	public ATN getATN() { return _ATN; }

	@Override
	public void action(RuleContext _localctx, int ruleIndex, int actionIndex) {
		switch (ruleIndex) {
		case 39:
			NEWLINE_action((RuleContext)_localctx, actionIndex);
			break;
		}
	}
	private void NEWLINE_action(RuleContext _localctx, int actionIndex) {
		switch (actionIndex) {
		case 0:
			this.onNewLine();
			break;
		}
	}
	@Override
	public boolean sempred(RuleContext _localctx, int ruleIndex, int predIndex) {
		switch (ruleIndex) {
		case 39:
			return NEWLINE_sempred((RuleContext)_localctx, predIndex);
		}
		return true;
	}
	private boolean NEWLINE_sempred(RuleContext _localctx, int predIndex) {
		switch (predIndex) {
		case 0:
			return this.atStartOfInput();
		}
		return true;
	}

	public static final String _serializedATN =
		"\3\u608b\ua72a\u8133\ub9ed\u417c\u3be7\u7786\u5964\2-\u0184\b\1\4\2\t"+
		"\2\4\3\t\3\4\4\t\4\4\5\t\5\4\6\t\6\4\7\t\7\4\b\t\b\4\t\t\t\4\n\t\n\4\13"+
		"\t\13\4\f\t\f\4\r\t\r\4\16\t\16\4\17\t\17\4\20\t\20\4\21\t\21\4\22\t\22"+
		"\4\23\t\23\4\24\t\24\4\25\t\25\4\26\t\26\4\27\t\27\4\30\t\30\4\31\t\31"+
		"\4\32\t\32\4\33\t\33\4\34\t\34\4\35\t\35\4\36\t\36\4\37\t\37\4 \t \4!"+
		"\t!\4\"\t\"\4#\t#\4$\t$\4%\t%\4&\t&\4\'\t\'\4(\t(\4)\t)\4*\t*\4+\t+\4"+
		",\t,\4-\t-\3\2\3\2\3\2\3\2\3\2\3\2\3\2\3\2\3\2\3\2\3\2\3\2\5\2h\n\2\3"+
		"\3\3\3\3\3\3\3\3\3\3\3\3\3\3\3\3\3\3\3\3\4\3\4\3\4\3\4\3\4\3\4\3\4\3\4"+
		"\3\4\3\4\3\4\3\5\3\5\3\5\3\5\3\5\3\5\3\5\3\6\3\6\3\6\3\6\3\6\3\6\3\7\3"+
		"\7\3\7\3\7\3\7\3\7\3\b\3\b\3\b\3\b\3\b\3\b\3\b\3\b\3\b\3\b\3\b\3\b\3\b"+
		"\3\b\5\b\u00a0\n\b\3\t\3\t\3\t\3\t\3\t\3\t\3\t\3\t\3\t\5\t\u00ab\n\t\3"+
		"\n\3\n\3\13\3\13\3\f\3\f\3\r\3\r\3\16\3\16\3\17\3\17\3\17\3\17\3\17\5"+
		"\17\u00bc\n\17\3\20\3\20\3\21\3\21\3\22\3\22\3\22\3\23\3\23\3\23\3\24"+
		"\3\24\3\25\3\25\3\26\3\26\3\27\3\27\3\30\3\30\3\31\3\31\3\32\3\32\3\33"+
		"\3\33\3\33\3\34\3\34\3\34\3\34\3\34\3\35\3\35\3\35\3\35\5\35\u00e2\n\35"+
		"\3\36\3\36\3\36\3\36\3\36\5\36\u00e9\n\36\3\37\6\37\u00ec\n\37\r\37\16"+
		"\37\u00ed\3 \6 \u00f1\n \r \16 \u00f2\3 \3 \6 \u00f7\n \r \16 \u00f8\3"+
		"!\3!\7!\u00fd\n!\f!\16!\u0100\13!\3!\3!\3!\7!\u0105\n!\f!\16!\u0108\13"+
		"!\3!\5!\u010b\n!\3\"\3\"\3\"\3\"\3\"\3\"\3\"\3\"\3\"\5\"\u0116\n\"\3#"+
		"\3#\3#\3#\3#\3$\3$\3%\3%\7%\u0121\n%\f%\16%\u0124\13%\3&\3&\3&\3&\3&\3"+
		"&\3&\3&\3&\3&\3&\3&\3&\3&\3&\3&\3&\3&\3&\3&\3&\3&\3&\3&\3&\3&\3&\3&\3"+
		"&\3&\3&\5&\u0145\n&\3\'\3\'\3\'\3\'\3\'\3\'\3\'\3(\3(\3(\3(\3(\3)\3)\3"+
		")\5)\u0156\n)\3)\3)\5)\u015a\n)\3)\5)\u015d\n)\5)\u015f\n)\3)\3)\3*\3"+
		"*\3*\5*\u0166\n*\3*\3*\3+\6+\u016b\n+\r+\16+\u016c\3,\3,\3,\5,\u0172\n"+
		",\3,\7,\u0175\n,\f,\16,\u0178\13,\3-\3-\5-\u017c\n-\3-\5-\u017f\n-\3-"+
		"\3-\5-\u0183\n-\2\2.\3\5\5\6\7\7\t\b\13\t\r\n\17\13\21\f\23\r\25\16\27"+
		"\17\31\20\33\21\35\22\37\23!\24#\25%\26\'\27)\30+\31-\32/\33\61\34\63"+
		"\35\65\36\67\379 ;!=\"?#A$C%E&G\'I(K)M*O+Q,S-U\2W\2Y\2\3\2\t\3\2\62;\3"+
		"\2$$\3\2))\5\2C\\aac|\6\2\62;C\\aac|\4\2\13\13\"\"\4\2\f\f\16\17\2\u019d"+
		"\2\3\3\2\2\2\2\5\3\2\2\2\2\7\3\2\2\2\2\t\3\2\2\2\2\13\3\2\2\2\2\r\3\2"+
		"\2\2\2\17\3\2\2\2\2\21\3\2\2\2\2\23\3\2\2\2\2\25\3\2\2\2\2\27\3\2\2\2"+
		"\2\31\3\2\2\2\2\33\3\2\2\2\2\35\3\2\2\2\2\37\3\2\2\2\2!\3\2\2\2\2#\3\2"+
		"\2\2\2%\3\2\2\2\2\'\3\2\2\2\2)\3\2\2\2\2+\3\2\2\2\2-\3\2\2\2\2/\3\2\2"+
		"\2\2\61\3\2\2\2\2\63\3\2\2\2\2\65\3\2\2\2\2\67\3\2\2\2\29\3\2\2\2\2;\3"+
		"\2\2\2\2=\3\2\2\2\2?\3\2\2\2\2A\3\2\2\2\2C\3\2\2\2\2E\3\2\2\2\2G\3\2\2"+
		"\2\2I\3\2\2\2\2K\3\2\2\2\2M\3\2\2\2\2O\3\2\2\2\2Q\3\2\2\2\2S\3\2\2\2\3"+
		"g\3\2\2\2\5i\3\2\2\2\7s\3\2\2\2\t~\3\2\2\2\13\u0085\3\2\2\2\r\u008b\3"+
		"\2\2\2\17\u009f\3\2\2\2\21\u00aa\3\2\2\2\23\u00ac\3\2\2\2\25\u00ae\3\2"+
		"\2\2\27\u00b0\3\2\2\2\31\u00b2\3\2\2\2\33\u00b4\3\2\2\2\35\u00bb\3\2\2"+
		"\2\37\u00bd\3\2\2\2!\u00bf\3\2\2\2#\u00c1\3\2\2\2%\u00c4\3\2\2\2\'\u00c7"+
		"\3\2\2\2)\u00c9\3\2\2\2+\u00cb\3\2\2\2-\u00cd\3\2\2\2/\u00cf\3\2\2\2\61"+
		"\u00d1\3\2\2\2\63\u00d3\3\2\2\2\65\u00d5\3\2\2\2\67\u00d8\3\2\2\29\u00e1"+
		"\3\2\2\2;\u00e8\3\2\2\2=\u00eb\3\2\2\2?\u00f0\3\2\2\2A\u010a\3\2\2\2C"+
		"\u0115\3\2\2\2E\u0117\3\2\2\2G\u011c\3\2\2\2I\u011e\3\2\2\2K\u0144\3\2"+
		"\2\2M\u0146\3\2\2\2O\u014d\3\2\2\2Q\u015e\3\2\2\2S\u0165\3\2\2\2U\u016a"+
		"\3\2\2\2W\u0171\3\2\2\2Y\u0179\3\2\2\2[\\\7r\2\2\\]\7k\2\2]^\7r\2\2^_"+
		"\7g\2\2_`\7n\2\2`a\7k\2\2ab\7p\2\2bh\7g\2\2cd\7r\2\2de\7k\2\2ef\7r\2\2"+
		"fh\7g\2\2g[\3\2\2\2gc\3\2\2\2h\4\3\2\2\2ij\7i\2\2jk\7n\2\2kl\7q\2\2lm"+
		"\7d\2\2mn\7c\2\2no\7n\2\2op\7G\2\2pq\7p\2\2qr\7x\2\2r\6\3\2\2\2st\7r\2"+
		"\2tu\7c\2\2uv\7t\2\2vw\7c\2\2wx\7o\2\2xy\7g\2\2yz\7v\2\2z{\7g\2\2{|\7"+
		"t\2\2|}\7u\2\2}\b\3\2\2\2~\177\7u\2\2\177\u0080\7v\2\2\u0080\u0081\7c"+
		"\2\2\u0081\u0082\7i\2\2\u0082\u0083\7g\2\2\u0083\u0084\7u\2\2\u0084\n"+
		"\3\2\2\2\u0085\u0086\7u\2\2\u0086\u0087\7v\2\2\u0087\u0088\7c\2\2\u0088"+
		"\u0089\7i\2\2\u0089\u008a\7g\2\2\u008a\f\3\2\2\2\u008b\u008c\7y\2\2\u008c"+
		"\u008d\7j\2\2\u008d\u008e\7k\2\2\u008e\u008f\7n\2\2\u008f\u0090\7g\2\2"+
		"\u0090\16\3\2\2\2\u0091\u0092\7h\2\2\u0092\u0093\7w\2\2\u0093\u00a0\7"+
		"p\2\2\u0094\u0095\7f\2\2\u0095\u0096\7g\2\2\u0096\u00a0\7h\2\2\u0097\u0098"+
		"\7h\2\2\u0098\u0099\7w\2\2\u0099\u009a\7p\2\2\u009a\u009b\7e\2\2\u009b"+
		"\u009c\7v\2\2\u009c\u009d\7k\2\2\u009d\u009e\7q\2\2\u009e\u00a0\7p\2\2"+
		"\u009f\u0091\3\2\2\2\u009f\u0094\3\2\2\2\u009f\u0097\3\2\2\2\u00a0\20"+
		"\3\2\2\2\u00a1\u00a2\7t\2\2\u00a2\u00a3\7g\2\2\u00a3\u00a4\7v\2\2\u00a4"+
		"\u00a5\7w\2\2\u00a5\u00a6\7t\2\2\u00a6\u00ab\7p\2\2\u00a7\u00a8\7t\2\2"+
		"\u00a8\u00a9\7g\2\2\u00a9\u00ab\7v\2\2\u00aa\u00a1\3\2\2\2\u00aa\u00a7"+
		"\3\2\2\2\u00ab\22\3\2\2\2\u00ac\u00ad\7-\2\2\u00ad\24\3\2\2\2\u00ae\u00af"+
		"\7/\2\2\u00af\26\3\2\2\2\u00b0\u00b1\7,\2\2\u00b1\30\3\2\2\2\u00b2\u00b3"+
		"\7\61\2\2\u00b3\32\3\2\2\2\u00b4\u00b5\7\'\2\2\u00b5\34\3\2\2\2\u00b6"+
		"\u00b7\7c\2\2\u00b7\u00b8\7p\2\2\u00b8\u00bc\7f\2\2\u00b9\u00ba\7q\2\2"+
		"\u00ba\u00bc\7t\2\2\u00bb\u00b6\3\2\2\2\u00bb\u00b9\3\2\2\2\u00bc\36\3"+
		"\2\2\2\u00bd\u00be\7@\2\2\u00be \3\2\2\2\u00bf\u00c0\7>\2\2\u00c0\"\3"+
		"\2\2\2\u00c1\u00c2\7@\2\2\u00c2\u00c3\7?\2\2\u00c3$\3\2\2\2\u00c4\u00c5"+
		"\7>\2\2\u00c5\u00c6\7?\2\2\u00c6&\3\2\2\2\u00c7\u00c8\7*\2\2\u00c8(\3"+
		"\2\2\2\u00c9\u00ca\7+\2\2\u00ca*\3\2\2\2\u00cb\u00cc\7.\2\2\u00cc,\3\2"+
		"\2\2\u00cd\u00ce\7=\2\2\u00ce.\3\2\2\2\u00cf\u00d0\7<\2\2\u00d0\60\3\2"+
		"\2\2\u00d1\u00d2\7\60\2\2\u00d2\62\3\2\2\2\u00d3\u00d4\7?\2\2\u00d4\64"+
		"\3\2\2\2\u00d5\u00d6\7k\2\2\u00d6\u00d7\7h\2\2\u00d7\66\3\2\2\2\u00d8"+
		"\u00d9\7g\2\2\u00d9\u00da\7n\2\2\u00da\u00db\7u\2\2\u00db\u00dc\7g\2\2"+
		"\u00dc8\3\2\2\2\u00dd\u00de\7?\2\2\u00de\u00e2\7?\2\2\u00df\u00e0\7#\2"+
		"\2\u00e0\u00e2\7?\2\2\u00e1\u00dd\3\2\2\2\u00e1\u00df\3\2\2\2\u00e2:\3"+
		"\2\2\2\u00e3\u00e4\7p\2\2\u00e4\u00e5\7q\2\2\u00e5\u00e6\7v\2\2\u00e6"+
		"\u00e9\7\"\2\2\u00e7\u00e9\7#\2\2\u00e8\u00e3\3\2\2\2\u00e8\u00e7\3\2"+
		"\2\2\u00e9<\3\2\2\2\u00ea\u00ec\t\2\2\2\u00eb\u00ea\3\2\2\2\u00ec\u00ed"+
		"\3\2\2\2\u00ed\u00eb\3\2\2\2\u00ed\u00ee\3\2\2\2\u00ee>\3\2\2\2\u00ef"+
		"\u00f1\t\2\2\2\u00f0\u00ef\3\2\2\2\u00f1\u00f2\3\2\2\2\u00f2\u00f0\3\2"+
		"\2\2\u00f2\u00f3\3\2\2\2\u00f3\u00f4\3\2\2\2\u00f4\u00f6\7\60\2\2\u00f5"+
		"\u00f7\t\2\2\2\u00f6\u00f5\3\2\2\2\u00f7\u00f8\3\2\2\2\u00f8\u00f6\3\2"+
		"\2\2\u00f8\u00f9\3\2\2\2\u00f9@\3\2\2\2\u00fa\u00fe\7$\2\2\u00fb\u00fd"+
		"\n\3\2\2\u00fc\u00fb\3\2\2\2\u00fd\u0100\3\2\2\2\u00fe\u00fc\3\2\2\2\u00fe"+
		"\u00ff\3\2\2\2\u00ff\u0101\3\2\2\2\u0100\u00fe\3\2\2\2\u0101\u010b\7$"+
		"\2\2\u0102\u0106\7)\2\2\u0103\u0105\n\4\2\2\u0104\u0103\3\2\2\2\u0105"+
		"\u0108\3\2\2\2\u0106\u0104\3\2\2\2\u0106\u0107\3\2\2\2\u0107\u0109\3\2"+
		"\2\2\u0108\u0106\3\2\2\2\u0109\u010b\7)\2\2\u010a\u00fa\3\2\2\2\u010a"+
		"\u0102\3\2\2\2\u010bB\3\2\2\2\u010c\u010d\7v\2\2\u010d\u010e\7t\2\2\u010e"+
		"\u010f\7w\2\2\u010f\u0116\7g\2\2\u0110\u0111\7h\2\2\u0111\u0112\7c\2\2"+
		"\u0112\u0113\7n\2\2\u0113\u0114\7u\2\2\u0114\u0116\7g\2\2\u0115\u010c"+
		"\3\2\2\2\u0115\u0110\3\2\2\2\u0116D\3\2\2\2\u0117\u0118\7p\2\2\u0118\u0119"+
		"\7w\2\2\u0119\u011a\7n\2\2\u011a\u011b\7n\2\2\u011bF\3\2\2\2\u011c\u011d"+
		"\5-\27\2\u011dH\3\2\2\2\u011e\u0122\t\5\2\2\u011f\u0121\t\6\2\2\u0120"+
		"\u011f\3\2\2\2\u0121\u0124\3\2\2\2\u0122\u0120\3\2\2\2\u0122\u0123\3\2"+
		"\2\2\u0123J\3\2\2\2\u0124\u0122\3\2\2\2\u0125\u0126\7u\2\2\u0126\u0127"+
		"\7v\2\2\u0127\u0128\7t\2\2\u0128\u0129\7k\2\2\u0129\u012a\7p\2\2\u012a"+
		"\u012b\7i\2\2\u012b\u012c\7R\2\2\u012c\u012d\7c\2\2\u012d\u012e\7t\2\2"+
		"\u012e\u012f\7c\2\2\u012f\u0145\7o\2\2\u0130\u0131\7d\2\2\u0131\u0132"+
		"\7q\2\2\u0132\u0133\7q\2\2\u0133\u0134\7n\2\2\u0134\u0135\7R\2\2\u0135"+
		"\u0136\7c\2\2\u0136\u0137\7t\2\2\u0137\u0138\7c\2\2\u0138\u0145\7o\2\2"+
		"\u0139\u013a\7e\2\2\u013a\u013b\7j\2\2\u013b\u013c\7q\2\2\u013c\u013d"+
		"\7k\2\2\u013d\u013e\7e\2\2\u013e\u013f\7g\2\2\u013f\u0140\7R\2\2\u0140"+
		"\u0141\7c\2\2\u0141\u0142\7t\2\2\u0142\u0143\7c\2\2\u0143\u0145\7o\2\2"+
		"\u0144\u0125\3\2\2\2\u0144\u0130\3\2\2\2\u0144\u0139\3\2\2\2\u0145L\3"+
		"\2\2\2\u0146\u0147\7u\2\2\u0147\u0148\7e\2\2\u0148\u0149\7t\2\2\u0149"+
		"\u014a\7k\2\2\u014a\u014b\7r\2\2\u014b\u014c\7v\2\2\u014cN\3\2\2\2\u014d"+
		"\u014e\7g\2\2\u014e\u014f\7e\2\2\u014f\u0150\7j\2\2\u0150\u0151\7q\2\2"+
		"\u0151P\3\2\2\2\u0152\u0153\6)\2\2\u0153\u015f\5U+\2\u0154\u0156\7\17"+
		"\2\2\u0155\u0154\3\2\2\2\u0155\u0156\3\2\2\2\u0156\u0157\3\2\2\2\u0157"+
		"\u015a\7\f\2\2\u0158\u015a\4\16\17\2\u0159\u0155\3\2\2\2\u0159\u0158\3"+
		"\2\2\2\u015a\u015c\3\2\2\2\u015b\u015d\5U+\2\u015c\u015b\3\2\2\2\u015c"+
		"\u015d\3\2\2\2\u015d\u015f\3\2\2\2\u015e\u0152\3\2\2\2\u015e\u0159\3\2"+
		"\2\2\u015f\u0160\3\2\2\2\u0160\u0161\b)\2\2\u0161R\3\2\2\2\u0162\u0166"+
		"\5U+\2\u0163\u0166\5W,\2\u0164\u0166\5Y-\2\u0165\u0162\3\2\2\2\u0165\u0163"+
		"\3\2\2\2\u0165\u0164\3\2\2\2\u0166\u0167\3\2\2\2\u0167\u0168\b*\3\2\u0168"+
		"T\3\2\2\2\u0169\u016b\t\7\2\2\u016a\u0169\3\2\2\2\u016b\u016c\3\2\2\2"+
		"\u016c\u016a\3\2\2\2\u016c\u016d\3\2\2\2\u016dV\3\2\2\2\u016e\u016f\7"+
		"\61\2\2\u016f\u0172\7\61\2\2\u0170\u0172\7%\2\2\u0171\u016e\3\2\2\2\u0171"+
		"\u0170\3\2\2\2\u0172\u0176\3\2\2\2\u0173\u0175\n\b\2\2\u0174\u0173\3\2"+
		"\2\2\u0175\u0178\3\2\2\2\u0176\u0174\3\2\2\2\u0176\u0177\3\2\2\2\u0177"+
		"X\3\2\2\2\u0178\u0176\3\2\2\2\u0179\u017b\7^\2\2\u017a\u017c\5U+\2\u017b"+
		"\u017a\3\2\2\2\u017b\u017c\3\2\2\2\u017c\u0182\3\2\2\2\u017d\u017f\7\17"+
		"\2\2\u017e\u017d\3\2\2\2\u017e\u017f\3\2\2\2\u017f\u0180\3\2\2\2\u0180"+
		"\u0183\7\f\2\2\u0181\u0183\4\16\17\2\u0182\u017e\3\2\2\2\u0182\u0181\3"+
		"\2\2\2\u0183Z\3\2\2\2\35\2g\u009f\u00aa\u00bb\u00e1\u00e8\u00ed\u00f2"+
		"\u00f8\u00fe\u0106\u010a\u0115\u0122\u0144\u0155\u0159\u015c\u015e\u0165"+
		"\u016c\u0171\u0176\u017b\u017e\u0182\4\3)\2\b\2\2";
	public static final ATN _ATN =
		new ATNDeserializer().deserialize(_serializedATN.toCharArray());
	static {
		_decisionToDFA = new DFA[_ATN.getNumberOfDecisions()];
		for (int i = 0; i < _ATN.getNumberOfDecisions(); i++) {
			_decisionToDFA[i] = new DFA(_ATN.getDecisionState(i), i);
		}
	}
}