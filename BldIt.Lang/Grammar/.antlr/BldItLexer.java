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
		INDENT=1, DEDENT=2, PIPELINE=3, GLOBALENV=4, PARAMETERS=5, STAGES=6, STAGE=7, 
		WHILE=8, ADD_OP=9, SUB_OP=10, MULT_OP=11, DIV_OP=12, MOD_OP=13, BOOL_OP=14, 
		GREATER_THAN_OP=15, LESS_THAN_OP=16, GREATER_THAN_EQUAL_OP=17, LESS_THAN_EQUAL_OP=18, 
		OPEN_PAREN=19, CLOSE_PAREN=20, COMMA=21, SEMICOLON=22, COLON=23, DOT=24, 
		ASSIGN_OP=25, IF=26, ELSE=27, EQUALITY=28, NOT=29, INTEGER=30, FLOAT=31, 
		STRING=32, BOOL=33, NULL=34, ENDLINE=35, ENDBLOCK=36, WS=37, NL=38, COMMENT=39, 
		IDENTIFIER=40;
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
			"ENDLINE", "ENDBLOCK", "WS", "NL", "COMMENT", "IDENTIFIER"
		};
	}
	public static final String[] ruleNames = makeRuleNames();

	private static String[] makeLiteralNames() {
		return new String[] {
			null, null, null, null, "'globalEnv'", "'parameters'", "'stages'", "'stage'", 
			"'while'", "'+'", "'-'", "'*'", "'/'", "'%'", null, "'>'", "'<'", "'>='", 
			"'<='", "'('", "')'", "','", "';'", "':'", "'.'", "'='", "'if'", "'else'", 
			null, null, null, null, null, null, "'null'", null, "'end'"
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
			"FLOAT", "STRING", "BOOL", "NULL", "ENDLINE", "ENDBLOCK", "WS", "NL", 
			"COMMENT", "IDENTIFIER"
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
		"\3\u608b\ua72a\u8133\ub9ed\u417c\u3be7\u7786\u5964\2*\u0123\b\1\4\2\t"+
		"\2\4\3\t\3\4\4\t\4\4\5\t\5\4\6\t\6\4\7\t\7\4\b\t\b\4\t\t\t\4\n\t\n\4\13"+
		"\t\13\4\f\t\f\4\r\t\r\4\16\t\16\4\17\t\17\4\20\t\20\4\21\t\21\4\22\t\22"+
		"\4\23\t\23\4\24\t\24\4\25\t\25\4\26\t\26\4\27\t\27\4\30\t\30\4\31\t\31"+
		"\4\32\t\32\4\33\t\33\4\34\t\34\4\35\t\35\4\36\t\36\4\37\t\37\4 \t \4!"+
		"\t!\4\"\t\"\4#\t#\4$\t$\4%\t%\4&\t&\4\'\t\'\3\2\3\2\3\2\3\2\3\2\3\2\3"+
		"\2\3\2\3\2\3\2\3\2\3\2\5\2\\\n\2\3\3\3\3\3\3\3\3\3\3\3\3\3\3\3\3\3\3\3"+
		"\3\3\4\3\4\3\4\3\4\3\4\3\4\3\4\3\4\3\4\3\4\3\4\3\5\3\5\3\5\3\5\3\5\3\5"+
		"\3\5\3\6\3\6\3\6\3\6\3\6\3\6\3\7\3\7\3\7\3\7\3\7\3\7\3\b\3\b\3\t\3\t\3"+
		"\n\3\n\3\13\3\13\3\f\3\f\3\r\3\r\3\r\3\r\3\r\5\r\u0095\n\r\3\16\3\16\3"+
		"\17\3\17\3\20\3\20\3\20\3\21\3\21\3\21\3\22\3\22\3\23\3\23\3\24\3\24\3"+
		"\25\3\25\3\26\3\26\3\27\3\27\3\30\3\30\3\31\3\31\3\31\3\32\3\32\3\32\3"+
		"\32\3\32\3\33\3\33\3\33\3\33\5\33\u00bb\n\33\3\34\3\34\3\34\3\34\3\34"+
		"\5\34\u00c2\n\34\3\35\6\35\u00c5\n\35\r\35\16\35\u00c6\3\36\6\36\u00ca"+
		"\n\36\r\36\16\36\u00cb\3\36\3\36\6\36\u00d0\n\36\r\36\16\36\u00d1\3\37"+
		"\3\37\7\37\u00d6\n\37\f\37\16\37\u00d9\13\37\3\37\3\37\3\37\7\37\u00de"+
		"\n\37\f\37\16\37\u00e1\13\37\3\37\5\37\u00e4\n\37\3 \3 \3 \3 \3 \3 \3"+
		" \3 \3 \5 \u00ef\n \3!\3!\3!\3!\3!\3\"\3\"\3#\3#\3#\3#\3$\6$\u00fd\n$"+
		"\r$\16$\u00fe\3$\3$\3%\5%\u0104\n%\3%\3%\7%\u0108\n%\f%\16%\u010b\13%"+
		"\3&\3&\3&\3&\7&\u0111\n&\f&\16&\u0114\13&\3&\5&\u0117\n&\3&\3&\3&\3&\3"+
		"\'\3\'\7\'\u011f\n\'\f\'\16\'\u0122\13\'\3\u0112\2(\3\5\5\6\7\7\t\b\13"+
		"\t\r\n\17\13\21\f\23\r\25\16\27\17\31\20\33\21\35\22\37\23!\24#\25%\26"+
		"\'\27)\30+\31-\32/\33\61\34\63\35\65\36\67\379 ;!=\"?#A$C%E&G\'I(K)M*"+
		"\3\2\b\3\2\62;\3\2$$\3\2))\5\2\f\f\17\17\"\"\5\2C\\aac|\6\2\62;C\\aac"+
		"|\2\u0133\2\3\3\2\2\2\2\5\3\2\2\2\2\7\3\2\2\2\2\t\3\2\2\2\2\13\3\2\2\2"+
		"\2\r\3\2\2\2\2\17\3\2\2\2\2\21\3\2\2\2\2\23\3\2\2\2\2\25\3\2\2\2\2\27"+
		"\3\2\2\2\2\31\3\2\2\2\2\33\3\2\2\2\2\35\3\2\2\2\2\37\3\2\2\2\2!\3\2\2"+
		"\2\2#\3\2\2\2\2%\3\2\2\2\2\'\3\2\2\2\2)\3\2\2\2\2+\3\2\2\2\2-\3\2\2\2"+
		"\2/\3\2\2\2\2\61\3\2\2\2\2\63\3\2\2\2\2\65\3\2\2\2\2\67\3\2\2\2\29\3\2"+
		"\2\2\2;\3\2\2\2\2=\3\2\2\2\2?\3\2\2\2\2A\3\2\2\2\2C\3\2\2\2\2E\3\2\2\2"+
		"\2G\3\2\2\2\2I\3\2\2\2\2K\3\2\2\2\2M\3\2\2\2\3[\3\2\2\2\5]\3\2\2\2\7g"+
		"\3\2\2\2\tr\3\2\2\2\13y\3\2\2\2\r\177\3\2\2\2\17\u0085\3\2\2\2\21\u0087"+
		"\3\2\2\2\23\u0089\3\2\2\2\25\u008b\3\2\2\2\27\u008d\3\2\2\2\31\u0094\3"+
		"\2\2\2\33\u0096\3\2\2\2\35\u0098\3\2\2\2\37\u009a\3\2\2\2!\u009d\3\2\2"+
		"\2#\u00a0\3\2\2\2%\u00a2\3\2\2\2\'\u00a4\3\2\2\2)\u00a6\3\2\2\2+\u00a8"+
		"\3\2\2\2-\u00aa\3\2\2\2/\u00ac\3\2\2\2\61\u00ae\3\2\2\2\63\u00b1\3\2\2"+
		"\2\65\u00ba\3\2\2\2\67\u00c1\3\2\2\29\u00c4\3\2\2\2;\u00c9\3\2\2\2=\u00e3"+
		"\3\2\2\2?\u00ee\3\2\2\2A\u00f0\3\2\2\2C\u00f5\3\2\2\2E\u00f7\3\2\2\2G"+
		"\u00fc\3\2\2\2I\u0103\3\2\2\2K\u010c\3\2\2\2M\u011c\3\2\2\2OP\7r\2\2P"+
		"Q\7k\2\2QR\7r\2\2RS\7g\2\2ST\7n\2\2TU\7k\2\2UV\7p\2\2V\\\7g\2\2WX\7r\2"+
		"\2XY\7k\2\2YZ\7r\2\2Z\\\7g\2\2[O\3\2\2\2[W\3\2\2\2\\\4\3\2\2\2]^\7i\2"+
		"\2^_\7n\2\2_`\7q\2\2`a\7d\2\2ab\7c\2\2bc\7n\2\2cd\7G\2\2de\7p\2\2ef\7"+
		"x\2\2f\6\3\2\2\2gh\7r\2\2hi\7c\2\2ij\7t\2\2jk\7c\2\2kl\7o\2\2lm\7g\2\2"+
		"mn\7v\2\2no\7g\2\2op\7t\2\2pq\7u\2\2q\b\3\2\2\2rs\7u\2\2st\7v\2\2tu\7"+
		"c\2\2uv\7i\2\2vw\7g\2\2wx\7u\2\2x\n\3\2\2\2yz\7u\2\2z{\7v\2\2{|\7c\2\2"+
		"|}\7i\2\2}~\7g\2\2~\f\3\2\2\2\177\u0080\7y\2\2\u0080\u0081\7j\2\2\u0081"+
		"\u0082\7k\2\2\u0082\u0083\7n\2\2\u0083\u0084\7g\2\2\u0084\16\3\2\2\2\u0085"+
		"\u0086\7-\2\2\u0086\20\3\2\2\2\u0087\u0088\7/\2\2\u0088\22\3\2\2\2\u0089"+
		"\u008a\7,\2\2\u008a\24\3\2\2\2\u008b\u008c\7\61\2\2\u008c\26\3\2\2\2\u008d"+
		"\u008e\7\'\2\2\u008e\30\3\2\2\2\u008f\u0090\7c\2\2\u0090\u0091\7p\2\2"+
		"\u0091\u0095\7f\2\2\u0092\u0093\7q\2\2\u0093\u0095\7t\2\2\u0094\u008f"+
		"\3\2\2\2\u0094\u0092\3\2\2\2\u0095\32\3\2\2\2\u0096\u0097\7@\2\2\u0097"+
		"\34\3\2\2\2\u0098\u0099\7>\2\2\u0099\36\3\2\2\2\u009a\u009b\7@\2\2\u009b"+
		"\u009c\7?\2\2\u009c \3\2\2\2\u009d\u009e\7>\2\2\u009e\u009f\7?\2\2\u009f"+
		"\"\3\2\2\2\u00a0\u00a1\7*\2\2\u00a1$\3\2\2\2\u00a2\u00a3\7+\2\2\u00a3"+
		"&\3\2\2\2\u00a4\u00a5\7.\2\2\u00a5(\3\2\2\2\u00a6\u00a7\7=\2\2\u00a7*"+
		"\3\2\2\2\u00a8\u00a9\7<\2\2\u00a9,\3\2\2\2\u00aa\u00ab\7\60\2\2\u00ab"+
		".\3\2\2\2\u00ac\u00ad\7?\2\2\u00ad\60\3\2\2\2\u00ae\u00af\7k\2\2\u00af"+
		"\u00b0\7h\2\2\u00b0\62\3\2\2\2\u00b1\u00b2\7g\2\2\u00b2\u00b3\7n\2\2\u00b3"+
		"\u00b4\7u\2\2\u00b4\u00b5\7g\2\2\u00b5\64\3\2\2\2\u00b6\u00b7\7?\2\2\u00b7"+
		"\u00bb\7?\2\2\u00b8\u00b9\7#\2\2\u00b9\u00bb\7?\2\2\u00ba\u00b6\3\2\2"+
		"\2\u00ba\u00b8\3\2\2\2\u00bb\66\3\2\2\2\u00bc\u00bd\7p\2\2\u00bd\u00be"+
		"\7q\2\2\u00be\u00bf\7v\2\2\u00bf\u00c2\7\"\2\2\u00c0\u00c2\7#\2\2\u00c1"+
		"\u00bc\3\2\2\2\u00c1\u00c0\3\2\2\2\u00c28\3\2\2\2\u00c3\u00c5\t\2\2\2"+
		"\u00c4\u00c3\3\2\2\2\u00c5\u00c6\3\2\2\2\u00c6\u00c4\3\2\2\2\u00c6\u00c7"+
		"\3\2\2\2\u00c7:\3\2\2\2\u00c8\u00ca\t\2\2\2\u00c9\u00c8\3\2\2\2\u00ca"+
		"\u00cb\3\2\2\2\u00cb\u00c9\3\2\2\2\u00cb\u00cc\3\2\2\2\u00cc\u00cd\3\2"+
		"\2\2\u00cd\u00cf\7\60\2\2\u00ce\u00d0\t\2\2\2\u00cf\u00ce\3\2\2\2\u00d0"+
		"\u00d1\3\2\2\2\u00d1\u00cf\3\2\2\2\u00d1\u00d2\3\2\2\2\u00d2<\3\2\2\2"+
		"\u00d3\u00d7\7$\2\2\u00d4\u00d6\n\3\2\2\u00d5\u00d4\3\2\2\2\u00d6\u00d9"+
		"\3\2\2\2\u00d7\u00d5\3\2\2\2\u00d7\u00d8\3\2\2\2\u00d8\u00da\3\2\2\2\u00d9"+
		"\u00d7\3\2\2\2\u00da\u00e4\7$\2\2\u00db\u00df\7)\2\2\u00dc\u00de\n\4\2"+
		"\2\u00dd\u00dc\3\2\2\2\u00de\u00e1\3\2\2\2\u00df\u00dd\3\2\2\2\u00df\u00e0"+
		"\3\2\2\2\u00e0\u00e2\3\2\2\2\u00e1\u00df\3\2\2\2\u00e2\u00e4\7)\2\2\u00e3"+
		"\u00d3\3\2\2\2\u00e3\u00db\3\2\2\2\u00e4>\3\2\2\2\u00e5\u00e6\7v\2\2\u00e6"+
		"\u00e7\7t\2\2\u00e7\u00e8\7w\2\2\u00e8\u00ef\7g\2\2\u00e9\u00ea\7h\2\2"+
		"\u00ea\u00eb\7c\2\2\u00eb\u00ec\7n\2\2\u00ec\u00ed\7u\2\2\u00ed\u00ef"+
		"\7g\2\2\u00ee\u00e5\3\2\2\2\u00ee\u00e9\3\2\2\2\u00ef@\3\2\2\2\u00f0\u00f1"+
		"\7p\2\2\u00f1\u00f2\7w\2\2\u00f2\u00f3\7n\2\2\u00f3\u00f4\7n\2\2\u00f4"+
		"B\3\2\2\2\u00f5\u00f6\5)\25\2\u00f6D\3\2\2\2\u00f7\u00f8\7g\2\2\u00f8"+
		"\u00f9\7p\2\2\u00f9\u00fa\7f\2\2\u00faF\3\2\2\2\u00fb\u00fd\t\5\2\2\u00fc"+
		"\u00fb\3\2\2\2\u00fd\u00fe\3\2\2\2\u00fe\u00fc\3\2\2\2\u00fe\u00ff\3\2"+
		"\2\2\u00ff\u0100\3\2\2\2\u0100\u0101\b$\2\2\u0101H\3\2\2\2\u0102\u0104"+
		"\7\17\2\2\u0103\u0102\3\2\2\2\u0103\u0104\3\2\2\2\u0104\u0105\3\2\2\2"+
		"\u0105\u0109\7\f\2\2\u0106\u0108\7\13\2\2\u0107\u0106\3\2\2\2\u0108\u010b"+
		"\3\2\2\2\u0109\u0107\3\2\2\2\u0109\u010a\3\2\2\2\u010aJ\3\2\2\2\u010b"+
		"\u0109\3\2\2\2\u010c\u010d\7\61\2\2\u010d\u010e\7\61\2\2\u010e\u0112\3"+
		"\2\2\2\u010f\u0111\13\2\2\2\u0110\u010f\3\2\2\2\u0111\u0114\3\2\2\2\u0112"+
		"\u0113\3\2\2\2\u0112\u0110\3\2\2\2\u0113\u0116\3\2\2\2\u0114\u0112\3\2"+
		"\2\2\u0115\u0117\7\17\2\2\u0116\u0115\3\2\2\2\u0116\u0117\3\2\2\2\u0117"+
		"\u0118\3\2\2\2\u0118\u0119\7\f\2\2\u0119\u011a\3\2\2\2\u011a\u011b\b&"+
		"\2\2\u011bL\3\2\2\2\u011c\u0120\t\6\2\2\u011d\u011f\t\7\2\2\u011e\u011d"+
		"\3\2\2\2\u011f\u0122\3\2\2\2\u0120\u011e\3\2\2\2\u0120\u0121\3\2\2\2\u0121"+
		"N\3\2\2\2\u0122\u0120\3\2\2\2\24\2[\u0094\u00ba\u00c1\u00c6\u00cb\u00d1"+
		"\u00d7\u00df\u00e3\u00ee\u00fe\u0103\u0109\u0112\u0116\u0120\3\b\2\2";
	public static final ATN _ATN =
		new ATNDeserializer().deserialize(_serializedATN.toCharArray());
	static {
		_decisionToDFA = new DFA[_ATN.getNumberOfDecisions()];
		for (int i = 0; i < _ATN.getNumberOfDecisions(); i++) {
			_decisionToDFA[i] = new DFA(_ATN.getDecisionState(i), i);
		}
	}
}