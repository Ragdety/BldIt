using BldIt.Lang.ValueObjects.BldItPipeline.PipelineSections.Stages.Steps;

namespace BldIt.Lang.ValueObjects.BldItPipeline.PipelineSections.Stages;

public class ScriptStep : CompoundStageStep
{
    private ScriptStep(CompoundStepType stepType, string stepIdentifier) : base(stepType, stepIdentifier)
    {
    }
    
    public ScriptStep(string stepIdentifier) 
        : this(CompoundStepType.ScriptStep, stepIdentifier) { }
}