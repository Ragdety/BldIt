// Generated from c:\Users\ragde\OneDrive\Desktop\Programming\BldIt\BldIt.Lang\Grammar\BldItLexer.g4 by ANTLR 4.9.2

using BldIt.Lang.External.AntlrDenter;

import org.antlr.v4.runtime.Lexer;
import org.antlr.v4.runtime.CharStream;
import org.antlr.v4.runtime.Token;
import org.antlr.v4.runtime.TokenStream;
import org.antlr.v4.runtime.*;
import org.antlr.v4.runtime.atn.*;
import org.antlr.v4.runtime.dfa.DFA;
import org.antlr.v4.runtime.misc.*;

@SuppressWarnings({"all", "warnings", "unchecked", "unused", "cast"})
public class BldItLexer extends Lexer {
	static { RuntimeMetaData.checkVersion("4.9.2", RuntimeMetaData.VERSION); }

	protected static final DFA[] _decisionToDFA;
	protected static final PredictionContextCache _sharedContextCache =
		new PredictionContextCache();
	public static final int
		INDENT=1, DEDENT=2, WHILE=3, ADD_OP=4, SUB_OP=5, MULT_OP=6, DIV_OP=7, 
		MOD_OP=8, BOOL_OP=9, GREATER_THAN_OP=10, LESS_THAN_OP=11, GREATER_THAN_EQUAL_OP=12, 
		LESS_THAN_EQUAL_OP=13, OPEN_PAREN=14, CLOSE_PAREN=15, COMMA=16, SEMICOLON=17, 
		COLON=18, DOT=19, ASSIGN_OP=20, IF=21, ELSE=22, EQUALITY=23, NOT=24, INTEGER=25, 
		FLOAT=26, STRING=27, BOOL=28, NULL=29, ENDLINE=30, ENDBLOCK=31, WS=32, 
		COMMENT=33, NL=34, IDENTIFIER=35;
	public static String[] channelNames = {
		"DEFAULT_TOKEN_CHANNEL", "HIDDEN"
	};

	public static String[] modeNames = {
		"DEFAULT_MODE"
	};

	private static String[] makeRuleNames() {
		return new String[] {
			"WHILE", "ADD_OP", "SUB_OP", "MULT_OP", "DIV_OP", "MOD_OP", "BOOL_OP", 
			"GREATER_THAN_OP", "LESS_THAN_OP", "GREATER_THAN_EQUAL_OP", "LESS_THAN_EQUAL_OP", 
			"OPEN_PAREN", "CLOSE_PAREN", "COMMA", "SEMICOLON", "COLON", "DOT", "ASSIGN_OP", 
			"IF", "ELSE", "EQUALITY", "NOT", "INTEGER", "FLOAT", "STRING", "BOOL", 
			"NULL", "ENDLINE", "ENDBLOCK", "WS", "COMMENT", "NL", "IDENTIFIER"
		};
	}
	public static final String[] ruleNames = makeRuleNames();

	private static String[] makeLiteralNames() {
		return new String[] {
			null, null, null, "'while'", "'+'", "'-'", "'*'", "'/'", "'%'", null, 
			"'>'", "'<'", "'>='", "'<='", "'('", "')'", "','", "';'", "':'", "'.'", 
			"'='", "'if'", "'else'", null, null, null, null, null, null, "'null'", 
			null, "'end'"
		};
	}
	private static final String[] _LITERAL_NAMES = makeLiteralNames();
	private static String[] makeSymbolicNames() {
		return new String[] {
			null, "INDENT", "DEDENT", "WHILE", "ADD_OP", "SUB_OP", "MULT_OP", "DIV_OP", 
			"MOD_OP", "BOOL_OP", "GREATER_THAN_OP", "LESS_THAN_OP", "GREATER_THAN_EQUAL_OP", 
			"LESS_THAN_EQUAL_OP", "OPEN_PAREN", "CLOSE_PAREN", "COMMA", "SEMICOLON", 
			"COLON", "DOT", "ASSIGN_OP", "IF", "ELSE", "EQUALITY", "NOT", "INTEGER", 
			"FLOAT", "STRING", "BOOL", "NULL", "ENDLINE", "ENDBLOCK", "WS", "COMMENT", 
			"NL", "IDENTIFIER"
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


	private DenterHelper denter;
	  
	public override IToken NextToken()
	{
	    if (denter == null)
	    {
	        denter = DenterHelper.Builder()
	            .Nl(NL)
	            .Indent(BldItParser.INDENT)
	            .Dedent(BldItParser.DEDENT)
	            .PullToken(base.NextToken);
	    }

	    return denter.NextToken();
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

	public static final String _serializedATN =
		"\3\u608b\ua72a\u8133\ub9ed\u417c\u3be7\u7786\u5964\2%\u00e9\b\1\4\2\t"+
		"\2\4\3\t\3\4\4\t\4\4\5\t\5\4\6\t\6\4\7\t\7\4\b\t\b\4\t\t\t\4\n\t\n\4\13"+
		"\t\13\4\f\t\f\4\r\t\r\4\16\t\16\4\17\t\17\4\20\t\20\4\21\t\21\4\22\t\22"+
		"\4\23\t\23\4\24\t\24\4\25\t\25\4\26\t\26\4\27\t\27\4\30\t\30\4\31\t\31"+
		"\4\32\t\32\4\33\t\33\4\34\t\34\4\35\t\35\4\36\t\36\4\37\t\37\4 \t \4!"+
		"\t!\4\"\t\"\3\2\3\2\3\2\3\2\3\2\3\2\3\3\3\3\3\4\3\4\3\5\3\5\3\6\3\6\3"+
		"\7\3\7\3\b\3\b\3\b\3\b\3\b\5\b[\n\b\3\t\3\t\3\n\3\n\3\13\3\13\3\13\3\f"+
		"\3\f\3\f\3\r\3\r\3\16\3\16\3\17\3\17\3\20\3\20\3\21\3\21\3\22\3\22\3\23"+
		"\3\23\3\24\3\24\3\24\3\25\3\25\3\25\3\25\3\25\3\26\3\26\3\26\3\26\5\26"+
		"\u0081\n\26\3\27\3\27\3\27\3\27\3\27\5\27\u0088\n\27\3\30\6\30\u008b\n"+
		"\30\r\30\16\30\u008c\3\31\6\31\u0090\n\31\r\31\16\31\u0091\3\31\3\31\6"+
		"\31\u0096\n\31\r\31\16\31\u0097\3\32\3\32\7\32\u009c\n\32\f\32\16\32\u009f"+
		"\13\32\3\32\3\32\3\32\7\32\u00a4\n\32\f\32\16\32\u00a7\13\32\3\32\5\32"+
		"\u00aa\n\32\3\33\3\33\3\33\3\33\3\33\3\33\3\33\3\33\3\33\5\33\u00b5\n"+
		"\33\3\34\3\34\3\34\3\34\3\34\3\35\3\35\3\36\3\36\3\36\3\36\3\37\6\37\u00c3"+
		"\n\37\r\37\16\37\u00c4\3\37\3\37\3 \3 \3 \3 \7 \u00cd\n \f \16 \u00d0"+
		"\13 \3 \5 \u00d3\n \3 \3 \3 \3 \3!\5!\u00da\n!\3!\3!\7!\u00de\n!\f!\16"+
		"!\u00e1\13!\3\"\3\"\7\"\u00e5\n\"\f\"\16\"\u00e8\13\"\3\u00ce\2#\3\5\5"+
		"\6\7\7\t\b\13\t\r\n\17\13\21\f\23\r\25\16\27\17\31\20\33\21\35\22\37\23"+
		"!\24#\25%\26\'\27)\30+\31-\32/\33\61\34\63\35\65\36\67\379 ;!=\"?#A$C"+
		"%\3\2\b\3\2\62;\3\2$$\3\2))\5\2\f\f\17\17\"\"\5\2C\\aac|\6\2\62;C\\aa"+
		"c|\2\u00f8\2\3\3\2\2\2\2\5\3\2\2\2\2\7\3\2\2\2\2\t\3\2\2\2\2\13\3\2\2"+
		"\2\2\r\3\2\2\2\2\17\3\2\2\2\2\21\3\2\2\2\2\23\3\2\2\2\2\25\3\2\2\2\2\27"+
		"\3\2\2\2\2\31\3\2\2\2\2\33\3\2\2\2\2\35\3\2\2\2\2\37\3\2\2\2\2!\3\2\2"+
		"\2\2#\3\2\2\2\2%\3\2\2\2\2\'\3\2\2\2\2)\3\2\2\2\2+\3\2\2\2\2-\3\2\2\2"+
		"\2/\3\2\2\2\2\61\3\2\2\2\2\63\3\2\2\2\2\65\3\2\2\2\2\67\3\2\2\2\29\3\2"+
		"\2\2\2;\3\2\2\2\2=\3\2\2\2\2?\3\2\2\2\2A\3\2\2\2\2C\3\2\2\2\3E\3\2\2\2"+
		"\5K\3\2\2\2\7M\3\2\2\2\tO\3\2\2\2\13Q\3\2\2\2\rS\3\2\2\2\17Z\3\2\2\2\21"+
		"\\\3\2\2\2\23^\3\2\2\2\25`\3\2\2\2\27c\3\2\2\2\31f\3\2\2\2\33h\3\2\2\2"+
		"\35j\3\2\2\2\37l\3\2\2\2!n\3\2\2\2#p\3\2\2\2%r\3\2\2\2\'t\3\2\2\2)w\3"+
		"\2\2\2+\u0080\3\2\2\2-\u0087\3\2\2\2/\u008a\3\2\2\2\61\u008f\3\2\2\2\63"+
		"\u00a9\3\2\2\2\65\u00b4\3\2\2\2\67\u00b6\3\2\2\29\u00bb\3\2\2\2;\u00bd"+
		"\3\2\2\2=\u00c2\3\2\2\2?\u00c8\3\2\2\2A\u00d9\3\2\2\2C\u00e2\3\2\2\2E"+
		"F\7y\2\2FG\7j\2\2GH\7k\2\2HI\7n\2\2IJ\7g\2\2J\4\3\2\2\2KL\7-\2\2L\6\3"+
		"\2\2\2MN\7/\2\2N\b\3\2\2\2OP\7,\2\2P\n\3\2\2\2QR\7\61\2\2R\f\3\2\2\2S"+
		"T\7\'\2\2T\16\3\2\2\2UV\7c\2\2VW\7p\2\2W[\7f\2\2XY\7q\2\2Y[\7t\2\2ZU\3"+
		"\2\2\2ZX\3\2\2\2[\20\3\2\2\2\\]\7@\2\2]\22\3\2\2\2^_\7>\2\2_\24\3\2\2"+
		"\2`a\7@\2\2ab\7?\2\2b\26\3\2\2\2cd\7>\2\2de\7?\2\2e\30\3\2\2\2fg\7*\2"+
		"\2g\32\3\2\2\2hi\7+\2\2i\34\3\2\2\2jk\7.\2\2k\36\3\2\2\2lm\7=\2\2m \3"+
		"\2\2\2no\7<\2\2o\"\3\2\2\2pq\7\60\2\2q$\3\2\2\2rs\7?\2\2s&\3\2\2\2tu\7"+
		"k\2\2uv\7h\2\2v(\3\2\2\2wx\7g\2\2xy\7n\2\2yz\7u\2\2z{\7g\2\2{*\3\2\2\2"+
		"|}\7?\2\2}\u0081\7?\2\2~\177\7#\2\2\177\u0081\7?\2\2\u0080|\3\2\2\2\u0080"+
		"~\3\2\2\2\u0081,\3\2\2\2\u0082\u0083\7p\2\2\u0083\u0084\7q\2\2\u0084\u0085"+
		"\7v\2\2\u0085\u0088\7\"\2\2\u0086\u0088\7#\2\2\u0087\u0082\3\2\2\2\u0087"+
		"\u0086\3\2\2\2\u0088.\3\2\2\2\u0089\u008b\t\2\2\2\u008a\u0089\3\2\2\2"+
		"\u008b\u008c\3\2\2\2\u008c\u008a\3\2\2\2\u008c\u008d\3\2\2\2\u008d\60"+
		"\3\2\2\2\u008e\u0090\t\2\2\2\u008f\u008e\3\2\2\2\u0090\u0091\3\2\2\2\u0091"+
		"\u008f\3\2\2\2\u0091\u0092\3\2\2\2\u0092\u0093\3\2\2\2\u0093\u0095\7\60"+
		"\2\2\u0094\u0096\t\2\2\2\u0095\u0094\3\2\2\2\u0096\u0097\3\2\2\2\u0097"+
		"\u0095\3\2\2\2\u0097\u0098\3\2\2\2\u0098\62\3\2\2\2\u0099\u009d\7$\2\2"+
		"\u009a\u009c\n\3\2\2\u009b\u009a\3\2\2\2\u009c\u009f\3\2\2\2\u009d\u009b"+
		"\3\2\2\2\u009d\u009e\3\2\2\2\u009e\u00a0\3\2\2\2\u009f\u009d\3\2\2\2\u00a0"+
		"\u00aa\7$\2\2\u00a1\u00a5\7)\2\2\u00a2\u00a4\n\4\2\2\u00a3\u00a2\3\2\2"+
		"\2\u00a4\u00a7\3\2\2\2\u00a5\u00a3\3\2\2\2\u00a5\u00a6\3\2\2\2\u00a6\u00a8"+
		"\3\2\2\2\u00a7\u00a5\3\2\2\2\u00a8\u00aa\7)\2\2\u00a9\u0099\3\2\2\2\u00a9"+
		"\u00a1\3\2\2\2\u00aa\64\3\2\2\2\u00ab\u00ac\7v\2\2\u00ac\u00ad\7t\2\2"+
		"\u00ad\u00ae\7w\2\2\u00ae\u00b5\7g\2\2\u00af\u00b0\7h\2\2\u00b0\u00b1"+
		"\7c\2\2\u00b1\u00b2\7n\2\2\u00b2\u00b3\7u\2\2\u00b3\u00b5\7g\2\2\u00b4"+
		"\u00ab\3\2\2\2\u00b4\u00af\3\2\2\2\u00b5\66\3\2\2\2\u00b6\u00b7\7p\2\2"+
		"\u00b7\u00b8\7w\2\2\u00b8\u00b9\7n\2\2\u00b9\u00ba\7n\2\2\u00ba8\3\2\2"+
		"\2\u00bb\u00bc\5\37\20\2\u00bc:\3\2\2\2\u00bd\u00be\7g\2\2\u00be\u00bf"+
		"\7p\2\2\u00bf\u00c0\7f\2\2\u00c0<\3\2\2\2\u00c1\u00c3\t\5\2\2\u00c2\u00c1"+
		"\3\2\2\2\u00c3\u00c4\3\2\2\2\u00c4\u00c2\3\2\2\2\u00c4\u00c5\3\2\2\2\u00c5"+
		"\u00c6\3\2\2\2\u00c6\u00c7\b\37\2\2\u00c7>\3\2\2\2\u00c8\u00c9\7\61\2"+
		"\2\u00c9\u00ca\7\61\2\2\u00ca\u00ce\3\2\2\2\u00cb\u00cd\13\2\2\2\u00cc"+
		"\u00cb\3\2\2\2\u00cd\u00d0\3\2\2\2\u00ce\u00cf\3\2\2\2\u00ce\u00cc\3\2"+
		"\2\2\u00cf\u00d2\3\2\2\2\u00d0\u00ce\3\2\2\2\u00d1\u00d3\7\17\2\2\u00d2"+
		"\u00d1\3\2\2\2\u00d2\u00d3\3\2\2\2\u00d3\u00d4\3\2\2\2\u00d4\u00d5\7\f"+
		"\2\2\u00d5\u00d6\3\2\2\2\u00d6\u00d7\b \2\2\u00d7@\3\2\2\2\u00d8\u00da"+
		"\7\17\2\2\u00d9\u00d8\3\2\2\2\u00d9\u00da\3\2\2\2\u00da\u00db\3\2\2\2"+
		"\u00db\u00df\7\f\2\2\u00dc\u00de\7\"\2\2\u00dd\u00dc\3\2\2\2\u00de\u00e1"+
		"\3\2\2\2\u00df\u00dd\3\2\2\2\u00df\u00e0\3\2\2\2\u00e0B\3\2\2\2\u00e1"+
		"\u00df\3\2\2\2\u00e2\u00e6\t\6\2\2\u00e3\u00e5\t\7\2\2\u00e4\u00e3\3\2"+
		"\2\2\u00e5\u00e8\3\2\2\2\u00e6\u00e4\3\2\2\2\u00e6\u00e7\3\2\2\2\u00e7"+
		"D\3\2\2\2\u00e8\u00e6\3\2\2\2\23\2Z\u0080\u0087\u008c\u0091\u0097\u009d"+
		"\u00a5\u00a9\u00b4\u00c4\u00ce\u00d2\u00d9\u00df\u00e6\3\b\2\2";
	public static final ATN _ATN =
		new ATNDeserializer().deserialize(_serializedATN.toCharArray());
	static {
		_decisionToDFA = new DFA[_ATN.getNumberOfDecisions()];
		for (int i = 0; i < _ATN.getNumberOfDecisions(); i++) {
			_decisionToDFA[i] = new DFA(_ATN.getDecisionState(i), i);
		}
	}
}