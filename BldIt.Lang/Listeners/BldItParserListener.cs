using Antlr4.Runtime;
using BldIt.Lang.Grammar;

namespace BldIt.Lang.Listeners;

public class BldItParserListener : BldItParserBaseListener
{
    private readonly BldItParser _parser;
    private readonly List<string> _ruleStack = new();

    public BldItParserListener(BldItParser parser)
    {
        _parser = parser;
        //parser.GetRuleInvocationStack();
    }

    public override void EnterEveryRule(ParserRuleContext ctx)
    {
        var rule = _parser.RuleNames[ctx.RuleIndex];
        _ruleStack.Add(rule);
        //Log.Logger.Debug("Enter Rule: {Rule}", rule);
    }

    public override void ExitEveryRule(ParserRuleContext ctx)
    {
        var rule = _parser.RuleNames[ctx.RuleIndex];
        _ruleStack.Remove(rule);
        //Log.Logger.Debug("Exit Rule: {Rule}", rule);
    }
}