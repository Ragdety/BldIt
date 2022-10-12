using BldIt.Lang.Exceptions;
using BldIt.Lang.ValueObjects.BldItExpressions;
using BldIt.Lang.ValueObjects.BldItExpressions.ConstantTypes;
using BldIt.Lang.ValueObjects.BldItPipeline;
using BldIt.Lang.ValueObjects.BldItPipeline.PipelineSections.Stages;
using BldIt.Lang.ValueObjects.BldItPipeline.PipelineSections.Stages.Steps.CompoundStageSteps;

namespace BldIt.Lang.Visitors.PipelineVisitors;

/// <summary>
/// Class with helper functions to get the build status or result
/// </summary>
public static class BuildResultStatusHelper
{
    /// <summary>
    /// Set the build status based on status variable
    /// </summary>
    /// <param name="globalEnv">The global environment dictionary for the pipeline</param>
    /// <param name="status">Status of the build (either "SUCCESS" or "FAILURE")</param>
    /// <returns>The new Global Env with the build status updated</returns>
    /// <exception cref="CompilingException">If the status is anything other than "SUCCESS" or "FAILURE"</exception>
    public static Dictionary<string, Expression> SetBuildResult(Dictionary<string, Expression> globalEnv, string status)
    {
        globalEnv["BUILD_RESULT"] = new StringValue(status);
        return globalEnv;
    }
    
    public static string GetBuildResult(Dictionary<string, Expression> globalEnv)
    {
        var result = (StringValue) globalEnv["BUILD_RESULT"];
        return result.Value;
    }

    public static Dictionary<string, Expression> CheckAndSetBuildResultBasedOnHandleErrorStep(
        Dictionary<string, Expression> globalEnv,
        Stage stage)
    {
        if (!globalEnv.ContainsKey("BUILD_RESULT"))
            throw new UndefinedEnvironmentVariableException("BUILD_RESULT");
        
        var result = globalEnv["BUILD_RESULT"];
        
        //If any step has handleError, then proceed to set the status
        if (stage.Steps.Any(step => step.StepIdentifier == "handleError"))
        {
            var handleErrorSteps = stage.Steps.Where(step => step.StepIdentifier == "handleError");
            
            //Instead of looping throughout all stages, we can just get the handleErrorSteps 
            foreach (var step in handleErrorSteps)
            {
                var handleErrorStep = (HandleErrorStep) step;

                //If the build was previously set to failure, keep it regardless of any other steps
                if (GetBuildResult(globalEnv) == PipelineConstants.BuildConstants.BuildFailureValue)
                {
                    break;
                }
                
                //If an error was caught within the handleError step, set to DesiredBuildResult
                if (handleErrorStep.ErrorCaught)
                {
                    result = new StringValue(handleErrorStep.DesiredBuildResult);
                }
                
                //Otherwise, set keep the same as before
            }
        }
        
        globalEnv["BUILD_RESULT"] = result;
        return globalEnv;
    }
    
    /// <summary>
    /// Check if the build was successful or not
    /// </summary>
    /// <param name="globalEnv">The global environment</param>
    /// <returns>True if BUILD_RESULT env is SUCCESS</returns>
    public static bool IsBuildSuccess(Dictionary<string, Expression> globalEnv)
    {
        return globalEnv["BUILD_RESULT"].ToString() == "SUCCESS";
    }
}