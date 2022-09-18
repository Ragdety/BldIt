using BldIt.Lang.ValueObjects.BldItPipeline.PipelineSections.Stages.Steps;
using BldIt.Lang.ValueObjects.BldItPipeline.PipelineSections.Stages.Steps.Enums;

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