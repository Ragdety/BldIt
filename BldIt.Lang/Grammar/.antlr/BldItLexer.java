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
		FLOAT=33, STRING=34, BOOL=35, NULL=36, ENDLINE=37, IDENTIFIER=38, NEWLINE=39, 
		SKIP_=40;
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
			"NULL", "ENDLINE", "IDENTIFIER", "NEWLINE", "SKIP_", "SPACES", "COMMENT", 
			"LINE_JOINING"
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
		case 36:
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
		case 36:
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
		"\3\u608b\ua72a\u8133\ub9ed\u417c\u3be7\u7786\u5964\2*\u0151\b\1\4\2\t"+
		"\2\4\3\t\3\4\4\t\4\4\5\t\5\4\6\t\6\4\7\t\7\4\b\t\b\4\t\t\t\4\n\t\n\4\13"+
		"\t\13\4\f\t\f\4\r\t\r\4\16\t\16\4\17\t\17\4\20\t\20\4\21\t\21\4\22\t\22"+
		"\4\23\t\23\4\24\t\24\4\25\t\25\4\26\t\26\4\27\t\27\4\30\t\30\4\31\t\31"+
		"\4\32\t\32\4\33\t\33\4\34\t\34\4\35\t\35\4\36\t\36\4\37\t\37\4 \t \4!"+
		"\t!\4\"\t\"\4#\t#\4$\t$\4%\t%\4&\t&\4\'\t\'\4(\t(\4)\t)\4*\t*\3\2\3\2"+
		"\3\2\3\2\3\2\3\2\3\2\3\2\3\2\3\2\3\2\3\2\5\2b\n\2\3\3\3\3\3\3\3\3\3\3"+
		"\3\3\3\3\3\3\3\3\3\3\3\4\3\4\3\4\3\4\3\4\3\4\3\4\3\4\3\4\3\4\3\4\3\5\3"+
		"\5\3\5\3\5\3\5\3\5\3\5\3\6\3\6\3\6\3\6\3\6\3\6\3\7\3\7\3\7\3\7\3\7\3\7"+
		"\3\b\3\b\3\b\3\b\3\b\3\b\3\b\3\b\3\b\3\b\3\b\3\b\3\b\3\b\5\b\u009a\n\b"+
		"\3\t\3\t\3\t\3\t\3\t\3\t\3\t\3\t\3\t\5\t\u00a5\n\t\3\n\3\n\3\13\3\13\3"+
		"\f\3\f\3\r\3\r\3\16\3\16\3\17\3\17\3\17\3\17\3\17\5\17\u00b6\n\17\3\20"+
		"\3\20\3\21\3\21\3\22\3\22\3\22\3\23\3\23\3\23\3\24\3\24\3\25\3\25\3\26"+
		"\3\26\3\27\3\27\3\30\3\30\3\31\3\31\3\32\3\32\3\33\3\33\3\33\3\34\3\34"+
		"\3\34\3\34\3\34\3\35\3\35\3\35\3\35\5\35\u00dc\n\35\3\36\3\36\3\36\3\36"+
		"\3\36\5\36\u00e3\n\36\3\37\6\37\u00e6\n\37\r\37\16\37\u00e7\3 \6 \u00eb"+
		"\n \r \16 \u00ec\3 \3 \6 \u00f1\n \r \16 \u00f2\3!\3!\7!\u00f7\n!\f!\16"+
		"!\u00fa\13!\3!\3!\3!\7!\u00ff\n!\f!\16!\u0102\13!\3!\5!\u0105\n!\3\"\3"+
		"\"\3\"\3\"\3\"\3\"\3\"\3\"\3\"\5\"\u0110\n\"\3#\3#\3#\3#\3#\3$\3$\3%\3"+
		"%\7%\u011b\n%\f%\16%\u011e\13%\3&\3&\3&\5&\u0123\n&\3&\3&\5&\u0127\n&"+
		"\3&\5&\u012a\n&\5&\u012c\n&\3&\3&\3\'\3\'\3\'\5\'\u0133\n\'\3\'\3\'\3"+
		"(\6(\u0138\n(\r(\16(\u0139\3)\3)\3)\5)\u013f\n)\3)\7)\u0142\n)\f)\16)"+
		"\u0145\13)\3*\3*\5*\u0149\n*\3*\5*\u014c\n*\3*\3*\5*\u0150\n*\2\2+\3\5"+
		"\5\6\7\7\t\b\13\t\r\n\17\13\21\f\23\r\25\16\27\17\31\20\33\21\35\22\37"+
		"\23!\24#\25%\26\'\27)\30+\31-\32/\33\61\34\63\35\65\36\67\379 ;!=\"?#"+
		"A$C%E&G\'I(K)M*O\2Q\2S\2\3\2\t\3\2\62;\3\2$$\3\2))\5\2C\\aac|\6\2\62;"+
		"C\\aac|\4\2\13\13\"\"\4\2\f\f\16\17\2\u0168\2\3\3\2\2\2\2\5\3\2\2\2\2"+
		"\7\3\2\2\2\2\t\3\2\2\2\2\13\3\2\2\2\2\r\3\2\2\2\2\17\3\2\2\2\2\21\3\2"+
		"\2\2\2\23\3\2\2\2\2\25\3\2\2\2\2\27\3\2\2\2\2\31\3\2\2\2\2\33\3\2\2\2"+
		"\2\35\3\2\2\2\2\37\3\2\2\2\2!\3\2\2\2\2#\3\2\2\2\2%\3\2\2\2\2\'\3\2\2"+
		"\2\2)\3\2\2\2\2+\3\2\2\2\2-\3\2\2\2\2/\3\2\2\2\2\61\3\2\2\2\2\63\3\2\2"+
		"\2\2\65\3\2\2\2\2\67\3\2\2\2\29\3\2\2\2\2;\3\2\2\2\2=\3\2\2\2\2?\3\2\2"+
		"\2\2A\3\2\2\2\2C\3\2\2\2\2E\3\2\2\2\2G\3\2\2\2\2I\3\2\2\2\2K\3\2\2\2\2"+
		"M\3\2\2\2\3a\3\2\2\2\5c\3\2\2\2\7m\3\2\2\2\tx\3\2\2\2\13\177\3\2\2\2\r"+
		"\u0085\3\2\2\2\17\u0099\3\2\2\2\21\u00a4\3\2\2\2\23\u00a6\3\2\2\2\25\u00a8"+
		"\3\2\2\2\27\u00aa\3\2\2\2\31\u00ac\3\2\2\2\33\u00ae\3\2\2\2\35\u00b5\3"+
		"\2\2\2\37\u00b7\3\2\2\2!\u00b9\3\2\2\2#\u00bb\3\2\2\2%\u00be\3\2\2\2\'"+
		"\u00c1\3\2\2\2)\u00c3\3\2\2\2+\u00c5\3\2\2\2-\u00c7\3\2\2\2/\u00c9\3\2"+
		"\2\2\61\u00cb\3\2\2\2\63\u00cd\3\2\2\2\65\u00cf\3\2\2\2\67\u00d2\3\2\2"+
		"\29\u00db\3\2\2\2;\u00e2\3\2\2\2=\u00e5\3\2\2\2?\u00ea\3\2\2\2A\u0104"+
		"\3\2\2\2C\u010f\3\2\2\2E\u0111\3\2\2\2G\u0116\3\2\2\2I\u0118\3\2\2\2K"+
		"\u012b\3\2\2\2M\u0132\3\2\2\2O\u0137\3\2\2\2Q\u013e\3\2\2\2S\u0146\3\2"+
		"\2\2UV\7r\2\2VW\7k\2\2WX\7r\2\2XY\7g\2\2YZ\7n\2\2Z[\7k\2\2[\\\7p\2\2\\"+
		"b\7g\2\2]^\7r\2\2^_\7k\2\2_`\7r\2\2`b\7g\2\2aU\3\2\2\2a]\3\2\2\2b\4\3"+
		"\2\2\2cd\7i\2\2de\7n\2\2ef\7q\2\2fg\7d\2\2gh\7c\2\2hi\7n\2\2ij\7G\2\2"+
		"jk\7p\2\2kl\7x\2\2l\6\3\2\2\2mn\7r\2\2no\7c\2\2op\7t\2\2pq\7c\2\2qr\7"+
		"o\2\2rs\7g\2\2st\7v\2\2tu\7g\2\2uv\7t\2\2vw\7u\2\2w\b\3\2\2\2xy\7u\2\2"+
		"yz\7v\2\2z{\7c\2\2{|\7i\2\2|}\7g\2\2}~\7u\2\2~\n\3\2\2\2\177\u0080\7u"+
		"\2\2\u0080\u0081\7v\2\2\u0081\u0082\7c\2\2\u0082\u0083\7i\2\2\u0083\u0084"+
		"\7g\2\2\u0084\f\3\2\2\2\u0085\u0086\7y\2\2\u0086\u0087\7j\2\2\u0087\u0088"+
		"\7k\2\2\u0088\u0089\7n\2\2\u0089\u008a\7g\2\2\u008a\16\3\2\2\2\u008b\u008c"+
		"\7h\2\2\u008c\u008d\7w\2\2\u008d\u009a\7p\2\2\u008e\u008f\7f\2\2\u008f"+
		"\u0090\7g\2\2\u0090\u009a\7h\2\2\u0091\u0092\7h\2\2\u0092\u0093\7w\2\2"+
		"\u0093\u0094\7p\2\2\u0094\u0095\7e\2\2\u0095\u0096\7v\2\2\u0096\u0097"+
		"\7k\2\2\u0097\u0098\7q\2\2\u0098\u009a\7p\2\2\u0099\u008b\3\2\2\2\u0099"+
		"\u008e\3\2\2\2\u0099\u0091\3\2\2\2\u009a\20\3\2\2\2\u009b\u009c\7t\2\2"+
		"\u009c\u009d\7g\2\2\u009d\u009e\7v\2\2\u009e\u009f\7w\2\2\u009f\u00a0"+
		"\7t\2\2\u00a0\u00a5\7p\2\2\u00a1\u00a2\7t\2\2\u00a2\u00a3\7g\2\2\u00a3"+
		"\u00a5\7v\2\2\u00a4\u009b\3\2\2\2\u00a4\u00a1\3\2\2\2\u00a5\22\3\2\2\2"+
		"\u00a6\u00a7\7-\2\2\u00a7\24\3\2\2\2\u00a8\u00a9\7/\2\2\u00a9\26\3\2\2"+
		"\2\u00aa\u00ab\7,\2\2\u00ab\30\3\2\2\2\u00ac\u00ad\7\61\2\2\u00ad\32\3"+
		"\2\2\2\u00ae\u00af\7\'\2\2\u00af\34\3\2\2\2\u00b0\u00b1\7c\2\2\u00b1\u00b2"+
		"\7p\2\2\u00b2\u00b6\7f\2\2\u00b3\u00b4\7q\2\2\u00b4\u00b6\7t\2\2\u00b5"+
		"\u00b0\3\2\2\2\u00b5\u00b3\3\2\2\2\u00b6\36\3\2\2\2\u00b7\u00b8\7@\2\2"+
		"\u00b8 \3\2\2\2\u00b9\u00ba\7>\2\2\u00ba\"\3\2\2\2\u00bb\u00bc\7@\2\2"+
		"\u00bc\u00bd\7?\2\2\u00bd$\3\2\2\2\u00be\u00bf\7>\2\2\u00bf\u00c0\7?\2"+
		"\2\u00c0&\3\2\2\2\u00c1\u00c2\7*\2\2\u00c2(\3\2\2\2\u00c3\u00c4\7+\2\2"+
		"\u00c4*\3\2\2\2\u00c5\u00c6\7.\2\2\u00c6,\3\2\2\2\u00c7\u00c8\7=\2\2\u00c8"+
		".\3\2\2\2\u00c9\u00ca\7<\2\2\u00ca\60\3\2\2\2\u00cb\u00cc\7\60\2\2\u00cc"+
		"\62\3\2\2\2\u00cd\u00ce\7?\2\2\u00ce\64\3\2\2\2\u00cf\u00d0\7k\2\2\u00d0"+
		"\u00d1\7h\2\2\u00d1\66\3\2\2\2\u00d2\u00d3\7g\2\2\u00d3\u00d4\7n\2\2\u00d4"+
		"\u00d5\7u\2\2\u00d5\u00d6\7g\2\2\u00d68\3\2\2\2\u00d7\u00d8\7?\2\2\u00d8"+
		"\u00dc\7?\2\2\u00d9\u00da\7#\2\2\u00da\u00dc\7?\2\2\u00db\u00d7\3\2\2"+
		"\2\u00db\u00d9\3\2\2\2\u00dc:\3\2\2\2\u00dd\u00de\7p\2\2\u00de\u00df\7"+
		"q\2\2\u00df\u00e0\7v\2\2\u00e0\u00e3\7\"\2\2\u00e1\u00e3\7#\2\2\u00e2"+
		"\u00dd\3\2\2\2\u00e2\u00e1\3\2\2\2\u00e3<\3\2\2\2\u00e4\u00e6\t\2\2\2"+
		"\u00e5\u00e4\3\2\2\2\u00e6\u00e7\3\2\2\2\u00e7\u00e5\3\2\2\2\u00e7\u00e8"+
		"\3\2\2\2\u00e8>\3\2\2\2\u00e9\u00eb\t\2\2\2\u00ea\u00e9\3\2\2\2\u00eb"+
		"\u00ec\3\2\2\2\u00ec\u00ea\3\2\2\2\u00ec\u00ed\3\2\2\2\u00ed\u00ee\3\2"+
		"\2\2\u00ee\u00f0\7\60\2\2\u00ef\u00f1\t\2\2\2\u00f0\u00ef\3\2\2\2\u00f1"+
		"\u00f2\3\2\2\2\u00f2\u00f0\3\2\2\2\u00f2\u00f3\3\2\2\2\u00f3@\3\2\2\2"+
		"\u00f4\u00f8\7$\2\2\u00f5\u00f7\n\3\2\2\u00f6\u00f5\3\2\2\2\u00f7\u00fa"+
		"\3\2\2\2\u00f8\u00f6\3\2\2\2\u00f8\u00f9\3\2\2\2\u00f9\u00fb\3\2\2\2\u00fa"+
		"\u00f8\3\2\2\2\u00fb\u0105\7$\2\2\u00fc\u0100\7)\2\2\u00fd\u00ff\n\4\2"+
		"\2\u00fe\u00fd\3\2\2\2\u00ff\u0102\3\2\2\2\u0100\u00fe\3\2\2\2\u0100\u0101"+
		"\3\2\2\2\u0101\u0103\3\2\2\2\u0102\u0100\3\2\2\2\u0103\u0105\7)\2\2\u0104"+
		"\u00f4\3\2\2\2\u0104\u00fc\3\2\2\2\u0105B\3\2\2\2\u0106\u0107\7v\2\2\u0107"+
		"\u0108\7t\2\2\u0108\u0109\7w\2\2\u0109\u0110\7g\2\2\u010a\u010b\7h\2\2"+
		"\u010b\u010c\7c\2\2\u010c\u010d\7n\2\2\u010d\u010e\7u\2\2\u010e\u0110"+
		"\7g\2\2\u010f\u0106\3\2\2\2\u010f\u010a\3\2\2\2\u0110D\3\2\2\2\u0111\u0112"+
		"\7p\2\2\u0112\u0113\7w\2\2\u0113\u0114\7n\2\2\u0114\u0115\7n\2\2\u0115"+
		"F\3\2\2\2\u0116\u0117\5-\27\2\u0117H\3\2\2\2\u0118\u011c\t\5\2\2\u0119"+
		"\u011b\t\6\2\2\u011a\u0119\3\2\2\2\u011b\u011e\3\2\2\2\u011c\u011a\3\2"+
		"\2\2\u011c\u011d\3\2\2\2\u011dJ\3\2\2\2\u011e\u011c\3\2\2\2\u011f\u0120"+
		"\6&\2\2\u0120\u012c\5O(\2\u0121\u0123\7\17\2\2\u0122\u0121\3\2\2\2\u0122"+
		"\u0123\3\2\2\2\u0123\u0124\3\2\2\2\u0124\u0127\7\f\2\2\u0125\u0127\4\16"+
		"\17\2\u0126\u0122\3\2\2\2\u0126\u0125\3\2\2\2\u0127\u0129\3\2\2\2\u0128"+
		"\u012a\5O(\2\u0129\u0128\3\2\2\2\u0129\u012a\3\2\2\2\u012a\u012c\3\2\2"+
		"\2\u012b\u011f\3\2\2\2\u012b\u0126\3\2\2\2\u012c\u012d\3\2\2\2\u012d\u012e"+
		"\b&\2\2\u012eL\3\2\2\2\u012f\u0133\5O(\2\u0130\u0133\5Q)\2\u0131\u0133"+
		"\5S*\2\u0132\u012f\3\2\2\2\u0132\u0130\3\2\2\2\u0132\u0131\3\2\2\2\u0133"+
		"\u0134\3\2\2\2\u0134\u0135\b\'\3\2\u0135N\3\2\2\2\u0136\u0138\t\7\2\2"+
		"\u0137\u0136\3\2\2\2\u0138\u0139\3\2\2\2\u0139\u0137\3\2\2\2\u0139\u013a"+
		"\3\2\2\2\u013aP\3\2\2\2\u013b\u013c\7\61\2\2\u013c\u013f\7\61\2\2\u013d"+
		"\u013f\7%\2\2\u013e\u013b\3\2\2\2\u013e\u013d\3\2\2\2\u013f\u0143\3\2"+
		"\2\2\u0140\u0142\n\b\2\2\u0141\u0140\3\2\2\2\u0142\u0145\3\2\2\2\u0143"+
		"\u0141\3\2\2\2\u0143\u0144\3\2\2\2\u0144R\3\2\2\2\u0145\u0143\3\2\2\2"+
		"\u0146\u0148\7^\2\2\u0147\u0149\5O(\2\u0148\u0147\3\2\2\2\u0148\u0149"+
		"\3\2\2\2\u0149\u014f\3\2\2\2\u014a\u014c\7\17\2\2\u014b\u014a\3\2\2\2"+
		"\u014b\u014c\3\2\2\2\u014c\u014d\3\2\2\2\u014d\u0150\7\f\2\2\u014e\u0150"+
		"\4\16\17\2\u014f\u014b\3\2\2\2\u014f\u014e\3\2\2\2\u0150T\3\2\2\2\34\2"+
		"a\u0099\u00a4\u00b5\u00db\u00e2\u00e7\u00ec\u00f2\u00f8\u0100\u0104\u010f"+
		"\u011c\u0122\u0126\u0129\u012b\u0132\u0139\u013e\u0143\u0148\u014b\u014f"+
		"\4\3&\2\b\2\2";
	public static final ATN _ATN =
		new ATNDeserializer().deserialize(_serializedATN.toCharArray());
	static {
		_decisionToDFA = new DFA[_ATN.getNumberOfDecisions()];
		for (int i = 0; i < _ATN.getNumberOfDecisions(); i++) {
			_decisionToDFA[i] = new DFA(_ATN.getDecisionState(i), i);
		}
	}
}