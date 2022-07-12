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
		WHILE=8, ADD_OP=9, SUB_OP=10, MULT_OP=11, DIV_OP=12, MOD_OP=13, BOOL_OP=14, 
		GREATER_THAN_OP=15, LESS_THAN_OP=16, GREATER_THAN_EQUAL_OP=17, LESS_THAN_EQUAL_OP=18, 
		OPEN_PAREN=19, CLOSE_PAREN=20, COMMA=21, SEMICOLON=22, COLON=23, DOT=24, 
		ASSIGN_OP=25, IF=26, ELSE=27, EQUALITY=28, NOT=29, INTEGER=30, FLOAT=31, 
		STRING=32, BOOL=33, NULL=34, ENDLINE=35, IDENTIFIER=36, NEWLINE=37, SKIP_=38;
	public static String[] channelNames = {
		"DEFAULT_TOKEN_CHANNEL", "HIDDEN"
	};

	public static String[] modeNames = {
		"DEFAULT_MODE"
	};

	private static String[] makeRuleNames() {
		return new String[] {
			"PIPELINE", "GLOBALENV", "PARAMETERS", "STAGES", "STAGE", "WHILE", "ADD_OP", 
			"SUB_OP", "MULT_OP", "DIV_OP", "MOD_OP", "BOOL_OP", "GREATER_THAN_OP", 
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
		case 34:
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
		case 34:
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
		"\3\u608b\ua72a\u8133\ub9ed\u417c\u3be7\u7786\u5964\2(\u0132\b\1\4\2\t"+
		"\2\4\3\t\3\4\4\t\4\4\5\t\5\4\6\t\6\4\7\t\7\4\b\t\b\4\t\t\t\4\n\t\n\4\13"+
		"\t\13\4\f\t\f\4\r\t\r\4\16\t\16\4\17\t\17\4\20\t\20\4\21\t\21\4\22\t\22"+
		"\4\23\t\23\4\24\t\24\4\25\t\25\4\26\t\26\4\27\t\27\4\30\t\30\4\31\t\31"+
		"\4\32\t\32\4\33\t\33\4\34\t\34\4\35\t\35\4\36\t\36\4\37\t\37\4 \t \4!"+
		"\t!\4\"\t\"\4#\t#\4$\t$\4%\t%\4&\t&\4\'\t\'\4(\t(\3\2\3\2\3\2\3\2\3\2"+
		"\3\2\3\2\3\2\3\2\3\2\3\2\3\2\5\2^\n\2\3\3\3\3\3\3\3\3\3\3\3\3\3\3\3\3"+
		"\3\3\3\3\3\4\3\4\3\4\3\4\3\4\3\4\3\4\3\4\3\4\3\4\3\4\3\5\3\5\3\5\3\5\3"+
		"\5\3\5\3\5\3\6\3\6\3\6\3\6\3\6\3\6\3\7\3\7\3\7\3\7\3\7\3\7\3\b\3\b\3\t"+
		"\3\t\3\n\3\n\3\13\3\13\3\f\3\f\3\r\3\r\3\r\3\r\3\r\5\r\u0097\n\r\3\16"+
		"\3\16\3\17\3\17\3\20\3\20\3\20\3\21\3\21\3\21\3\22\3\22\3\23\3\23\3\24"+
		"\3\24\3\25\3\25\3\26\3\26\3\27\3\27\3\30\3\30\3\31\3\31\3\31\3\32\3\32"+
		"\3\32\3\32\3\32\3\33\3\33\3\33\3\33\5\33\u00bd\n\33\3\34\3\34\3\34\3\34"+
		"\3\34\5\34\u00c4\n\34\3\35\6\35\u00c7\n\35\r\35\16\35\u00c8\3\36\6\36"+
		"\u00cc\n\36\r\36\16\36\u00cd\3\36\3\36\6\36\u00d2\n\36\r\36\16\36\u00d3"+
		"\3\37\3\37\7\37\u00d8\n\37\f\37\16\37\u00db\13\37\3\37\3\37\3\37\7\37"+
		"\u00e0\n\37\f\37\16\37\u00e3\13\37\3\37\5\37\u00e6\n\37\3 \3 \3 \3 \3"+
		" \3 \3 \3 \3 \5 \u00f1\n \3!\3!\3!\3!\3!\3\"\3\"\3#\3#\7#\u00fc\n#\f#"+
		"\16#\u00ff\13#\3$\3$\3$\5$\u0104\n$\3$\3$\5$\u0108\n$\3$\5$\u010b\n$\5"+
		"$\u010d\n$\3$\3$\3%\3%\3%\5%\u0114\n%\3%\3%\3&\6&\u0119\n&\r&\16&\u011a"+
		"\3\'\3\'\3\'\5\'\u0120\n\'\3\'\7\'\u0123\n\'\f\'\16\'\u0126\13\'\3(\3"+
		"(\5(\u012a\n(\3(\5(\u012d\n(\3(\3(\5(\u0131\n(\2\2)\3\5\5\6\7\7\t\b\13"+
		"\t\r\n\17\13\21\f\23\r\25\16\27\17\31\20\33\21\35\22\37\23!\24#\25%\26"+
		"\'\27)\30+\31-\32/\33\61\34\63\35\65\36\67\379 ;!=\"?#A$C%E&G\'I(K\2M"+
		"\2O\2\3\2\t\3\2\62;\3\2$$\3\2))\5\2C\\aac|\6\2\62;C\\aac|\4\2\13\13\""+
		"\"\4\2\f\f\16\17\2\u0146\2\3\3\2\2\2\2\5\3\2\2\2\2\7\3\2\2\2\2\t\3\2\2"+
		"\2\2\13\3\2\2\2\2\r\3\2\2\2\2\17\3\2\2\2\2\21\3\2\2\2\2\23\3\2\2\2\2\25"+
		"\3\2\2\2\2\27\3\2\2\2\2\31\3\2\2\2\2\33\3\2\2\2\2\35\3\2\2\2\2\37\3\2"+
		"\2\2\2!\3\2\2\2\2#\3\2\2\2\2%\3\2\2\2\2\'\3\2\2\2\2)\3\2\2\2\2+\3\2\2"+
		"\2\2-\3\2\2\2\2/\3\2\2\2\2\61\3\2\2\2\2\63\3\2\2\2\2\65\3\2\2\2\2\67\3"+
		"\2\2\2\29\3\2\2\2\2;\3\2\2\2\2=\3\2\2\2\2?\3\2\2\2\2A\3\2\2\2\2C\3\2\2"+
		"\2\2E\3\2\2\2\2G\3\2\2\2\2I\3\2\2\2\3]\3\2\2\2\5_\3\2\2\2\7i\3\2\2\2\t"+
		"t\3\2\2\2\13{\3\2\2\2\r\u0081\3\2\2\2\17\u0087\3\2\2\2\21\u0089\3\2\2"+
		"\2\23\u008b\3\2\2\2\25\u008d\3\2\2\2\27\u008f\3\2\2\2\31\u0096\3\2\2\2"+
		"\33\u0098\3\2\2\2\35\u009a\3\2\2\2\37\u009c\3\2\2\2!\u009f\3\2\2\2#\u00a2"+
		"\3\2\2\2%\u00a4\3\2\2\2\'\u00a6\3\2\2\2)\u00a8\3\2\2\2+\u00aa\3\2\2\2"+
		"-\u00ac\3\2\2\2/\u00ae\3\2\2\2\61\u00b0\3\2\2\2\63\u00b3\3\2\2\2\65\u00bc"+
		"\3\2\2\2\67\u00c3\3\2\2\29\u00c6\3\2\2\2;\u00cb\3\2\2\2=\u00e5\3\2\2\2"+
		"?\u00f0\3\2\2\2A\u00f2\3\2\2\2C\u00f7\3\2\2\2E\u00f9\3\2\2\2G\u010c\3"+
		"\2\2\2I\u0113\3\2\2\2K\u0118\3\2\2\2M\u011f\3\2\2\2O\u0127\3\2\2\2QR\7"+
		"r\2\2RS\7k\2\2ST\7r\2\2TU\7g\2\2UV\7n\2\2VW\7k\2\2WX\7p\2\2X^\7g\2\2Y"+
		"Z\7r\2\2Z[\7k\2\2[\\\7r\2\2\\^\7g\2\2]Q\3\2\2\2]Y\3\2\2\2^\4\3\2\2\2_"+
		"`\7i\2\2`a\7n\2\2ab\7q\2\2bc\7d\2\2cd\7c\2\2de\7n\2\2ef\7G\2\2fg\7p\2"+
		"\2gh\7x\2\2h\6\3\2\2\2ij\7r\2\2jk\7c\2\2kl\7t\2\2lm\7c\2\2mn\7o\2\2no"+
		"\7g\2\2op\7v\2\2pq\7g\2\2qr\7t\2\2rs\7u\2\2s\b\3\2\2\2tu\7u\2\2uv\7v\2"+
		"\2vw\7c\2\2wx\7i\2\2xy\7g\2\2yz\7u\2\2z\n\3\2\2\2{|\7u\2\2|}\7v\2\2}~"+
		"\7c\2\2~\177\7i\2\2\177\u0080\7g\2\2\u0080\f\3\2\2\2\u0081\u0082\7y\2"+
		"\2\u0082\u0083\7j\2\2\u0083\u0084\7k\2\2\u0084\u0085\7n\2\2\u0085\u0086"+
		"\7g\2\2\u0086\16\3\2\2\2\u0087\u0088\7-\2\2\u0088\20\3\2\2\2\u0089\u008a"+
		"\7/\2\2\u008a\22\3\2\2\2\u008b\u008c\7,\2\2\u008c\24\3\2\2\2\u008d\u008e"+
		"\7\61\2\2\u008e\26\3\2\2\2\u008f\u0090\7\'\2\2\u0090\30\3\2\2\2\u0091"+
		"\u0092\7c\2\2\u0092\u0093\7p\2\2\u0093\u0097\7f\2\2\u0094\u0095\7q\2\2"+
		"\u0095\u0097\7t\2\2\u0096\u0091\3\2\2\2\u0096\u0094\3\2\2\2\u0097\32\3"+
		"\2\2\2\u0098\u0099\7@\2\2\u0099\34\3\2\2\2\u009a\u009b\7>\2\2\u009b\36"+
		"\3\2\2\2\u009c\u009d\7@\2\2\u009d\u009e\7?\2\2\u009e \3\2\2\2\u009f\u00a0"+
		"\7>\2\2\u00a0\u00a1\7?\2\2\u00a1\"\3\2\2\2\u00a2\u00a3\7*\2\2\u00a3$\3"+
		"\2\2\2\u00a4\u00a5\7+\2\2\u00a5&\3\2\2\2\u00a6\u00a7\7.\2\2\u00a7(\3\2"+
		"\2\2\u00a8\u00a9\7=\2\2\u00a9*\3\2\2\2\u00aa\u00ab\7<\2\2\u00ab,\3\2\2"+
		"\2\u00ac\u00ad\7\60\2\2\u00ad.\3\2\2\2\u00ae\u00af\7?\2\2\u00af\60\3\2"+
		"\2\2\u00b0\u00b1\7k\2\2\u00b1\u00b2\7h\2\2\u00b2\62\3\2\2\2\u00b3\u00b4"+
		"\7g\2\2\u00b4\u00b5\7n\2\2\u00b5\u00b6\7u\2\2\u00b6\u00b7\7g\2\2\u00b7"+
		"\64\3\2\2\2\u00b8\u00b9\7?\2\2\u00b9\u00bd\7?\2\2\u00ba\u00bb\7#\2\2\u00bb"+
		"\u00bd\7?\2\2\u00bc\u00b8\3\2\2\2\u00bc\u00ba\3\2\2\2\u00bd\66\3\2\2\2"+
		"\u00be\u00bf\7p\2\2\u00bf\u00c0\7q\2\2\u00c0\u00c1\7v\2\2\u00c1\u00c4"+
		"\7\"\2\2\u00c2\u00c4\7#\2\2\u00c3\u00be\3\2\2\2\u00c3\u00c2\3\2\2\2\u00c4"+
		"8\3\2\2\2\u00c5\u00c7\t\2\2\2\u00c6\u00c5\3\2\2\2\u00c7\u00c8\3\2\2\2"+
		"\u00c8\u00c6\3\2\2\2\u00c8\u00c9\3\2\2\2\u00c9:\3\2\2\2\u00ca\u00cc\t"+
		"\2\2\2\u00cb\u00ca\3\2\2\2\u00cc\u00cd\3\2\2\2\u00cd\u00cb\3\2\2\2\u00cd"+
		"\u00ce\3\2\2\2\u00ce\u00cf\3\2\2\2\u00cf\u00d1\7\60\2\2\u00d0\u00d2\t"+
		"\2\2\2\u00d1\u00d0\3\2\2\2\u00d2\u00d3\3\2\2\2\u00d3\u00d1\3\2\2\2\u00d3"+
		"\u00d4\3\2\2\2\u00d4<\3\2\2\2\u00d5\u00d9\7$\2\2\u00d6\u00d8\n\3\2\2\u00d7"+
		"\u00d6\3\2\2\2\u00d8\u00db\3\2\2\2\u00d9\u00d7\3\2\2\2\u00d9\u00da\3\2"+
		"\2\2\u00da\u00dc\3\2\2\2\u00db\u00d9\3\2\2\2\u00dc\u00e6\7$\2\2\u00dd"+
		"\u00e1\7)\2\2\u00de\u00e0\n\4\2\2\u00df\u00de\3\2\2\2\u00e0\u00e3\3\2"+
		"\2\2\u00e1\u00df\3\2\2\2\u00e1\u00e2\3\2\2\2\u00e2\u00e4\3\2\2\2\u00e3"+
		"\u00e1\3\2\2\2\u00e4\u00e6\7)\2\2\u00e5\u00d5\3\2\2\2\u00e5\u00dd\3\2"+
		"\2\2\u00e6>\3\2\2\2\u00e7\u00e8\7v\2\2\u00e8\u00e9\7t\2\2\u00e9\u00ea"+
		"\7w\2\2\u00ea\u00f1\7g\2\2\u00eb\u00ec\7h\2\2\u00ec\u00ed\7c\2\2\u00ed"+
		"\u00ee\7n\2\2\u00ee\u00ef\7u\2\2\u00ef\u00f1\7g\2\2\u00f0\u00e7\3\2\2"+
		"\2\u00f0\u00eb\3\2\2\2\u00f1@\3\2\2\2\u00f2\u00f3\7p\2\2\u00f3\u00f4\7"+
		"w\2\2\u00f4\u00f5\7n\2\2\u00f5\u00f6\7n\2\2\u00f6B\3\2\2\2\u00f7\u00f8"+
		"\5)\25\2\u00f8D\3\2\2\2\u00f9\u00fd\t\5\2\2\u00fa\u00fc\t\6\2\2\u00fb"+
		"\u00fa\3\2\2\2\u00fc\u00ff\3\2\2\2\u00fd\u00fb\3\2\2\2\u00fd\u00fe\3\2"+
		"\2\2\u00feF\3\2\2\2\u00ff\u00fd\3\2\2\2\u0100\u0101\6$\2\2\u0101\u010d"+
		"\5K&\2\u0102\u0104\7\17\2\2\u0103\u0102\3\2\2\2\u0103\u0104\3\2\2\2\u0104"+
		"\u0105\3\2\2\2\u0105\u0108\7\f\2\2\u0106\u0108\4\16\17\2\u0107\u0103\3"+
		"\2\2\2\u0107\u0106\3\2\2\2\u0108\u010a\3\2\2\2\u0109\u010b\5K&\2\u010a"+
		"\u0109\3\2\2\2\u010a\u010b\3\2\2\2\u010b\u010d\3\2\2\2\u010c\u0100\3\2"+
		"\2\2\u010c\u0107\3\2\2\2\u010d\u010e\3\2\2\2\u010e\u010f\b$\2\2\u010f"+
		"H\3\2\2\2\u0110\u0114\5K&\2\u0111\u0114\5M\'\2\u0112\u0114\5O(\2\u0113"+
		"\u0110\3\2\2\2\u0113\u0111\3\2\2\2\u0113\u0112\3\2\2\2\u0114\u0115\3\2"+
		"\2\2\u0115\u0116\b%\3\2\u0116J\3\2\2\2\u0117\u0119\t\7\2\2\u0118\u0117"+
		"\3\2\2\2\u0119\u011a\3\2\2\2\u011a\u0118\3\2\2\2\u011a\u011b\3\2\2\2\u011b"+
		"L\3\2\2\2\u011c\u011d\7\61\2\2\u011d\u0120\7\61\2\2\u011e\u0120\7%\2\2"+
		"\u011f\u011c\3\2\2\2\u011f\u011e\3\2\2\2\u0120\u0124\3\2\2\2\u0121\u0123"+
		"\n\b\2\2\u0122\u0121\3\2\2\2\u0123\u0126\3\2\2\2\u0124\u0122\3\2\2\2\u0124"+
		"\u0125\3\2\2\2\u0125N\3\2\2\2\u0126\u0124\3\2\2\2\u0127\u0129\7^\2\2\u0128"+
		"\u012a\5K&\2\u0129\u0128\3\2\2\2\u0129\u012a\3\2\2\2\u012a\u0130\3\2\2"+
		"\2\u012b\u012d\7\17\2\2\u012c\u012b\3\2\2\2\u012c\u012d\3\2\2\2\u012d"+
		"\u012e\3\2\2\2\u012e\u0131\7\f\2\2\u012f\u0131\4\16\17\2\u0130\u012c\3"+
		"\2\2\2\u0130\u012f\3\2\2\2\u0131P\3\2\2\2\32\2]\u0096\u00bc\u00c3\u00c8"+
		"\u00cd\u00d3\u00d9\u00e1\u00e5\u00f0\u00fd\u0103\u0107\u010a\u010c\u0113"+
		"\u011a\u011f\u0124\u0129\u012c\u0130\4\3$\2\b\2\2";
	public static final ATN _ATN =
		new ATNDeserializer().deserialize(_serializedATN.toCharArray());
	static {
		_decisionToDFA = new DFA[_ATN.getNumberOfDecisions()];
		for (int i = 0; i < _ATN.getNumberOfDecisions(); i++) {
			_decisionToDFA[i] = new DFA(_ATN.getDecisionState(i), i);
		}
	}
}