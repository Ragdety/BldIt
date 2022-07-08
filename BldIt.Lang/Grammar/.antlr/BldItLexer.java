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
		INDENT=1, DEDENT=2, NL=3, WHILE=4, ADD_OP=5, SUB_OP=6, MULT_OP=7, DIV_OP=8, 
		MOD_OP=9, BOOL_OP=10, GREATER_THAN_OP=11, LESS_THAN_OP=12, GREATER_THAN_EQUAL_OP=13, 
		LESS_THAN_EQUAL_OP=14, OPEN_PAREN=15, CLOSE_PAREN=16, COMMA=17, SEMICOLON=18, 
		COLON=19, DOT=20, ASSIGN_OP=21, IF=22, ELSE=23, EQUALITY=24, NOT=25, INTEGER=26, 
		FLOAT=27, STRING=28, BOOL=29, NULL=30, ENDLINE=31, WS=32, IDENTIFIER=33;
	public static String[] channelNames = {
		"DEFAULT_TOKEN_CHANNEL", "HIDDEN"
	};

	public static String[] modeNames = {
		"DEFAULT_MODE"
	};

	private static String[] makeRuleNames() {
		return new String[] {
			"NL", "WHILE", "ADD_OP", "SUB_OP", "MULT_OP", "DIV_OP", "MOD_OP", "BOOL_OP", 
			"GREATER_THAN_OP", "LESS_THAN_OP", "GREATER_THAN_EQUAL_OP", "LESS_THAN_EQUAL_OP", 
			"OPEN_PAREN", "CLOSE_PAREN", "COMMA", "SEMICOLON", "COLON", "DOT", "ASSIGN_OP", 
			"IF", "ELSE", "EQUALITY", "NOT", "INTEGER", "FLOAT", "STRING", "BOOL", 
			"NULL", "ENDLINE", "WS", "IDENTIFIER"
		};
	}
	public static final String[] ruleNames = makeRuleNames();

	private static String[] makeLiteralNames() {
		return new String[] {
			null, null, null, null, "'while'", "'+'", "'-'", "'*'", "'/'", "'%'", 
			null, "'>'", "'<'", "'>='", "'<='", "'('", "')'", "','", "';'", "':'", 
			"'.'", "'='", "'if'", "'else'", null, null, null, null, null, null, "'null'"
		};
	}
	private static final String[] _LITERAL_NAMES = makeLiteralNames();
	private static String[] makeSymbolicNames() {
		return new String[] {
			null, "INDENT", "DEDENT", "NL", "WHILE", "ADD_OP", "SUB_OP", "MULT_OP", 
			"DIV_OP", "MOD_OP", "BOOL_OP", "GREATER_THAN_OP", "LESS_THAN_OP", "GREATER_THAN_EQUAL_OP", 
			"LESS_THAN_EQUAL_OP", "OPEN_PAREN", "CLOSE_PAREN", "COMMA", "SEMICOLON", 
			"COLON", "DOT", "ASSIGN_OP", "IF", "ELSE", "EQUALITY", "NOT", "INTEGER", 
			"FLOAT", "STRING", "BOOL", "NULL", "ENDLINE", "WS", "IDENTIFIER"
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
		"\3\u608b\ua72a\u8133\ub9ed\u417c\u3be7\u7786\u5964\2#\u00d1\b\1\4\2\t"+
		"\2\4\3\t\3\4\4\t\4\4\5\t\5\4\6\t\6\4\7\t\7\4\b\t\b\4\t\t\t\4\n\t\n\4\13"+
		"\t\13\4\f\t\f\4\r\t\r\4\16\t\16\4\17\t\17\4\20\t\20\4\21\t\21\4\22\t\22"+
		"\4\23\t\23\4\24\t\24\4\25\t\25\4\26\t\26\4\27\t\27\4\30\t\30\4\31\t\31"+
		"\4\32\t\32\4\33\t\33\4\34\t\34\4\35\t\35\4\36\t\36\4\37\t\37\4 \t \3\2"+
		"\5\2C\n\2\3\2\3\2\7\2G\n\2\f\2\16\2J\13\2\3\3\3\3\3\3\3\3\3\3\3\3\3\4"+
		"\3\4\3\5\3\5\3\6\3\6\3\7\3\7\3\b\3\b\3\t\3\t\3\t\3\t\3\t\5\ta\n\t\3\n"+
		"\3\n\3\13\3\13\3\f\3\f\3\f\3\r\3\r\3\r\3\16\3\16\3\17\3\17\3\20\3\20\3"+
		"\21\3\21\3\22\3\22\3\23\3\23\3\24\3\24\3\25\3\25\3\25\3\26\3\26\3\26\3"+
		"\26\3\26\3\27\3\27\3\27\3\27\5\27\u0087\n\27\3\30\3\30\3\30\3\30\3\30"+
		"\5\30\u008e\n\30\3\31\6\31\u0091\n\31\r\31\16\31\u0092\3\32\6\32\u0096"+
		"\n\32\r\32\16\32\u0097\3\32\3\32\6\32\u009c\n\32\r\32\16\32\u009d\3\33"+
		"\3\33\7\33\u00a2\n\33\f\33\16\33\u00a5\13\33\3\33\3\33\3\33\7\33\u00aa"+
		"\n\33\f\33\16\33\u00ad\13\33\3\33\5\33\u00b0\n\33\3\34\3\34\3\34\3\34"+
		"\3\34\3\34\3\34\3\34\3\34\5\34\u00bb\n\34\3\35\3\35\3\35\3\35\3\35\3\36"+
		"\3\36\3\37\6\37\u00c5\n\37\r\37\16\37\u00c6\3\37\3\37\3 \3 \7 \u00cd\n"+
		" \f \16 \u00d0\13 \2\2!\3\5\5\6\7\7\t\b\13\t\r\n\17\13\21\f\23\r\25\16"+
		"\27\17\31\20\33\21\35\22\37\23!\24#\25%\26\'\27)\30+\31-\32/\33\61\34"+
		"\63\35\65\36\67\379 ;!=\"?#\3\2\b\3\2\62;\3\2$$\3\2))\5\2\f\f\17\17\""+
		"\"\5\2C\\aac|\6\2\62;C\\aac|\2\u00de\2\3\3\2\2\2\2\5\3\2\2\2\2\7\3\2\2"+
		"\2\2\t\3\2\2\2\2\13\3\2\2\2\2\r\3\2\2\2\2\17\3\2\2\2\2\21\3\2\2\2\2\23"+
		"\3\2\2\2\2\25\3\2\2\2\2\27\3\2\2\2\2\31\3\2\2\2\2\33\3\2\2\2\2\35\3\2"+
		"\2\2\2\37\3\2\2\2\2!\3\2\2\2\2#\3\2\2\2\2%\3\2\2\2\2\'\3\2\2\2\2)\3\2"+
		"\2\2\2+\3\2\2\2\2-\3\2\2\2\2/\3\2\2\2\2\61\3\2\2\2\2\63\3\2\2\2\2\65\3"+
		"\2\2\2\2\67\3\2\2\2\29\3\2\2\2\2;\3\2\2\2\2=\3\2\2\2\2?\3\2\2\2\3B\3\2"+
		"\2\2\5K\3\2\2\2\7Q\3\2\2\2\tS\3\2\2\2\13U\3\2\2\2\rW\3\2\2\2\17Y\3\2\2"+
		"\2\21`\3\2\2\2\23b\3\2\2\2\25d\3\2\2\2\27f\3\2\2\2\31i\3\2\2\2\33l\3\2"+
		"\2\2\35n\3\2\2\2\37p\3\2\2\2!r\3\2\2\2#t\3\2\2\2%v\3\2\2\2\'x\3\2\2\2"+
		")z\3\2\2\2+}\3\2\2\2-\u0086\3\2\2\2/\u008d\3\2\2\2\61\u0090\3\2\2\2\63"+
		"\u0095\3\2\2\2\65\u00af\3\2\2\2\67\u00ba\3\2\2\29\u00bc\3\2\2\2;\u00c1"+
		"\3\2\2\2=\u00c4\3\2\2\2?\u00ca\3\2\2\2AC\7\17\2\2BA\3\2\2\2BC\3\2\2\2"+
		"CD\3\2\2\2DH\7\f\2\2EG\7\13\2\2FE\3\2\2\2GJ\3\2\2\2HF\3\2\2\2HI\3\2\2"+
		"\2I\4\3\2\2\2JH\3\2\2\2KL\7y\2\2LM\7j\2\2MN\7k\2\2NO\7n\2\2OP\7g\2\2P"+
		"\6\3\2\2\2QR\7-\2\2R\b\3\2\2\2ST\7/\2\2T\n\3\2\2\2UV\7,\2\2V\f\3\2\2\2"+
		"WX\7\61\2\2X\16\3\2\2\2YZ\7\'\2\2Z\20\3\2\2\2[\\\7c\2\2\\]\7p\2\2]a\7"+
		"f\2\2^_\7q\2\2_a\7t\2\2`[\3\2\2\2`^\3\2\2\2a\22\3\2\2\2bc\7@\2\2c\24\3"+
		"\2\2\2de\7>\2\2e\26\3\2\2\2fg\7@\2\2gh\7?\2\2h\30\3\2\2\2ij\7>\2\2jk\7"+
		"?\2\2k\32\3\2\2\2lm\7*\2\2m\34\3\2\2\2no\7+\2\2o\36\3\2\2\2pq\7.\2\2q"+
		" \3\2\2\2rs\7=\2\2s\"\3\2\2\2tu\7<\2\2u$\3\2\2\2vw\7\60\2\2w&\3\2\2\2"+
		"xy\7?\2\2y(\3\2\2\2z{\7k\2\2{|\7h\2\2|*\3\2\2\2}~\7g\2\2~\177\7n\2\2\177"+
		"\u0080\7u\2\2\u0080\u0081\7g\2\2\u0081,\3\2\2\2\u0082\u0083\7?\2\2\u0083"+
		"\u0087\7?\2\2\u0084\u0085\7#\2\2\u0085\u0087\7?\2\2\u0086\u0082\3\2\2"+
		"\2\u0086\u0084\3\2\2\2\u0087.\3\2\2\2\u0088\u0089\7p\2\2\u0089\u008a\7"+
		"q\2\2\u008a\u008b\7v\2\2\u008b\u008e\7\"\2\2\u008c\u008e\7#\2\2\u008d"+
		"\u0088\3\2\2\2\u008d\u008c\3\2\2\2\u008e\60\3\2\2\2\u008f\u0091\t\2\2"+
		"\2\u0090\u008f\3\2\2\2\u0091\u0092\3\2\2\2\u0092\u0090\3\2\2\2\u0092\u0093"+
		"\3\2\2\2\u0093\62\3\2\2\2\u0094\u0096\t\2\2\2\u0095\u0094\3\2\2\2\u0096"+
		"\u0097\3\2\2\2\u0097\u0095\3\2\2\2\u0097\u0098\3\2\2\2\u0098\u0099\3\2"+
		"\2\2\u0099\u009b\7\60\2\2\u009a\u009c\t\2\2\2\u009b\u009a\3\2\2\2\u009c"+
		"\u009d\3\2\2\2\u009d\u009b\3\2\2\2\u009d\u009e\3\2\2\2\u009e\64\3\2\2"+
		"\2\u009f\u00a3\7$\2\2\u00a0\u00a2\n\3\2\2\u00a1\u00a0\3\2\2\2\u00a2\u00a5"+
		"\3\2\2\2\u00a3\u00a1\3\2\2\2\u00a3\u00a4\3\2\2\2\u00a4\u00a6\3\2\2\2\u00a5"+
		"\u00a3\3\2\2\2\u00a6\u00b0\7$\2\2\u00a7\u00ab\7)\2\2\u00a8\u00aa\n\4\2"+
		"\2\u00a9\u00a8\3\2\2\2\u00aa\u00ad\3\2\2\2\u00ab\u00a9\3\2\2\2\u00ab\u00ac"+
		"\3\2\2\2\u00ac\u00ae\3\2\2\2\u00ad\u00ab\3\2\2\2\u00ae\u00b0\7)\2\2\u00af"+
		"\u009f\3\2\2\2\u00af\u00a7\3\2\2\2\u00b0\66\3\2\2\2\u00b1\u00b2\7v\2\2"+
		"\u00b2\u00b3\7t\2\2\u00b3\u00b4\7w\2\2\u00b4\u00bb\7g\2\2\u00b5\u00b6"+
		"\7h\2\2\u00b6\u00b7\7c\2\2\u00b7\u00b8\7n\2\2\u00b8\u00b9\7u\2\2\u00b9"+
		"\u00bb\7g\2\2\u00ba\u00b1\3\2\2\2\u00ba\u00b5\3\2\2\2\u00bb8\3\2\2\2\u00bc"+
		"\u00bd\7p\2\2\u00bd\u00be\7w\2\2\u00be\u00bf\7n\2\2\u00bf\u00c0\7n\2\2"+
		"\u00c0:\3\2\2\2\u00c1\u00c2\5!\21\2\u00c2<\3\2\2\2\u00c3\u00c5\t\5\2\2"+
		"\u00c4\u00c3\3\2\2\2\u00c5\u00c6\3\2\2\2\u00c6\u00c4\3\2\2\2\u00c6\u00c7"+
		"\3\2\2\2\u00c7\u00c8\3\2\2\2\u00c8\u00c9\b\37\2\2\u00c9>\3\2\2\2\u00ca"+
		"\u00ce\t\6\2\2\u00cb\u00cd\t\7\2\2\u00cc\u00cb\3\2\2\2\u00cd\u00d0\3\2"+
		"\2\2\u00ce\u00cc\3\2\2\2\u00ce\u00cf\3\2\2\2\u00cf@\3\2\2\2\u00d0\u00ce"+
		"\3\2\2\2\21\2BH`\u0086\u008d\u0092\u0097\u009d\u00a3\u00ab\u00af\u00ba"+
		"\u00c6\u00ce\3\b\2\2";
	public static final ATN _ATN =
		new ATNDeserializer().deserialize(_serializedATN.toCharArray());
	static {
		_decisionToDFA = new DFA[_ATN.getNumberOfDecisions()];
		for (int i = 0; i < _ATN.getNumberOfDecisions(); i++) {
			_decisionToDFA[i] = new DFA(_ATN.getDecisionState(i), i);
		}
	}
}