using BldIt.Lang.ValueObjects.BldItPipeline.PipelineSections.Stages.Steps;

namespace BldIt.Lang.ValueObjects.BldItPipeline.PipelineSections.Stages;

public class ScriptStep : CompoundStageStep
{
    private ScriptStep(CompoundStepType stepType) : base(stepType)
    {
        StepIdentifier = "script";
    }
    
    public ScriptStep() 
        : this(CompoundStepType.ScriptStep) { }
}