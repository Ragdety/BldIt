namespace BldIt.Lang.ValueObjects.BldItPipeline;

public static class PipelineConstants
{
    public static class BuildConstants
    {
        public const string BuildFailureValue = "FAILURE";
        public const string BuildSuccessValue = "SUCCESS";
        public const string BuildUnknownValue = "UNKNOWN";
    }
    
    public static class StageConstants
    {
        public const string StageFailureValue = "FAILURE";
        public const string StageSuccessValue = "SUCCESS";
        public const string StageUnknownValue = "UNKNOWN";
    }
}