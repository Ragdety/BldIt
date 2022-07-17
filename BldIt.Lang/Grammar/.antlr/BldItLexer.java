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
		WHILE=8, FUNCTION=9, ADD_OP=10, SUB_OP=11, MULT_OP=12, DIV_OP=13, MOD_OP=14, 
		BOOL_OP=15, GREATER_THAN_OP=16, LESS_THAN_OP=17, GREATER_THAN_EQUAL_OP=18, 
		LESS_THAN_EQUAL_OP=19, OPEN_PAREN=20, CLOSE_PAREN=21, COMMA=22, SEMICOLON=23, 
		COLON=24, DOT=25, ASSIGN_OP=26, IF=27, ELSE=28, EQUALITY=29, NOT=30, INTEGER=31, 
		FLOAT=32, STRING=33, BOOL=34, NULL=35, ENDLINE=36, IDENTIFIER=37, NEWLINE=38, 
		SKIP_=39;
	public static String[] channelNames = {
		"DEFAULT_TOKEN_CHANNEL", "HIDDEN"
	};

	public static String[] modeNames = {
		"DEFAULT_MODE"
	};

	private static String[] makeRuleNames() {
		return new String[] {
			"PIPELINE", "GLOBALENV", "PARAMETERS", "STAGES", "STAGE", "WHILE", "FUNCTION", 
			"ADD_OP", "SUB_OP", "MULT_OP", "DIV_OP", "MOD_OP", "BOOL_OP", "GREATER_THAN_OP", 
			"LESS_THAN_OP", "GREATER_THAN_EQUAL_OP", "LESS_THAN_EQUAL_OP", "OPEN_PAREN", 
			"CLOSE_PAREN", "COMMA", "SEMICOLON", "COLON", "DOT", "ASSIGN_OP", "IF", 
			"ELSE", "EQUALITY", "NOT", "INTEGER", "FLOAT", "STRING", "BOOL", "NULL", 
			"ENDLINE", "IDENTIFIER", "NEWLINE", "SKIP_", "SPACES", "COMMENT", "LINE_JOINING"
		};
	}
	public static final String[] ruleNames = makeRuleNames();

	private static String[] makeLiteralNames() {
		return new String[] {
			null, null, null, null, "'globalEnv'", "'parameters'", "'stages'", "'stage'", 
			"'while'", null, "'+'", "'-'", "'*'", "'/'", "'%'", null, "'>'", "'<'", 
			"'>='", "'<='", "'('", "')'", "','", "';'", "':'", "'.'", "'='", "'if'", 
			"'else'", null, null, null, null, null, null, "'null'"
		};
	}
	private static final String[] _LITERAL_NAMES = makeLiteralNames();
	private static String[] makeSymbolicNames() {
		return new String[] {
			null, "INDENT", "DEDENT", "PIPELINE", "GLOBALENV", "PARAMETERS", "STAGES", 
			"STAGE", "WHILE", "FUNCTION", "ADD_OP", "SUB_OP", "MULT_OP", "DIV_OP", 
			"MOD_OP", "BOOL_OP", "GREATER_THAN_OP", "LESS_THAN_OP", "GREATER_THAN_EQUAL_OP", 
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
		case 35:
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
		case 35:
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
		"\3\u608b\ua72a\u8133\ub9ed\u417c\u3be7\u7786\u5964\2)\u0144\b\1\4\2\t"+
		"\2\4\3\t\3\4\4\t\4\4\5\t\5\4\6\t\6\4\7\t\7\4\b\t\b\4\t\t\t\4\n\t\n\4\13"+
		"\t\13\4\f\t\f\4\r\t\r\4\16\t\16\4\17\t\17\4\20\t\20\4\21\t\21\4\22\t\22"+
		"\4\23\t\23\4\24\t\24\4\25\t\25\4\26\t\26\4\27\t\27\4\30\t\30\4\31\t\31"+
		"\4\32\t\32\4\33\t\33\4\34\t\34\4\35\t\35\4\36\t\36\4\37\t\37\4 \t \4!"+
		"\t!\4\"\t\"\4#\t#\4$\t$\4%\t%\4&\t&\4\'\t\'\4(\t(\4)\t)\3\2\3\2\3\2\3"+
		"\2\3\2\3\2\3\2\3\2\3\2\3\2\3\2\3\2\5\2`\n\2\3\3\3\3\3\3\3\3\3\3\3\3\3"+
		"\3\3\3\3\3\3\3\3\4\3\4\3\4\3\4\3\4\3\4\3\4\3\4\3\4\3\4\3\4\3\5\3\5\3\5"+
		"\3\5\3\5\3\5\3\5\3\6\3\6\3\6\3\6\3\6\3\6\3\7\3\7\3\7\3\7\3\7\3\7\3\b\3"+
		"\b\3\b\3\b\3\b\3\b\3\b\3\b\3\b\3\b\3\b\3\b\3\b\3\b\5\b\u0098\n\b\3\t\3"+
		"\t\3\n\3\n\3\13\3\13\3\f\3\f\3\r\3\r\3\16\3\16\3\16\3\16\3\16\5\16\u00a9"+
		"\n\16\3\17\3\17\3\20\3\20\3\21\3\21\3\21\3\22\3\22\3\22\3\23\3\23\3\24"+
		"\3\24\3\25\3\25\3\26\3\26\3\27\3\27\3\30\3\30\3\31\3\31\3\32\3\32\3\32"+
		"\3\33\3\33\3\33\3\33\3\33\3\34\3\34\3\34\3\34\5\34\u00cf\n\34\3\35\3\35"+
		"\3\35\3\35\3\35\5\35\u00d6\n\35\3\36\6\36\u00d9\n\36\r\36\16\36\u00da"+
		"\3\37\6\37\u00de\n\37\r\37\16\37\u00df\3\37\3\37\6\37\u00e4\n\37\r\37"+
		"\16\37\u00e5\3 \3 \7 \u00ea\n \f \16 \u00ed\13 \3 \3 \3 \7 \u00f2\n \f"+
		" \16 \u00f5\13 \3 \5 \u00f8\n \3!\3!\3!\3!\3!\3!\3!\3!\3!\5!\u0103\n!"+
		"\3\"\3\"\3\"\3\"\3\"\3#\3#\3$\3$\7$\u010e\n$\f$\16$\u0111\13$\3%\3%\3"+
		"%\5%\u0116\n%\3%\3%\5%\u011a\n%\3%\5%\u011d\n%\5%\u011f\n%\3%\3%\3&\3"+
		"&\3&\5&\u0126\n&\3&\3&\3\'\6\'\u012b\n\'\r\'\16\'\u012c\3(\3(\3(\5(\u0132"+
		"\n(\3(\7(\u0135\n(\f(\16(\u0138\13(\3)\3)\5)\u013c\n)\3)\5)\u013f\n)\3"+
		")\3)\5)\u0143\n)\2\2*\3\5\5\6\7\7\t\b\13\t\r\n\17\13\21\f\23\r\25\16\27"+
		"\17\31\20\33\21\35\22\37\23!\24#\25%\26\'\27)\30+\31-\32/\33\61\34\63"+
		"\35\65\36\67\379 ;!=\"?#A$C%E&G\'I(K)M\2O\2Q\2\3\2\t\3\2\62;\3\2$$\3\2"+
		"))\5\2C\\aac|\6\2\62;C\\aac|\4\2\13\13\"\"\4\2\f\f\16\17\2\u015a\2\3\3"+
		"\2\2\2\2\5\3\2\2\2\2\7\3\2\2\2\2\t\3\2\2\2\2\13\3\2\2\2\2\r\3\2\2\2\2"+
		"\17\3\2\2\2\2\21\3\2\2\2\2\23\3\2\2\2\2\25\3\2\2\2\2\27\3\2\2\2\2\31\3"+
		"\2\2\2\2\33\3\2\2\2\2\35\3\2\2\2\2\37\3\2\2\2\2!\3\2\2\2\2#\3\2\2\2\2"+
		"%\3\2\2\2\2\'\3\2\2\2\2)\3\2\2\2\2+\3\2\2\2\2-\3\2\2\2\2/\3\2\2\2\2\61"+
		"\3\2\2\2\2\63\3\2\2\2\2\65\3\2\2\2\2\67\3\2\2\2\29\3\2\2\2\2;\3\2\2\2"+
		"\2=\3\2\2\2\2?\3\2\2\2\2A\3\2\2\2\2C\3\2\2\2\2E\3\2\2\2\2G\3\2\2\2\2I"+
		"\3\2\2\2\2K\3\2\2\2\3_\3\2\2\2\5a\3\2\2\2\7k\3\2\2\2\tv\3\2\2\2\13}\3"+
		"\2\2\2\r\u0083\3\2\2\2\17\u0097\3\2\2\2\21\u0099\3\2\2\2\23\u009b\3\2"+
		"\2\2\25\u009d\3\2\2\2\27\u009f\3\2\2\2\31\u00a1\3\2\2\2\33\u00a8\3\2\2"+
		"\2\35\u00aa\3\2\2\2\37\u00ac\3\2\2\2!\u00ae\3\2\2\2#\u00b1\3\2\2\2%\u00b4"+
		"\3\2\2\2\'\u00b6\3\2\2\2)\u00b8\3\2\2\2+\u00ba\3\2\2\2-\u00bc\3\2\2\2"+
		"/\u00be\3\2\2\2\61\u00c0\3\2\2\2\63\u00c2\3\2\2\2\65\u00c5\3\2\2\2\67"+
		"\u00ce\3\2\2\29\u00d5\3\2\2\2;\u00d8\3\2\2\2=\u00dd\3\2\2\2?\u00f7\3\2"+
		"\2\2A\u0102\3\2\2\2C\u0104\3\2\2\2E\u0109\3\2\2\2G\u010b\3\2\2\2I\u011e"+
		"\3\2\2\2K\u0125\3\2\2\2M\u012a\3\2\2\2O\u0131\3\2\2\2Q\u0139\3\2\2\2S"+
		"T\7r\2\2TU\7k\2\2UV\7r\2\2VW\7g\2\2WX\7n\2\2XY\7k\2\2YZ\7p\2\2Z`\7g\2"+
		"\2[\\\7r\2\2\\]\7k\2\2]^\7r\2\2^`\7g\2\2_S\3\2\2\2_[\3\2\2\2`\4\3\2\2"+
		"\2ab\7i\2\2bc\7n\2\2cd\7q\2\2de\7d\2\2ef\7c\2\2fg\7n\2\2gh\7G\2\2hi\7"+
		"p\2\2ij\7x\2\2j\6\3\2\2\2kl\7r\2\2lm\7c\2\2mn\7t\2\2no\7c\2\2op\7o\2\2"+
		"pq\7g\2\2qr\7v\2\2rs\7g\2\2st\7t\2\2tu\7u\2\2u\b\3\2\2\2vw\7u\2\2wx\7"+
		"v\2\2xy\7c\2\2yz\7i\2\2z{\7g\2\2{|\7u\2\2|\n\3\2\2\2}~\7u\2\2~\177\7v"+
		"\2\2\177\u0080\7c\2\2\u0080\u0081\7i\2\2\u0081\u0082\7g\2\2\u0082\f\3"+
		"\2\2\2\u0083\u0084\7y\2\2\u0084\u0085\7j\2\2\u0085\u0086\7k\2\2\u0086"+
		"\u0087\7n\2\2\u0087\u0088\7g\2\2\u0088\16\3\2\2\2\u0089\u008a\7h\2\2\u008a"+
		"\u008b\7w\2\2\u008b\u0098\7p\2\2\u008c\u008d\7f\2\2\u008d\u008e\7g\2\2"+
		"\u008e\u0098\7h\2\2\u008f\u0090\7h\2\2\u0090\u0091\7w\2\2\u0091\u0092"+
		"\7p\2\2\u0092\u0093\7e\2\2\u0093\u0094\7v\2\2\u0094\u0095\7k\2\2\u0095"+
		"\u0096\7q\2\2\u0096\u0098\7p\2\2\u0097\u0089\3\2\2\2\u0097\u008c\3\2\2"+
		"\2\u0097\u008f\3\2\2\2\u0098\20\3\2\2\2\u0099\u009a\7-\2\2\u009a\22\3"+
		"\2\2\2\u009b\u009c\7/\2\2\u009c\24\3\2\2\2\u009d\u009e\7,\2\2\u009e\26"+
		"\3\2\2\2\u009f\u00a0\7\61\2\2\u00a0\30\3\2\2\2\u00a1\u00a2\7\'\2\2\u00a2"+
		"\32\3\2\2\2\u00a3\u00a4\7c\2\2\u00a4\u00a5\7p\2\2\u00a5\u00a9\7f\2\2\u00a6"+
		"\u00a7\7q\2\2\u00a7\u00a9\7t\2\2\u00a8\u00a3\3\2\2\2\u00a8\u00a6\3\2\2"+
		"\2\u00a9\34\3\2\2\2\u00aa\u00ab\7@\2\2\u00ab\36\3\2\2\2\u00ac\u00ad\7"+
		">\2\2\u00ad \3\2\2\2\u00ae\u00af\7@\2\2\u00af\u00b0\7?\2\2\u00b0\"\3\2"+
		"\2\2\u00b1\u00b2\7>\2\2\u00b2\u00b3\7?\2\2\u00b3$\3\2\2\2\u00b4\u00b5"+
		"\7*\2\2\u00b5&\3\2\2\2\u00b6\u00b7\7+\2\2\u00b7(\3\2\2\2\u00b8\u00b9\7"+
		".\2\2\u00b9*\3\2\2\2\u00ba\u00bb\7=\2\2\u00bb,\3\2\2\2\u00bc\u00bd\7<"+
		"\2\2\u00bd.\3\2\2\2\u00be\u00bf\7\60\2\2\u00bf\60\3\2\2\2\u00c0\u00c1"+
		"\7?\2\2\u00c1\62\3\2\2\2\u00c2\u00c3\7k\2\2\u00c3\u00c4\7h\2\2\u00c4\64"+
		"\3\2\2\2\u00c5\u00c6\7g\2\2\u00c6\u00c7\7n\2\2\u00c7\u00c8\7u\2\2\u00c8"+
		"\u00c9\7g\2\2\u00c9\66\3\2\2\2\u00ca\u00cb\7?\2\2\u00cb\u00cf\7?\2\2\u00cc"+
		"\u00cd\7#\2\2\u00cd\u00cf\7?\2\2\u00ce\u00ca\3\2\2\2\u00ce\u00cc\3\2\2"+
		"\2\u00cf8\3\2\2\2\u00d0\u00d1\7p\2\2\u00d1\u00d2\7q\2\2\u00d2\u00d3\7"+
		"v\2\2\u00d3\u00d6\7\"\2\2\u00d4\u00d6\7#\2\2\u00d5\u00d0\3\2\2\2\u00d5"+
		"\u00d4\3\2\2\2\u00d6:\3\2\2\2\u00d7\u00d9\t\2\2\2\u00d8\u00d7\3\2\2\2"+
		"\u00d9\u00da\3\2\2\2\u00da\u00d8\3\2\2\2\u00da\u00db\3\2\2\2\u00db<\3"+
		"\2\2\2\u00dc\u00de\t\2\2\2\u00dd\u00dc\3\2\2\2\u00de\u00df\3\2\2\2\u00df"+
		"\u00dd\3\2\2\2\u00df\u00e0\3\2\2\2\u00e0\u00e1\3\2\2\2\u00e1\u00e3\7\60"+
		"\2\2\u00e2\u00e4\t\2\2\2\u00e3\u00e2\3\2\2\2\u00e4\u00e5\3\2\2\2\u00e5"+
		"\u00e3\3\2\2\2\u00e5\u00e6\3\2\2\2\u00e6>\3\2\2\2\u00e7\u00eb\7$\2\2\u00e8"+
		"\u00ea\n\3\2\2\u00e9\u00e8\3\2\2\2\u00ea\u00ed\3\2\2\2\u00eb\u00e9\3\2"+
		"\2\2\u00eb\u00ec\3\2\2\2\u00ec\u00ee\3\2\2\2\u00ed\u00eb\3\2\2\2\u00ee"+
		"\u00f8\7$\2\2\u00ef\u00f3\7)\2\2\u00f0\u00f2\n\4\2\2\u00f1\u00f0\3\2\2"+
		"\2\u00f2\u00f5\3\2\2\2\u00f3\u00f1\3\2\2\2\u00f3\u00f4\3\2\2\2\u00f4\u00f6"+
		"\3\2\2\2\u00f5\u00f3\3\2\2\2\u00f6\u00f8\7)\2\2\u00f7\u00e7\3\2\2\2\u00f7"+
		"\u00ef\3\2\2\2\u00f8@\3\2\2\2\u00f9\u00fa\7v\2\2\u00fa\u00fb\7t\2\2\u00fb"+
		"\u00fc\7w\2\2\u00fc\u0103\7g\2\2\u00fd\u00fe\7h\2\2\u00fe\u00ff\7c\2\2"+
		"\u00ff\u0100\7n\2\2\u0100\u0101\7u\2\2\u0101\u0103\7g\2\2\u0102\u00f9"+
		"\3\2\2\2\u0102\u00fd\3\2\2\2\u0103B\3\2\2\2\u0104\u0105\7p\2\2\u0105\u0106"+
		"\7w\2\2\u0106\u0107\7n\2\2\u0107\u0108\7n\2\2\u0108D\3\2\2\2\u0109\u010a"+
		"\5+\26\2\u010aF\3\2\2\2\u010b\u010f\t\5\2\2\u010c\u010e\t\6\2\2\u010d"+
		"\u010c\3\2\2\2\u010e\u0111\3\2\2\2\u010f\u010d\3\2\2\2\u010f\u0110\3\2"+
		"\2\2\u0110H\3\2\2\2\u0111\u010f\3\2\2\2\u0112\u0113\6%\2\2\u0113\u011f"+
		"\5M\'\2\u0114\u0116\7\17\2\2\u0115\u0114\3\2\2\2\u0115\u0116\3\2\2\2\u0116"+
		"\u0117\3\2\2\2\u0117\u011a\7\f\2\2\u0118\u011a\4\16\17\2\u0119\u0115\3"+
		"\2\2\2\u0119\u0118\3\2\2\2\u011a\u011c\3\2\2\2\u011b\u011d\5M\'\2\u011c"+
		"\u011b\3\2\2\2\u011c\u011d\3\2\2\2\u011d\u011f\3\2\2\2\u011e\u0112\3\2"+
		"\2\2\u011e\u0119\3\2\2\2\u011f\u0120\3\2\2\2\u0120\u0121\b%\2\2\u0121"+
		"J\3\2\2\2\u0122\u0126\5M\'\2\u0123\u0126\5O(\2\u0124\u0126\5Q)\2\u0125"+
		"\u0122\3\2\2\2\u0125\u0123\3\2\2\2\u0125\u0124\3\2\2\2\u0126\u0127\3\2"+
		"\2\2\u0127\u0128\b&\3\2\u0128L\3\2\2\2\u0129\u012b\t\7\2\2\u012a\u0129"+
		"\3\2\2\2\u012b\u012c\3\2\2\2\u012c\u012a\3\2\2\2\u012c\u012d\3\2\2\2\u012d"+
		"N\3\2\2\2\u012e\u012f\7\61\2\2\u012f\u0132\7\61\2\2\u0130\u0132\7%\2\2"+
		"\u0131\u012e\3\2\2\2\u0131\u0130\3\2\2\2\u0132\u0136\3\2\2\2\u0133\u0135"+
		"\n\b\2\2\u0134\u0133\3\2\2\2\u0135\u0138\3\2\2\2\u0136\u0134\3\2\2\2\u0136"+
		"\u0137\3\2\2\2\u0137P\3\2\2\2\u0138\u0136\3\2\2\2\u0139\u013b\7^\2\2\u013a"+
		"\u013c\5M\'\2\u013b\u013a\3\2\2\2\u013b\u013c\3\2\2\2\u013c\u0142\3\2"+
		"\2\2\u013d\u013f\7\17\2\2\u013e\u013d\3\2\2\2\u013e\u013f\3\2\2\2\u013f"+
		"\u0140\3\2\2\2\u0140\u0143\7\f\2\2\u0141\u0143\4\16\17\2\u0142\u013e\3"+
		"\2\2\2\u0142\u0141\3\2\2\2\u0143R\3\2\2\2\33\2_\u0097\u00a8\u00ce\u00d5"+
		"\u00da\u00df\u00e5\u00eb\u00f3\u00f7\u0102\u010f\u0115\u0119\u011c\u011e"+
		"\u0125\u012c\u0131\u0136\u013b\u013e\u0142\4\3%\2\b\2\2";
	public static final ATN _ATN =
		new ATNDeserializer().deserialize(_serializedATN.toCharArray());
	static {
		_decisionToDFA = new DFA[_ATN.getNumberOfDecisions()];
		for (int i = 0; i < _ATN.getNumberOfDecisions(); i++) {
			_decisionToDFA[i] = new DFA(_ATN.getDecisionState(i), i);
		}
	}
}