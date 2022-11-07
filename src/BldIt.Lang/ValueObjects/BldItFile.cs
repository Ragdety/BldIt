using BldIt.Lang.ValueObjects.BldItPipeline;
using BldIt.Lang.ValueObjects.BldItStatements;

namespace BldIt.Lang.ValueObjects;

public class BldItFile
{
    public List<Statement> Statements { get; }
    public Pipeline Pipeline { get; set; }

    public BldItFile()
    {
        Pipeline = new Pipeline();
        Statements = new List<Statement>();
    }

    public void AddStatement(Statement statement)
    {
        Statements.Add(statement);
    }
    
    public void SetPipeline(Pipeline pipeline)
    {
        Pipeline = pipeline;
    }
}