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
		HANDLE_ERROR=8, WHILE=9, FUNCTION=10, RETURN=11, ADD_OP=12, SUB_OP=13, 
		MULT_OP=14, DIV_OP=15, MOD_OP=16, BOOL_OP=17, GREATER_THAN_OP=18, LESS_THAN_OP=19, 
		GREATER_THAN_EQUAL_OP=20, LESS_THAN_EQUAL_OP=21, OPEN_PAREN=22, CLOSE_PAREN=23, 
		COMMA=24, SEMICOLON=25, COLON=26, DOT=27, ASSIGN_OP=28, IF=29, ELSE=30, 
		EQUALITY=31, NOT=32, PARAM_TYPE=33, SCRIPT=34, NEWLINE=35, SKIP_=36, INTEGER=37, 
		FLOAT=38, STRING=39, BOOL=40, NULL=41, ENDLINE=42, IDENTIFIER=43;
	public static String[] channelNames = {
		"DEFAULT_TOKEN_CHANNEL", "HIDDEN"
	};

	public static String[] modeNames = {
		"DEFAULT_MODE"
	};

	private static String[] makeRuleNames() {
		return new String[] {
			"PIPELINE", "GLOBALENV", "PARAMETERS", "STAGES", "STAGE", "HANDLE_ERROR", 
			"WHILE", "FUNCTION", "RETURN", "ADD_OP", "SUB_OP", "MULT_OP", "DIV_OP", 
			"MOD_OP", "BOOL_OP", "GREATER_THAN_OP", "LESS_THAN_OP", "GREATER_THAN_EQUAL_OP", 
			"LESS_THAN_EQUAL_OP", "OPEN_PAREN", "CLOSE_PAREN", "COMMA", "SEMICOLON", 
			"COLON", "DOT", "ASSIGN_OP", "IF", "ELSE", "EQUALITY", "NOT", "PARAM_TYPE", 
			"SCRIPT", "NEWLINE", "SKIP_", "SPACES", "COMMENT", "LINE_JOINING", "INTEGER", 
			"FLOAT", "STRING", "BOOL", "NULL", "ENDLINE", "IDENTIFIER"
		};
	}
	public static final String[] ruleNames = makeRuleNames();

	private static String[] makeLiteralNames() {
		return new String[] {
			null, null, null, null, "'globalEnv'", "'parameters'", "'stages'", "'stage'", 
			"'handleError'", "'while'", null, null, "'+'", "'-'", "'*'", "'/'", "'%'", 
			null, "'>'", "'<'", "'>='", "'<='", "'('", "')'", "','", "';'", "':'", 
			"'.'", "'='", "'if'", "'else'", null, null, null, "'script'", null, null, 
			null, null, null, null, "'null'"
		};
	}
	private static final String[] _LITERAL_NAMES = makeLiteralNames();
	private static String[] makeSymbolicNames() {
		return new String[] {
			null, "INDENT", "DEDENT", "PIPELINE", "GLOBALENV", "PARAMETERS", "STAGES", 
			"STAGE", "HANDLE_ERROR", "WHILE", "FUNCTION", "RETURN", "ADD_OP", "SUB_OP", 
			"MULT_OP", "DIV_OP", "MOD_OP", "BOOL_OP", "GREATER_THAN_OP", "LESS_THAN_OP", 
			"GREATER_THAN_EQUAL_OP", "LESS_THAN_EQUAL_OP", "OPEN_PAREN", "CLOSE_PAREN", 
			"COMMA", "SEMICOLON", "COLON", "DOT", "ASSIGN_OP", "IF", "ELSE", "EQUALITY", 
			"NOT", "PARAM_TYPE", "SCRIPT", "NEWLINE", "SKIP_", "INTEGER", "FLOAT", 
			"STRING", "BOOL", "NULL", "ENDLINE", "IDENTIFIER"
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
		case 32:
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
		case 32:
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
		"\3\u608b\ua72a\u8133\ub9ed\u417c\u3be7\u7786\u5964\2-\u018b\b\1\4\2\t"+
		"\2\4\3\t\3\4\4\t\4\4\5\t\5\4\6\t\6\4\7\t\7\4\b\t\b\4\t\t\t\4\n\t\n\4\13"+
		"\t\13\4\f\t\f\4\r\t\r\4\16\t\16\4\17\t\17\4\20\t\20\4\21\t\21\4\22\t\22"+
		"\4\23\t\23\4\24\t\24\4\25\t\25\4\26\t\26\4\27\t\27\4\30\t\30\4\31\t\31"+
		"\4\32\t\32\4\33\t\33\4\34\t\34\4\35\t\35\4\36\t\36\4\37\t\37\4 \t \4!"+
		"\t!\4\"\t\"\4#\t#\4$\t$\4%\t%\4&\t&\4\'\t\'\4(\t(\4)\t)\4*\t*\4+\t+\4"+
		",\t,\4-\t-\3\2\3\2\3\2\3\2\3\2\3\2\3\2\3\2\3\2\3\2\3\2\3\2\5\2h\n\2\3"+
		"\3\3\3\3\3\3\3\3\3\3\3\3\3\3\3\3\3\3\3\3\4\3\4\3\4\3\4\3\4\3\4\3\4\3\4"+
		"\3\4\3\4\3\4\3\5\3\5\3\5\3\5\3\5\3\5\3\5\3\6\3\6\3\6\3\6\3\6\3\6\3\7\3"+
		"\7\3\7\3\7\3\7\3\7\3\7\3\7\3\7\3\7\3\7\3\7\3\b\3\b\3\b\3\b\3\b\3\b\3\t"+
		"\3\t\3\t\3\t\3\t\3\t\3\t\3\t\3\t\3\t\3\t\3\t\3\t\3\t\5\t\u00ac\n\t\3\n"+
		"\3\n\3\n\3\n\3\n\3\n\3\n\3\n\3\n\5\n\u00b7\n\n\3\13\3\13\3\f\3\f\3\r\3"+
		"\r\3\16\3\16\3\17\3\17\3\20\3\20\3\20\3\20\3\20\5\20\u00c8\n\20\3\21\3"+
		"\21\3\22\3\22\3\23\3\23\3\23\3\24\3\24\3\24\3\25\3\25\3\26\3\26\3\27\3"+
		"\27\3\30\3\30\3\31\3\31\3\32\3\32\3\33\3\33\3\34\3\34\3\34\3\35\3\35\3"+
		"\35\3\35\3\35\3\36\3\36\3\36\3\36\5\36\u00ee\n\36\3\37\3\37\3\37\3\37"+
		"\3\37\5\37\u00f5\n\37\3 \3 \3 \3 \3 \3 \3 \3 \3 \3 \3 \3 \3 \3 \3 \3 "+
		"\3 \3 \3 \3 \3 \3 \3 \3 \3 \3 \3 \3 \3 \3 \3 \5 \u0116\n \3!\3!\3!\3!"+
		"\3!\3!\3!\3\"\3\"\3\"\5\"\u0122\n\"\3\"\3\"\5\"\u0126\n\"\3\"\5\"\u0129"+
		"\n\"\5\"\u012b\n\"\3\"\3\"\3#\3#\3#\5#\u0132\n#\3#\3#\3$\6$\u0137\n$\r"+
		"$\16$\u0138\3%\3%\3%\5%\u013e\n%\3%\7%\u0141\n%\f%\16%\u0144\13%\3&\3"+
		"&\5&\u0148\n&\3&\5&\u014b\n&\3&\3&\5&\u014f\n&\3\'\6\'\u0152\n\'\r\'\16"+
		"\'\u0153\3(\6(\u0157\n(\r(\16(\u0158\3(\3(\6(\u015d\n(\r(\16(\u015e\3"+
		")\3)\7)\u0163\n)\f)\16)\u0166\13)\3)\3)\3)\7)\u016b\n)\f)\16)\u016e\13"+
		")\3)\5)\u0171\n)\3*\3*\3*\3*\3*\3*\3*\3*\3*\5*\u017c\n*\3+\3+\3+\3+\3"+
		"+\3,\3,\3-\3-\7-\u0187\n-\f-\16-\u018a\13-\2\2.\3\5\5\6\7\7\t\b\13\t\r"+
		"\n\17\13\21\f\23\r\25\16\27\17\31\20\33\21\35\22\37\23!\24#\25%\26\'\27"+
		")\30+\31-\32/\33\61\34\63\35\65\36\67\379 ;!=\"?#A$C%E&G\2I\2K\2M\'O("+
		"Q)S*U+W,Y-\3\2\t\4\2\13\13\"\"\4\2\f\f\16\17\3\2\62;\3\2$$\3\2))\5\2C"+
		"\\aac|\6\2\62;C\\aac|\2\u01a4\2\3\3\2\2\2\2\5\3\2\2\2\2\7\3\2\2\2\2\t"+
		"\3\2\2\2\2\13\3\2\2\2\2\r\3\2\2\2\2\17\3\2\2\2\2\21\3\2\2\2\2\23\3\2\2"+
		"\2\2\25\3\2\2\2\2\27\3\2\2\2\2\31\3\2\2\2\2\33\3\2\2\2\2\35\3\2\2\2\2"+
		"\37\3\2\2\2\2!\3\2\2\2\2#\3\2\2\2\2%\3\2\2\2\2\'\3\2\2\2\2)\3\2\2\2\2"+
		"+\3\2\2\2\2-\3\2\2\2\2/\3\2\2\2\2\61\3\2\2\2\2\63\3\2\2\2\2\65\3\2\2\2"+
		"\2\67\3\2\2\2\29\3\2\2\2\2;\3\2\2\2\2=\3\2\2\2\2?\3\2\2\2\2A\3\2\2\2\2"+
		"C\3\2\2\2\2E\3\2\2\2\2M\3\2\2\2\2O\3\2\2\2\2Q\3\2\2\2\2S\3\2\2\2\2U\3"+
		"\2\2\2\2W\3\2\2\2\2Y\3\2\2\2\3g\3\2\2\2\5i\3\2\2\2\7s\3\2\2\2\t~\3\2\2"+
		"\2\13\u0085\3\2\2\2\r\u008b\3\2\2\2\17\u0097\3\2\2\2\21\u00ab\3\2\2\2"+
		"\23\u00b6\3\2\2\2\25\u00b8\3\2\2\2\27\u00ba\3\2\2\2\31\u00bc\3\2\2\2\33"+
		"\u00be\3\2\2\2\35\u00c0\3\2\2\2\37\u00c7\3\2\2\2!\u00c9\3\2\2\2#\u00cb"+
		"\3\2\2\2%\u00cd\3\2\2\2\'\u00d0\3\2\2\2)\u00d3\3\2\2\2+\u00d5\3\2\2\2"+
		"-\u00d7\3\2\2\2/\u00d9\3\2\2\2\61\u00db\3\2\2\2\63\u00dd\3\2\2\2\65\u00df"+
		"\3\2\2\2\67\u00e1\3\2\2\29\u00e4\3\2\2\2;\u00ed\3\2\2\2=\u00f4\3\2\2\2"+
		"?\u0115\3\2\2\2A\u0117\3\2\2\2C\u012a\3\2\2\2E\u0131\3\2\2\2G\u0136\3"+
		"\2\2\2I\u013d\3\2\2\2K\u0145\3\2\2\2M\u0151\3\2\2\2O\u0156\3\2\2\2Q\u0170"+
		"\3\2\2\2S\u017b\3\2\2\2U\u017d\3\2\2\2W\u0182\3\2\2\2Y\u0184\3\2\2\2["+
		"\\\7r\2\2\\]\7k\2\2]^\7r\2\2^_\7g\2\2_`\7n\2\2`a\7k\2\2ab\7p\2\2bh\7g"+
		"\2\2cd\7r\2\2de\7k\2\2ef\7r\2\2fh\7g\2\2g[\3\2\2\2gc\3\2\2\2h\4\3\2\2"+
		"\2ij\7i\2\2jk\7n\2\2kl\7q\2\2lm\7d\2\2mn\7c\2\2no\7n\2\2op\7G\2\2pq\7"+
		"p\2\2qr\7x\2\2r\6\3\2\2\2st\7r\2\2tu\7c\2\2uv\7t\2\2vw\7c\2\2wx\7o\2\2"+
		"xy\7g\2\2yz\7v\2\2z{\7g\2\2{|\7t\2\2|}\7u\2\2}\b\3\2\2\2~\177\7u\2\2\177"+
		"\u0080\7v\2\2\u0080\u0081\7c\2\2\u0081\u0082\7i\2\2\u0082\u0083\7g\2\2"+
		"\u0083\u0084\7u\2\2\u0084\n\3\2\2\2\u0085\u0086\7u\2\2\u0086\u0087\7v"+
		"\2\2\u0087\u0088\7c\2\2\u0088\u0089\7i\2\2\u0089\u008a\7g\2\2\u008a\f"+
		"\3\2\2\2\u008b\u008c\7j\2\2\u008c\u008d\7c\2\2\u008d\u008e\7p\2\2\u008e"+
		"\u008f\7f\2\2\u008f\u0090\7n\2\2\u0090\u0091\7g\2\2\u0091\u0092\7G\2\2"+
		"\u0092\u0093\7t\2\2\u0093\u0094\7t\2\2\u0094\u0095\7q\2\2\u0095\u0096"+
		"\7t\2\2\u0096\16\3\2\2\2\u0097\u0098\7y\2\2\u0098\u0099\7j\2\2\u0099\u009a"+
		"\7k\2\2\u009a\u009b\7n\2\2\u009b\u009c\7g\2\2\u009c\20\3\2\2\2\u009d\u009e"+
		"\7h\2\2\u009e\u009f\7w\2\2\u009f\u00ac\7p\2\2\u00a0\u00a1\7f\2\2\u00a1"+
		"\u00a2\7g\2\2\u00a2\u00ac\7h\2\2\u00a3\u00a4\7h\2\2\u00a4\u00a5\7w\2\2"+
		"\u00a5\u00a6\7p\2\2\u00a6\u00a7\7e\2\2\u00a7\u00a8\7v\2\2\u00a8\u00a9"+
		"\7k\2\2\u00a9\u00aa\7q\2\2\u00aa\u00ac\7p\2\2\u00ab\u009d\3\2\2\2\u00ab"+
		"\u00a0\3\2\2\2\u00ab\u00a3\3\2\2\2\u00ac\22\3\2\2\2\u00ad\u00ae\7t\2\2"+
		"\u00ae\u00af\7g\2\2\u00af\u00b0\7v\2\2\u00b0\u00b1\7w\2\2\u00b1\u00b2"+
		"\7t\2\2\u00b2\u00b7\7p\2\2\u00b3\u00b4\7t\2\2\u00b4\u00b5\7g\2\2\u00b5"+
		"\u00b7\7v\2\2\u00b6\u00ad\3\2\2\2\u00b6\u00b3\3\2\2\2\u00b7\24\3\2\2\2"+
		"\u00b8\u00b9\7-\2\2\u00b9\26\3\2\2\2\u00ba\u00bb\7/\2\2\u00bb\30\3\2\2"+
		"\2\u00bc\u00bd\7,\2\2\u00bd\32\3\2\2\2\u00be\u00bf\7\61\2\2\u00bf\34\3"+
		"\2\2\2\u00c0\u00c1\7\'\2\2\u00c1\36\3\2\2\2\u00c2\u00c3\7c\2\2\u00c3\u00c4"+
		"\7p\2\2\u00c4\u00c8\7f\2\2\u00c5\u00c6\7q\2\2\u00c6\u00c8\7t\2\2\u00c7"+
		"\u00c2\3\2\2\2\u00c7\u00c5\3\2\2\2\u00c8 \3\2\2\2\u00c9\u00ca\7@\2\2\u00ca"+
		"\"\3\2\2\2\u00cb\u00cc\7>\2\2\u00cc$\3\2\2\2\u00cd\u00ce\7@\2\2\u00ce"+
		"\u00cf\7?\2\2\u00cf&\3\2\2\2\u00d0\u00d1\7>\2\2\u00d1\u00d2\7?\2\2\u00d2"+
		"(\3\2\2\2\u00d3\u00d4\7*\2\2\u00d4*\3\2\2\2\u00d5\u00d6\7+\2\2\u00d6,"+
		"\3\2\2\2\u00d7\u00d8\7.\2\2\u00d8.\3\2\2\2\u00d9\u00da\7=\2\2\u00da\60"+
		"\3\2\2\2\u00db\u00dc\7<\2\2\u00dc\62\3\2\2\2\u00dd\u00de\7\60\2\2\u00de"+
		"\64\3\2\2\2\u00df\u00e0\7?\2\2\u00e0\66\3\2\2\2\u00e1\u00e2\7k\2\2\u00e2"+
		"\u00e3\7h\2\2\u00e38\3\2\2\2\u00e4\u00e5\7g\2\2\u00e5\u00e6\7n\2\2\u00e6"+
		"\u00e7\7u\2\2\u00e7\u00e8\7g\2\2\u00e8:\3\2\2\2\u00e9\u00ea\7?\2\2\u00ea"+
		"\u00ee\7?\2\2\u00eb\u00ec\7#\2\2\u00ec\u00ee\7?\2\2\u00ed\u00e9\3\2\2"+
		"\2\u00ed\u00eb\3\2\2\2\u00ee<\3\2\2\2\u00ef\u00f0\7p\2\2\u00f0\u00f1\7"+
		"q\2\2\u00f1\u00f2\7v\2\2\u00f2\u00f5\7\"\2\2\u00f3\u00f5\7#\2\2\u00f4"+
		"\u00ef\3\2\2\2\u00f4\u00f3\3\2\2\2\u00f5>\3\2\2\2\u00f6\u00f7\7u\2\2\u00f7"+
		"\u00f8\7v\2\2\u00f8\u00f9\7t\2\2\u00f9\u00fa\7k\2\2\u00fa\u00fb\7p\2\2"+
		"\u00fb\u00fc\7i\2\2\u00fc\u00fd\7R\2\2\u00fd\u00fe\7c\2\2\u00fe\u00ff"+
		"\7t\2\2\u00ff\u0100\7c\2\2\u0100\u0116\7o\2\2\u0101\u0102\7d\2\2\u0102"+
		"\u0103\7q\2\2\u0103\u0104\7q\2\2\u0104\u0105\7n\2\2\u0105\u0106\7R\2\2"+
		"\u0106\u0107\7c\2\2\u0107\u0108\7t\2\2\u0108\u0109\7c\2\2\u0109\u0116"+
		"\7o\2\2\u010a\u010b\7e\2\2\u010b\u010c\7j\2\2\u010c\u010d\7q\2\2\u010d"+
		"\u010e\7k\2\2\u010e\u010f\7e\2\2\u010f\u0110\7g\2\2\u0110\u0111\7R\2\2"+
		"\u0111\u0112\7c\2\2\u0112\u0113\7t\2\2\u0113\u0114\7c\2\2\u0114\u0116"+
		"\7o\2\2\u0115\u00f6\3\2\2\2\u0115\u0101\3\2\2\2\u0115\u010a\3\2\2\2\u0116"+
		"@\3\2\2\2\u0117\u0118\7u\2\2\u0118\u0119\7e\2\2\u0119\u011a\7t\2\2\u011a"+
		"\u011b\7k\2\2\u011b\u011c\7r\2\2\u011c\u011d\7v\2\2\u011dB\3\2\2\2\u011e"+
		"\u011f\6\"\2\2\u011f\u012b\5G$\2\u0120\u0122\7\17\2\2\u0121\u0120\3\2"+
		"\2\2\u0121\u0122\3\2\2\2\u0122\u0123\3\2\2\2\u0123\u0126\7\f\2\2\u0124"+
		"\u0126\4\16\17\2\u0125\u0121\3\2\2\2\u0125\u0124\3\2\2\2\u0126\u0128\3"+
		"\2\2\2\u0127\u0129\5G$\2\u0128\u0127\3\2\2\2\u0128\u0129\3\2\2\2\u0129"+
		"\u012b\3\2\2\2\u012a\u011e\3\2\2\2\u012a\u0125\3\2\2\2\u012b\u012c\3\2"+
		"\2\2\u012c\u012d\b\"\2\2\u012dD\3\2\2\2\u012e\u0132\5G$\2\u012f\u0132"+
		"\5I%\2\u0130\u0132\5K&\2\u0131\u012e\3\2\2\2\u0131\u012f\3\2\2\2\u0131"+
		"\u0130\3\2\2\2\u0132\u0133\3\2\2\2\u0133\u0134\b#\3\2\u0134F\3\2\2\2\u0135"+
		"\u0137\t\2\2\2\u0136\u0135\3\2\2\2\u0137\u0138\3\2\2\2\u0138\u0136\3\2"+
		"\2\2\u0138\u0139\3\2\2\2\u0139H\3\2\2\2\u013a\u013b\7\61\2\2\u013b\u013e"+
		"\7\61\2\2\u013c\u013e\7%\2\2\u013d\u013a\3\2\2\2\u013d\u013c\3\2\2\2\u013e"+
		"\u0142\3\2\2\2\u013f\u0141\n\3\2\2\u0140\u013f\3\2\2\2\u0141\u0144\3\2"+
		"\2\2\u0142\u0140\3\2\2\2\u0142\u0143\3\2\2\2\u0143J\3\2\2\2\u0144\u0142"+
		"\3\2\2\2\u0145\u0147\7^\2\2\u0146\u0148\5G$\2\u0147\u0146\3\2\2\2\u0147"+
		"\u0148\3\2\2\2\u0148\u014e\3\2\2\2\u0149\u014b\7\17\2\2\u014a\u0149\3"+
		"\2\2\2\u014a\u014b\3\2\2\2\u014b\u014c\3\2\2\2\u014c\u014f\7\f\2\2\u014d"+
		"\u014f\4\16\17\2\u014e\u014a\3\2\2\2\u014e\u014d\3\2\2\2\u014fL\3\2\2"+
		"\2\u0150\u0152\t\4\2\2\u0151\u0150\3\2\2\2\u0152\u0153\3\2\2\2\u0153\u0151"+
		"\3\2\2\2\u0153\u0154\3\2\2\2\u0154N\3\2\2\2\u0155\u0157\t\4\2\2\u0156"+
		"\u0155\3\2\2\2\u0157\u0158\3\2\2\2\u0158\u0156\3\2\2\2\u0158\u0159\3\2"+
		"\2\2\u0159\u015a\3\2\2\2\u015a\u015c\7\60\2\2\u015b\u015d\t\4\2\2\u015c"+
		"\u015b\3\2\2\2\u015d\u015e\3\2\2\2\u015e\u015c\3\2\2\2\u015e\u015f\3\2"+
		"\2\2\u015fP\3\2\2\2\u0160\u0164\7$\2\2\u0161\u0163\n\5\2\2\u0162\u0161"+
		"\3\2\2\2\u0163\u0166\3\2\2\2\u0164\u0162\3\2\2\2\u0164\u0165\3\2\2\2\u0165"+
		"\u0167\3\2\2\2\u0166\u0164\3\2\2\2\u0167\u0171\7$\2\2\u0168\u016c\7)\2"+
		"\2\u0169\u016b\n\6\2\2\u016a\u0169\3\2\2\2\u016b\u016e\3\2\2\2\u016c\u016a"+
		"\3\2\2\2\u016c\u016d\3\2\2\2\u016d\u016f\3\2\2\2\u016e\u016c\3\2\2\2\u016f"+
		"\u0171\7)\2\2\u0170\u0160\3\2\2\2\u0170\u0168\3\2\2\2\u0171R\3\2\2\2\u0172"+
		"\u0173\7v\2\2\u0173\u0174\7t\2\2\u0174\u0175\7w\2\2\u0175\u017c\7g\2\2"+
		"\u0176\u0177\7h\2\2\u0177\u0178\7c\2\2\u0178\u0179\7n\2\2\u0179\u017a"+
		"\7u\2\2\u017a\u017c\7g\2\2\u017b\u0172\3\2\2\2\u017b\u0176\3\2\2\2\u017c"+
		"T\3\2\2\2\u017d\u017e\7p\2\2\u017e\u017f\7w\2\2\u017f\u0180\7n\2\2\u0180"+
		"\u0181\7n\2\2\u0181V\3\2\2\2\u0182\u0183\5/\30\2\u0183X\3\2\2\2\u0184"+
		"\u0188\t\7\2\2\u0185\u0187\t\b\2\2\u0186\u0185\3\2\2\2\u0187\u018a\3\2"+
		"\2\2\u0188\u0186\3\2\2\2\u0188\u0189\3\2\2\2\u0189Z\3\2\2\2\u018a\u0188"+
		"\3\2\2\2\35\2g\u00ab\u00b6\u00c7\u00ed\u00f4\u0115\u0121\u0125\u0128\u012a"+
		"\u0131\u0138\u013d\u0142\u0147\u014a\u014e\u0153\u0158\u015e\u0164\u016c"+
		"\u0170\u017b\u0188\4\3\"\2\b\2\2";
	public static final ATN _ATN =
		new ATNDeserializer().deserialize(_serializedATN.toCharArray());
	static {
		_decisionToDFA = new DFA[_ATN.getNumberOfDecisions()];
		for (int i = 0; i < _ATN.getNumberOfDecisions(); i++) {
			_decisionToDFA[i] = new DFA(_ATN.getDecisionState(i), i);
		}
	}
}