﻿using BldIt.Lang.ValueObjects.BldItPipeline.PipelineSections.Stages.Steps;

namespace BldIt.Lang.ValueObjects.BldItPipeline.PipelineSections.Stages;

public class Stage : PipelineSection
{
    public List<StageStep> StageSteps { get; }
    
    public Stage()
    {
        StageSteps = new List<StageStep>();
    }
}