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
		NEWLINE=40, SKIP_=41;
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
			"NULL", "ENDLINE", "IDENTIFIER", "PARAM_TYPE", "NEWLINE", "SKIP_", "SPACES", 
			"COMMENT", "LINE_JOINING"
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
		case 37:
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
		case 37:
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
		"\3\u608b\ua72a\u8133\ub9ed\u417c\u3be7\u7786\u5964\2+\u0174\b\1\4\2\t"+
		"\2\4\3\t\3\4\4\t\4\4\5\t\5\4\6\t\6\4\7\t\7\4\b\t\b\4\t\t\t\4\n\t\n\4\13"+
		"\t\13\4\f\t\f\4\r\t\r\4\16\t\16\4\17\t\17\4\20\t\20\4\21\t\21\4\22\t\22"+
		"\4\23\t\23\4\24\t\24\4\25\t\25\4\26\t\26\4\27\t\27\4\30\t\30\4\31\t\31"+
		"\4\32\t\32\4\33\t\33\4\34\t\34\4\35\t\35\4\36\t\36\4\37\t\37\4 \t \4!"+
		"\t!\4\"\t\"\4#\t#\4$\t$\4%\t%\4&\t&\4\'\t\'\4(\t(\4)\t)\4*\t*\4+\t+\3"+
		"\2\3\2\3\2\3\2\3\2\3\2\3\2\3\2\3\2\3\2\3\2\3\2\5\2d\n\2\3\3\3\3\3\3\3"+
		"\3\3\3\3\3\3\3\3\3\3\3\3\3\3\4\3\4\3\4\3\4\3\4\3\4\3\4\3\4\3\4\3\4\3\4"+
		"\3\5\3\5\3\5\3\5\3\5\3\5\3\5\3\6\3\6\3\6\3\6\3\6\3\6\3\7\3\7\3\7\3\7\3"+
		"\7\3\7\3\b\3\b\3\b\3\b\3\b\3\b\3\b\3\b\3\b\3\b\3\b\3\b\3\b\3\b\5\b\u009c"+
		"\n\b\3\t\3\t\3\t\3\t\3\t\3\t\3\t\3\t\3\t\5\t\u00a7\n\t\3\n\3\n\3\13\3"+
		"\13\3\f\3\f\3\r\3\r\3\16\3\16\3\17\3\17\3\17\3\17\3\17\5\17\u00b8\n\17"+
		"\3\20\3\20\3\21\3\21\3\22\3\22\3\22\3\23\3\23\3\23\3\24\3\24\3\25\3\25"+
		"\3\26\3\26\3\27\3\27\3\30\3\30\3\31\3\31\3\32\3\32\3\33\3\33\3\33\3\34"+
		"\3\34\3\34\3\34\3\34\3\35\3\35\3\35\3\35\5\35\u00de\n\35\3\36\3\36\3\36"+
		"\3\36\3\36\5\36\u00e5\n\36\3\37\6\37\u00e8\n\37\r\37\16\37\u00e9\3 \6"+
		" \u00ed\n \r \16 \u00ee\3 \3 \6 \u00f3\n \r \16 \u00f4\3!\3!\7!\u00f9"+
		"\n!\f!\16!\u00fc\13!\3!\3!\3!\7!\u0101\n!\f!\16!\u0104\13!\3!\5!\u0107"+
		"\n!\3\"\3\"\3\"\3\"\3\"\3\"\3\"\3\"\3\"\5\"\u0112\n\"\3#\3#\3#\3#\3#\3"+
		"$\3$\3%\3%\7%\u011d\n%\f%\16%\u0120\13%\3&\3&\3&\3&\3&\3&\3&\3&\3&\3&"+
		"\3&\3&\3&\3&\3&\3&\3&\3&\3&\3&\3&\3&\3&\3&\3&\3&\3&\3&\3&\3&\3&\5&\u0141"+
		"\n&\3\'\3\'\3\'\5\'\u0146\n\'\3\'\3\'\5\'\u014a\n\'\3\'\5\'\u014d\n\'"+
		"\5\'\u014f\n\'\3\'\3\'\3(\3(\3(\5(\u0156\n(\3(\3(\3)\6)\u015b\n)\r)\16"+
		")\u015c\3*\3*\3*\5*\u0162\n*\3*\7*\u0165\n*\f*\16*\u0168\13*\3+\3+\5+"+
		"\u016c\n+\3+\5+\u016f\n+\3+\3+\5+\u0173\n+\2\2,\3\5\5\6\7\7\t\b\13\t\r"+
		"\n\17\13\21\f\23\r\25\16\27\17\31\20\33\21\35\22\37\23!\24#\25%\26\'\27"+
		")\30+\31-\32/\33\61\34\63\35\65\36\67\379 ;!=\"?#A$C%E&G\'I(K)M*O+Q\2"+
		"S\2U\2\3\2\t\3\2\62;\3\2$$\3\2))\5\2C\\aac|\6\2\62;C\\aac|\4\2\13\13\""+
		"\"\4\2\f\f\16\17\2\u018d\2\3\3\2\2\2\2\5\3\2\2\2\2\7\3\2\2\2\2\t\3\2\2"+
		"\2\2\13\3\2\2\2\2\r\3\2\2\2\2\17\3\2\2\2\2\21\3\2\2\2\2\23\3\2\2\2\2\25"+
		"\3\2\2\2\2\27\3\2\2\2\2\31\3\2\2\2\2\33\3\2\2\2\2\35\3\2\2\2\2\37\3\2"+
		"\2\2\2!\3\2\2\2\2#\3\2\2\2\2%\3\2\2\2\2\'\3\2\2\2\2)\3\2\2\2\2+\3\2\2"+
		"\2\2-\3\2\2\2\2/\3\2\2\2\2\61\3\2\2\2\2\63\3\2\2\2\2\65\3\2\2\2\2\67\3"+
		"\2\2\2\29\3\2\2\2\2;\3\2\2\2\2=\3\2\2\2\2?\3\2\2\2\2A\3\2\2\2\2C\3\2\2"+
		"\2\2E\3\2\2\2\2G\3\2\2\2\2I\3\2\2\2\2K\3\2\2\2\2M\3\2\2\2\2O\3\2\2\2\3"+
		"c\3\2\2\2\5e\3\2\2\2\7o\3\2\2\2\tz\3\2\2\2\13\u0081\3\2\2\2\r\u0087\3"+
		"\2\2\2\17\u009b\3\2\2\2\21\u00a6\3\2\2\2\23\u00a8\3\2\2\2\25\u00aa\3\2"+
		"\2\2\27\u00ac\3\2\2\2\31\u00ae\3\2\2\2\33\u00b0\3\2\2\2\35\u00b7\3\2\2"+
		"\2\37\u00b9\3\2\2\2!\u00bb\3\2\2\2#\u00bd\3\2\2\2%\u00c0\3\2\2\2\'\u00c3"+
		"\3\2\2\2)\u00c5\3\2\2\2+\u00c7\3\2\2\2-\u00c9\3\2\2\2/\u00cb\3\2\2\2\61"+
		"\u00cd\3\2\2\2\63\u00cf\3\2\2\2\65\u00d1\3\2\2\2\67\u00d4\3\2\2\29\u00dd"+
		"\3\2\2\2;\u00e4\3\2\2\2=\u00e7\3\2\2\2?\u00ec\3\2\2\2A\u0106\3\2\2\2C"+
		"\u0111\3\2\2\2E\u0113\3\2\2\2G\u0118\3\2\2\2I\u011a\3\2\2\2K\u0140\3\2"+
		"\2\2M\u014e\3\2\2\2O\u0155\3\2\2\2Q\u015a\3\2\2\2S\u0161\3\2\2\2U\u0169"+
		"\3\2\2\2WX\7r\2\2XY\7k\2\2YZ\7r\2\2Z[\7g\2\2[\\\7n\2\2\\]\7k\2\2]^\7p"+
		"\2\2^d\7g\2\2_`\7r\2\2`a\7k\2\2ab\7r\2\2bd\7g\2\2cW\3\2\2\2c_\3\2\2\2"+
		"d\4\3\2\2\2ef\7i\2\2fg\7n\2\2gh\7q\2\2hi\7d\2\2ij\7c\2\2jk\7n\2\2kl\7"+
		"G\2\2lm\7p\2\2mn\7x\2\2n\6\3\2\2\2op\7r\2\2pq\7c\2\2qr\7t\2\2rs\7c\2\2"+
		"st\7o\2\2tu\7g\2\2uv\7v\2\2vw\7g\2\2wx\7t\2\2xy\7u\2\2y\b\3\2\2\2z{\7"+
		"u\2\2{|\7v\2\2|}\7c\2\2}~\7i\2\2~\177\7g\2\2\177\u0080\7u\2\2\u0080\n"+
		"\3\2\2\2\u0081\u0082\7u\2\2\u0082\u0083\7v\2\2\u0083\u0084\7c\2\2\u0084"+
		"\u0085\7i\2\2\u0085\u0086\7g\2\2\u0086\f\3\2\2\2\u0087\u0088\7y\2\2\u0088"+
		"\u0089\7j\2\2\u0089\u008a\7k\2\2\u008a\u008b\7n\2\2\u008b\u008c\7g\2\2"+
		"\u008c\16\3\2\2\2\u008d\u008e\7h\2\2\u008e\u008f\7w\2\2\u008f\u009c\7"+
		"p\2\2\u0090\u0091\7f\2\2\u0091\u0092\7g\2\2\u0092\u009c\7h\2\2\u0093\u0094"+
		"\7h\2\2\u0094\u0095\7w\2\2\u0095\u0096\7p\2\2\u0096\u0097\7e\2\2\u0097"+
		"\u0098\7v\2\2\u0098\u0099\7k\2\2\u0099\u009a\7q\2\2\u009a\u009c\7p\2\2"+
		"\u009b\u008d\3\2\2\2\u009b\u0090\3\2\2\2\u009b\u0093\3\2\2\2\u009c\20"+
		"\3\2\2\2\u009d\u009e\7t\2\2\u009e\u009f\7g\2\2\u009f\u00a0\7v\2\2\u00a0"+
		"\u00a1\7w\2\2\u00a1\u00a2\7t\2\2\u00a2\u00a7\7p\2\2\u00a3\u00a4\7t\2\2"+
		"\u00a4\u00a5\7g\2\2\u00a5\u00a7\7v\2\2\u00a6\u009d\3\2\2\2\u00a6\u00a3"+
		"\3\2\2\2\u00a7\22\3\2\2\2\u00a8\u00a9\7-\2\2\u00a9\24\3\2\2\2\u00aa\u00ab"+
		"\7/\2\2\u00ab\26\3\2\2\2\u00ac\u00ad\7,\2\2\u00ad\30\3\2\2\2\u00ae\u00af"+
		"\7\61\2\2\u00af\32\3\2\2\2\u00b0\u00b1\7\'\2\2\u00b1\34\3\2\2\2\u00b2"+
		"\u00b3\7c\2\2\u00b3\u00b4\7p\2\2\u00b4\u00b8\7f\2\2\u00b5\u00b6\7q\2\2"+
		"\u00b6\u00b8\7t\2\2\u00b7\u00b2\3\2\2\2\u00b7\u00b5\3\2\2\2\u00b8\36\3"+
		"\2\2\2\u00b9\u00ba\7@\2\2\u00ba \3\2\2\2\u00bb\u00bc\7>\2\2\u00bc\"\3"+
		"\2\2\2\u00bd\u00be\7@\2\2\u00be\u00bf\7?\2\2\u00bf$\3\2\2\2\u00c0\u00c1"+
		"\7>\2\2\u00c1\u00c2\7?\2\2\u00c2&\3\2\2\2\u00c3\u00c4\7*\2\2\u00c4(\3"+
		"\2\2\2\u00c5\u00c6\7+\2\2\u00c6*\3\2\2\2\u00c7\u00c8\7.\2\2\u00c8,\3\2"+
		"\2\2\u00c9\u00ca\7=\2\2\u00ca.\3\2\2\2\u00cb\u00cc\7<\2\2\u00cc\60\3\2"+
		"\2\2\u00cd\u00ce\7\60\2\2\u00ce\62\3\2\2\2\u00cf\u00d0\7?\2\2\u00d0\64"+
		"\3\2\2\2\u00d1\u00d2\7k\2\2\u00d2\u00d3\7h\2\2\u00d3\66\3\2\2\2\u00d4"+
		"\u00d5\7g\2\2\u00d5\u00d6\7n\2\2\u00d6\u00d7\7u\2\2\u00d7\u00d8\7g\2\2"+
		"\u00d88\3\2\2\2\u00d9\u00da\7?\2\2\u00da\u00de\7?\2\2\u00db\u00dc\7#\2"+
		"\2\u00dc\u00de\7?\2\2\u00dd\u00d9\3\2\2\2\u00dd\u00db\3\2\2\2\u00de:\3"+
		"\2\2\2\u00df\u00e0\7p\2\2\u00e0\u00e1\7q\2\2\u00e1\u00e2\7v\2\2\u00e2"+
		"\u00e5\7\"\2\2\u00e3\u00e5\7#\2\2\u00e4\u00df\3\2\2\2\u00e4\u00e3\3\2"+
		"\2\2\u00e5<\3\2\2\2\u00e6\u00e8\t\2\2\2\u00e7\u00e6\3\2\2\2\u00e8\u00e9"+
		"\3\2\2\2\u00e9\u00e7\3\2\2\2\u00e9\u00ea\3\2\2\2\u00ea>\3\2\2\2\u00eb"+
		"\u00ed\t\2\2\2\u00ec\u00eb\3\2\2\2\u00ed\u00ee\3\2\2\2\u00ee\u00ec\3\2"+
		"\2\2\u00ee\u00ef\3\2\2\2\u00ef\u00f0\3\2\2\2\u00f0\u00f2\7\60\2\2\u00f1"+
		"\u00f3\t\2\2\2\u00f2\u00f1\3\2\2\2\u00f3\u00f4\3\2\2\2\u00f4\u00f2\3\2"+
		"\2\2\u00f4\u00f5\3\2\2\2\u00f5@\3\2\2\2\u00f6\u00fa\7$\2\2\u00f7\u00f9"+
		"\n\3\2\2\u00f8\u00f7\3\2\2\2\u00f9\u00fc\3\2\2\2\u00fa\u00f8\3\2\2\2\u00fa"+
		"\u00fb\3\2\2\2\u00fb\u00fd\3\2\2\2\u00fc\u00fa\3\2\2\2\u00fd\u0107\7$"+
		"\2\2\u00fe\u0102\7)\2\2\u00ff\u0101\n\4\2\2\u0100\u00ff\3\2\2\2\u0101"+
		"\u0104\3\2\2\2\u0102\u0100\3\2\2\2\u0102\u0103\3\2\2\2\u0103\u0105\3\2"+
		"\2\2\u0104\u0102\3\2\2\2\u0105\u0107\7)\2\2\u0106\u00f6\3\2\2\2\u0106"+
		"\u00fe\3\2\2\2\u0107B\3\2\2\2\u0108\u0109\7v\2\2\u0109\u010a\7t\2\2\u010a"+
		"\u010b\7w\2\2\u010b\u0112\7g\2\2\u010c\u010d\7h\2\2\u010d\u010e\7c\2\2"+
		"\u010e\u010f\7n\2\2\u010f\u0110\7u\2\2\u0110\u0112\7g\2\2\u0111\u0108"+
		"\3\2\2\2\u0111\u010c\3\2\2\2\u0112D\3\2\2\2\u0113\u0114\7p\2\2\u0114\u0115"+
		"\7w\2\2\u0115\u0116\7n\2\2\u0116\u0117\7n\2\2\u0117F\3\2\2\2\u0118\u0119"+
		"\5-\27\2\u0119H\3\2\2\2\u011a\u011e\t\5\2\2\u011b\u011d\t\6\2\2\u011c"+
		"\u011b\3\2\2\2\u011d\u0120\3\2\2\2\u011e\u011c\3\2\2\2\u011e\u011f\3\2"+
		"\2\2\u011fJ\3\2\2\2\u0120\u011e\3\2\2\2\u0121\u0122\7u\2\2\u0122\u0123"+
		"\7v\2\2\u0123\u0124\7t\2\2\u0124\u0125\7k\2\2\u0125\u0126\7p\2\2\u0126"+
		"\u0127\7i\2\2\u0127\u0128\7R\2\2\u0128\u0129\7c\2\2\u0129\u012a\7t\2\2"+
		"\u012a\u012b\7c\2\2\u012b\u0141\7o\2\2\u012c\u012d\7d\2\2\u012d\u012e"+
		"\7q\2\2\u012e\u012f\7q\2\2\u012f\u0130\7n\2\2\u0130\u0131\7R\2\2\u0131"+
		"\u0132\7c\2\2\u0132\u0133\7t\2\2\u0133\u0134\7c\2\2\u0134\u0141\7o\2\2"+
		"\u0135\u0136\7e\2\2\u0136\u0137\7j\2\2\u0137\u0138\7q\2\2\u0138\u0139"+
		"\7k\2\2\u0139\u013a\7e\2\2\u013a\u013b\7g\2\2\u013b\u013c\7R\2\2\u013c"+
		"\u013d\7c\2\2\u013d\u013e\7t\2\2\u013e\u013f\7c\2\2\u013f\u0141\7o\2\2"+
		"\u0140\u0121\3\2\2\2\u0140\u012c\3\2\2\2\u0140\u0135\3\2\2\2\u0141L\3"+
		"\2\2\2\u0142\u0143\6\'\2\2\u0143\u014f\5Q)\2\u0144\u0146\7\17\2\2\u0145"+
		"\u0144\3\2\2\2\u0145\u0146\3\2\2\2\u0146\u0147\3\2\2\2\u0147\u014a\7\f"+
		"\2\2\u0148\u014a\4\16\17\2\u0149\u0145\3\2\2\2\u0149\u0148\3\2\2\2\u014a"+
		"\u014c\3\2\2\2\u014b\u014d\5Q)\2\u014c\u014b\3\2\2\2\u014c\u014d\3\2\2"+
		"\2\u014d\u014f\3\2\2\2\u014e\u0142\3\2\2\2\u014e\u0149\3\2\2\2\u014f\u0150"+
		"\3\2\2\2\u0150\u0151\b\'\2\2\u0151N\3\2\2\2\u0152\u0156\5Q)\2\u0153\u0156"+
		"\5S*\2\u0154\u0156\5U+\2\u0155\u0152\3\2\2\2\u0155\u0153\3\2\2\2\u0155"+
		"\u0154\3\2\2\2\u0156\u0157\3\2\2\2\u0157\u0158\b(\3\2\u0158P\3\2\2\2\u0159"+
		"\u015b\t\7\2\2\u015a\u0159\3\2\2\2\u015b\u015c\3\2\2\2\u015c\u015a\3\2"+
		"\2\2\u015c\u015d\3\2\2\2\u015dR\3\2\2\2\u015e\u015f\7\61\2\2\u015f\u0162"+
		"\7\61\2\2\u0160\u0162\7%\2\2\u0161\u015e\3\2\2\2\u0161\u0160\3\2\2\2\u0162"+
		"\u0166\3\2\2\2\u0163\u0165\n\b\2\2\u0164\u0163\3\2\2\2\u0165\u0168\3\2"+
		"\2\2\u0166\u0164\3\2\2\2\u0166\u0167\3\2\2\2\u0167T\3\2\2\2\u0168\u0166"+
		"\3\2\2\2\u0169\u016b\7^\2\2\u016a\u016c\5Q)\2\u016b\u016a\3\2\2\2\u016b"+
		"\u016c\3\2\2\2\u016c\u0172\3\2\2\2\u016d\u016f\7\17\2\2\u016e\u016d\3"+
		"\2\2\2\u016e\u016f\3\2\2\2\u016f\u0170\3\2\2\2\u0170\u0173\7\f\2\2\u0171"+
		"\u0173\4\16\17\2\u0172\u016e\3\2\2\2\u0172\u0171\3\2\2\2\u0173V\3\2\2"+
		"\2\35\2c\u009b\u00a6\u00b7\u00dd\u00e4\u00e9\u00ee\u00f4\u00fa\u0102\u0106"+
		"\u0111\u011e\u0140\u0145\u0149\u014c\u014e\u0155\u015c\u0161\u0166\u016b"+
		"\u016e\u0172\4\3\'\2\b\2\2";
	public static final ATN _ATN =
		new ATNDeserializer().deserialize(_serializedATN.toCharArray());
	static {
		_decisionToDFA = new DFA[_ATN.getNumberOfDecisions()];
		for (int i = 0; i < _ATN.getNumberOfDecisions(); i++) {
			_decisionToDFA[i] = new DFA(_ATN.getDecisionState(i), i);
		}
	}
}