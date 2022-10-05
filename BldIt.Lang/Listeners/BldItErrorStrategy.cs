using Antlr4.Runtime;

namespace BldIt.Lang.Listeners;

/// <summary>
/// From https://stackoverflow.com/questions/26675254/antlr-error-strategy-to-skip-tokens-until-rule-matches-again
/// </summary>
public class BldItErrorStrategy : DefaultErrorStrategy
{
    public override void Recover(Parser recognizer, RecognitionException e)
    {
        // This should should move the current position to the next 'END' token
        base.Recover(recognizer, e);

        var tokenStream = (ITokenStream)recognizer.InputStream;

        // Verify we are where we expect to be
        var la = tokenStream.La(1);
        if (tokenStream.La(1) != Grammar.BldItParser.NEWLINE) return;
        
        // Get the next possible tokens
        var intervalSet = GetErrorRecoverySet(recognizer);

        // Move to the next token
        tokenStream.Consume();

        // Move to the next possible token
        // If the errant element is the last in the set, this will move to the 'END' token in 'END MODULE'.
        // If there are subsequent elements in the set, this will move to the 'BEGIN' token in 'BEGIN module_element'.
        ConsumeUntil(recognizer, intervalSet);
    }
}